using System.Text.Json;
using AutoMapper;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [IgnoreAntiforgeryToken]
    public class AddItemToCartModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public AddItemToCartModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var dto = JsonSerializer.Deserialize<OrderItemActionDto>(Request.Form.Keys.First());
            dto.UserId = int.Parse(User.FindFirst("Id").Value);

            var userDraftOrder = this._ordersManager.GetOrCreateUserDraftOrder(dto.UserId);
            var productAlreadyAdded = userDraftOrder.GetOrderItems().Any(oi => oi.Product.ProductId == dto.ProductId);

            if (productAlreadyAdded)
            {
                throw new InvalidOperationException("Product already added to cart! Please check cart for details!");
            }

            userDraftOrder.AddOrderItem(dto.ProductId, dto.Quantity, dto.SelectedTags);

            return new JsonResult(new { status = "success", responseText = "Product added successfully to cart!" });
        }
    }
}
