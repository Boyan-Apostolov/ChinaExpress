using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DataAccess;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
namespace ChinaExpress.Logic
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrdersDbHelper _databaseHelper;
        private readonly IProductsManager _productsManager;
        private readonly IUserManager _userManager;

        public OrdersManager(IOrdersDbHelper ordersDbHelper, IProductsManager productsManager, IUserManager userManager)
        {
            this._databaseHelper = ordersDbHelper;
            _productsManager = productsManager;
            _userManager = userManager;
        }

        public Order GetOrCreateUserDraftOrder(int userId)
        {
            return this._databaseHelper.GetOrCreateUserDraftOrder(userId);
        }

        private void LowerItemsQuantities(SqlTransaction sqlTransaction, Order order)
        {
            foreach (var orderItem in order.GetOrderItems())
            {
                if (orderItem.Product.GetType() == typeof(ComboBox))
                {
                    var comboBoxItems = this._productsManager
                        .GetComboBoxItems(orderItem.Product.ItemId);
                    foreach (var comboBoxItem in comboBoxItems)
                    {
                        this._productsManager.UpdateSingleProductQuantity(sqlTransaction,
                            comboBoxItem.ItemId,
                            comboBoxItem.GetQuantity() - orderItem.Quantity);
                    }
                }
                else
                {
                    this._productsManager.UpdateSingleProductQuantity(sqlTransaction, orderItem.Product.ItemId,
                        orderItem.Product.GetQuantity() - orderItem.Quantity);
                }

            }
        }

        public ICollection<Order> GetUserOrders(int userId)
        {
            return CustomExtensions.Where(GetAllOrders(filterUserId: userId),
                o => o.OrderStatus != OrderStatus.Draft);
        }

        private ICollection<Order> GetAllOrders(int? filterOrderId = null, int? filterUserId = null, int? limit = null)
        {
            return this._databaseHelper.GetAllOrders(filterOrderId, filterUserId, limit);
        }

        public ICollection<Order> GetAllActiveOrders(int? limit = null)
        {
            return CustomExtensions.Where(GetAllOrders(limit: limit), o => o.OrderStatus > OrderStatus.Draft)
                .OrderByDescending(o => o.Id)
                .ToList();
        }

        public Order GetOrder(int orderId)
        {
            return CustomExtensions.FirstOrDefault(GetAllOrders(filterOrderId: orderId), x => true);
        }

        public void SubmitOrder(int orderId, string deliveryAddress)
        {
            var order = GetOrder(orderId);

            if (order.OrderStatus != OrderStatus.Draft)
            {
                throw new InvalidOperationException($"Order {orderId} has already been sent!");
            }

            if (!order.GetOrderItems().Any())
                throw new InvalidOperationException($"Cannot send empty order ! Please add items");

            var transaction = _databaseHelper.GetNewSqlTransaction();

            try
            {
                this._databaseHelper.SubmitOrder(transaction, orderId, deliveryAddress);

                LowerItemsQuantities(transaction, order);

                transaction?.Commit();

                var successMessage = "Order was placed successfully! It will be shipped within 3 business days.";

                EmailSender.SendEmailAsync(order.User.Email,
                    $"New order #{order.Id}",
                    successMessage + $" Delivery: {deliveryAddress}").GetAwaiter().GetResult();
            }
            catch (InvalidOperationException e)
            {
                transaction?.Rollback();
                Console.WriteLine(e.Message);
                throw new InvalidOperationException($"Order is canceled! Items missing!!!");
            }
            finally
            {
                transaction?.Connection?.Close();
                transaction?.Dispose();

                GetOrCreateUserDraftOrder(order.User.Id);
            }
        }

        public void ConfirmOrder(int orderId)
        {
            var order = GetOrder(orderId);

            if (order.OrderStatus != OrderStatus.Sent)
            {
                throw new InvalidOperationException($"Order {orderId} has already been confirmed!");
            }

            this._databaseHelper.ConfirmOrder(orderId);

            this._userManager.AddReferralPoints(order.User.Id,
                (int)Math.Ceiling(order.GetTotalPrice() / 10m));

        }

        public void SendOrder(int orderId)
        {
            var order = GetOrder(orderId);

            if (order.OrderStatus != OrderStatus.Requested)
            {
                throw new InvalidOperationException($"Order {orderId} has already been sent!");
            }

            this._databaseHelper.SendOrder(orderId);
        }

        public void AddReview(int stars, string description, int orderItemId, int infoUserId)
        {
            this._databaseHelper.AddReview(stars, description, orderItemId, infoUserId);
        }

        public async Task<int> GetOrdersCount()
        {
            return await this._databaseHelper.GetOrdersCount();
        }

        public async Task<int> GetReviewsCount()
        {
            return await this._databaseHelper.GetReviewsCount();
        }

        public decimal GetTotalProfit()
        {
            return CustomExtensions.Sum(GetAllOrders(),
                o => o.GetTotalPrice());
        }

        public List<KeyValuePair<string, int>> GetSalesPerCategory()
        {
            return GetAllOrders()
                .SelectMany(o => o.GetOrderItems().Select(oi => oi.Product))
                .GroupBy(p => p.Category.Name)
                .Select(p =>
                    new KeyValuePair<string, int>(p.Key, p.ToArray().Length))
                .ToList();
        }

        public List<KeyValuePair<string, decimal>> GetLastTenOrderRecords()
        {
            return
                CustomExtensions.Where(GetAllOrders(), o => o.OrderDate.HasValue)
                    .OrderByDescending(o => o.Id)
                    .Take(10)
                    .Select(o =>
                        new KeyValuePair<string, decimal>(o.OrderDate.Value.Date.ToShortDateString(),
                            o.GetTotalPrice()))
                    .ToList();
        }

        public void ApplyDiscount(int orderId, IDiscountStrategy foundDiscount)
        {
            this._databaseHelper.ApplyDiscount(orderId, foundDiscount);
        }

        public void RemoveDiscount(int orderId)
        {
            this._databaseHelper.RemoveDiscount(orderId);
        }
    }
}
