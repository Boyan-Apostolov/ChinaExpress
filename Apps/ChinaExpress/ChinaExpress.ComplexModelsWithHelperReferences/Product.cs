using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.SimpleEntityModels;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
namespace ChinaExpress.ComplexModelsWithHelperReferences
{
    public abstract class Product
    {
        private readonly IInternalProductManagementHelper _internalProductManagementHelper;
        private List<Review> _reviews;
        private List<ProductView> _views;

        protected Product(int itemId, int productId, string name, string description, string photoUrl,
            Category category, IInternalProductManagementHelper internalProductManagementHelper = null)
        {
            _internalProductManagementHelper = internalProductManagementHelper;
            ProductId = productId;
            ItemId = itemId;
            Name = name;
            Description = description;
            PhotoUrl = photoUrl;
            Category = category;
        }

        public int ItemId { get; }
        public int ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public string PhotoUrl { get; }

        public Category Category { get; }

        public virtual decimal GetPrice() => 0m;
        public virtual int GetQuantity() => 0;

        public virtual List<Review> GetReviews()
        {
            if (this._reviews == null) this._reviews = _internalProductManagementHelper.GetProductReviews(this.ProductId);

            return this._reviews;
        }
        public virtual List<ProductView> GetViews()
        {
            if (this._views == null) this._views = _internalProductManagementHelper.GetProductViews(this.ProductId);

            return this._views;
        }

        public virtual void IncreaseViews(int userId)
        {
            this._internalProductManagementHelper.IncreaseViews(this.ProductId, userId);
            this._views = null; //Reset the collection so it can be updated on the next GET
        }


        public double Rating => this.GetReviews()?.Any() is true
            ? CustomExtensions.Average(GetReviews(), r => r.Stars)
            : 0;


        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
