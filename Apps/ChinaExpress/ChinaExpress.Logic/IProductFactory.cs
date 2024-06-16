using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.Logic
{
    public interface IProductFactory
    {
        BaseProductDto CreateProduct(string name, string photoUrl, int quantity, string description, object category, decimal? price, object discountStrategy, ICollection<int> productItemIds);

        BaseProductDto UpdateProduct(int itemId, int productId, string name, string photoUrl, int quantity, string description, object category, decimal? price, object discountStrategy);

    }
}
