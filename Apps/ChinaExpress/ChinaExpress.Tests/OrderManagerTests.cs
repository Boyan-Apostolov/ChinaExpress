using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Tests
{
    [TestClass]
    public class OrderManagerTests : BaseTestClass
    {

        [TestMethod]
        public void GetOrCreateUserDraftOrderShouldCreateNewOrderWhenTheUserDoesNotHaveOrders()
        {
            AddTestUser();

            var userOrders = this.OrdersManager.GetUserOrders(1);

            Assert.AreEqual(0, userOrders.Count);
        }

        [TestMethod]
        public void GetOrCreateUserDraftOrderShouldReturnTheOrderWhenExisting()
        {
            AddTestUser();

            var userOrders = this.OrdersManager.GetUserOrders(1);
            Assert.AreEqual(0, userOrders.Count);

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);
            Assert.IsNotNull(newOrder);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubmitOrderShouldThrowExceptionWithoutItems()
        {
            AddTestUser();

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);
            Assert.AreEqual(OrderStatus.Draft, newOrder.OrderStatus);

            this.OrdersManager.SubmitOrder(1, "test address");
        }

        [TestMethod]
        public void SubmitOrderShouldChangeItsStatusCorrectly()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);
            Assert.AreEqual(OrderStatus.Draft, newOrder.OrderStatus);

            newOrder.AddOrderItem(1, 1, null);

            this.OrdersManager.SubmitOrder(1, "test address");
            newOrder = this.OrdersManager.GetOrder(1);
            Assert.AreEqual(OrderStatus.Requested, newOrder.OrderStatus);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubmitOrderShouldThrowErrorIfTheOrderHasAlreadyBeenSent()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 5, null);

            this.OrdersManager.SubmitOrder(1, "test address");
            this.OrdersManager.SubmitOrder(1, "test address");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubmitOrderShouldThrowErrorIfTheItemsAreOutOfQuantities()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 5, null);

            this.ProductsManager.UpdateSingleProductQuantity(null, 1, 0);

            this.OrdersManager.SubmitOrder(1, "test address");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SendOrderShouldThrowExceptionForOrderThatHasNotBeenRequested()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 1, null);

            this.OrdersManager.SendOrder(1);
        }

        [TestMethod]
        public void SendOrderShouldChangeItsStatusCorrectly()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 1, null);

            this.OrdersManager.SubmitOrder(1, "test address");
            this.OrdersManager.SendOrder(1);

            newOrder = this.OrdersManager.GetOrder(1);
            Assert.AreEqual(OrderStatus.Sent, newOrder.OrderStatus);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConfimOrderShouldThrowExceptionForOrderThatHasNotBeenSent()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 1, null);

            this.OrdersManager.ConfirmOrder(1);
        }

        [TestMethod]
        public void ConfirmOrderShouldChangeItsStatusCorrectly()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 1, null);

            this.OrdersManager.SubmitOrder(1, "test address");
            this.OrdersManager.SendOrder(1);
            this.OrdersManager.ConfirmOrder(1);

            newOrder = this.OrdersManager.GetOrder(1);
            Assert.AreEqual(OrderStatus.Finished, newOrder.OrderStatus);
        }

        [TestMethod]
        public void ConfirmOrderAddsTheCorrectReferralPointsToTheUser()
        {
            AddTestUser();
            AddTestSingleItem("test");

            this.OrdersManager.GetOrCreateUserDraftOrder(1);

            var newOrder = this.OrdersManager.GetOrder(1);

            newOrder.AddOrderItem(1, 1, null);

            this.OrdersManager.SubmitOrder(1, "test address");
            this.OrdersManager.SendOrder(1);
            this.OrdersManager.ConfirmOrder(1);

            var user = this.UserManager.GetUser(1);

            Assert.AreEqual(1, user.ReferralPoints);
        }

        [TestMethod]
        public void GetTotalOrdersCountShouldRetreiveTheCorrectCount()
        {
            this.UserManager.AddUser(new CreateUserDto("test", "test", "0889746634", "test1@test.com", "123123",
                "123123", 1, 0, false));

            this.UserManager.AddUser(new CreateUserDto("test", "test", "0889746634", "test2@test.com", "123123",
                "123123", 1, 0, false));

            this.UserManager.AddUser(new CreateUserDto("test", "test", "0889746634", "tes3@test.com", "123123",
                "123123", 1, 0, false));

            this.OrdersManager.GetOrCreateUserDraftOrder(1);
            this.OrdersManager.GetOrCreateUserDraftOrder(2);
            this.OrdersManager.GetOrCreateUserDraftOrder(3);

            Assert.AreEqual(3, this.OrdersManager.GetOrdersCount().GetAwaiter().GetResult());
        }
    }
}
