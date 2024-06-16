using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ChinaExpress.Web.Pages
{
    [IgnoreAntiforgeryToken]
    public class ChangeCartItemQuantityModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public ChangeCartItemQuantityModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var dto = JsonSerializer.Deserialize<OrderItemActionDto>(Request.Form.Keys.First());

            var userOrder = this._ordersManager.GetOrCreateUserDraftOrder(int.Parse(User.FindFirst("Id").Value));

            if (dto.Quantity == 0)
            {
                userOrder.DeleteOrderItem(dto.ProductId);
            }
            else
            {
                userOrder.ChangeItemQuantiy(dto.ProductId, dto.Quantity);
            }

            return new JsonResult(new { status = "success" });
        }
    }
}
