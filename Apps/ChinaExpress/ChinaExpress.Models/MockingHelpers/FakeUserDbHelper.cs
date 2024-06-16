using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeUserDbHelper : IUsersDbHelper
    {
        private List<User> _users;
        public FakeUserDbHelper()
        {
            this._users = new List<User>();
        }
        public User? GetUserById(int userId)
        {
            return this._users.FirstOrDefault(u => u.Id == userId);
        }


        public User[] GetAllUsers(int? filterUserId = null, string? filterUserEmal= null)
        {
            return this._users.ToArray();
        }

        public bool AddUser(User user)
        {
            if (this._users.Any(u => u.Email == user.Email)) throw new InvalidOperationException("User already exists!");

            this._users
                .Add(new User(this._users.Count + 1, user.FirstName, user.LastName, user.PhoneNumber, user.Email, User.HashPassword(user.Password), user.UserRole, 0));

            return true;
        }

        public void EditUser(User user)
        {
            var existingUser = this._users.FirstOrDefault(u => u.Id == user.Id);

            this._users.Remove(existingUser);
            this._users.Add(user);
        }

        public async Task<int> GetUsersCount()
        {
            return this._users.Count;
        }

        public void AddReferralPoints(int userId, int referralPoints)
        {
            var user = GetUserById(userId);

            this._users.Remove(user);

            this._users.Add(new User(user.Id, user.FirstName, user.LastName, user.PhoneNumber, user.Email, user.Password, user.UserRole, user.ReferralPoints + referralPoints));
        }
    }
}
