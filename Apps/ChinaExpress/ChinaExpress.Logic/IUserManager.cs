using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Logic
{
    public interface IUserManager
    {
        bool IsLoggedIn();
        Task<ICollection<User>> GetAllUsersAsync(string filterUserEmai = null, int? countUsers = null);

        User GetUser(int userId);

        void Logout();
        User? Login(string email, string password, bool shouldSetSessionUser);
        bool AddUser(CreateUserDto userDto);
        void EditUser(int userId, CreateUserDto userDto);

        Task<int> GetUsersCount();
        void AddReferralPoints(int userId, int referralPoints);
    }
}
