using ChinaExpress.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.DataAccess;
using ChinaExpress.Desktop.Properties;
using ChinaExpress.DTOs;
using ChinaExpress.Logic;

namespace ChinaExpress.Desktop
{
    public partial class CategoriesForm : Form
    {
        private CategoryManager _propertiesManager;
        public CategoriesForm(HomePage mainForm)
        {
            this._propertiesManager = new CategoryManager(mainForm.CategoriesDbHelper);

            InitializeComponent();

            PopulateCategories();

            PopulateFeatures();
        }

        private void PopulateCategories()
        {
            var categories = this._propertiesManager.GetAllCategories();

            this.tableView.Rows.Clear();
            foreach (var category in categories)
            {
                this.tableView.Rows.Add(new object[] { category.Id,
                    category.Name, 
                    $"{category.ItemsCount} items",
                    string.Join(", ", category.Features.Select(f=>f.Name)),
                    Resources.deleteIcon });
            }
        }

        private void PopulateFeatures()
        {
            var features = this._propertiesManager.GetAllFeatures();

            this.featuresCheckedBox.Items.Clear();
            foreach (var feature in features)
            {
                this.featuresCheckedBox.Items.Add(feature);
            }
        }

        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;

            if (e.ColumnIndex == 4)
            {
                var foundCategory = this._propertiesManager
                    .GetAllCategories()
                    .Skip(e.RowIndex)
                    .Take(1)
                    .First();

                var shouldDelete = MessageBox.Show("Are you sure you want to delete this item?", "Delete confirmation",
                    MessageBoxButtons.YesNo);

                if (shouldDelete == DialogResult.Yes)
                {
                    this._propertiesManager.DeleteCategory(foundCategory.Id);
                    PopulateCategories();
                }
            }
        }

        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            var newCategoryText = this.newCategoryText.Text;

            var selectedFeatures = featuresCheckedBox.CheckedIndices;
            List<int> featureIds = new List<int>();
            foreach (int selectedFeature in selectedFeatures)
            {
                featureIds.Add(selectedFeature + 1);
            }


            try
            {
                this._propertiesManager
                    .CreateCategory(new CreateCategoryDto(newCategoryText),
                    featureIds);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Logic Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.newCategoryText.Text = string.Empty;
            this.featuresCheckedBox.ClearSelected();

            PopulateCategories();
        }
    }
}
