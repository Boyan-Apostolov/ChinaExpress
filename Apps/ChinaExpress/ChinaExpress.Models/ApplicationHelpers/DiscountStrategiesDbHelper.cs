using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.Extensions;
using ChinaExpress.InternalHelpersSimpleModels;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using static ChinaExpress.SimpleEntityModels.DiscountStrategy;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.DataAccess.ApplicationHelpers
{
    public class DiscountStrategiesDbHelper : BaseDbHelper, IDiscountStrategiesDbHelper
    {
        private readonly IDiscountStrategiesManagementHelper _managementHelper;

        public DiscountStrategiesDbHelper(IDiscountStrategiesManagementHelper managementHelper)
        {
            _managementHelper = managementHelper;
        }

        public ICollection<IDiscountStrategy> GetAllDiscountStrategies()
        {
            return this._managementHelper.GetAllDiscountStrategies();
        }

        public IDiscountStrategy GetDiscountStrategy(int discountStrategyId)
        {
            return this._managementHelper.GetDiscountStrategy(discountStrategyId);
        }

        public void CreateDiscountStrategy(int value, string code, DiscountStrategyType type, int remainingUses)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO DiscountStrategy (Value, Code, Type, RemainingUses)
                            VALUES (@Value, @Code, @Type, @RemainingUses)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Value", value);
            cmd.Parameters.AddWithValue("@Code", code);
            cmd.Parameters.AddWithValue("@Type", (int)type);
            cmd.Parameters.AddWithValue("@RemainingUses", remainingUses);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteDiscountStrategy(int discountStrategyId)
        {
            var conn = GetConnection();

            string sql = @"DELETE FROM DiscountStrategy WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", discountStrategyId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void LowerDiscountStrategyUses(int discountStrategyId)
        {
            var conn = GetConnection();

            string sql = @"UPDATE DiscountStrategy SET RemainingUses = RemainingUses - 1 WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", discountStrategyId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IDiscountStrategy GetDiscountStrategy(string discountStrategyCode)
        {
            return this._managementHelper.GetDiscountStrategy(discountStrategyCode);
        }
    }
}
