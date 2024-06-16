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
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels.Enums;
using ArgumentException = System.ArgumentException;
using ChinaExpress.DTOs;

namespace ChinaExpress.Desktop
{
    public partial class DiscountsForm : Form
    {
        private readonly IDiscountManager _discountManager;

        public DiscountsForm(HomePage mainForm, IDiscountManager discountManager)
        {
            _discountManager = discountManager;

            InitializeComponent();

            PopulateDiscountType();

            PopulateDiscountItems();
        }

        private void PopulateDiscountType()
        {
            discountType.Items.Clear();
            foreach (var discountTypeName in Enum.GetNames(typeof(DiscountStrategyType)))
            {
                discountType.Items.Add(discountTypeName);
            }
        }

        private void PopulateDiscountItems()
        {
            tableView.Rows.Clear();
            foreach (var discountStrategy in _discountManager.GetAllDiscountStrategies())
            {
                this.tableView.Rows.Add(
                    new object[] { discountStrategy.Id, discountStrategy.Code, discountStrategy.Value, discountStrategy.RemainingUses, Resources.deleteIcon });
            }
        }
        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;
            if (e.ColumnIndex == 4)
            {
                var foundCategory = this._discountManager
                    .GetAllDiscountStrategies()
                    .Skip(e.RowIndex)
                    .Take(1)
                    .First();

                var shouldDelete = MessageBox.Show("Are you sure you want to delete this item?", "Delete confirmation",
                    MessageBoxButtons.YesNo);

                if (shouldDelete == DialogResult.Yes)
                {
                    this._discountManager.DeleteDiscountStrategy(foundCategory.Id);
                    PopulateDiscountItems();
                }
            }
        }

        private void reamainingUses_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new CreateDiscountDto((int)discountValue.Value,
                    codeInput.Text,
                    discountType.SelectedIndex,
                    (int)reamainingUses.Value);

                this._discountManager.CreateDiscountStrategy(dto);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            discountValue.Value = 0;
            reamainingUses.Value = 0;
            discountType.SelectedIndex = -1;
            PopulateDiscountItems();
        }
    }
}
