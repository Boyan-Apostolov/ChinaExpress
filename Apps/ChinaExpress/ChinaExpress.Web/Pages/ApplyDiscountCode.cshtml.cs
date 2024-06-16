using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;

namespace ChinaExpress.Web.Pages
{
    [IgnoreAntiforgeryToken]
    public class ApplyDiscountCodeModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;
        private readonly IDiscountManager _discountManager;

        public ApplyDiscountCodeModel(IOrdersManager ordersManager, IDiscountManager discountManager)
        {
            _ordersManager = ordersManager;
            _discountManager = discountManager;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var dto = JsonSerializer.Deserialize<ApplyDiscountCodeDto>(Request.Form.Keys.First());

            var foundDiscount = _discountManager.GetDiscountStrategy(dto.DiscountCode);
            if (foundDiscount == null || foundDiscount.RemainingUses == 0)
            {
                throw new InvalidOperationException("Discount is invalid or expired! Please, use another code!");
            }

            _ordersManager.ApplyDiscount(dto.OrderId, foundDiscount);
            _discountManager.LowerDiscountStrategyUses(foundDiscount.Id);

            return new JsonResult(new { status = "success" });
            
        }
    }
}
