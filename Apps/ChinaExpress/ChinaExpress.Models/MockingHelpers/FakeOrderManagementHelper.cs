using ChinaExpress.InternalHelpersSimpleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.SimpleEntityModels;
using Newtonsoft.Json;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.InternalHelpersComplexModels;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeOrderManagementHelper : IOrderManagementHelper
    {
        private IInternalProductManagementHelper fakeInternalProductManagementHelper;
        public FakeOrderManagementHelper()
        {
            this.fakeInternalProductManagementHelper = new FakeInternalProductManagementHelper();
        }
        private List<OrderItem> orderItems = new List<OrderItem>();

        public void CreateOrderItem(int orderId, int productId, int quantity, List<string> selectedTags)
        {
            var tempProduct = new SingleItem(productId, "", "", "", 5, 5, null, productId, fakeInternalProductManagementHelper);
            this.orderItems.Add(new OrderItem(this.orderItems.Count + 1, orderId, tempProduct, quantity, JsonConvert.SerializeObject(selectedTags), null));
        }

        public void RemoveOrderItem(int orderId, int productId)
        {
            var orderItem =
                this.orderItems.FirstOrDefault(o => o.OrderId == orderId && o.Product.ProductId == productId);

            this.orderItems.Remove(orderItem);
        }

        public void ChangeOrderItemQuantity(int orderId, int productId, int quantity)
        {
            RemoveOrderItem(orderId, productId);
            CreateOrderItem(orderId, productId, quantity, new List<string>());
        }

        public List<OrderItem> LoadOrderItems(int orderId)
        {
            return this.orderItems.Where(o => o.OrderId == orderId).ToList();
        }

        public Review GetReviewForOrderItem(int orderItemId)
        {
            return this.orderItems.FirstOrDefault(o => o.Id == orderItemId).Review;
        }

        public List<Review> GetAllReviews(int? productId = null)
        {
            throw new NotImplementedException();
        }
    }
}
