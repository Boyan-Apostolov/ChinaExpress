using ChinaExpress.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductsManager _productsManager;
        private readonly ICategoryManager _categoryManager;

        public ProductsModel(IProductsManager productsManager, ICategoryManager categoryManager)
        {
            _productsManager = productsManager;
            _categoryManager = categoryManager;
            Products = new List<ProductCardDto>();
            Category = new List<int>(); // Initialize the collections here
            Rating = new List<int>();
            Sort = "ASC";
        }

        [BindProperty(SupportsGet = true)]
        public string? Sort { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<int> Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Keyword { get; set; } 
        
        [BindProperty(SupportsGet = true)]
        public bool RecommendationMode { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<int> Rating { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 8;
        public int TotalPages { get; set; }

        public ICollection<ProductCardDto> Products { get; set; }
        public ICollection<Category> AvailableCategories { get; set; }

        public void OnGet()
        {
            ICollection<Product> products;
            if (!RecommendationMode)
            {
                var totalItemCount = _productsManager.CountProducts(Keyword, Category, Rating).GetAwaiter().GetResult();
                TotalPages = (int)Math.Ceiling(totalItemCount / (double)PageSize);

                products = _productsManager
                    .GetAllProducts( Keyword, null, Category, Rating, Sort, CurrentPage - 1, PageSize);
            }
            else
            {
                products = _productsManager
                    .GenerateRecommendedProducts(int.Parse(User.FindFirst("Id").Value), true);
            }

            foreach (var p in products)
            {
                Products.Add(new ProductCardDto()
                {
                    Id = p.ProductId,
                    Name = p.Name,
                    PhotoUrl = p.PhotoUrl,
                    Price = $"$ {p.GetPrice():f2}",
                    Rating = p.Rating,
                    Description = p.Description.Substring(0, p.Description.Length > 50 ? 50 : p.Description.Length)
                });
            }

            AvailableCategories = _categoryManager.GetAllCategories();
        }
    }
}
