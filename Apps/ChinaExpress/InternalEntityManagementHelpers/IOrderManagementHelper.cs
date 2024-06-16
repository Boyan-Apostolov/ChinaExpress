using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.InternalHelpersSimpleModels
{
    public interface IOrderManagementHelper
    {
        void CreateOrderItem(int orderId, int productId, int quantity, List<string> selectedTags);
        void RemoveOrderItem(int orderId, int productId);
        void ChangeOrderItemQuantity(int orderId, int productId, int quantity);
        List<OrderItem> LoadOrderItems(int orderId);
        Review GetReviewForOrderItem(int orderItemId);

        List<Review> GetAllReviews(int? productId = null);
    }
}
