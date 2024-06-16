
using System.Security.Claims;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserManager _userManager;

        public RegisterModel(IUserManager userManager)
        {
            _userManager = userManager;
            this.FormData = new RegisterDto();
        }

        [BindProperty]
        public RegisterDto FormData { get; set; }

        public string ReferralUserName { get; set; }

        public void OnGet(int? referralUserId = null)
        {
            FormData.ReferralUserId = referralUserId;
            var foundUser = _userManager.GetUser(referralUserId ?? 0);
            if (foundUser != null)
            {
                ReferralUserName = $"{foundUser.FirstName} {foundUser.LastName}";
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (this.FormData.Password != this.FormData.RepeatPassword)
            {
                this.FormData.Message = "Passwords don't match!";
                return Page();
            }

            try
            {
                var userIsCreated = this._userManager.AddUser(
                    new CreateUserDto(this.FormData.FirstName,
                        this.FormData.LastName,
                        this.FormData.Phone,
                        this.FormData.Email,
                        this.FormData.Password,
                        this.FormData.RepeatPassword,
                        1, FormData.ReferralUserId.HasValue ? 100 : 0, true));

                if (!userIsCreated)
                {
                    throw new ArgumentException("User with that email already exists!");
                    return Page();
                }
            }
            catch (ArgumentException ex)
            {
                this.FormData.Message = ex.Message;
                return Page();
            }

            if (FormData.ReferralUserId.HasValue)
            {
                this._userManager.AddReferralPoints(FormData.ReferralUserId.Value, 100);
            }

            var loggedUser = this._userManager.Login(this.FormData.Email, this.FormData.Password, false);

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
            else
            {
                this.FormData.Message = "Something went wrong, please try again!";
                return Page();
            }
        }
    }
}
