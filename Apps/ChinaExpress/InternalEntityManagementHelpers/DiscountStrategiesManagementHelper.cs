using System.Data.SqlClient;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;


namespace ChinaExpress.InternalHelpersSimpleModels
{
    public class DiscountStrategiesManagementHelper : BaseDbHelper, IDiscountStrategiesManagementHelper
    {
        public ICollection<IDiscountStrategy> GetAllDiscountStrategies()
        {
            var foundDiscounts = new List<IDiscountStrategy>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT * FROM DiscountStrategy";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    switch ((DiscountStrategyType)dr[2])
                    {
                        case DiscountStrategyType.Percentage:
                            foundDiscounts.Add(new PercentageDiscountStrategy((int)dr[0],
                                (int)dr[1],
                                (int)dr[3],
                                dr[4].ToString()));
                            break;
                        case DiscountStrategyType.Fixed:
                            foundDiscounts.Add(new FixedDiscountStrategy((int)dr[0],
                                (int)dr[1],
                                (int)dr[3],
                                dr[4].ToString()));
                            break;
                    }
                }
            }

            return foundDiscounts;
        }

        public IDiscountStrategy GetDiscountStrategy(int discountStrategyId)
        {
            return CustomExtensions.FirstOrDefault(GetAllDiscountStrategies(), d => d.Id == discountStrategyId);
        }

        public IDiscountStrategy GetDiscountStrategy(string discountCode)
        {
            return CustomExtensions.FirstOrDefault(GetAllDiscountStrategies(), d => d.Code == discountCode);
        }
    }
}
