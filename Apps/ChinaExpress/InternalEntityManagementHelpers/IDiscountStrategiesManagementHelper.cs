using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.InternalHelpersSimpleModels
{
    public interface IDiscountStrategiesManagementHelper
    {
        public ICollection<IDiscountStrategy> GetAllDiscountStrategies();

        public IDiscountStrategy GetDiscountStrategy(int discountStrategyId);
        public IDiscountStrategy GetDiscountStrategy(string discountCode);
    }
}
