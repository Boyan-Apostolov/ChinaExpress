using ChinaExpress.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    public class CouponGameModel : PageModel
    {
        private readonly IDiscountManager _discountManager;

        public CouponGameModel(IDiscountManager discountManager)
        {
            _discountManager = discountManager;
            this.Codes = new List<string>();
        }

        public List<string> Codes { get; set; }
        public void OnGet()
        {
            this.Codes = _discountManager
                .GetAllDiscountStrategies(true)
                .Select(x => x.Code)
                .ToList();
        }
    }
}
