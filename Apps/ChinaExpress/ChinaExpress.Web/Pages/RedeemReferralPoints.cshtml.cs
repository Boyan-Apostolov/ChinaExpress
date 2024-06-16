using ChinaExpress.DTOs;
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [Authorize]
    public class RedeemReferralPointsModel : PageModel
    {
        private readonly IUserManager _userManager;
        private readonly IDiscountManager _dicountManager;

        public RedeemReferralPointsModel(IUserManager userManager, IDiscountManager dicountManager)
        {
            _userManager = userManager;
            _dicountManager = dicountManager;
        }
        public IActionResult OnGet()
        {
            var r = new Random();
            var user = _userManager.GetUser(int.Parse(User.FindFirst("Id").Value));
            if (user.ReferralPoints == 0) throw new InvalidOperationException("User has no referral points!");

            var generatedDicountCode = $"{user.LastName}#{user.ReferralPoints}-{r.Next(1000)}";

            _dicountManager.CreateDiscountStrategy(new CreateDiscountDto((int)Math.Ceiling(user.ReferralPoints / 10m), generatedDicountCode, 0, 1),
                shouldSentNotificationEmail: false)
                .GetAwaiter()
                .GetResult();

            _userManager.AddReferralPoints(user.Id, -user.ReferralPoints);

            return Content($"F#{generatedDicountCode}");
        }
    }
}
