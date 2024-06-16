using System.Security.Claims;
using ChinaExpress.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IUserManager _userManager;

        public LogoutModel(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage(nameof(Index));
        }
    }
}
