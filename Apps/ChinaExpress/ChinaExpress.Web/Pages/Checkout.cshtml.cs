using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using ChinaExpress.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public CheckoutModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
            this.CheckoutDto = new CheckoutDto();
        }

        [BindProperty]
        public CheckoutDto CheckoutDto { get; set; }

        public IActionResult OnGet()
        {
            var cartOrder = _ordersManager.GetOrCreateUserDraftOrder(int.Parse(User.FindFirst("Id").Value));

            this.CheckoutDto.OrderId = cartOrder.Id;
            this.CheckoutDto.TotalItems = cartOrder.GetOrderItems().Count;
            this.CheckoutDto.TotalPrice = cartOrder.GetTotalPrice();

            if (this.CheckoutDto.TotalItems == 0)
            {
                return RedirectToPage(nameof(Index));
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            try
            {
                this._ordersManager.SubmitOrder(this.CheckoutDto.OrderId, this.CheckoutDto.DeliveryAddress);

                var successMessage = "Order was placed successfully! It will be shipped within 3 business days.";
                this.CheckoutDto.ProgramMessage = successMessage;
            
                return Redirect("/MyOrders");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Page();
        }
    }
}
