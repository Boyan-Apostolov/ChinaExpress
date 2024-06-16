using ChinaExpress.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace ChinaExpress.Web.Pages
{
    [Authorize]
    public class ReferralsModel : PageModel
    {
        private readonly IUserManager _userManager;

        public ReferralsModel(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public string ReferralLink { get; set; }
        public int ReferralPoints { get; set; }
        public void OnGet()
        {
            var currentUser = _userManager.GetUser(int.Parse(User.FindFirst("Id").Value));
            ReferralLink = $"{HttpContext.Request.Host.Value}/Register?referralUserId={currentUser.Id}";
            ReferralPoints = currentUser.ReferralPoints;
        }
    }
}
