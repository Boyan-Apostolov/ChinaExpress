using AutoMapper;
using ChinaExpress.DataAccess;
using ChinaExpress.DataAccess.ApplicationHelpers;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.InternalHelpersSimpleModels;
using FontAwesome.Sharp;

namespace ChinaExpress.Desktop
{
    public partial class HomePage : Form
    {
        private IconButton _currentBtn;
        private Form _currentChildForm;
        private static Color _activePageColor = Color.AntiqueWhite;

        public IOrdersDbHelper OrdersDbHelper;
        public IUsersDbHelper UsersDbHelper;
        public IProductsDbHelper ProductsDbHelper;
        public ICategoriesDbHelper CategoriesDbHelper;
        public IDiscountStrategiesDbHelper DiscountStrategiesDbHelper;

        public IProductManagementHelper ProductManagementHelper;
        public IInternalProductManagementHelper InternalProductManagementHelper;
        public IDiscountStrategiesManagementHelper DiscountStrategiesManagementHelper;
        public IOrderManagementHelper OrderManagementHelper;

        public IUserManager UserManager;
        public IProductsManager ProductsManager;
        public ICategoryManager CategoryManager;
        public IDiscountManager DiscountsManager;
        public IProductFactory ProductFactory;
        private List<IconButton> _authorizedButtons;

        public HomePage()
        {

            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this._authorizedButtons = new List<IconButton>()
            {
                this.categoriesBtn,
                this.productsBtn,
                this.usersBtn,
                this.ordersBtn,
                this.logoutBtn,
                this.discountsBtn
            };

            InternalProductManagementHelper = new InternalProductManagementHelper();
            DiscountStrategiesManagementHelper = new DiscountStrategiesManagementHelper();
            ProductManagementHelper = new ProductManagementHelper(DiscountStrategiesManagementHelper, InternalProductManagementHelper);
            OrderManagementHelper = new OrderManagementHelper(ProductManagementHelper);

            DiscountStrategiesDbHelper = new DiscountStrategiesDbHelper(DiscountStrategiesManagementHelper);

            UsersDbHelper = new UsersDbHelper();
            ProductsDbHelper = new ProductsDbHelper(ProductManagementHelper);
            OrdersDbHelper = new OrdersDbHelper(UsersDbHelper, DiscountStrategiesDbHelper, OrderManagementHelper);
            CategoriesDbHelper = new CategoriesDbHelper();

            this.ProductFactory = new ProductFactory(ProductsDbHelper);


            this.UserManager = new UserManager(UsersDbHelper);
            this.CategoryManager = new CategoryManager(CategoriesDbHelper);
            this.DiscountsManager = new DiscountManager(DiscountStrategiesDbHelper, UserManager);
            
            ProductsManager = new ProductsManager(ProductsDbHelper, OrdersDbHelper, CategoriesDbHelper);
            

            CheckedLoggedUser();
        }

        public void CheckedLoggedUser()
        {
            var userIsLogged = this.UserManager.IsLoggedIn();

            if (userIsLogged)
            {
                _authorizedButtons.ForEach(b => b.Show());
            }
            else
            {
                _authorizedButtons.ForEach(b => b.Hide());

                //this.Close();
                OpenChildForm(new LoginForm(UserManager, this));
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            DisableButton();

            _currentBtn = (IconButton)senderBtn;
            _currentBtn.BackColor = Color.FromArgb(80, 89, 107);
            _currentBtn.ForeColor = color;
            _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            _currentBtn.IconColor = color;
            _currentBtn.ImageAlign = ContentAlignment.MiddleRight;
        }

        private void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.FromArgb(1, 45, 60);
                _currentBtn.ForeColor = Color.FromArgb(183, 222, 221); //115, 210, 222
                _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                _currentBtn.IconColor = Color.FromArgb(183, 222, 221);
                _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void ScheduleBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, _activePageColor);
            OpenChildForm(new ProductsForm(this));
        }

        public void OpenChildForm(Form childForm)
        {
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Reset()
        {
            DisableButton();
        }


        #region Logic For Effects on Sizable Buttons
        private void ClosingAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaximiseBtn_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal
                ? FormWindowState.Maximized
                : FormWindowState.Normal;
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
            => WindowState = FormWindowState.Minimized;

        private void MinimizeBtn_MouseHover(object sender, EventArgs e)
            => MinimizeBtn.BackColor = Color.FromArgb(118, 139, 176);

        private void MinimizeBtn_MouseLeave(object sender, EventArgs e)
            => MinimizeBtn.BackColor = Color.FromArgb(1, 45, 60);

        private void ClosingAppBtn_MouseEnter(object sender, EventArgs e)
            => ClosingAppBtn.BackColor = Color.FromArgb(229, 49, 49);

        private void ClosingAppBtn_MouseLeave(object sender, EventArgs e)
            => ClosingAppBtn.BackColor = Color.FromArgb(1, 45, 60);
        #endregion


        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void categoriesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, _activePageColor);
            OpenChildForm(new CategoriesForm(this));
        }

        private void panelDesktop_MouseEnter(object sender, EventArgs e)
        {
            CheckedLoggedUser();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.UserManager.Logout();
            CheckedLoggedUser();
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, _activePageColor);
            OpenChildForm(new UsersForm(this, this.UserManager));
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, _activePageColor);
            OpenChildForm(new OrdersForm(this));
        }

        private void discountsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, _activePageColor);
            OpenChildForm(new DiscountsForm(this, DiscountsManager));
        }
    }
}
