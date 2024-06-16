using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.Interfaces
{
    public interface IOrdersDbHelper
    {
        SqlTransaction GetNewSqlTransaction();
        List<Order> GetAllOrders(int? filterOrderId = null, int? filterUserId = null, int? limit = null);
        Order GetOrCreateUserDraftOrder(int userId);
        void SubmitOrder(SqlTransaction sqlTransaction, int orderId, string deliveryAddress);
        void ConfirmOrder(int orderId);
        void SendOrder(int orderId);
        void AddReview(int stars, string description, int orderItemId, int infoUserId);
        void ApplyDiscount(int orderDto, IDiscountStrategy foundDiscount);
        Task<int> GetOrdersCount();
        Task<int> GetReviewsCount();
        void RemoveDiscount(int orderId);
    }
}
