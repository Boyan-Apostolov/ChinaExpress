using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [Authorize]
    public class MyOrdersModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public MyOrdersModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }

        public ICollection<Order> Orders { get; set; }
        public void OnGet()
        {
            this.Orders = this._ordersManager.GetUserOrders(int.Parse(User.FindFirst("Id").Value));
        }
    }
}
