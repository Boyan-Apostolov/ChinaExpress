using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.Logic
{
    public class ProductsManager : IProductsManager
    {
        private readonly IProductsDbHelper _productsDbHelper;
        private readonly IOrdersDbHelper _ordersDbHelper;
        private readonly ICategoriesDbHelper _categoriesDbHelper;

        public ProductsManager(IProductsDbHelper productsDbHelper, IOrdersDbHelper ordersDbHelper, ICategoriesDbHelper categoriesDbHelper)
        {
            _productsDbHelper = productsDbHelper;
            _ordersDbHelper = ordersDbHelper;
            _categoriesDbHelper = categoriesDbHelper;
        }

        public ICollection<Product> GetAllProducts(
            string keyword = null,
            List<int> excludedProductIds = null,
            List<int> categories = null,
            List<int> ratings = null,
            string? sort = null,
            int currentPage = 0,
            int pageSize = Int32.MaxValue)
        {
            var isFilteringReviews = ratings?.Any() is true;

            List<Product> foundProducts = this._productsDbHelper
                .GetAllPoducts(keyword, categories,
                    isFilteringReviews ? 0 : currentPage, 
                    isFilteringReviews ? int.MaxValue : pageSize);

            foundProducts.ForEach(fi =>
                fi.Category.SetFeatures(_categoriesDbHelper.GetCategoyFeatures(fi.Category.Id))
            );

            if (isFilteringReviews)
            {
                foundProducts = CustomExtensions.Where(foundProducts, p => ratings.Contains((int)Math.Floor(p.Rating)));

                foundProducts = foundProducts
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }

            if (excludedProductIds?.Any() is true)
            {
                foundProducts = CustomExtensions.Where(foundProducts, p =>
                    !excludedProductIds.Contains(p.ProductId));
            }

            return foundProducts;
        }


        public ICollection<ProductView> GetProductViews(int productId)
        {
            return this._productsDbHelper.GetAllPoducts(filterProductId: productId).First().GetViews();
        }

        public async Task<int> CountProducts(string? keyword, List<int> category, List<int> rating)
        {
            return GetAllProducts(keyword: keyword, categories: category, ratings: rating).Count;
        }

        public ICollection<Product> GetRandomProducts(int count, List<int> excludedProductIds = null)
        {
            var random = new Random();

            return GetAllProducts(excludedProductIds: excludedProductIds)
                .OrderBy(x => random.Next())
                .Take(count)
                .ToArray();
        }

        public void AddProduct(BaseProductDto productDto)
        {
            _productsDbHelper.AddProduct(productDto);
        }

        public void UpdateProduct(BaseProductDto productDto)
        {
            _productsDbHelper.UpdateProduct(productDto);
        }

        public void DeleteProduct(int productId)
        {
            this._productsDbHelper.DeleteProdcut(productId);
        }


        public bool IsSingleProductInComboBox(int singleItemId)
        {
            return this._productsDbHelper.IsSingleProductInComboBox(singleItemId);
        }

        public Product? GetProduct(int productId)
        {
            return CustomExtensions
                .FirstOrDefault(this.GetAllProducts(), p => p.ProductId == productId);
        }


        public ComboBox? GetComboBoxByProductId(int productId)
        {
            return CustomExtensions
                .FirstOrDefault(_productsDbHelper.GetAllComboBoxes(), p => p.ProductId == productId);
        }

        public void UpdateSingleProductQuantity(SqlTransaction sqlTransaction, int itemId, int newQuantity)
        {
            this._productsDbHelper.EditSingleProductQuantity(sqlTransaction, itemId, newQuantity);
        }

        public ICollection<Product> GetComboBoxItems(int id)
        {
            return this._productsDbHelper.GetComboBoxItems(id);
        }

        #region Recommendation Algorhitm

        /// <summary>
        /// Recommends 8 products and possible 4 more random items
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="includeRandomReccomendations"></param>
        /// <returns></returns>
        public ICollection<Product> GenerateRecommendedProducts(int userId, bool includeRandomReccomendations = false)
        {
            var orders = _ordersDbHelper.GetAllOrders();
            var allProductViewsForUser = GetUserProductViews(userId);

            var currentUserCart = CustomExtensions
                .FirstOrDefault(orders,
                o => o.User.Id == userId && o.OrderStatus == OrderStatus.Draft
                );

            var productsInCartIds = currentUserCart.GetOrderItems().Select(oi => oi.Product.ProductId).ToList();

            var foreignOrders = CustomExtensions
                .Where(orders, o => o.User.Id != userId);
            var recommendedFromSimilar = GetRecommendedItemsFromSimilarOrders(foreignOrders, productsInCartIds);

            var primaryProjection =
                GetRecommendationProjection(recommendedFromSimilar, allProductViewsForUser, 1);

            var primaryProjectinProductItemIds = primaryProjection
                .Select(p => p.Product.ProductId)
                .ToArray();

            var foreignOrderItems = foreignOrders
                .SelectMany(o => o.GetOrderItems())
                .DistinctBy(o => o.Id)
                .ToArray();

            var rawSecondaryProjection =
                GetRecommendationProjection(foreignOrderItems, allProductViewsForUser, 2)
                .ToArray();

            var secondaryProjection =
                CustomExtensions.Where(rawSecondaryProjection, rp =>
                    !primaryProjectinProductItemIds.Contains(rp.Product.ProductId)
                    && !productsInCartIds.Contains(rp.Product.ProductId)
                    );

            var finishedReccomendations = primaryProjection
                .Concat(secondaryProjection)
                .OrderBy(p => p.Priority) //Place the items from similar first, the from other orders
                .ThenByDescending(p => p.Views.Count()) //sort by views from the current user
                .ThenBy(p => p.DayWeight) // Sort by recently viewed
                .ThenByDescending(p => p.Rating) //sort by review stars
                .Select(p => p.Product)
                .DistinctBy(d => d.ProductId)
                .Take(8)
                .ToList();

            var randomRecommendations = GetRandomProducts(Math.Max(4, 12 - finishedReccomendations.Count),
                finishedReccomendations.Select(r => r.ProductId).ToList()
                );

            if (!includeRandomReccomendations) return finishedReccomendations;

            var random = new Random();
            foreach (var recommendation in randomRecommendations)
            {
                if (finishedReccomendations.Count > 3)
                {
                    finishedReccomendations
                        .Insert(random.Next(3, finishedReccomendations.Count + 1), recommendation);
                }
                else
                {
                    finishedReccomendations.Add(recommendation);
                }

            }

            return finishedReccomendations;
        }

        public async Task<int> GetViewsCount()
        {
            return await this._productsDbHelper.GetViewsCount();
        }

        public List<KeyValuePair<string, int>> GetMostPopularItems()
        {
            return GetAllProducts()
                .OrderByDescending(p => p.GetViews().Count)
                .Take(5)
                .Select(p =>
                    new KeyValuePair<string, int>(p.Name, p.GetViews().Count))
                .ToList();
        }

        private ICollection<ProductView> GetUserProductViews(int userId)
        {
            return this._productsDbHelper.GetUserProductViews(userId);
        }

        private ICollection<RecommendationProjectionDTO> GetRecommendationProjection(ICollection<OrderItem> orderItems,
            ICollection<ProductView> productViews, int priority)
        {
            return orderItems
                .GroupBy(p => p.Product)
                .Select(x => new
                {
                    Priority = priority,
                    Product = x.First().Product,
                    Views = CustomExtensions.Where(productViews,
                        pv => pv.ProductId == x.First().Product.ProductId),
                    Rating = x.Average(r => r.Review?.Stars) ?? 0,
                }).Select(x => new RecommendationProjectionDTO()
                {
                    Priority = x.Priority,
                    Views = x.Views,
                    Product = x.Product,
                    Rating = x.Rating,
                    DayWeight = CustomExtensions.Sum(x.Views,
                        v => (DateTime.Now - v.ViewDateTime).Hours)
                })
                .ToList();
        }

        private List<OrderItem> GetRecommendedItemsFromSimilarOrders(ICollection<Order> foreignOrders, List<int> productsInCartIds)
        {
            var similarOrders = new List<Order>();
            foreach (var foreignOrder in foreignOrders)
            {
                var orderProductItemIds = foreignOrder
                    .GetOrderItems()
                    .Select(oi => oi.Product.ProductId);

                if (orderProductItemIds.Intersect(productsInCartIds).Count() >= 2) // atleast 2 similar items
                {
                    similarOrders.Add(foreignOrder);
                }
            }

            var recommendedItems = new List<OrderItem>();
            foreach (var similarOrder in similarOrders)
            {

                var notAddedItems = CustomExtensions
                    .Where(similarOrder.GetOrderItems(), oi =>
                        !productsInCartIds.Contains(oi.Product.ProductId))
                    .ToList();

                recommendedItems.AddRange(notAddedItems);
            }

            return recommendedItems;
        }
        #endregion
    }
}
