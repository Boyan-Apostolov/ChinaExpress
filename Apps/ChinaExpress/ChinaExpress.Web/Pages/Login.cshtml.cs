using System.Security.Claims;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserManager _userManager;

        public LoginModel(IUserManager userManager)
        {
            _userManager = userManager;
            this.FormData = new LoginDto();
        }

        [BindProperty]
        public LoginDto FormData { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            User loggedUser = null;

            try
            {
                loggedUser = this._userManager.Login(this.FormData.Email, this.FormData.Password, false);
            }
            catch (InvalidOperationException e)
            {
                this.FormData.Message = e.Message;
                return Page();
            }

            if (loggedUser != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, loggedUser.Email),
                    new Claim("Id", loggedUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, loggedUser.UserRole.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage(nameof(Index));

            }

            this.FormData.Message = "Login failed! Email or password is incorrect!";
            return Page();
        }
    }
}
