using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.Logic
{
    public interface IProductsManager
    {
        ICollection<Product> GetRandomProducts(int count, List<int> excludedProductIds = null);
        void DeleteProduct(int productId);


        void AddProduct(BaseProductDto productDto);

        void UpdateProduct(BaseProductDto productDto);

        ICollection<Product> GetAllProducts(
            string keyword = null,
            List<int> excludedProductIds = null,
            List<int> categories = null,
            List<int> ratings = null,
            string? sort = null,
            int currentPage = 0, int pageSize = int.MaxValue);

        Product? GetProduct(int productId);
        ICollection<Product> GetComboBoxItems(int id);

        ComboBox? GetComboBoxByProductId(int productId);
        void UpdateSingleProductQuantity(SqlTransaction sqlTransaction, int itemId, int newQuantity);
       
        ICollection<ProductView> GetProductViews(int productId);
        Task<int> CountProducts(string? keyword, List<int> category, List<int> rating);
        ICollection<Product> GenerateRecommendedProducts(int userId, bool includeRandomReccomendations = false);
        Task<int> GetViewsCount();
        List<KeyValuePair<string, int>> GetMostPopularItems();
    }
}
