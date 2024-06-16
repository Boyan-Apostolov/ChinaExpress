using ChinaExpress.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChinaExpress.DTOs;

namespace ChinaExpress.Desktop
{
    public partial class CardListItem : UserControl
    {
        private string _title;
        private string _price;
        private string _image;
        private string _quantity;

        public event EventHandler<CustomListItemEventArgs> DeleteButtonClickEvent;
        public event EventHandler<CustomListItemEventArgs> EditButtonClickEvent;
        public event EventHandler<CustomListItemEventArgs> SelectedItemEvent;

        public CardListItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                this.TitleLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public int ItemId { get; set; }

        [Category("Custom Props")]
        public int ProductId { get; set; }

        [Category("Custom Props")]
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                this.priceLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                if ((value ?? "").Contains("junk.jpg")) this.selectItemCheckbox.Hide(); //Workaround due to using a custom listing type
                this.pictureBox.ImageLocation = value;
            }
        }

        [Category("Custom Props")]
        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                this.quantityLabel.Text = $"{value} in stock";
            }
        }

        private void CardListItem_Load(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteButtonClickEvent?.Invoke(this, new CustomListItemEventArgs(this.ItemId, this.ProductId));
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EditButtonClickEvent?.Invoke(this, new CustomListItemEventArgs(this.ItemId, this.ProductId));
        }

        private void selectItemCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SelectedItemEvent?.Invoke(this, new CustomListItemEventArgs(this.ItemId, this.ProductId));
        }
    }
}
