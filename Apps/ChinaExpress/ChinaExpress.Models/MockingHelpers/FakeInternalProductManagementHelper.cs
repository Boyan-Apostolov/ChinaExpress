using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.InternalHelpersComplexModels;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeInternalProductManagementHelper : IInternalProductManagementHelper
    {
        private List<Review> _reviews;
        private List<ProductView> _views;

        public FakeInternalProductManagementHelper()
        {
            _reviews = new List<Review>();
            _views = new List<ProductView>();
        }

        public List<Review> GetProductReviews(int id)
        {
            return this._reviews.Where(p => p.OrderItemId == id).ToList();
        }

        public List<ProductView> GetProductViews(int id)
        {
            return this._views.Where(p => p.ProductId == id).ToList();
        }

        public void IncreaseViews(int productId, int userId)
        {
            this._views.Add(new ProductView(this._views.Count + 1, userId, productId, DateTime.Now));
        }
    }
}
