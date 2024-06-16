using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Tests
{
    [TestClass]
    public class ProductManagerTests : BaseTestClass
    {
        private const string ValidName = "test-name";
        private const string ValidDescription = "test-description";
        private const string ValidImgUrl = "test-image";
        private Category ValidCategory = new Category(1, "test", 1);
        private const decimal ValidPrice = 5m;
        private const int ValidQuantity = 5;
        private IDiscountStrategy ValidDiscountStrategy = new FixedDiscountStrategy(1, 1, 1, "F#123");
        public ProductManagerTests()
        {
        }
        #region Entity Data Validation Test
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_Invalid_ThrowsArgumentException()
        {
            new SingleItemDto(
                0,
                0,
                null,
                ValidImgUrl,
                ValidCategory,
                ValidDescription,
                ValidPrice,
                ValidQuantity);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PhotoUrl_Invalid_ThrowsArgumentException()
        {
            new SingleItemDto(
                0,
                0,
                ValidName,
                null,
                ValidCategory,
                ValidDescription,
                ValidPrice,
                ValidQuantity);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Category_Invalid_ThrowsArgumentException()
        {
            new SingleItemDto(
                0,
                0,
                ValidName,
                ValidImgUrl,
                null,
                ValidDescription,
                ValidPrice,
                ValidQuantity);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Description_Invalid_ThrowsArgumentException()
        {
            new SingleItemDto(
                0,
                0,
                ValidName,
                ValidImgUrl,
                ValidCategory,
                null,
                ValidPrice,
                ValidQuantity);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Price_Invalid_ThrowsArgumentException()
        {
            new SingleItemDto(
                0,
                0,
                ValidName,
                ValidImgUrl,
                ValidCategory,
                ValidDescription,
                -1,
                ValidQuantity);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Quantity_Invalid_ThrowsArgumentException()
        {
            new SingleItemDto(
                0,
                0,
                ValidName,
                ValidImgUrl,
                ValidCategory,
                ValidDescription,
                ValidPrice,
                -1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DiscountStrategy_Invalid_ThrowsArgumentException()
        {
            new ComboBoxDto(
                0,
                0,
                ValidName,
                ValidImgUrl,
                ValidCategory,
                ValidDescription,
                null,
                null);
        }
        #endregion

        [TestMethod]
        public void AddProductShouldAddTheCorrectSingleItem()
        {
            var items = ProductsManager.GetAllProducts();

            Assert.AreEqual(0, items.Count);

            AddTestSingleItem("test");

            items = ProductsManager.GetAllProducts();

            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("test", items.First().Name);

        }

        [TestMethod]
        public void AddProductShouldAddTheCorrectComboBOx()
        {
            var items = ProductsManager.GetAllProducts();

            Assert.AreEqual(0, items.Count);

            AddTestComboBox();

            var comboBox = ProductsManager.GetComboBoxByProductId(3);

            Assert.AreEqual("test-box", comboBox.Name);

        }

        [TestMethod]
        public void GetComboBoxItemsShouldReturnCorrectItems()
        {
            AddTestComboBox();

            var comboBoxItems = this.ProductsManager.GetComboBoxItems(1).ToArray();

            Assert.AreEqual(2, comboBoxItems.Length);
            Assert.AreEqual("cb-i-1", comboBoxItems[0].Name);
            Assert.AreEqual("description", comboBoxItems[1].Description);

        }

        [TestMethod]
        public void GetProductShouldReturnItIfItExist()
        {
            AddTestSingleItem("test");

            var product = this.ProductsManager.GetProduct(1);

            Assert.IsNotNull(product);
            Assert.AreEqual("test", product.Name);
        }


        [TestMethod]
        public void GetProductShouldReturnNullItIfItNotExist()
        {
            var product = this.ProductsManager.GetProduct(1);

            Assert.IsNull(product);
        }

        [TestMethod]
        public void GetRandomProductsShouldReturnCorrectAmoutOfProduts()
        {
            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");
            AddTestSingleItem("test4");
            AddTestComboBox();
            AddTestComboBox();
            var products = this.ProductsManager.GetRandomProducts(4);

            Assert.AreEqual(4, products.Count);
        }

        [TestMethod]
        public void GetRandomProductsWwithExcludedProdctsShouldReturnCorrectProduts()
        {
            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");

            var products = this.ProductsManager
                .GetRandomProducts(3, excludedProductIds: new List<int>() { 1, 2 });

            Assert.AreEqual(1, products.Count);
            Assert.IsTrue(!products.Any(p => p.ProductId == 1 || p.ProductId == 2));
        }

        [TestMethod]
        public void GetAllProdctsByKeywordShoulReturnTheCorrectProducts()
        {
            AddTestSingleItem("test 1");
            AddTestSingleItem("test 2");
            AddTestSingleItem("something 3");

            var products = this.ProductsManager
                .GetAllProducts(keyword: "test");

            Assert.AreEqual(2, products.Count);
            Assert.IsTrue(products.All(p => p.Name != "something 3"));
        }

        [TestMethod]
        public void GetAllProdctsByExcludedIdsShoulReturnTheCorrectProducts()
        {
            AddTestSingleItem("test 1");
            AddTestSingleItem("test 2");
            AddTestSingleItem("something 3");

            var products = this.ProductsManager
                .GetAllProducts(excludedProductIds: new List<int>() { 1, 2 });

            Assert.AreEqual(1, products.Count);
            Assert.IsTrue(!products.All(p => p.Name.Contains("test")));
        }

        [TestMethod]
        public void GetAllProdctsByCategoriesShoulReturnTheCorrectProducts()
        {
            AddTestSingleItem("test 1");
            AddTestSingleItem("something 2", true);
            AddTestSingleItem("test 3");

            var products = this.ProductsManager
                .GetAllProducts(categories: new List<int>() { 1 });

            Assert.AreEqual(2, products.Count);
            Assert.IsTrue(products.All(p => p.Name.Contains("test")));
        }

        [TestMethod]
        public void GetAllShouldReturnCorrectItems()
        {
            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");
            AddTestSingleItem("test4");
            AddTestComboBox();
            var products = this.ProductsManager.GetAllProducts().ToArray();

            Assert.AreEqual(7, products.Length); // 4 items, 2 new items from combo box + combo box
            Assert.AreEqual("test1", products[0].Name);
            Assert.AreEqual("test2", products[1].Name);
            Assert.AreEqual("test3", products[2].Name);
            Assert.AreEqual("test4", products[3].Name);
        }

        [TestMethod]
        public void DeleteShouldRemoveTheProductFromTheDb()
        {
            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");

            var items = ProductsManager.GetAllProducts();
            Assert.AreEqual(3, items.Count);

            ProductsManager.DeleteProduct(2);

            Assert.IsNull(ProductsManager.GetProduct(2));

            items = ProductsManager.GetAllProducts();
            Assert.AreEqual(2, items.Count);
        }

        [TestMethod]
        public void UpdateShouldUpdateTheProductData()
        {
            AddTestSingleItem("test1");

            var product = ProductsManager.GetProduct(1);

            Assert.AreEqual("test1", product.Name);


            ProductsManager.UpdateProduct(
                new SingleItemDto(1, 1, "updated-name", "test", CategoryManager.GetAllCategories().First(), "test", 2, 10));

            product = ProductsManager.GetProduct(1);
            Assert.AreEqual("updated-name", product.Name);
        }

        [TestMethod]
        public void QuantityUpdateShouldUpdateProductQuantity()
        {
            AddTestSingleItem("test1");

            var product = ProductsManager.GetProduct(1);

            Assert.AreEqual(5, product.GetQuantity());

            ProductsManager.UpdateSingleProductQuantity(null, 1, 10);

            product = ProductsManager.GetProduct(1);

            Assert.AreEqual(10, product.GetQuantity());
        }

        [TestMethod]
        public void GetViewsReturnsTheCorrctAmountOfViews()
        {
            AddTestSingleItem("test1");

            UserManager.AddUser(new CreateUserDto("test", "test", "0884203364", "test@test.com", "test", "test", 1, 0, true));

            Assert.AreEqual(0, ProductsManager.GetProductViews(1).Count);

            var product = ProductsManager.GetProduct(1);
            product.IncreaseViews(1);
            product.IncreaseViews(1);

            Assert.AreEqual(2, ProductsManager.GetProductViews(1).Count);
        }

        [TestMethod]
        public void GetMostPopularShouldReturnTheCorrectProducts()
        {
            AddTestSingleItem("test1");
            AddTestSingleItem("test2");

            UserManager.AddUser(
                new CreateUserDto("test", "test", "0884203364", "test@test.com", "test", "test", 1, 0, true)
                );

            Assert.AreEqual(0, ProductsManager.GetProductViews(1).Count);

            var product1 = ProductsManager.GetProduct(1);
            var product2 = ProductsManager.GetProduct(2);
            product1.IncreaseViews(1);
            product1.IncreaseViews(1);

            product2.IncreaseViews(1);

            var mostPopularItems = ProductsManager.GetMostPopularItems();
            Assert.AreEqual("test1", mostPopularItems[0].Key);
            Assert.AreEqual(2, mostPopularItems[0].Value);
        }

        [TestMethod]
        public void CountProductsReturnsCorrectAmounOfProdct()
        {
            var productsCount = ProductsManager.CountProducts(null, null, null)
                .GetAwaiter().GetResult();
            Assert.AreEqual(0, productsCount);

            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");

            productsCount = ProductsManager.CountProducts(null, null, null)
                .GetAwaiter().GetResult();
            Assert.AreEqual(3, productsCount);

            productsCount = ProductsManager.CountProducts("test3", null, null)
                .GetAwaiter().GetResult();
            Assert.AreEqual(1, productsCount);

        }


        [TestMethod]
        public void RecommendItemsShouldNotRecommendAnythngWitoutHavngTurnOnTheRandomFeature()
        {
            this.UserManager.AddUser(new CreateUserDto("john", "test", "0889898834", "j@smith.com", "123", "123", 1, 0, false));

            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var recommendedProducts = this.ProductsManager.GenerateRecommendedProducts(1, includeRandomReccomendations: false);

            Assert.AreEqual(0, recommendedProducts.Count);
        }

        [TestMethod]
        public void RecommendItemsShouldReturnRandomItemsWhenNoDataIsPresentForTheUser()
        {
            this.UserManager.AddUser(new CreateUserDto("john", "test", "0889898834", "j@smith.com", "123", "123", 1, 0, false));
            AddTestSingleItem("test1");
            AddTestSingleItem("test2");
            AddTestSingleItem("test3");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var recommendedProducts = this.ProductsManager.GenerateRecommendedProducts(1, includeRandomReccomendations: true).ToList();

            Assert.AreEqual(3, recommendedProducts.Count);

            CollectionAssert.Contains(recommendedProducts, ProductsManager.GetProduct(1));
            CollectionAssert.Contains(recommendedProducts, ProductsManager.GetProduct(2));
            CollectionAssert.Contains(recommendedProducts, ProductsManager.GetProduct(3));
        }

        //test with similar orders
        //test without similar order

        private void SeedUsersForRecommendation()
        {
            this.UserManager.AddUser(new CreateUserDto("Bob", "bib", "0889898834", "bob@smith.com", "123", "123", 1, 0, false));

            this.UserManager.AddUser(new CreateUserDto("Alice", "bib", "0889898834", "alice@smith.com", "123", "123", 1, 0, false));

            this.UserManager.AddUser(new CreateUserDto("John", "bib", "0889898834", "john@smith.com", "123", "123", 1, 0, false));
        }

        private void SeedProductsForRecommendation()
        {
            AddTestSingleItem("IPhone");
            AddTestSingleItem("Vaccuum");
            AddTestSingleItem("Watch");
            AddTestSingleItem("Laptop");
            AddTestSingleItem("Cat");
            AddTestSingleItem("Bike");
        }

        private void SeedOrdersForRecommendations(bool includeSimilarOrderWithJohn)
        {
            var bobsOrder = this.OrdersManager.GetOrCreateUserDraftOrder(1);
            bobsOrder.AddOrderItem(3, 10, null); //Watch
            bobsOrder.AddOrderItem(4, 10, null); // Laptop


            var johnsOrder = this.OrdersManager.GetOrCreateUserDraftOrder(2);
            johnsOrder.AddOrderItem(2, 10, null); // Vaccuum
            johnsOrder.AddOrderItem(1, 10, null);//Iphone

            var aliceOrder = this.OrdersManager.GetOrCreateUserDraftOrder(3);
            aliceOrder.AddOrderItem(5, 10, null); //cat
            aliceOrder.AddOrderItem(2, 10, null); //vaccuum
            aliceOrder.AddOrderItem(6, 10, null); // bike

            var similarOrder = (includeSimilarOrderWithJohn ? johnsOrder : aliceOrder);

            similarOrder.AddOrderItem(3, 10, null); //Watch
            similarOrder.AddOrderItem(4, 10, null); //Laptop
        }

        private void SeedProductViewsForRecommendations()
        {
            var productWatch = ProductsManager.GetProduct(3);
            productWatch.IncreaseViews(1);
            productWatch.IncreaseViews(1);

            var productLaptop = ProductsManager.GetProduct(4);
            productLaptop.IncreaseViews(1);
            productLaptop.IncreaseViews(1);

            var productBike = ProductsManager.GetProduct(6);
            productBike.IncreaseViews(1);
            productBike.IncreaseViews(1);

            var productIphone = ProductsManager.GetProduct(1);
            productIphone.IncreaseViews(1);
            productIphone.IncreaseViews(1);
            productIphone.IncreaseViews(1);
            productIphone.IncreaseViews(1);
        }

        [TestMethod]
        public void RecommendItemsShouldGiveTheCorrectRecommendationsBasedOnSimilarOrders()
        {
            SeedUsersForRecommendation();

            SeedProductsForRecommendation();

            SeedOrdersForRecommendations(true);

            SeedProductViewsForRecommendations();

            var recommenedItems = ProductsManager.GenerateRecommendedProducts(1, false);

            var recommendedItemIds = recommenedItems.Select(p => p.ProductId).ToList();
            var expectedItemIds = new List<int>() { 1, 2, 6, 5 }; //IPhone, Vaccuum, Bike, Cat

            CollectionAssert.AreEqual(expectedItemIds, recommendedItemIds);

        }


        [TestMethod]
        public void RecommendItemsShouldGiveTheCorrectRecommendationsWithSimilarOrdersWithIncludedRandomItes()
        {
            SeedUsersForRecommendation();

            SeedProductsForRecommendation();

            AddTestSingleItem("test-item-1");
            AddTestSingleItem("test-item-2");
            AddTestSingleItem("test-item-3");
            AddTestSingleItem("test-item-4");

            SeedOrdersForRecommendations(true);

            SeedProductViewsForRecommendations();

            var recommenedItems = ProductsManager.GenerateRecommendedProducts(1, true);

            var recommendedItemIds = recommenedItems.Select(p => p.ProductId).ToList();
            var expectedItemIds = new List<int>() { 1, 2, 6 }; //IPhone, Vaccuum, Bike
            var remaningItemIds = new List<int>() { 3, 4, 5, 7, 8, 9, 10 }; //IPhone, Vaccuum, Bike

            Assert.AreEqual(10, recommendedItemIds.Count);

            //The first three items should be the actual recommendations without random items
            CollectionAssert.AreEqual(recommendedItemIds.Take(3).ToList(), expectedItemIds);

            var doActualItemsContainRemainingNotExpectedItemIds =
                recommendedItemIds.Except(expectedItemIds).All(x => remaningItemIds.Contains(x));
            Assert.IsTrue(doActualItemsContainRemainingNotExpectedItemIds);
        }

        [TestMethod]
        public void RecommendItemsShouldRetunTheCorrectAmountOfItems()
        {
            SeedUsersForRecommendation();

            SeedProductsForRecommendation();

            AddTestSingleItem("test-item-1");
            AddTestSingleItem("test-item-2");
            AddTestSingleItem("test-item-3");
            AddTestSingleItem("test-item-4");
            AddTestSingleItem("test-item-5");
            AddTestSingleItem("test-item-6");
            AddTestSingleItem("test-item-7");
            AddTestSingleItem("test-item-8");
            AddTestSingleItem("test-item-9");

            SeedOrdersForRecommendations(true);

            SeedProductViewsForRecommendations();

            var recommenedItems = ProductsManager.GenerateRecommendedProducts(1, true);

            var recommendedItemIds = recommenedItems.Select(p => p.ProductId).ToList();

            Assert.AreEqual(12, recommendedItemIds.Count);
        }

        [TestMethod]
        public void RecommendItemsShouldGiveTheCorrectRecommendationsWithoutSimilarOrders()
        {
            SeedUsersForRecommendation();

            SeedProductsForRecommendation();

            SeedOrdersForRecommendations(false);

            SeedProductViewsForRecommendations();

            var recommenedItems = ProductsManager.GenerateRecommendedProducts(1, false);

            var recommendedItemIds = recommenedItems.Select(p => p.ProductId).ToList();
            var expectedItemIds = new List<int>() { 6, 5, 2, 1 }; // Bike, Cat, Vaccuum, IPhone

            CollectionAssert.AreEqual(expectedItemIds, recommendedItemIds);
        }
    }
}
