using System.Data.SqlClient;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.Extensions;
using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.SimpleEntityModels;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.InternalHelpersSimpleModels
{
    public class ProductManagementHelper : BaseDbHelper, IProductManagementHelper
    {
        private readonly IDiscountStrategiesManagementHelper _discountStrategiesManagementHelper;
        private readonly IInternalProductManagementHelper _internalProductManagementHelper;

        public ProductManagementHelper(IDiscountStrategiesManagementHelper discountStrategiesManagementHelper, IInternalProductManagementHelper internalProductManagementHelper)
        {
            this._discountStrategiesManagementHelper = discountStrategiesManagementHelper;
            _internalProductManagementHelper = internalProductManagementHelper;
        }
        public Product GetProductById(int productId, bool getViews)
        {

            return CustomExtensions.FirstOrDefault(
                GetAllPoducts(pageSize: int.MaxValue, shouldGetViews: getViews, filterProductId: productId), x => true);
        }

        public List<Product> GetAllPoducts(string keyword = null, List<int> categories = null,
            int pageIndex = 0, int pageSize = 8, bool shouldGetViews = true, int? filterProductId = null)
        {
            categories ??= new List<int>();

            var foundItems = new List<Product>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    $@"SELECT p.Id, p.Name, p.[Description], p.PhotoUrl, c.Id, c.Name, si.Id, si.Price, si.Quantity, cb.Id, cb.DiscountStrategyId FROM Product as p
                LEFT JOIN SingleItem as si ON p.Id = si.ProductId
                LEFT JOIN ComboBox as cb ON cb.ProductId = p.Id
                JOIN Category as c ON p.CategoryId = c.Id WHERE 1=1 ";

                if (categories.Any())
                {
                    sql += $" AND (c.Id IN ({string.Join(", ", categories)}))";
                }

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql +=
                        " AND (p.Name LIKE @keyword OR p.[Description] LIKE @keyword OR c.Name LIKE @keyword)";
                }

                if (filterProductId.HasValue)
                {
                    sql += " AND p.Id = @ProductId";
                }

                sql += " ORDER BY p.Id";
                sql += " OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                cmd.Parameters.AddWithValue("@Offset", pageIndex * pageSize);
                cmd.Parameters.AddWithValue("@Fetch", pageSize);
                cmd.Parameters.AddWithValue("@ProductId", filterProductId ?? 0);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var productId = (int)dr[0];
                    if (dr[6] != DBNull.Value) //SingleItem
                    {
                        foundItems.Add(new SingleItem(
                            (int)dr[6],
                            dr[1].ToString(),
                            dr[2].ToString(),
                            dr[3].ToString(),
                            (int)dr[8],
                            (decimal)dr[7],
                            new Category((int)dr[4], dr[5].ToString(), 0),
                            productId,
                            this._internalProductManagementHelper));
                    }
                    else //ComboBox
                    {
                        var discountStrategy = dr[10] == DBNull.Value
                            ? null
                            : this._discountStrategiesManagementHelper
                                .GetDiscountStrategy((int)dr[10]);

                        var comboBoxId = (int)dr[9];
                        foundItems.Add(new ComboBox(
                            comboBoxId,
                            dr[1].ToString(),
                            dr[2].ToString(),
                            dr[3].ToString(),
                            discountStrategy,
                            new Category((int)dr[4], dr[5].ToString(), 0),
                            productId,
                            GetComboBoxItems(comboBoxId).ToList(),
                            this._internalProductManagementHelper)
                        );
                    }
                }
            }


            return foundItems;
        }

        /// <summary>
        /// Method used only for gathering combo box single items due to circilar dependency
        /// </summary>
        /// <returns></returns>
        public List<SingleItem> GetAllSingleItems()
        {
            var foundItems = new List<SingleItem>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT si.Id, p.Name, p.Description, p.PhotoUrl, si.Quantity, si.Price, c.Id, c.Name, p.Id 
                    FROM SingleItem as si
                    JOIN Product as p
                    on si.ProductId = p.Id
                    JOIN Category as c
                    on p.CategoryId = c.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    foundItems.Add(new SingleItem(
                        (int)dr[0],
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        (int)dr[4],
                        (decimal)dr[5],
                        new Category((int)dr[6], dr[7].ToString(), 0),
                        (int)dr[8]));
                }
            }

            return foundItems;
        }

        public List<ComboBox> GetAllComboBoxes()
        {
            var foundComboBoxes = new List<ComboBox>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT cbx.Id, p.Name, p.Description, p.PhotoUrl, cbx.DiscountStrategyId, c.Id, c.Name, p.Id
                      FROM ComboBox as cbx
                      JOIN Product as p
                      on p.Id = cbx.ProductId
                      JOIN Category as c
                      on c.Id = p.CategoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var comboBoxId = (int)dr[0];

                    var discountStrategy = dr[4] == DBNull.Value
                        ? null
                        : _discountStrategiesManagementHelper.GetDiscountStrategy((int)dr[4]);

                    foundComboBoxes.Add(new ComboBox(
                        comboBoxId,
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        discountStrategy,
                        new Category((int)dr[5], dr[6].ToString(), 0),
                        (int)dr[7],
                        GetComboBoxItems(comboBoxId).ToList())
                    );
                }
            }

            return foundComboBoxes;
        }

        public Product[] GetComboBoxItems(int comboBoxId)
        {
            var allProducts = GetAllSingleItems();
            var foundItems = new List<Product>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT *
                    FROM ComboBoxItem
                    WHERE ComboBoxId = @ComboBoxId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ComboBoxId", comboBoxId);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var itemId = (int)dr[1];
                    foundItems.Add(CustomExtensions
                        .FirstOrDefault(allProducts, si => si.ItemId == itemId)
                    );
                }
            }

            return foundItems.ToArray();
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
