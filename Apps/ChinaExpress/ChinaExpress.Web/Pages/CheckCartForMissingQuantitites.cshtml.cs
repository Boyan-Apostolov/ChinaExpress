using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using ChinaExpress.Logic;

namespace ChinaExpress.Web.Pages
{
    [IgnoreAntiforgeryToken]
    public class CheckCartForMissingQuantititesModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;
        private readonly IDiscountManager _discountManager;

        public CheckCartForMissingQuantititesModel(IOrdersManager ordersManager, IDiscountManager discountManager)
        {
            _ordersManager = ordersManager;
            _discountManager = discountManager;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var cartOrder = this._ordersManager.GetOrCreateUserDraftOrder(int.Parse(User.FindFirst("Id").Value));
            foreach (var cartOrderItem in cartOrder.GetOrderItems())
            {
                if (cartOrderItem.Quantity > cartOrderItem.Product.GetQuantity())
                {
                    throw new InvalidOperationException(
                        $"Product {cartOrderItem.Product.Name} has only {cartOrderItem.Product.GetQuantity()} quantities in stock! Please, change your desired quantity!");
                }
            }

            if (cartOrder.DiscountStrategy != null && cartOrder.DiscountStrategy.RemainingUses <= 0)
            {
                this._ordersManager.RemoveDiscount(cartOrder.Id);

                throw new InvalidOperationException("The discount code is no longer valid, please refresh the page!");
            }
            return new JsonResult(new { status = "success" });
        }
    }
}
