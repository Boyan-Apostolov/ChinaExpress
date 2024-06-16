using ChinaExpress.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
using ChinaExpress.Extensions;
using ChinaExpress.InternalHelpersSimpleModels;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.DataAccess.ApplicationHelpers
{
    public class OrdersDbHelper : BaseDbHelper, IOrdersDbHelper
    {
        private readonly IUsersDbHelper _userDbHelper;
        private readonly IDiscountStrategiesDbHelper _discountStrategiesDbHelper;
        private readonly IOrderManagementHelper _orderManagementHelper;

        public OrdersDbHelper(IUsersDbHelper userDbHelper,
            IDiscountStrategiesDbHelper discountStrategiesDbHelper,
            IOrderManagementHelper orderManagementHelper)
        {
            _userDbHelper = userDbHelper;
            _discountStrategiesDbHelper = discountStrategiesDbHelper;
            _orderManagementHelper = orderManagementHelper;
        }

        private List<Order> GetUserOrders(int userId)
        {
            return GetAllOrders(null, userId);
        }


        public List<Order> GetAllOrders(int? filterOrderId, int? filterUserId = null, int? limit = null)
        {
            var foundOrders = new List<Order>();
            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT TOP(@TopPlaceHolder) * 
                    FROM [Order]";

                if (filterUserId.HasValue)
                {
                    sql += " WHERE UserId = @UserId";
                }

                if (filterOrderId.HasValue)
                {
                    sql += " WHERE Id = @OrderId";
                }

                sql += " ORDER BY Id DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserId", filterUserId ?? 0);
                cmd.Parameters.AddWithValue("@OrderId", filterOrderId ?? 0);
                cmd.Parameters.AddWithValue("@TopPlaceHolder", limit ?? int.MaxValue);
                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var orderDateString = dr[1].ToString();
                    foundOrders.Add(new Order((int)dr[0],
                        _userDbHelper.GetUserById((int)dr[3]),
                        string.IsNullOrWhiteSpace(orderDateString) ? DateTime.Now : DateTime.Parse(orderDateString),
                        (OrderStatus)dr[2],
                        dr[4].ToString(),
                        dr[5] != DBNull.Value ? _discountStrategiesDbHelper.GetDiscountStrategy((int)dr[5]) : null,
                        _orderManagementHelper
                        )
                    );
                }
            }

            return foundOrders.OrderByDescending(o => o.OrderDate).ToList();
        }
        public Order GetOrCreateUserDraftOrder(int userId)
        {
            var userDraftOrder = CustomExtensions.FirstOrDefault(GetUserOrders(userId), o => o.OrderStatus == OrderStatus.Draft);

            if (userDraftOrder != null)
            {
                return userDraftOrder;
            }
            else
            {
                CreateDraftOrder(new Order(0, _userDbHelper.GetUserById(userId)));
                return GetOrCreateUserDraftOrder(userId);
            }
        }

        private void CreateDraftOrder(Order order)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO [Order] (UserId, Status)
                            VALUES (@UserId, @Status)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", order.User.Id);
            cmd.Parameters.AddWithValue("@Status", order.OrderStatus);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SubmitOrder(SqlTransaction sqlTransaction, int orderId, string deliveryAddress)
        {
            string sql = @"UPDATE [Order]
                            SET Address = @Address, Status = @Status, CreationDate = @CreationDate
                            WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, sqlTransaction.Connection, sqlTransaction);
            cmd.Parameters.AddWithValue("@Id", orderId);
            cmd.Parameters.AddWithValue("@Address", deliveryAddress);
            cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Status", (int)OrderStatus.Requested);

            cmd.ExecuteNonQuery();
        }

        private void SetOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var conn = GetConnection();

            string sql = @"UPDATE [Order]
                            SET Status = @Status
                            WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", orderId);
            cmd.Parameters.AddWithValue("@Status", (int)orderStatus);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void ConfirmOrder(int orderId)
        {
            SetOrderStatus(orderId, OrderStatus.Finished);
        }

        public void SendOrder(int orderId)
        {
            SetOrderStatus(orderId, OrderStatus.Sent);
        }

        public List<Review> GetAllReviews(int? productId)
        {
            return this._orderManagementHelper.GetAllReviews(productId);
        }

        public void AddReview(int stars, string description, int orderItemId, int infoUserId)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO Review (Description, Stars, UserId, OrderItemId)
                            VALUES (@Description, @Stars, @UserId, @OrderItemId)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Stars", stars);
            cmd.Parameters.AddWithValue("@UserId", infoUserId);
            cmd.Parameters.AddWithValue("@OrderItemId", orderItemId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void ApplyDiscount(int orderId, IDiscountStrategy foundDiscount)
        {
            var conn = GetConnection();

            string sql = @"UPDATE [Order]
                            SET DiscountStrategyId = @DiscountStrategyId
                            WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", orderId);
            cmd.Parameters.AddWithValue("@DiscountStrategyId", foundDiscount.Id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public async Task<int> GetOrdersCount()
        {
            var conn = GetConnection();

            var sql = @"SELECT COUNT(*)
                        FROM [Order]";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            var count = (int)(await cmd.ExecuteScalarAsync());
            conn.Close();

            return count;
        }

        public async Task<int> GetReviewsCount()
        {
            var conn = GetConnection();

            var sql = @"SELECT COUNT(*)
                        FROM [Review]";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            var count = (int)(await cmd.ExecuteScalarAsync());
            conn.Close();

            return count;
        }

        public void RemoveDiscount(int orderId)
        {
            var conn = GetConnection();

            string sql = @"UPDATE [Order]
                            SET DiscountStrategyId = NULL
                            WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", orderId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
