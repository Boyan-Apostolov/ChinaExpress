using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.ComplexModelsWithHelperReferences
{
    public class SingleItem : Product
    {
        private decimal _price;
        private int _quantity;

        public SingleItem(int id, string name, string description, string photoUrl, int quantity, decimal price, Category category, int productId, IInternalProductManagementHelper internalProductManagementHelper = null) 
            : base(id, productId, name, description, photoUrl, category, internalProductManagementHelper)
        {
            this._price = price;
            this._quantity = quantity;
        }

        public override int GetQuantity() => this._quantity;

        public override decimal GetPrice() => this._price;
    }
}
