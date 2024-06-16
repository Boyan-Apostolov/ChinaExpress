using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public CartModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }

        public Order Order { get; set; }
        public bool IsNewOrder { get; set; }
        public void OnGet(int? id)
        {
            this.IsNewOrder = id == null;

            this.Order = this.IsNewOrder
                ? _ordersManager.GetOrCreateUserDraftOrder(int.Parse(User.FindFirst("Id").Value))
                : _ordersManager.GetOrder(id.Value);
        }
    }
}
