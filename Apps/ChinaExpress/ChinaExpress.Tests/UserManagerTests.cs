using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DataAccess.MockingHelpers;
using ChinaExpress.DTOs;
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Tests
{
    [TestClass]
    public class UserManagerTests : BaseTestClass
    {

        public UserManagerTests()
        {
        }

        private const string ValidFirstName = "John";
        private const string ValidLastName = "Doe";
        private const string ValidPhoneNumber = "123-456-7890";
        private const string ValidEmail = "john.doe@example.com";
        private const string ValidPassword = "Password123";
        private const string ValidRepeatPassword = "Password123";
        private const int ValidUserRole = 1;
        private const int ValidReferralPoints = 10;
        private const bool IsPasswordRequired = true;


        #region Entity Data Validation Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FirstName_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                null,
                ValidLastName,
                ValidPhoneNumber,
                ValidEmail,
                ValidPassword,
                ValidRepeatPassword,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LastName_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                null,
                ValidPhoneNumber,
                ValidEmail,
                ValidPassword,
                ValidRepeatPassword,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PhoneNumber_Empty_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                null,
                ValidEmail,
                ValidPassword,
                ValidRepeatPassword,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PhoneNumber_InvalidFormat_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                "123",
                ValidEmail,
                ValidPassword,
                ValidRepeatPassword,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Email_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                ValidPhoneNumber,
                null,
                ValidPassword,
                ValidRepeatPassword,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Password_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                ValidPhoneNumber,
                ValidEmail,
                null,
                ValidRepeatPassword,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RepeatPassword_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                ValidPhoneNumber,
                ValidEmail,
                ValidPassword,
                null,
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RepeatPassword_NotMatching_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                ValidPhoneNumber,
                ValidEmail,
                ValidPassword,
                "123",
                ValidUserRole,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReferralPoints_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                ValidPhoneNumber,
                ValidEmail,
                ValidPassword,
                ValidRepeatPassword,
                ValidUserRole,
                -1,
                IsPasswordRequired);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UserRole_Invalid_ThrowsArgumentException()
        {
            new CreateUserDto(
                ValidFirstName,
                ValidLastName,
                ValidPhoneNumber,
                ValidEmail,
                ValidPassword,
                ValidRepeatPassword,
                -1,
                ValidReferralPoints,
                IsPasswordRequired);
        }

        #endregion


        [TestMethod]
        public async Task AddUserWithCorrectDataShouldAddThem()
        {
            var addedUser = this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            Assert.IsTrue(addedUser);
            var users = await UserManager.GetAllUsersAsync();

            Assert.AreEqual(users.First().FirstName, "John");
            Assert.AreEqual(users.First().LastName, "Smith");
        }

        [TestMethod]
        public async Task GetAllSholdReturnTheCorrectUsers()
        {
            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "john@test.com", "123456", "123456", 1, 0, false));

            this.UserManager
                .AddUser(new CreateUserDto("Test", "test", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var users = (await UserManager.GetAllUsersAsync()).ToList();

            Assert.AreEqual(users[0].FirstName, "John");
            Assert.AreEqual(users[1].FirstName, "Test");
            Assert.AreEqual(users.Count, 2);
        }

        [TestMethod]
        public async Task GetAllWithLimitSholdReturnTheCorrectUsers()
        {
            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            this.UserManager
                .AddUser(new CreateUserDto("Test", "Test", "0884321834", "someone@test.com", "123456", "123456", 1, 0, false));

            var users = (await UserManager.GetAllUsersAsync(countUsers: 1)).ToList();

            Assert.AreEqual(users[0].FirstName, "John");
            Assert.AreEqual(users.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AdingEistingUerShouldThrow()
        {
            var addedUser = this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));
        }

        [TestMethod]
        public void LoginWithCorrectDataShouldLoginTheUser()
        {
            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var loggedInUser = UserManager.Login("test@test.com", "123456", true);
            var userIsLoggedIn = UserManager.IsLoggedIn();

            Assert.AreEqual(loggedInUser.FirstName, "John");
            Assert.IsNotNull(loggedInUser);
            Assert.IsTrue(userIsLoggedIn);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoginWithFakeUserShouldThrowException()
        {
            var loggedInUser = UserManager.Login("fake@email.com", "123456", true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoginWIthInvalidPasswordShouldThrowException()
        {
            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var loggedInUser = UserManager.Login("test@test.com", "fake-pass", true);
        }

        [TestMethod]
        public void IsLoggedInShouldBeFalseWhenNooneIsLoggedIn()
        {
            var userIsLoggedIn = UserManager.IsLoggedIn();

            Assert.IsFalse(userIsLoggedIn);
        }

        [TestMethod]
        public void LogoutShouldClearTheUser()
        {
            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var loggedInUser = UserManager.Login("test@test.com", "123456", true);
            var userIsLoggedIn = UserManager.IsLoggedIn();

            Assert.IsTrue(userIsLoggedIn);

            this.UserManager.Logout();

            userIsLoggedIn = UserManager.IsLoggedIn();

            Assert.IsFalse(userIsLoggedIn);
        }

        [TestMethod]
        public async Task EditUserWithCorrectDataShouldEditThem()
        {
            var addedUser = this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var users = await UserManager.GetAllUsersAsync();
            var userToEdit = users.First();

            UserManager.EditUser(userToEdit.Id, new CreateUserDto("New", "Guy", "0884388834", "new-guy@test.com", "123456", "123456", 1, 0, false));

            users = UserManager.GetAllUsersAsync().GetAwaiter().GetResult();
            var editedUser = users.First();

            Assert.AreEqual(editedUser.FirstName, "New");
            Assert.AreEqual(users.First().LastName, "Guy");
        }

        [TestMethod]
        public void GetUserShouldReturnTheFoundUser()
        {
            var addedUser = this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var user = UserManager.GetUser(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.FirstName, "John");
            Assert.AreEqual(user.LastName, "Smith");
        }

        [TestMethod]
        public void GetUserShouldReturnNullWhenNotFound()
        {
            var user = UserManager.GetUser(1);

            Assert.IsNull(user);
        }

        [TestMethod]
        public async Task GetCountShouldReturnCorrectData()
        {
            var usersCount = await UserManager.GetUsersCount();

            Assert.AreEqual(0, usersCount);

            this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            usersCount = await UserManager.GetUsersCount();

            Assert.AreEqual(1, usersCount);
        }

        [TestMethod]
        public void AddReferrlPointsShouldAddTheCorrctAmountToTheUe()
        {
            var addedUser = this.UserManager
                .AddUser(new CreateUserDto("John", "Smith", "0884388834", "test@test.com", "123456", "123456", 1, 0, false));

            var user = UserManager.GetUser(1);
            Assert.AreEqual(user.ReferralPoints, 0);

            UserManager.AddReferralPoints(user.Id, 10);

            user = UserManager.GetUser(1);
            Assert.AreEqual(user.ReferralPoints, 10);
        }
    }
}
