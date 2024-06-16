using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
using ChinaExpress.DataAccess.Interfaces;
using ChinaExpress.SimpleEntityModels;
using ChinaExpress.DTOs;


namespace ChinaExpress.Logic
{

    public class CategoryManager : ICategoryManager
    {
        private ICategoriesDbHelper _databaseHelper;
        public CategoryManager(ICategoriesDbHelper categoriesDbHelper)
        {
            this._databaseHelper = categoriesDbHelper;
        }

        public ICollection<Category> GetAllCategories()
        {
           return this._databaseHelper.GetAllCategories().AsReadOnly();
        }

        private bool DoesCategoryExist(string categoryName)
        {
            return CustomExtensions.FirstOrDefault(GetAllCategories(), 
                c => c.Name == categoryName) != null;
        }

        public void CreateCategory(CreateCategoryDto catgoryDo, List<int> features)
        {
            if (DoesCategoryExist(catgoryDo.Name)) throw new InvalidOperationException("Category already exists!");

            this._databaseHelper.CreateCategory(catgoryDo.Name, features);
        }

        public void DeleteCategory(int foundCategoryId)
        {
            this._databaseHelper.DeleteCategory(foundCategoryId);
        }

        public ICollection<Feature> GetAllFeatures()
        {
            return this._databaseHelper.GetAllFeatures();
        }
    }
}
