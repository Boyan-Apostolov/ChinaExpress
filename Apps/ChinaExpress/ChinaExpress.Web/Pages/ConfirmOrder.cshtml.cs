using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;

namespace ChinaExpress.Web.Pages
{
    [IgnoreAntiforgeryToken]
    public class ConfirmOrderModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public ConfirmOrderModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var dto = JsonSerializer.Deserialize<OrderItemActionDto>(Request.Form.Keys.First());

            this._ordersManager.ConfirmOrder(dto.OrderId);

            return new JsonResult(new { status = "success" });
        }
    }
}
