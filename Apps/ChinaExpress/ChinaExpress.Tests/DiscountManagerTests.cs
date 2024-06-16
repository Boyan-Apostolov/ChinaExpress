using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DTOs;
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Tests
{
    [TestClass]
    public class DiscountManagerTests : BaseTestClass
    {
        private const string ValidCode = "John";
        private const int ValidUses = 1;
        private const int ValidType = 1;
        private const int ValidValue = 1;


        #region Entity Data Validation Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Value_Invalid_ThrowsArgumentException()
        {
            new CreateDiscountDto(
                -1,
                ValidCode,
                ValidType,
                ValidUses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Code_Invalid_ThrowsArgumentException()
        {
            new CreateDiscountDto(
                ValidValue,
                null,
                ValidType,
                ValidUses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Type_Invalid_ThrowsArgumentException()
        {
            new CreateDiscountDto(
                ValidValue,
                ValidCode,
                -1,
                ValidUses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Uss_Invalid_ThrowsArgumentException()
        {
            new CreateDiscountDto(
                ValidValue,
                ValidCode,
                ValidType,
                -1);
        }

        #endregion

        [TestMethod]
        public void CreateDiscountStrategyShouldAddTheDiscount()
        {
            var strategiesCount = this.DiscountsManager.GetAllDiscountStrategies().Count;
            Assert.AreEqual(0, strategiesCount);

            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(20, "test", 1, 5));

            strategiesCount = this.DiscountsManager.GetAllDiscountStrategies().Count;
            Assert.AreEqual(1, strategiesCount);
        }

        [TestMethod]
        public void GetAllDiscuntShouldReturnCorrectDiscounts()
        {
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(20, "test", 0, 5));
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(30, "test2", 1, 5));

            var strategies = this.DiscountsManager.GetAllDiscountStrategies().ToList();

            Assert.AreEqual("F#test", strategies[0].Code);
            Assert.AreEqual("P#test2", strategies[1].Code);
        }

        [TestMethod]
        public void GetDiscountStrategyByIdShouldReturnTheCorrectStrategy()
        {
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(20, "test", 1, 5));
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(30, "test2", 1, 5));

            var strategy = this.DiscountsManager.GetDiscountStrategy(1);

            Assert.AreEqual("P#test", strategy.Code);
            Assert.AreEqual(5, strategy.RemainingUses);
        }

        [TestMethod]
        public void GetDiscountStrategyByIdShouldReturnTheNullWithIncorrectId()
        {
            var strategy = this.DiscountsManager.GetDiscountStrategy(999);

            Assert.IsNull(strategy);
        }

        [TestMethod]
        public void GetDiscountStrategyByCodeShouldReturnTheCorrectStrategy()
        {
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(20, "test", 1, 5));
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(30, "test2", 1, 5));

            var strategy = this.DiscountsManager.GetDiscountStrategy("P#test");

            Assert.AreEqual("P#test", strategy.Code);
            Assert.AreEqual(5, strategy.RemainingUses);
        }

        [TestMethod]
        public void GetDiscountStrategyByIdShouldReturnTheNullWithIncorrectCode()
        {
            var strategy = this.DiscountsManager.GetDiscountStrategy("test");

            Assert.IsNull(strategy);
        }

        [TestMethod]
        public void DeleteDiscountShouldRemoveIt()
        {
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(20, "test", 1, 5));
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(30, "test2", 1, 5));

            Assert.AreEqual(2, this.DiscountsManager.GetAllDiscountStrategies().Count);

            this.DiscountsManager.DeleteDiscountStrategy(1);

            Assert.AreEqual(1, this.DiscountsManager.GetAllDiscountStrategies().Count);
            Assert.IsNull(this.DiscountsManager.GetDiscountStrategy(1));
        }

        [TestMethod]
        public void LowerDiscountUsageShouldLowerTheRemainingUses()
        {
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(20, "test", 1, 5));
            this.DiscountsManager.CreateDiscountStrategy(new CreateDiscountDto(30, "test2", 1, 5));

            Assert.AreEqual(5, this.DiscountsManager.GetDiscountStrategy(1).RemainingUses);

            this.DiscountsManager.LowerDiscountStrategyUses(1);

            Assert.AreEqual(4, this.DiscountsManager.GetDiscountStrategy(1).RemainingUses);
        }
    }
}
