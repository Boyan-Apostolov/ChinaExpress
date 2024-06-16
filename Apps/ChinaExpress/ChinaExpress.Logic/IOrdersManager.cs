using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.Logic
{
    public interface IOrdersManager
    {
        public Order GetOrCreateUserDraftOrder(int userId);

        void SubmitOrder(int orderId, string deliveryAddres);
        void SendOrder(int orderId);
        ICollection<Order> GetUserOrders(int userId);
        ICollection<Order> GetAllActiveOrders(int? limit = null);
        Order GetOrder(int orderId);
        void ConfirmOrder(int orderId);

        void AddReview(int stars, string description, int orderItemId, int infoUserId);
        Task<int> GetOrdersCount();
        Task<int> GetReviewsCount();
        decimal GetTotalProfit();
        List<KeyValuePair<string, int>> GetSalesPerCategory();

        List<KeyValuePair<string, decimal>> GetLastTenOrderRecords();
        void ApplyDiscount(int orderId, IDiscountStrategy foundDiscount);
        void RemoveDiscount(int orderId);
    }
}
