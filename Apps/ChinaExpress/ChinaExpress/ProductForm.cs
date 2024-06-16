using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.Desktop.Properties;
using ChinaExpress.DTOs;
using ChinaExpress.Logic;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
namespace ChinaExpress.Desktop
{
    public partial class ProductForm : Form
    {
        private readonly int? _itemId;
        private readonly int? _productId;
        private readonly List<int> _selectedProductIds;
        private bool _isForComboBox;

        private const string ComboBoxImgUrl = "https://www.scribner-ne.gov/wp-content/uploads/junk.jpg";

        private readonly IDiscountManager _discountManager;
        private readonly IProductsManager _productsManager;
        private readonly IProductFactory _productFactory;
        private readonly ICategoryManager _categoryManager;
        public ProductForm(HomePage mainForm, int? itemId = null, int? productId = null, List<int> selectedProductIds = null)
        {
            _itemId = itemId;
            _productId = productId;
            _selectedProductIds = selectedProductIds;
            _isForComboBox = selectedProductIds?.Any() is true; ;
            this._productsManager = mainForm.ProductsManager;
            this._categoryManager = mainForm.CategoryManager;
            this._discountManager = mainForm.DiscountsManager;
            this._productFactory = mainForm.ProductFactory;

            InitializeComponent();

            LoadCategories();
            LoadDiscounts();

            TryLoadProductData();
        }

        private void ToggleCorrespondingInputs()
        {
            if (_isForComboBox)
            {
                quantityPanel.Hide();
                pricePanel.Hide();
                discountSelectPanel.Show();
            }
            else
            {
                quantityPanel.Show();
                pricePanel.Show();
                discountSelectPanel.Hide();
            }
        }

        private void TryLoadProductData()
        {
            if (this._itemId.HasValue && this._productId.HasValue)
            {
                var product = this._productsManager.GetProduct(this._productId.Value);

                var categries = this._categoryManager.GetAllCategories();

                this.categoryInput.SelectedIndex = categries
                    .ToList()
                    .FindIndex(x => x.Name == product.Category.Name);

                if (product.PhotoUrl == ComboBoxImgUrl) _isForComboBox = true;

                this.nameTxB.Text = product.Name;
                this.descriptionTxb.Text = product.Description;
                this.photoUrlTxb.Text = product.PhotoUrl;
                this.quantityInput.Text = product.GetQuantity().ToString();

                this.titleLabel.Text = "Edit Product";
                this.createProductBtn.Text = "Edit Product";

                if (_isForComboBox)
                {
                    var discounts = this._discountManager
                        .GetAllDiscountStrategies();

                    var comboBox = _productsManager.GetComboBoxByProductId(this._productId.Value);
                    this.discountTypeSelect.SelectedIndex = discounts
                        .ToList()
                        .FindIndex(x => x.Code == comboBox.DiscountStrategy.Code);
                }
                else
                {
                    this.priceInput.Text = product.GetPrice().ToString();
                }
            }
            else
            {
                this.titleLabel.Text = "New Product";
                this.createProductBtn.Text = "Create Product";

                this.pictureBox.ImageLocation = _isForComboBox
                    ? ComboBoxImgUrl
                    : "https://i.ibb.co/hC1LZNR/logo.png";

                this.photoUrlTxb.Text = _isForComboBox
                    ? ComboBoxImgUrl
                    : string.Empty;

                this.photoUrlTxb.Enabled = !this._isForComboBox;
            }

            ToggleCorrespondingInputs();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadCategories()
        {
            var categries = this._categoryManager.GetAllCategories();
            this.categoryInput.Items.Clear();

            foreach (var category in categries)
            {
                this.categoryInput.Items.Add(category);
            }
        }

        private void LoadDiscounts()
        {
            var discounts =
                CustomExtensions.Where(
                    this._discountManager.GetAllDiscountStrategies(), 
                    d => d.RemainingUses > 0);
            this.discountTypeSelect.Items.Clear();

            foreach (var discount in discounts)
            {
                this.discountTypeSelect.Items.Add(discount);
            }
        }

        private void photoUrlTxb_TextChanged(object sender, EventArgs e)
        {
            var url = photoUrlTxb.Text;

            pictureBox.ImageLocation = url;
        }

        private void createProductBtn_Click(object sender, EventArgs e)
        {
            var name = nameTxB.Text;
            var photoUrl = photoUrlTxb.Text;
            var quantity = int.Parse(quantityInput.Text);
            var description = descriptionTxb.Text;
            var category = categoryInput.SelectedItem;
            var discountStrategy = discountTypeSelect.SelectedItem;
            var price = decimal.Parse(priceInput.Text);

            try
            {
                if (this._itemId.HasValue && this._productId.HasValue)
                {
                    var updateDto = _productFactory
                        .UpdateProduct(this._itemId.Value, this._productId.Value, name, photoUrl, quantity, description, category, price, discountStrategy);

                    this._productsManager.UpdateProduct(updateDto);
                }
                else
                {
                    var createDto = _productFactory
                        .CreateProduct(name, photoUrl, quantity, description, category, price, discountStrategy, _selectedProductIds);

                    this._productsManager.AddProduct(createDto);
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }
    }
}
