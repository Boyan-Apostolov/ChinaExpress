using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChinaExpress.DTOs;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.Logic
{
    public interface ICategoryManager
    {
        ICollection<Category> GetAllCategories();
        ICollection<Feature> GetAllFeatures();
        void CreateCategory(CreateCategoryDto catgoryDo, List<int> features);
        void DeleteCategory(int categoryId);
    }
}
