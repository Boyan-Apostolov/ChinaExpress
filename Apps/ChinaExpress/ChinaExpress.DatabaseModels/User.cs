using System.Security.Cryptography;
using System.Text;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.SimpleEntityModels
{
    public class User
    {
        public User(int id, string firstName, string lastName, string phoneNumber, string email, string password, UserRole userRole, int referralPoints)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            UserRole = userRole;
            ReferralPoints = referralPoints;
        }

        public int Id { get; }
        public string FirstName { get;  }
        public string LastName { get; }
        public string PhoneNumber { get; }   
        public string Email { get; }
        public string Password { get;  }
        public int ReferralPoints { get;  }
        public UserRole UserRole { get; }

        public static string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] hashedBytes = sha256
                .ComputeHash(Encoding.UTF8.GetBytes(password));

            string hashedPassword = BitConverter
                .ToString(hashedBytes)
                .Replace("-", "")
                .ToLower();

            return hashedPassword;
        }

        public bool IsPasswordCorrect(string inputPassword)
            => HashPassword(inputPassword) == Password;
    }
}
