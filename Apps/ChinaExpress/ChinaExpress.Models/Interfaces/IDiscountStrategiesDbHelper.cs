using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.DataAccess.Interfaces
{
    public interface IDiscountStrategiesDbHelper
    {
        ICollection<IDiscountStrategy> GetAllDiscountStrategies();
        IDiscountStrategy GetDiscountStrategy(int discountStrategyId);
        void CreateDiscountStrategy(int value, string code, DiscountStrategyType type, int remainingUses);
        void DeleteDiscountStrategy(int discountStrategyId);
        void LowerDiscountStrategyUses(int discountStrategyId);
        IDiscountStrategy GetDiscountStrategy(string discountStrategyCode);
    }
}
