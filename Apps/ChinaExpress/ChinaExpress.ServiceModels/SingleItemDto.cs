using ChinaExpress.ComplexModelsWithHelperReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DTOs
{
    public class SingleItemDto : BaseProductDto
    {
        private decimal _price;
        private int _quantity;

        public SingleItemDto(int productId, int itemId, string name, string photoUrl, Category category, string description, decimal price, int quantity) : base(productId, itemId, name, photoUrl, category, description)
        {
            this.Price = price;
            this.Quantity = quantity;
        }

        public decimal Price
        {
            get => this._price;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Product Price cannot be zero!");

                this._price = value;
            }
        }


        public int Quantity
        {
            get => this._quantity;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Product quantity cannot be zero!");

                this._quantity = value;
            }
        }
    }
}
