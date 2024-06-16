using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DataAccess.ApplicationHelpers;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.InternalHelpersSimpleModels;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeOrdersDbHelper : IOrdersDbHelper
    {
        private List<Order> _orders;
        private IOrderManagementHelper _orderManagementHelper;

        public FakeOrdersDbHelper()
        {
            this._orders = new List<Order>();
            _orderManagementHelper = new FakeOrderManagementHelper();
        }

        public SqlTransaction GetNewSqlTransaction()
        {
            return null;
        }

        public List<Order> GetAllOrders(int? filterOrderId, int? filterUserId = null, int? limit = null)
        {
            var orders = _orders;
            if (filterUserId.HasValue) orders = orders.Where(o => o.User.Id == filterUserId.Value).ToList();

            if(filterOrderId.HasValue)
                orders = orders.Where(o => o.Id == filterOrderId.Value).ToList();

            return orders;
        }

        public Order GetOrCreateUserDraftOrder(int userId)
        {
            var userDraftOrder = GetAllOrders(null, userId, null).FirstOrDefault(o => o.OrderStatus == OrderStatus.Draft);

            if (userDraftOrder != null)
            {
                return userDraftOrder;
            }
            else
            {
                this._orders.Add(new Order(this._orders.Count + 1, new User(userId, "","", "", "","", UserRole.Client, 0),internaManagementHelper: _orderManagementHelper));

                return GetOrCreateUserDraftOrder(userId);
            }
        }

        public void SubmitOrder(SqlTransaction sqlTransaction, int orderId, string deliveryAddress)
        {
            var order = this._orders.FirstOrDefault(o => o.Id == orderId);
            this._orders.Remove(order);

            this._orders.Add(new Order(orderId, order.User, order.OrderDate, OrderStatus.Requested, deliveryAddress, order.DiscountStrategy, internaManagementHelper: _orderManagementHelper));
        }

        public void ConfirmOrder(int orderId)
        {
            var order = this._orders.FirstOrDefault(o => o.Id == orderId);
            this._orders.Remove(order);

            this._orders.Add(new Order(orderId, order.User, order.OrderDate, OrderStatus.Finished, order.Address, order.DiscountStrategy, internaManagementHelper: _orderManagementHelper));
        }

        public void SendOrder(int orderId)
        {
            var order = this._orders.FirstOrDefault(o => o.Id == orderId);
            this._orders.Remove(order);

            this._orders.Add(new Order(orderId, order.User, order.OrderDate, OrderStatus.Sent, order.Address, order.DiscountStrategy, internaManagementHelper: _orderManagementHelper));
        }

        public List<Review> GetAllReviews(int? productId)
        {
            return new List<Review>();
        }

        public void AddReview(int stars, string description, int orderItemId, int infoUserId)
        {
            throw new NotImplementedException();
        }

        public void ApplyDiscount(int orderDto, IDiscountStrategy foundDiscount)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetOrdersCount()
        {
            return this._orders.Count;
        }

        public Task<int> GetReviewsCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveDiscount(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
