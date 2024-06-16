using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.InternalHelpersSimpleModels
{
    public interface IProductManagementHelper
    {
        public Product GetProductById(int productId, bool getViews);

        public List<Product> GetAllPoducts(string keyword = null, List<int> categories = null,
            int pageIndex = 0, int pageSize = 8, bool shouldGetViews = true, int? filterProductId = null);

        /// <summary>
        /// Method used only for gathering combo box single items due to circilar dependency
        /// </summary>
        /// <returns></returns>
        public List<SingleItem> GetAllSingleItems();

        public List<ComboBox> GetAllComboBoxes();

        public Product[] GetComboBoxItems(int comboBoxId);

        public List<ProductView> GetProductViews(int productId);
    }
}
