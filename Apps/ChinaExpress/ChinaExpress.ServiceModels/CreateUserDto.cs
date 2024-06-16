using ChinaExpress.SimpleEntityModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class CreateUserDto
    {
        private bool _isPasswordRequired;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private string _password;
        private int _referralPoints;
        private int _userRole;
        private string _repeatPass;

        public CreateUserDto(string firstName, string lastName, string phoneNumber, string email, string password, string repeatPass, int userRole, int referralPoints, bool isPasswordRequired)
        {
            _isPasswordRequired = isPasswordRequired;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Password = password;
            this.UserRole = userRole;
            this.ReferralPoints = referralPoints;
            this.RepeatPassword = repeatPass;
        }

        public string FirstName
        {
            get => this._firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First Name cannot be empty!");
                this._firstName = value;
            }
        }

        public string LastName
        {
            get => this._lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last Name cannot be empty!");
                this._lastName = value;
            }
        }

        public string PhoneNumber
        {
            get => this._phoneNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone Number cannot be empty!");

                var phoneValidator = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                if (!phoneValidator.IsMatch(value))
                    throw new ArgumentException("Phone Number is in wrong format!");

                this._phoneNumber = value;
            }
        }

        public string Email
        {
            get => this._email;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be empty!");
                this._email = value;
            }
        }

        public string Password
        {
            get => this._password;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && _isPasswordRequired)
                    throw new ArgumentException("Password cannot be empty!");

                this._password = value;
            }
        }

        public string RepeatPassword
        {
            get => this._repeatPass;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && _isPasswordRequired)
                    throw new ArgumentException("Repeat Password cannot be empty!");

                if (this.Password != value)
                    throw new ArgumentException("Passwords do not match!");

                this._password = value;
            }
        }

        public int ReferralPoints
        {
            get => this._referralPoints;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Referral Points cannot be negative!");
                this._referralPoints = value;
            }
        }

        public int UserRole
        {
            get => this._userRole;
            private set
            {
                if (value == -1)
                    throw new ArgumentException("User role must be selected!");
                this._userRole = value;
            }
        }
    }
}
