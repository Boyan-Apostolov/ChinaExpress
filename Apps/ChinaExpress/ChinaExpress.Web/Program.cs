using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DataAccess.ApplicationHelpers;
using ChinaExpress.Extensions;
using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.InternalHelpersSimpleModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddMemoryCache();
builder.Services.AddSingleton<CacheHelper>();

builder.Services.AddSingleton<IUsersDbHelper, UsersDbHelper>();
builder.Services.AddSingleton<IProductsDbHelper, ProductsDbHelper>();
builder.Services.AddSingleton<ICategoriesDbHelper, CategoriesDbHelper>();
builder.Services.AddSingleton<IOrdersDbHelper, OrdersDbHelper>();
builder.Services.AddSingleton<IDiscountStrategiesDbHelper, DiscountStrategiesDbHelper>();

builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IProductFactory, ProductFactory>();
builder.Services.AddTransient<IProductsManager, ProductsManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IOrdersManager, OrdersManager>();
builder.Services.AddTransient<IDiscountManager, DiscountManager>();

builder.Services.AddTransient<IDiscountStrategiesManagementHelper, DiscountStrategiesManagementHelper>();
builder.Services.AddTransient<IProductManagementHelper, ProductManagementHelper>();
builder.Services.AddTransient<IOrderManagementHelper, OrderManagementHelper>();
builder.Services.AddTransient<IInternalProductManagementHelper, InternalProductManagementHelper>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/AccessDenied");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });

app.Run();
