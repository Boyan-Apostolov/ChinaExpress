using System.Diagnostics;
using ChinaExpress.DTOs;
using ChinaExpress.Extensions;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinaExpress.Web.Pages
{
    [Authorize(Roles = "Employee")]
    public class StatisticsModel : PageModel
    {
        private const string GeneralStatisticsCacheKey = "GeneralStatistics";
        private readonly IUserManager _userManager;
        private readonly IProductsManager _productsManager;
        private readonly IOrdersManager _ordersManager;
        private readonly CacheHelper _cacheHelper;

        public StatisticsModel(IUserManager userManager, IProductsManager productsManager, IOrdersManager ordersManager, CacheHelper cacheHelper)
        {
            _userManager = userManager;
            _productsManager = productsManager;
            _ordersManager = ordersManager;
            _cacheHelper = cacheHelper;
        }

        public int UsersCount { get; set; }
        public int ProductsCount { get; set; }
        public int OrdersCount { get; set; }
        public int ReviewsCount { get; set; }
        public int ViewsCount { get; set; }
        public int TotalProfit { get; set; }

        public List<KeyValuePair<string, int>> MostPopularItems { get; set; }
        public List<KeyValuePair<string, int>> SalesPerCatgory { get; set; }
        public List<KeyValuePair<string, decimal>> LastTenOrderRecords { get; set; }

        public bool ShouldIgnoreCache { get; set; }
        public async Task OnGet(bool shouldIgnoreCache)
        {
            this.ShouldIgnoreCache = shouldIgnoreCache;

            var sp = new Stopwatch();
            sp.Start();

            await LoadGeneralStatistics();

            var hasCachedData = LoadGraphicalStatisticsData();

            sp.Stop();
            Console.WriteLine($"Getting statistics.... {sp.Elapsed.Milliseconds} ms, {hasCachedData} cache");
        }

        private bool LoadGraphicalStatisticsData()
        {
            var cacheKey = !this.ShouldIgnoreCache
                ? $"{UsersCount}#{ProductsCount}#{OrdersCount}#{ReviewsCount}#{ViewsCount}#{TotalProfit}"
                : string.Empty;

            var cachedData = (CachedStatisticsDto)this._cacheHelper.GetValue(cacheKey);
            var hasCachedData = cachedData != null;

            this.MostPopularItems = !hasCachedData
                ? this._productsManager.GetMostPopularItems()
                : cachedData.MostPopularItems;

            this.SalesPerCatgory = !hasCachedData
                ? this._ordersManager.GetSalesPerCategory()
                : cachedData.SalesPerCategory;

            this.LastTenOrderRecords = !hasCachedData
                ? this._ordersManager.GetLastTenOrderRecords()
                : cachedData.LastTenOrderRecords;

            if (!hasCachedData)
            {
                this._cacheHelper.SetValue(cacheKey, new CachedStatisticsDto()
                {
                    MostPopularItems = MostPopularItems,
                    SalesPerCategory = SalesPerCatgory,
                    LastTenOrderRecords = LastTenOrderRecords
                }, TimeSpan.FromMinutes(5));
            }

            return hasCachedData;
        }

        private async Task LoadGeneralStatistics()
        {
            var cachedGeneralStatistics = (List<int>)this._cacheHelper.GetValue(GeneralStatisticsCacheKey);
            if (cachedGeneralStatistics != null && !this.ShouldIgnoreCache)
            {
                this.UsersCount = cachedGeneralStatistics[0];
                this.ProductsCount = cachedGeneralStatistics[1];
                this.OrdersCount = cachedGeneralStatistics[2];
                this.ReviewsCount = cachedGeneralStatistics[3];
                this.ViewsCount = cachedGeneralStatistics[4];
                this.TotalProfit = cachedGeneralStatistics[5];
            }
            else
            {
                this.UsersCount = await this._userManager.GetUsersCount();
                this.ProductsCount = await this._productsManager.CountProducts(string.Empty, null, null);
                this.OrdersCount = await this._ordersManager.GetOrdersCount();
                this.ReviewsCount = await this._ordersManager.GetReviewsCount();
                this.ViewsCount = await this._productsManager.GetViewsCount();
                this.TotalProfit = (int)this._ordersManager.GetTotalProfit();

                this._cacheHelper.SetValue(GeneralStatisticsCacheKey, new List<int>()
                {
                    this.UsersCount,
                    this.ProductsCount,
                    this.OrdersCount,
                    this.ReviewsCount,
                    this.ViewsCount,
                    this.TotalProfit,
                }, TimeSpan.FromMinutes(1));
            }
        }
    }
}
