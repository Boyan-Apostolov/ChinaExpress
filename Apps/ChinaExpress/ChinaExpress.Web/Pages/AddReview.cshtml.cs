using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [Authorize]
    public class AddReviewModel : PageModel
    {
        private readonly IOrdersManager _ordersManager;

        public AddReviewModel(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
            ReviewInfo = new ReviewInfoDto();
        }

        [BindProperty]
        public ReviewInfoDto ReviewInfo { get; set; }
        public IActionResult OnGet(int? orderItemId = null)
        {
            if (!orderItemId.HasValue) return RedirectToPage(nameof(Index));

            this.ReviewInfo.OrderItemId = orderItemId.Value;
            this.ReviewInfo.UserId = int.Parse(User.FindFirst("Id").Value);

            return Page();
        }

        public IActionResult OnPost()
        {
            this._ordersManager.AddReview(ReviewInfo.Stars, ReviewInfo.Description, ReviewInfo.OrderItemId, ReviewInfo.UserId);
            return Redirect("/MyOrders");
        }
    }
}
