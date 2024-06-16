using System.Text;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    public class ProductModel : PageModel
    {
        public const string IPDataKey = "20426234f75dd6aeafcc498fa3839229dfc9ed6953f42aedb4fcfb41";
        private readonly IProductsManager _productsManager;

        public ProductModel(IProductsManager productsManager)
        {
            _productsManager = productsManager;
            this.ComboBoxItems = new List<Product>();
        }

        public Product Product { get; set; }
        public ICollection<Product> ComboBoxItems { get; set; }
        public IActionResult OnGet(int? id)
        {
            this.Product = this._productsManager.GetProduct(id.Value);

            if (this.Product == null) return RedirectToPage(nameof(Index));

            var combobox = _productsManager.GetComboBoxByProductId(id.Value);
            if (combobox != null)
            {
                this.ComboBoxItems = this._productsManager.GetComboBoxItems(combobox.ItemId);
            }
           
            var userIdClaim = User.FindFirst("Id")?.Value ?? null;
            if (userIdClaim != null)
            {
                Product.IncreaseViews(int.Parse(userIdClaim));
            }

            return Page();
        }

        public string GetStars(double productRating)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= Math.Floor(productRating); i++)
            {
                sb.Append(" <i class='fa-solid fa-star'></i>");
            }

            return sb.ToString().Trim();
        }
    }
}
