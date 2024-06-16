using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.DTOs;
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels.Enums;
using CustomExtensions = ChinaExpress.Extensions.Extensions;

namespace ChinaExpress.Desktop
{
    public partial class UserForm : Form
    {
        private readonly HomePage _mainForm;
        private readonly int? _userId;
        private UserManager _userManager;
        public UserForm(IUsersDbHelper userDbHelper, HomePage mainForm, int? userId = null)
        {
            _mainForm = mainForm;
            _userId = userId;
            InitializeComponent();

            this._userManager = new UserManager(userDbHelper);

            LoadRoles();

            if (userId.HasValue)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            titleLabel.Text = "Edit User";
            addUserBtn.Text = "Edit User";

            var foundUser = this._userManager.GetUser(this._userId.Value);

            firstNameTb.Text = foundUser.FirstName;
            lastNameTb.Text = foundUser.LastName;

            phoneTb.Text = foundUser.PhoneNumber;
            emailTb.Text = foundUser.Email;

            passwordInputsPanel.Hide();

            rolesComboBox.SelectedIndex = (int)foundUser.UserRole;
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            var firstName = firstNameTb.Text;
            var lastName = lastNameTb.Text;

            var phone = phoneTb.Text;
            var email = emailTb.Text;

            var pass = passwordInput.Text;
            var repeatPass = repeatPasswordInput.Text;

            var role = rolesComboBox.SelectedIndex;

            try
            {
                var dto = new CreateUserDto(firstName, lastName, phone, email, pass, repeatPass, role, 0, isPasswordRequired: !this._userId.HasValue);

                if (this._userId.HasValue)
                {
                    _userManager.EditUser(this._userId.Value, dto);
                }
                else
                {
                    _userManager.AddUser(dto);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            _mainForm.OpenChildForm(new UsersForm(_mainForm, _userManager));
        }

        private void LoadRoles()
        {
            this.rolesComboBox.Items.Clear();

            foreach (var role in Enum.GetNames(typeof(UserRole)))
            {
                this.rolesComboBox.Items.Add(role);
            }
        }
    }
}
