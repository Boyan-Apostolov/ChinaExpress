using ChinaExpress.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.DataAccess.ApplicationHelpers
{
    public class UsersDbHelper : BaseDbHelper, IUsersDbHelper
    {
        public User GetUserById(int userId)
            => CustomExtensions.FirstOrDefault(GetAllUsers(userId), x => true);

        public User[] GetAllUsers(int? filterUserId = null, string? filterUserEmail = null)
        {
            var foundUsers = new List<User>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT * FROM [User]";

                if (filterUserId.HasValue)
                {
                    sql += " WHERE Id = @UserId";
                }
                if (!string.IsNullOrWhiteSpace(filterUserEmail))
                {
                    sql += " WHERE Email = @Email";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserId", filterUserId ?? 0);
                cmd.Parameters.AddWithValue("@Email", filterUserEmail ?? "");

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    foundUsers.Add(new User(
                        (int)dr[0],
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        (UserRole)dr[6],
                        (int)dr[7])
                    );
                }
            }

            return foundUsers.ToArray();
        }

        public bool AddUser(User user)
        {
            if (UserAlreadyExists(user))
            {
                throw new InvalidOperationException("User already exists!");
            }

            var conn = GetConnection();

            string sql = @"INSERT INTO [User] (FirstName, LastName, PhoneNumber, Email, Password, UserRole, ReferralPoints)
                            VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Password, @UserRole, @ReferralPoints)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", User.HashPassword(user.Password));
            cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
            cmd.Parameters.AddWithValue("@ReferralPoints", user.ReferralPoints);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        private bool UserAlreadyExists(User user)
        {
            var conn = GetConnection();

            var sql = @"SELECT *
                        FROM [User]
                        WHERE Email = @email";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", user.Email);

            conn.Open();
            var id = (int?)cmd.ExecuteScalar();
            conn.Close();

            return id.HasValue;
        }

        public void EditUser(User user)
        {
            var conn = GetConnection();

            string sql = @"UPDATE [User]
                            Set FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email, UserRole = @UserRole
                           WHERE Id = @UserId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
            cmd.Parameters.AddWithValue("@UserId", user.Id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public async Task<int> GetUsersCount()
        {
            var conn = GetConnection();

            var sql = @"SELECT COUNT(*)
                        FROM [User]";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            var count = (int)(await cmd.ExecuteScalarAsync());
            conn.Close();

            return count;
        }

        public void AddReferralPoints(int userId, int referralPoints)
        {
            var conn = GetConnection();

            string sql = @"UPDATE [User]
                            Set ReferralPoints = ReferralPoints + @ReferralPoints
                           WHERE Id = @UserId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ReferralPoints", referralPoints);
            cmd.Parameters.AddWithValue("@UserId", userId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
