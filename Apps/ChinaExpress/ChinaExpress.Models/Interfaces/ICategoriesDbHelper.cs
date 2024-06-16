using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.Interfaces
{
    public interface ICategoriesDbHelper
    {
        Category[] GetAllCategories();
        void CreateCategory(string categoryName, List<int> features);
        void DeleteCategory(int categoryId);
        Feature[] GetAllFeatures();
        List<Feature> GetCategoyFeatures(int categoryId);
    }
}
