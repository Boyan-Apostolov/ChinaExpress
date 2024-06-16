using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.Logic
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductsDbHelper _productsDbHelper;

        public ProductFactory(IProductsDbHelper productsDbHelper)
        {
            _productsDbHelper = productsDbHelper;
        }
        public BaseProductDto CreateProduct(string name, string photoUrl, int quantity, string description, object category, decimal? price, object discountStrategy, ICollection<int> productItemIds)
        {
            if (productItemIds == null)
            {
                if (!price.HasValue)
                    throw new ArgumentException("Price is required for a single item product");

                return new SingleItemDto(0, 0, name, photoUrl, (Category)category, description, price.Value, quantity);
            }
            else
            {
                var nestedProducts = CustomExtensions
                    .Where(_productsDbHelper.GetAllPoducts(pageSize: int.MaxValue),
                        p => productItemIds.Contains(p.ItemId));

                if (nestedProducts.Count == 0)
                    throw new ArgumentException("Something went wrong, no products found for combo box!");

                return new ComboBoxDto(0, 0, name, photoUrl, (Category)category, description, (IDiscountStrategy) discountStrategy, nestedProducts);
            }
        }

        public BaseProductDto UpdateProduct(int itemId, int productId, string name, string photoUrl, int quantity, string description, object category, decimal? price, object discountStrategy)
        {
            if (price != null)
            {
                return
                    new SingleItemDto(productId, itemId, name, photoUrl, (Category)category, description, price.Value, quantity);
              
            }
            else
            {
                return new ComboBoxDto(productId, itemId, name, photoUrl, (Category)category, description, (IDiscountStrategy)discountStrategy, null);
            }
        }
    }
}
