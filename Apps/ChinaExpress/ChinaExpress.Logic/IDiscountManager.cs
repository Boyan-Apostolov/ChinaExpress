using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Logic
{
    public interface IDiscountManager
    {
        ICollection<IDiscountStrategy> GetAllDiscountStrategies(bool filterOnlyActiveDiscounts = false);
        IDiscountStrategy GetDiscountStrategy(int discountStrategyId);
        IDiscountStrategy GetDiscountStrategy(string discountCode);

        Task CreateDiscountStrategy(CreateDiscountDto createDto, bool shouldSentNotificationEmail = true);
            void DeleteDiscountStrategy(int discountStrategyId);
        void LowerDiscountStrategyUses(int discountStrategyId);
    }
}
