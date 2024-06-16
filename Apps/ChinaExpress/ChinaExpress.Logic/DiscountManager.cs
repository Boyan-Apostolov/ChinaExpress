using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.Logic
{
    public class DiscountManager : IDiscountManager
    {
        private readonly IDiscountStrategiesDbHelper _dbHelper;
        private readonly IUserManager _userManager;

        public DiscountManager(IDiscountStrategiesDbHelper dbHelper, IUserManager userManager)
        {
            _dbHelper = dbHelper;
            _userManager = userManager;
        }
        public ICollection<IDiscountStrategy> GetAllDiscountStrategies(bool filterOnlyActiveDiscounts = false)
        {
            var discounts = _dbHelper.GetAllDiscountStrategies();

            if (filterOnlyActiveDiscounts) return CustomExtensions.Where(discounts, d => d.RemainingUses > 1);

            return discounts;
        }

        public IDiscountStrategy GetDiscountStrategy(int discountStrategyId)
        {
            return _dbHelper.GetDiscountStrategy(discountStrategyId);
        }

        public IDiscountStrategy GetDiscountStrategy(string discountCode)
        {
            return _dbHelper.GetDiscountStrategy(discountCode);
        }

        public async Task CreateDiscountStrategy(CreateDiscountDto createDto, bool shouldSentNotificationEmail = true)
        {
            var discountType = (DiscountStrategyType)createDto.Type;

            var discountCode = $"{discountType.ToString()[0]}#{createDto.Code}";
            _dbHelper.CreateDiscountStrategy(createDto.Value, discountCode, discountType, createDto.RemainingUses);

            if (shouldSentNotificationEmail)
            {
                await SendDiscountEmailsAsync(createDto.Value, discountCode, discountType, createDto.RemainingUses);
            }
        }

        private async Task SendDiscountEmailsAsync(int value, string code, DiscountStrategyType type, int remainingUses)
        {
            var users = await _userManager.GetAllUsersAsync(countUsers: remainingUses);
            foreach (var user in users)
            {
                await EmailSender.SendEmailAsync(user.Email, "New Discount!",
                    $"Hey {user.FirstName} {user.LastName}! " +
                    $"The first <b>{remainingUses} users</b> can use the code <b>{code}</b> to get <b>{value}</b> {(type == DiscountStrategyType.Percentage ? "percent" : "euros")} off their order!");
            }
        }

        public void DeleteDiscountStrategy(int discountStrategyId)
        {
            _dbHelper.DeleteDiscountStrategy(discountStrategyId);
        }

        public void LowerDiscountStrategyUses(int discountStrategyId)
        {
            _dbHelper.LowerDiscountStrategyUses(discountStrategyId);
        }
    }
}
