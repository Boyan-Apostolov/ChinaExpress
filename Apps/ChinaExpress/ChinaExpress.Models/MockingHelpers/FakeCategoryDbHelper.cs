using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.MockingHelpers
{
    public class FakeCategoryDbHelper : ICategoriesDbHelper
    {
        private List<Category> _categories = new List<Category>()
        {
            new Category(1, "test", 0)
        };

        private List<Feature> Features = new List<Feature>()
        {
            new Feature(1, "Size", JsonSerializer.Serialize(new List<string>()
            {
                "S", "M", "L"
            })),
            new Feature(2, "Color", JsonSerializer.Serialize(new List<string>()
            {
                "Black", "Green", "Red", "Blue"
            })),
        };
        private Dictionary<int, List<int>> _categoryFeatres = new Dictionary<int, List<int>>()
        {
            { 1, new List<int> { 1 } }
        };


        public FakeCategoryDbHelper()
        {
        }

        public Category[] GetAllCategories()
        {
            return this._categories.ToArray();
        }

        public void CreateCategory(string categoryName, List<int> features)
        {
            this._categories.Add(new Category(this._categories.Count + 1, categoryName, 0));
            _categoryFeatres.Add(this._categories.Count + 1, features);
        }

        public void DeleteCategory(int categoryId)
        {
            var category = this._categories.FirstOrDefault(c => c.Id == categoryId);
            this._categories.Remove(category);
        }

        public Feature[] GetAllFeatures()
        {
            return Features.ToArray();
        }

        public List<Feature> GetCategoyFeatures(int categoryId)
        {
            return Features.Where(f => _categoryFeatres[categoryId].Contains(f.Id)).ToList();
        }
    }
}
