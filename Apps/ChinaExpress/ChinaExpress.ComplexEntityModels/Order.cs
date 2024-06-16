using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.InternalHelpersSimpleModels;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
namespace ChinaExpress.ComplexModelsWithoutHelperReferences
{
    public class Order
    {
        private readonly IOrderManagementHelper _internaManagementHelper;
        private List<OrderItem> _orderItems;

        public Order(
            int id,
            User user,
            DateTime? orderDate = null,
            OrderStatus orderStatus = OrderStatus.Draft,
            string address = "",
            IDiscountStrategy discountStrategy = null,
            IOrderManagementHelper internaManagementHelper = null)
        {
            _internaManagementHelper = internaManagementHelper;
            this.Id = id;
            this.OrderStatus = orderStatus;
            Address = address;
            DiscountStrategy = discountStrategy;
            this.OrderDate = orderDate;
            this.User = user;

            this._orderItems = null;
        }

        public int Id { get; }
        public DateTime? OrderDate { get; }
        public OrderStatus OrderStatus { get; }
        public string Address { get; }

        public User User { get; }
        public IDiscountStrategy? DiscountStrategy { get; private set; }

        public decimal GetTotalPrice()
        {
            var totalPrice = CustomExtensions.Sum(GetOrderItems(),
                product => product.Product.GetPrice() * product.Quantity);

            return DiscountStrategy?.ApplyDiscount(totalPrice) ?? totalPrice;
        }

        public ICollection<OrderItem> GetOrderItems()
        {
            if (this._orderItems == null) this._orderItems = _internaManagementHelper.LoadOrderItems(this.Id);

            return this._orderItems;
        }

        public void AddOrderItem(int productId, int quantity, List<string> selectedTags)
        {
            this._internaManagementHelper.CreateOrderItem(this.Id, productId, quantity, selectedTags);
        }
        
        public void DeleteOrderItem(int productId)
        {
            this._internaManagementHelper.RemoveOrderItem(this.Id, productId);
        }
        
        public void ChangeItemQuantiy(int productId, int quantity)
        {
            this._internaManagementHelper.ChangeOrderItemQuantity(this.Id, productId, quantity);
        }

        public string GetOrderStatusText()
        {
            return OrderStatus switch
            {
                OrderStatus.Requested => $"<span class='text-primary'><i class=\"fa-solid fa-warehouse\"> - {OrderStatus}</i></span>",
                OrderStatus.Sent => $"<span class='text-secondary'><i class=\"fa-solid fa-truck-fast\"> - {OrderStatus}</i></span>",
                OrderStatus.Finished => $"<span class='text-success'><i class=\"fa-solid fa-check\"> - {OrderStatus}</i></span>",
                _ => ""
            };
        }

    }
}
