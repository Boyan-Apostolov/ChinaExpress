using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.InternalHelpersComplexModels
{
    public interface IInternalProductManagementHelper
    {
        List<Review> GetProductReviews(int id);
        List<ProductView> GetProductViews(int id);
        void IncreaseViews(int productId, int userId);
    }
}
