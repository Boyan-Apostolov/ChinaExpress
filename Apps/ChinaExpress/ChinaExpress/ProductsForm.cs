using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.DataAccess;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;

namespace ChinaExpress.Desktop
{
    public partial class ProductsForm : Form
    {
        private readonly HomePage _mainForm;
        private ProductsManager _productsManager;
        private bool lastActionWasCreate = false;
        private List<int> _selectedProductIds;
        public ProductsForm(HomePage mainForm)
        {
            _mainForm = mainForm;
            this._productsManager = new ProductsManager(_mainForm.ProductsDbHelper, _mainForm.OrdersDbHelper, _mainForm.CategoriesDbHelper);
            this._selectedProductIds = new List<int>();

            InitializeComponent();

            PopulateItems();
        }

        private void PopulateItems(string keyword = null)
        {
            this.addComboBoxBtn.Hide();

            this._selectedProductIds.Clear();

            flowLayoutPanel1.Controls.Clear();

            var allProducts = _productsManager.GetAllProducts(keyword: keyword);

            foreach (var product in allProducts)
            {
                var listItem = new CardListItem();
                listItem.ItemId = product.ItemId;
                listItem.ProductId = product.ProductId;
                listItem.Title = product.Name;
                listItem.Price = $"{product.GetPrice():f2} $";
                listItem.Image = product.PhotoUrl;
                listItem.Quantity = $"{product.GetQuantity()}";

                listItem.DeleteButtonClickEvent += ListItemOnDeleteButtonClickEvent;
                listItem.EditButtonClickEvent += ListItemOnEditButtonClickEvent;
                listItem.SelectedItemEvent += SelectedItemEvent;

                flowLayoutPanel1.Controls.Add(listItem);
            }

            CheckForMergeBtnVisibility();
        }

        private void ListItemOnDeleteButtonClickEvent(object? sender, CustomListItemEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButtons.YesNo);

            if (messageBoxResult == DialogResult.Yes)
            {

                var isProductInComboBox = this._productsManager.IsSingleProductInComboBox(e.ItemId);

                if (isProductInComboBox)
                {
                    MessageBox.Show("Product is part of a Combo Box and cannot be deleted!");
                    return;
                }

                this._productsManager.DeleteProduct(e.ProductId);

                PopulateItems();
            }
        }

        private void SelectedItemEvent(object? sender, CustomListItemEventArgs e)
        {
            if (this._selectedProductIds.Contains(e.ItemId))
            {
                this._selectedProductIds.Remove(e.ItemId);
            }
            else
            {
                this._selectedProductIds.Add(e.ItemId);
            }

            CheckForMergeBtnVisibility();
        }

        private void CheckForMergeBtnVisibility()
        {
            if (this._selectedProductIds.Count > 1)
            {
                this.addComboBoxBtn.Show();
            }
            else
            {
                this.addComboBoxBtn.Hide();
            }
        }
        private void ListItemOnEditButtonClickEvent(object? sender, CustomListItemEventArgs e)
        {
            lastActionWasCreate = true;
            var productForm = new ProductForm(_mainForm, e.ItemId, e.ProductId);
            productForm.Show();
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm(_mainForm);
            productForm.Show();
            lastActionWasCreate = true;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {

        }

        private void ProductsForm_MouseEnter(object sender, EventArgs e)
        {
            if (!lastActionWasCreate) return;

            PopulateItems();
            lastActionWasCreate = false;
        }

        private void cardListItem1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void addComboBoxBtn_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm(_mainForm, null, null, this._selectedProductIds);
            productForm.Show();
            lastActionWasCreate = true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var keyword = searchBox.Text;

            PopulateItems(keyword);
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var keyword = searchBox.Text;
                PopulateItems(keyword);
            }
        }
    }
}
