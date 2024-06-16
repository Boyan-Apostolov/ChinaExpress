using System.Data.SqlClient;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.InternalHelpersComplexModels
{
    public class InternalProductManagementHelper : BaseDbHelper, IInternalProductManagementHelper
    {
        public void IncreaseViews(int productId, int userId)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO ProductView (ProductId, UserId, ViewDateTime)
                            VALUES (@ProductId, @UserId, @ViewDateTime)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ViewDateTime", DateTime.Now);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Review> GetProductReviews(int productId)
        {
            var productReviews = new List<Review>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT r.Id, r.[Description], r.Stars, CONCAT(u.FirstName, ' ', u.LastName), r.OrderItemId
                    FROM Review as r
                    JOIN [User] as u 
                    on r.Userid = u.Id
                    JOIN OrderItem as oi
                    on r.OrderItemId = oi.Id WHERE oi.ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductId", productId);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    productReviews.Add(new Review((int)dr[0],
                        dr[1].ToString(),
                        (int)dr[2],
                        dr[3].ToString(),
                        (int)dr[4])
                    );
                }
            }
            return productReviews;
        }

        public List<ProductView> GetProductViews(int productId)
        {
            var productViews = new List<ProductView>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT * FROM ProductView WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductId", productId);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    productViews.Add(new ProductView((int)dr[0],
                        (int)dr[2],
                        (int)dr[1],
                        (DateTime)dr[3])
                    );
                }
            }
            return productViews;
        }
    }
}
