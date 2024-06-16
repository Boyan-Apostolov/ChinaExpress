using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.Logic
{
    public class UserManager : IUserManager
    {
        private readonly IUsersDbHelper _databaseHelper;
        private User _sessionUser;
        public UserManager(IUsersDbHelper usersDbHelper)
        {
            _databaseHelper = usersDbHelper;
        }

        public bool IsLoggedIn() => this._sessionUser != null;
        //public bool IsLoggedIn() => true;

        public async Task<ICollection<User>> GetAllUsersAsync(string filterUserEmail = null, int? countUsers = null)
        {
            if (!countUsers.HasValue) return this._databaseHelper.GetAllUsers(filterUserEmail: filterUserEmail);

            return this._databaseHelper
                .GetAllUsers()
                .ToList()
                .Take(countUsers.Value)
                .ToList();
        }

        public void Logout() => this._sessionUser = null;

        public User? Login(string email, string password, bool shouldSetSessionUser)
        {
            var user = this.GetAllUsersAsync(filterUserEmail: email).GetAwaiter().GetResult().FirstOrDefault();
            if (user == null) throw new InvalidOperationException("User cannot be found!");

            var isPasswordValid = user.IsPasswordCorrect(password);

            if (!isPasswordValid) throw new InvalidOperationException("Email or password is invalid!");
            if (shouldSetSessionUser) this._sessionUser = user;

            return user;
        }

        public bool AddUser(CreateUserDto userDto)
        {
            return _databaseHelper.AddUser(new User(0, userDto.FirstName, userDto.LastName, userDto.PhoneNumber, userDto.Email, userDto.Password, (UserRole)userDto.UserRole, userDto.ReferralPoints));
        }

        public void EditUser(int userId, CreateUserDto userDto)
        {
            _databaseHelper.EditUser(new User(userId, userDto.FirstName, userDto.LastName, userDto.PhoneNumber, userDto.Email, userDto.Password, (UserRole)userDto.UserRole, userDto.ReferralPoints));
        }

        public async Task<int> GetUsersCount()
        {
            return await _databaseHelper.GetUsersCount();
        }

        public void AddReferralPoints(int userId, int referralPoints)
        {
            this._databaseHelper.AddReferralPoints( userId, referralPoints);
        }

        public User GetUser(int userId)
        {
            return CustomExtensions.FirstOrDefault(this.GetAllUsersAsync().GetAwaiter().GetResult(),
                 u => u.Id == userId);
        }
    }
}
