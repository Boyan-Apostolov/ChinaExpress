using ChinaExpress.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.Extensions;
using ChinaExpress.InternalHelpersSimpleModels;
using ChinaExpress.SimpleEntityModels;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
using ChinaExpress.DTOs;

namespace ChinaExpress.DataAccess.ApplicationHelpers
{
    public class ProductsDbHelper : BaseDbHelper, IProductsDbHelper
    {
        private readonly IProductManagementHelper _productManagementHelper;

        public ProductsDbHelper(IProductManagementHelper productManagementHelper)
        {
            _productManagementHelper = productManagementHelper;
        }

        public List<Product> GetAllPoducts(string keyword = null, List<int> categories = null, int pageIndex = 0, int pageSize = 8,
            bool shouldGetViews = true, int? filterProductId = null)
        {
            return _productManagementHelper
                .GetAllPoducts(keyword, categories, pageIndex, pageSize, shouldGetViews, filterProductId);
        }

        public List<ComboBox> GetAllComboBoxes()
        {
            return this._productManagementHelper.GetAllComboBoxes();
        }

        public void AddSingleProduct(SingleItemDto product)
        {
            var conn = GetConnection();
            var sql = @"INSERT INTO SingleItem (Price, ProductId, Quantity)
                               VALUES (@Price, @ProductId, @Quantity)";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@ProductId", GetLastCreatedId(nameof(Product)));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void UpdateComboBox(ComboBoxDto comboBox)
        {
            var conn = GetConnection();

            var sql = @"UPDATE ComboBox
                    SET DiscountStrategyId = @DiscountStrategyId
                    WHERE Id = @Id";

            var cmd = new SqlCommand(sql, conn);
            
            cmd.Parameters.AddWithValue("@DiscountStrategyId", comboBox.DiscountStrategy.Id);
            cmd.Parameters.AddWithValue("@Id", comboBox.ItemId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void UpdateSingleProduct(SingleItemDto singleItem)
        {
            var conn = GetConnection();

            var sql = @"UPDATE SingleItem
                    SET Price = @Price, Quantity = @Quantity
                    WHERE Id = @Id";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Price", singleItem.Price);
            cmd.Parameters.AddWithValue("@Quantity", singleItem.Quantity);
            cmd.Parameters.AddWithValue("@Id", singleItem.ItemId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        private int GetSingleItemQuantity(int itemId)
        {
            var conn = GetConnection();

            var sql = $"SELECT Quantity FROM SingleItem WHERE Id = @Id";
            var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", itemId);

            conn.Open();
            var id = (int)cmd.ExecuteScalar();
            conn.Close();

            return id;
        }

        public void EditSingleProductQuantity(SqlTransaction sqlTransaction, int itemId, int newQUantity)
        {
            var sql = @"UPDATE SingleItem
                    SET Quantity = @Quantity
                    WHERE Id = @Id";

            var productQuantiy = GetSingleItemQuantity(itemId);

            if (productQuantiy == 0 || newQUantity <= 0)
                throw new InvalidOperationException("Product is out of stock!");

            var cmd = new SqlCommand(sql, sqlTransaction.Connection, sqlTransaction);
            cmd.Parameters.AddWithValue("@Quantity", newQUantity);
            cmd.Parameters.AddWithValue("@Id", itemId);

            cmd.ExecuteNonQuery();
        }

        public void DeleteProdcut(int productId)
        {
            var conn = GetConnection();

            string sql = @"DELETE FROM Product WHERE Id = @productId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@productId", productId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Product[] GetComboBoxItems(int comboBoxId)
        {
            return this._productManagementHelper.GetComboBoxItems(comboBoxId);
        }

        public void AddProduct(BaseProductDto productDto)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO Product (Name, Description, PhotoUrl, CategoryId)
                            VALUES (@Name, @Description, @PhotoUrl, @CategoryId)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", productDto.Name);
            cmd.Parameters.AddWithValue("@Description", productDto.Description);
            cmd.Parameters.AddWithValue("@PhotoUrl", productDto.PhotoUrl);
            cmd.Parameters.AddWithValue("@CategoryId", productDto.Category.Id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (productDto.GetType() == typeof(SingleItemDto))
            {
                AddSingleProduct((SingleItemDto)productDto);
            }
            else
            {
                AddComboBox((ComboBoxDto)productDto);
            }
        }

        public void AddComboBox(ComboBoxDto comboBox)
        {
            var conn = GetConnection();

            var sql = @"INSERT INTO ComboBox (ProductId, DiscountStrategyId)
                               VALUES (@ProductId, @DiscountStrategyId)";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProductId", GetLastCreatedId(nameof(Product)));
            cmd.Parameters.AddWithValue("@DiscountStrategyId", comboBox.DiscountStrategy.Id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            var newComboBoxId = GetLastCreatedId(nameof(ComboBox));

            foreach (var comboBoxProduct in comboBox.SelectedProducts)
            {
                sql = @"INSERT INTO ComboBoxItem (ComboBoxId, SingleItemId)
                               VALUES (@ComboBoxId, @SingleItemId)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ComboBoxId", newComboBoxId);
                cmd.Parameters.AddWithValue("@SingleItemId", comboBoxProduct.ItemId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateProduct(BaseProductDto product)
        {
            var conn = GetConnection();

            string sql = @"UPDATE Product 
                           Set Name = @Name, Description = @Description, PhotoUrl = @PhotoUrl, CategoryId = @CategoryId
                           WHERE Id = @ProductId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@PhotoUrl", product.PhotoUrl);
            cmd.Parameters.AddWithValue("@CategoryId", product.Category.Id);
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (product.GetType() == typeof(SingleItemDto))
            {
                UpdateSingleProduct((SingleItemDto)product);
            }
            else
            {
                UpdateComboBox((ComboBoxDto)product);
            }
        }

        public bool IsSingleProductInComboBox(int singleProductId)
        {
            var conn = GetConnection();

            var sql = @"SELECT *
                        FROM ComboBoxItem
                        WHERE SingleItemId = @ItemId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ItemId", singleProductId);

            conn.Open();
            var id = (int?)cmd.ExecuteScalar();
            conn.Close();

            return id.HasValue;
        }

        public ICollection<ProductView> GetUserProductViews(int userId)
        {
            var productViews = new List<ProductView>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT * FROM ProductView WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserId", userId);

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

        public async Task<int> GetViewsCount()
        {
            var conn = GetConnection();

            var sql = @"SELECT COUNT(*)
                        FROM [ProductView]";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            var count = (int)(await cmd.ExecuteScalarAsync());
            conn.Close();

            return count;
        }
    }
}
