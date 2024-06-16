
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChinaExpress.Extensions;

namespace ChinaExpress.Web.Pages
{
    public class IndexModel : PageModel
    {
        private IProductsManager _productsManager;
        private readonly ICategoryManager _categoryManager;

        public ICollection<ProductCardDto> ProductCards { get; set; }
        public ICollection<CategoryCard> CategoryCards { get; set; }
        public IndexModel(IProductsManager productsManager, ICategoryManager categoryManager)
        {
            _productsManager = productsManager;
            _categoryManager = categoryManager;
            this.ProductCards = new List<ProductCardDto>();
            this.CategoryCards = new List<CategoryCard>();
        }

        public async Task OnGet()
        {
            foreach (var p in this._productsManager.GetRandomProducts(4))
            {
                this.ProductCards.Add(new ProductCardDto()
                {
                    Id = p.ProductId,
                    Name = p.Name,
                    PhotoUrl = p.PhotoUrl,
                    Price = $"$ {p.GetPrice():f2}",
                    Rating = p.Rating,
                    Description = p.Description.Substring(0, p.Description.Length > 50 ? 50 : p.Description.Length)
                });
            }

            foreach (var category in _categoryManager.GetAllCategories())
            {
                CategoryCards.Add(new CategoryCard()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImgUrl = await APIHelper.GetRandomPhoto(category.Name.ToLower())
                });
            }

            ;
        }
    }
}
