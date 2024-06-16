using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.SimpleEntityModels.Enums;

namespace ChinaExpress.Desktop
{
    public partial class LoginForm : Form
    {
        private IUserManager _userManager;
        private readonly HomePage _mainForm;

        public LoginForm(IUserManager userManager, HomePage mainForm)
        {
            _userManager = userManager;
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            User loggedInUser = null;
            try
            {
                loggedInUser = this._userManager
                    .Login(this.emailTxb.Text, this.passwordThx.Text, true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loggedInUser?.UserRole == UserRole.Client)
            {
                MessageBox.Show("Clients are not allowed to use this app!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _mainForm.CheckedLoggedUser();
            _mainForm.OpenChildForm(new ProductsForm(_mainForm));
            this.Close();
        }
    }
}
