using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeDiscountStrategiesDbHelper : IDiscountStrategiesDbHelper
    {
        private List<IDiscountStrategy> _discountStrategies = new List<IDiscountStrategy>();
        public ICollection<IDiscountStrategy> GetAllDiscountStrategies()
        {
            return this._discountStrategies;
        }

        public IDiscountStrategy GetDiscountStrategy(int discountStrategyId)
        {
            return this._discountStrategies.FirstOrDefault(d => d.Id == discountStrategyId);
        }

        public void CreateDiscountStrategy(int value, string code, DiscountStrategyType type, int remainingUses)
        {
            switch (type)
            {
                case DiscountStrategyType.Percentage:
                    this._discountStrategies.Add(new PercentageDiscountStrategy(this._discountStrategies.Count + 1, value, remainingUses, code));
                    break;
                case DiscountStrategyType.Fixed:
                    this._discountStrategies.Add(new FixedDiscountStrategy(this._discountStrategies.Count + 1, value, remainingUses, code));
                    break;
            }
        }

        public void DeleteDiscountStrategy(int discountStrategyId)
        {
            var discount = GetDiscountStrategy(discountStrategyId);
            this._discountStrategies.Remove(discount);
        }

        public void LowerDiscountStrategyUses(int discountStrategyId)
        {
            var discount = GetDiscountStrategy(discountStrategyId);
            discount.RemainingUses -= 1;
        }

        public IDiscountStrategy GetDiscountStrategy(string discountStrategyCode)
        {
            return this._discountStrategies.FirstOrDefault(d => d.Code == discountStrategyCode);
        }
    }
}
