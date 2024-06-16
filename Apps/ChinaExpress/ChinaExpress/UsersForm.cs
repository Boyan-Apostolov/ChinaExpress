using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.DataAccess;
using ChinaExpress.Desktop.Properties;
using ChinaExpress.Logic;

namespace ChinaExpress.Desktop
{
    public partial class UsersForm : Form
    {
        private readonly HomePage _mainForm;
        private readonly IUserManager _userManager;

        public UsersForm(HomePage mainForm, IUserManager userManager)
        {
            _mainForm = mainForm;
            _userManager = userManager;
            InitializeComponent();

            LoadUsers();
        }

        private async Task LoadUsers()
        {
            var users = await this._userManager.GetAllUsersAsync();

            this.tableView.Rows.Clear();

            foreach (var user in users)
            {
                this.tableView.Rows.Add(new object[] { user.FirstName, user.LastName, user.PhoneNumber, user.Email, user.UserRole, Resources.editIcon });
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            this._mainForm.OpenChildForm(new UserForm(_mainForm.UsersDbHelper, _mainForm));
        }

        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;

            if (e.ColumnIndex == 5)
            {
                var foundUser = this._userManager
                    .GetAllUsersAsync().GetAwaiter().GetResult()
                    .Skip(e.RowIndex)
                    .Take(1)
                    .First();

                this._mainForm.OpenChildForm(new UserForm(_mainForm.UsersDbHelper, _mainForm, foundUser.Id));
            }
        }
    }
}
