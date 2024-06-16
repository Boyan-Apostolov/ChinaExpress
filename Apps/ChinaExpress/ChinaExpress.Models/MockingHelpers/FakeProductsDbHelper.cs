using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeProductsDbHelper : IProductsDbHelper
    {
        private IInternalProductManagementHelper internalProductManagementHelper;
        private List<Product> products;
        private List<SingleItem> singleItems;
        private List<ComboBox> comboBoxes;
        public FakeProductsDbHelper()
        {
            this.products = new List<Product>();
            this.singleItems = new List<SingleItem>();
            this.comboBoxes = new List<ComboBox>();

            internalProductManagementHelper = new FakeInternalProductManagementHelper();
        }

        public List<Product> GetAllPoducts(string keyword = null,
            List<int> categories = null,
            int pageIndex = 0, int pageSize = 8,
            bool shouldGetViews = true, //not tested
            int? filterProductId = null)
        {
            var products = this.products;

            if (filterProductId.HasValue)
            {
                return this.products.Where(p => p.ProductId == filterProductId.Value).ToList();
            }

            if (keyword != null)
            {
                products = products.Where(p => p.Name.Contains(keyword)).ToList();
            }

            if (categories?.Any() ?? false)
            {
                products = this.products.Where(p => categories.Contains(p.Category.Id)).ToList();
            }


            return products
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public List<ComboBox> GetAllComboBoxes()
        {
            return this.comboBoxes.ToList();
        }

        public void EditSingleProductQuantity(SqlTransaction sqlTransaction, int itemId, int newQUantity)
        {
            var singlItem = this.singleItems.FirstOrDefault(p => p.ItemId == itemId);

            if (singlItem.GetQuantity() == 0 || newQUantity <= 0)
                throw new InvalidOperationException("Product is out of stock!");

            var product = this.products.FirstOrDefault(p => p.ProductId == itemId);
            this.singleItems.Remove(singlItem);

            this.products.Remove(product);

            var updatedsingleItem = new SingleItem(singlItem.ItemId, singlItem.Name, singlItem.Description,
                singlItem.PhotoUrl, newQUantity, singlItem.GetPrice(), singlItem.Category, singlItem.ProductId, internalProductManagementHelper);

            this.singleItems.Add(updatedsingleItem);
            this.products.Add(updatedsingleItem);
        }

        public void DeleteProdcut(int productId)
        {
            var product = this.products.FirstOrDefault(p => p.ProductId == productId);
            this.products.Remove(product);
        }

        public Product[] GetComboBoxItems(int comboBoxId)
        {
            return this.comboBoxes.FirstOrDefault(cb => cb.ItemId == comboBoxId).GetProducts();
        }

        public void UpdateProduct(BaseProductDto product)
        {
            var oldPoduct = this.products.FirstOrDefault(p => p.ProductId == product.ProductId);
            this.products.Remove(oldPoduct);

            product.ProductId = oldPoduct.ProductId;
            var castSingleProduct = (SingleItemDto)product;
            var newSingleItem = new SingleItem(this.singleItems.Count + 1, castSingleProduct.Name,
                castSingleProduct.Description, castSingleProduct.PhotoUrl, castSingleProduct.Quantity,
                castSingleProduct.Price, castSingleProduct.Category, product.ProductId,
                internalProductManagementHelper);
            this.products.Add(newSingleItem);
        }

        public void AddProduct(BaseProductDto product)
        {
            product.ProductId = this.products.Count + 1;
            
            if (product.GetType() == typeof(ComboBoxDto))
            {
                var castComboBx = (ComboBoxDto)product;
                var newComboBox = new ComboBox(this.comboBoxes.Count + 1, castComboBx.Name, castComboBx.Description,
                    castComboBx.PhotoUrl, castComboBx.DiscountStrategy, castComboBx.Category, product.ProductId,
                    castComboBx.SelectedProducts, internalProductManagementHelper);

                this.comboBoxes.Add(newComboBox);
                this.products.Add(newComboBox);
            }

            if (product.GetType() == typeof(SingleItemDto))
            {
                var castSingleProduct = (SingleItemDto)product;
                var newSingleItem = new SingleItem(this.singleItems.Count + 1, castSingleProduct.Name,
                    castSingleProduct.Description, castSingleProduct.PhotoUrl, castSingleProduct.Quantity,
                    castSingleProduct.Price, castSingleProduct.Category, product.ProductId,
                    internalProductManagementHelper);

                this.singleItems.Add(newSingleItem);
                this.products.Add(newSingleItem);
            }
        }

        public bool IsSingleProductInComboBox(int singleProductId)
        {
            return this.comboBoxes.Any(cb => cb.GetProducts().Any(p => p.ProductId == singleProductId));
        }

        public List<ProductView> GetProductViews(int productId)
        {
            return this.products.FirstOrDefault(p => p.ProductId == productId).GetViews();
        }

        public ICollection<ProductView> GetUserProductViews(int userId)
        {
            return this.products.SelectMany(p => p.GetViews().Where(v => v.UserId == userId)).ToArray();
        }

        public async Task<int> GetViewsCount()
        {
            return this.products.Sum(p => p.GetViews().Count);
        }
    }
}
