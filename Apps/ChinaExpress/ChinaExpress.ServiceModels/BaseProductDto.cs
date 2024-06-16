using System;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DTOs
{
    public class BaseProductDto
    {
        private  int _productId;
        private  int _itemId;
        private string _name;
        private string _photoUrl;
        private Category _category;
        private string _description;

        public BaseProductDto(int productId, int itemId, string name, string photoUrl, Category category, string description)
        {
            _productId = productId;
            _itemId = itemId;
            this.Name = name;
            this.PhotoUrl = photoUrl;
            this.Category = category;
            this.Description = description;
        }

        public int ProductId
        {
            get => this._productId;
            set => this._productId = value; //Setter used only for testing
        }
        public int ItemId => this._itemId;


        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product Name cannot be empty!");

                this._name = value;
            }
        }

        public string Description
        {
            get => this._description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product Description cannot be empty!");

                this._description = value;
            }

        }

        public string PhotoUrl
        {
            get => this._photoUrl;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product Photo cannot be empty!");

                this._photoUrl = value;
            }
        }

        public Category Category
        {
            get => this._category;
            private set
            {
                if (value == null)
                    throw new ArgumentException("Product Category cannot be empty!");

                this._category = value;
            }
        }
    }
}
