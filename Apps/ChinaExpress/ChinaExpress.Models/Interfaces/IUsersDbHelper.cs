using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.Interfaces
{
    public interface IUsersDbHelper
    {
        User GetUserById(int userId);
        User[] GetAllUsers(int? filterUserId = null, string ? filterUserEmail = null);
        bool AddUser(User user);
        void EditUser(User user);
        Task<int> GetUsersCount();
        void AddReferralPoints(int userId, int referralPoints);
    }
}
