using System.Text.Json;
using AutoMapper;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages.Shared
{
    public class ProductCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ProductCardDto dto)
        {
            return View(dto);
        }
    }
}