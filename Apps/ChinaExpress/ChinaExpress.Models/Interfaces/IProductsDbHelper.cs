using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.Interfaces
{
    public interface IProductsDbHelper
    {
        List<Product> GetAllPoducts(string keyword = null,
            List<int> categories = null,
            int pageIndex = 0, int pageSize = 8,
            bool shouldGetViews = true, int? filterProductId = null);

        List<ComboBox> GetAllComboBoxes();
        void EditSingleProductQuantity(SqlTransaction sqlTransaction, int itemId, int newQUantity);
        void DeleteProdcut(int productId);
        Product[] GetComboBoxItems(int comboBoxId);
        void UpdateProduct(BaseProductDto productDto);
        void AddProduct(BaseProductDto productDto);
        bool IsSingleProductInComboBox(int singleProductId);
        ICollection<ProductView> GetUserProductViews(int userId);
        Task<int> GetViewsCount();
    }
}
