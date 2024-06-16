using AutoMapper;
using ChinaExpress.DataAccess.MockingHelpers;
using ChinaExpress.Logic;
using ChinaExpress.DTOs;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static System.Net.Mime.MediaTypeNames;

namespace ChinaExpress.Tests
{
    [TestClass]
    public class CategoryManagerTests : BaseTestClass
    {
        public CategoryManagerTests()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShouldThowExceptionWithInvalidModelData()
        {
            this.CategoryManager.CreateCategory(new CreateCategoryDto(""), new List<int>() { 0 });
        }

        [TestMethod]
        public void GetAllShouldReturnCorrectData()
        {
            var allCategories = this.CategoryManager.GetAllCategories().ToArray();
            Assert.AreEqual(1, allCategories.Length);

            this.CategoryManager.CreateCategory(new CreateCategoryDto("test1"), new List<int>() { 0 });
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test2"), new List<int>() { 1 });
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test3"), null);

            allCategories = this.CategoryManager.GetAllCategories().ToArray();

            Assert.AreEqual(4, allCategories.Length);
            Assert.AreEqual("test1", allCategories[1].Name);
        }

        [TestMethod]
        public void CreateNewCategoryShouldAddItToTheList()
        {
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test123"), new List<int>() { 0 });

            var allCategories = this.CategoryManager.GetAllCategories();

            Assert.AreEqual("test123", allCategories.Last().Name);
            Assert.IsNotNull(allCategories.FirstOrDefault(c => c.Name == "test123"));
        }

        [TestMethod]
        public void CreateExistingCategoryShouldThrowException()
        {
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test123"), null);

            Assert.ThrowsException<InvalidOperationException>(() => this.CategoryManager.CreateCategory(new CreateCategoryDto("test123"), null));
        }

        [TestMethod]
        public void DeleteRemovesTheCategoryFromTheList()
        {
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test1"), null);
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test2"), null);
            this.CategoryManager.CreateCategory(new CreateCategoryDto("test3"), null);

            var allCategories = this.CategoryManager.GetAllCategories();

            Assert.IsNotNull(allCategories.FirstOrDefault(c => c.Name == "test2"));

            this.CategoryManager.DeleteCategory(1);
            allCategories = this.CategoryManager.GetAllCategories();

            Assert.IsNull(allCategories.FirstOrDefault(c => c.Id == 1));
        }

        [TestMethod]
        public void GetAllFeaturesShouldReturnThCorrectData()
        {
            var features = this.CategoryManager.GetAllFeatures().ToArray();

            //No Act as the features cannot be added/changed

            Assert.AreEqual(features[0].Name, "Size");
            Assert.AreEqual(features[1].Name, "Color");
        }
    }
}