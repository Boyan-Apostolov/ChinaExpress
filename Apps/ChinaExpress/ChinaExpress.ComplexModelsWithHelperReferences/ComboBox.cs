using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.ComplexModelsWithHelperReferences
{
    public class ComboBox : Product
    {
        private ICollection<Product> _products;

        public ComboBox(int id, string name, string description, string photoUrl, IDiscountStrategy discountStrategy, Category category, int productId, ICollection<Product> products, IInternalProductManagementHelper internalProductManagementHelper = null) 
            : base(id, productId, name, description, photoUrl, category, internalProductManagementHelper)
        {
            DiscountStrategy = discountStrategy;
            this._products = products;
        }

        public IDiscountStrategy DiscountStrategy { get; }

        public Product[] GetProducts() => _products.ToArray();

        public override decimal GetPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in _products) totalPrice += product.GetPrice();

            return this.DiscountStrategy?.ApplyDiscount(totalPrice) ?? totalPrice;
        }

        public override int GetQuantity()
        {
            var boxesAvailable = int.MaxValue;

            foreach (var quantity in this._products.Select(item => item.GetQuantity()))
            {
                if (quantity == 0)
                    return 0;

                boxesAvailable = Math.Min(boxesAvailable, quantity);
            }

            return boxesAvailable;
        }
    }
}
