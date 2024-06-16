using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using AutoMapper;
using ChinaExpress.ComplexModelsWithoutHelperReferences;
using ChinaExpress.DataAccess;
using ChinaExpress.Desktop.Properties;
using ChinaExpress.Logic;
using ChinaExpress.SimpleEntityModels.Enums;
using Microsoft.VisualBasic.ApplicationServices;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ChinaExpress.Desktop
{
    public partial class OrdersForm : Form
    {
        private OrdersManager _ordersManager;
        public OrdersForm(HomePage mainForm)
        {
            _ordersManager = new OrdersManager(mainForm.OrdersDbHelper, mainForm.ProductsManager, mainForm.UserManager);
            InitializeComponent();

            LoadOrders(false);
        }

        private void LoadOrders(bool ignoreLimit)
        {
            int? limit = ignoreLimit ? null : 10;
            var orders = this._ordersManager.GetAllActiveOrders(limit);

            tableView.Rows.Clear();
            foreach (var orderDto in orders)
            {
                this.tableView.Rows.Add(new object[] { orderDto.Id,
                    orderDto.OrderDate?.ToShortDateString(),
                    orderDto.Address,
                    orderDto.GetTotalPrice(),
                    $"{orderDto.User.FirstName} {orderDto.User.LastName}",
                    orderDto.OrderStatus.ToString(), Resources.info1,
                    orderDto.OrderStatus == OrderStatus.Requested ? Resources.delivery : Resources.empty1 });
            }
        }

        private void tableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var orderId = (int)tableView.Rows[e.RowIndex].Cells[0].Value;
            if (e.ColumnIndex == 6)
            {
                var order = this._ordersManager.GetOrder(orderId);

                var infMsg = new StringBuilder()
                        .AppendLine($"Order #{orderId}")
                        .AppendLine($"Order Date: {order.OrderDate.Value.ToShortDateString()}")
                        .AppendLine($"Purchased by: {order.User.FirstName} {order.User.LastName}")
                        .AppendLine($"Delivery Address: {order.Address}")
                        .AppendLine($"Purchased items: {order.GetOrderItems().Count} qty - {order.GetTotalPrice():f2} $");

                order.GetOrderItems()
                    .ToList()
                    .ForEach(oi =>
                        infMsg.AppendLine($"  - {oi.Product} " +
                                          $"{(oi.SelectedTags.Any() ? string.Join(", ", oi.SelectedTags) : "")}" +
                                          $" - {oi.Quantity} qty"));

                MessageBox.Show(infMsg.ToString().Trim());
            }
            else if (e.ColumnIndex == 7)
            {
                try
                {
                    this._ordersManager.SendOrder(orderId);
                    MessageBox.Show($"Order has been sent!", "Order sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadOrders(false);
            }
        }

        private void viewAllOrders_Click(object sender, EventArgs e)
        {
            LoadOrders(true);
        }
    }
}
