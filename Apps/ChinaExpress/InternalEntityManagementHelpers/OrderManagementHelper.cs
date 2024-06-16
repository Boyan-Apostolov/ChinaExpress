using System.Data.SqlClient;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;
using Newtonsoft.Json;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.InternalHelpersSimpleModels
{
    public class OrderManagementHelper : BaseDbHelper, IOrderManagementHelper
    {
        private readonly IProductManagementHelper _productManagementHelper;
        public OrderManagementHelper(IProductManagementHelper productManagementHelper)
        {
            this._productManagementHelper = productManagementHelper;
        }

        public void CreateOrderItem(int orderId, int productId, int quantity, List<string> selectedTags)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO OrderItem (OrderId, ProductId, Quantity, SerializedSelectedTags)
                            VALUES (@OrderId, @ProductId, @Quantity, @SerializedSelectedTags)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@SerializedSelectedTags", JsonConvert.SerializeObject(selectedTags));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveOrderItem(int orderId, int productId)
        {
            var conn = GetConnection();

            string sql = @"DELETE OrderItem WHERE OrderId = @OrderId AND ProductId = @ProductId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void ChangeOrderItemQuantity(int orderId, int productId, int quantity)
        {
            var conn = GetConnection();

            string sql = @"UPDATE OrderItem
                           SET Quantity = @Quantity
                           WHERE OrderId = @OrderId AND ProductId = @ProductId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<OrderItem> LoadOrderItems(int orderId)
        {
            var foundItems = new List<OrderItem>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT * FROM OrderItem WHERE OrderId = @OrderId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var orderItemId = (int)dr[0];
                    foundItems.Add(new OrderItem(
                        orderItemId,
                        (int)dr[1],
                        _productManagementHelper.GetProductById((int)dr[2], false),
                        (int)dr[3],
                        dr[4].ToString(),
                        GetReviewForOrderItem(orderItemId))
                    );
                }
            }

            return foundItems;
        }

        public Review GetReviewForOrderItem(int orderItemId)
        {
            return CustomExtensions.FirstOrDefault(GetAllReviews(), r => r.OrderItemId == orderItemId);
        }

        public List<Review> GetAllReviews(int? productId = null)
        {
            var foundReviws = new List<Review>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT r.Id, r.Description, r.Stars, r.UserId, r.OrderItemId, oi.ProductId, CONCAT(u.FirstName, ' ', u.LastName)
                      FROM Review as r 
                      JOIN OrderItem as oi 
                      ON r.OrderItemId = oi.Id
                      JOIN [User] as u
                      on u.Id = r.UserId ";

                if (productId.HasValue)
                {
                    sql += "WHERE oi.ProductId = @ProductId";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);

                if (productId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId.Value);
                }

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    foundReviws.Add(new Review(
                        (int)dr[0],
                        dr[1].ToString(),
                        (int)dr[2],
                        dr[6].ToString(),
                        (int)dr[4])
                    );
                }
            }

            return foundReviws;
        }
    }
}
