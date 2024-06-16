using ChinaExpress.DataAccess.ApplicationHelpers;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.Logic;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DataAccess.MockingHelpers;
using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.InternalHelpersSimpleModels;
using ChinaExpress.DTOs;
using ChinaExpress.ComplexModelsWithHelperReferences;

namespace ChinaExpress.Tests
{
    public class BaseTestClass
    {
        private IOrdersDbHelper OrdersDbHelper;
        private IUsersDbHelper UsersDbHelper;
        private IProductsDbHelper ProductsDbHelper;
        private ICategoriesDbHelper CategoriesDbHelper;
        private IDiscountStrategiesDbHelper DiscountStrategiesDbHelper;

        public IProductManagementHelper ProductManagementHelper;
        public IInternalProductManagementHelper InternalProductManagementHelper;
        public IDiscountStrategiesManagementHelper DiscountStrategiesManagementHelper;
        public IOrderManagementHelper OrderManagementHelper;

        public IUserManager UserManager;
        public IProductsManager ProductsManager;
        public ICategoryManager CategoryManager;
        public IOrdersManager OrdersManager;
        public IDiscountManager DiscountsManager;
        public IProductFactory ProductFactory;

        public BaseTestClass()
        {
            InternalProductManagementHelper = new InternalProductManagementHelper();
            DiscountStrategiesManagementHelper = new DiscountStrategiesManagementHelper();
            ProductManagementHelper = new ProductManagementHelper(DiscountStrategiesManagementHelper, InternalProductManagementHelper);
            OrderManagementHelper = new OrderManagementHelper(ProductManagementHelper);

            DiscountStrategiesDbHelper = new FakeDiscountStrategiesDbHelper();
            UsersDbHelper = new FakeUserDbHelper();
            ProductsDbHelper = new FakeProductsDbHelper();
            OrdersDbHelper = new FakeOrdersDbHelper();
            CategoriesDbHelper = new FakeCategoryDbHelper();

            this.ProductFactory = new ProductFactory(ProductsDbHelper);


            this.UserManager = new UserManager(UsersDbHelper);
            this.CategoryManager = new CategoryManager(CategoriesDbHelper);
            this.DiscountsManager = new DiscountManager(DiscountStrategiesDbHelper, UserManager);

            ProductsManager = new ProductsManager(ProductsDbHelper, OrdersDbHelper, CategoriesDbHelper);

            this.OrdersManager = new OrdersManager(OrdersDbHelper, ProductsManager, UserManager);
        }
        public void AddTestUser()
        {
            this.UserManager.AddUser(new CreateUserDto("test", "test", "0889746634", "test@test.com", "123123",
                "123123", 1, 0, false));
        }

        public void AddTestSingleItem(string name, bool shouldAddTwoCategory = false)
        {
            var cateory = CategoryManager.GetAllCategories().First();
            if (shouldAddTwoCategory)
            {
                this.CategoryManager.CreateCategory(new CreateCategoryDto("new catgr"), null);
                cateory = CategoryManager.GetAllCategories().Last();
            }

            this.ProductsManager.AddProduct(new SingleItemDto(0, 0, name, "photo", cateory, "description", 5m, 5));
        }

        public void AddTestComboBox()
        {
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(5, "test", 1, 5))
                .GetAwaiter().GetResult();

            AddTestSingleItem("cb-i-1");
            AddTestSingleItem("db-i-2");
            var singleItems = this.ProductsManager
                .GetAllProducts()
                .Where(p => p.GetType() == typeof(SingleItem))
                .ToList();

            var comboBxDto = new ComboBoxDto(0, 0, "test-box", "photo", CategoryManager.GetAllCategories().First(), "description",
                this.DiscountsManager.GetAllDiscountStrategies().First(),
                singleItems);

            this.ProductsManager.AddProduct(comboBxDto);
        }
    }
}
