using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.SimpleEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class ComboBoxDto : BaseProductDto
    {
        private IDiscountStrategy _discountStategy;
        private List<Product> _selectedProducts;

        public ComboBoxDto(int productId, int itemId, string name, string photoUrl, Category category, string description, IDiscountStrategy discountStategy, List<Product> selectedProducts)
            : base(productId, itemId, name, photoUrl, category, description)
        {
            this.DiscountStrategy = discountStategy;
            _selectedProducts = selectedProducts;
        }

        public IDiscountStrategy DiscountStrategy
        {
            get => this._discountStategy;
            private set
            {
                if (value == null)
                    throw new ArgumentException("Product Discount cannot be empty!");

                this._discountStategy = value;
            }
        }

        public List<Product> SelectedProducts => this._selectedProducts;
    }
}
