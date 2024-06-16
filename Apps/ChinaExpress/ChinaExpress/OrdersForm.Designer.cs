namespace ChinaExpress.Desktop
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tableView = new DataGridView();
            Nº = new DataGridViewTextBoxColumn();
            OrderDate = new DataGridViewTextBoxColumn();
            DeliveryAddress = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            User = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Info = new DataGridViewImageColumn();
            Send = new DataGridViewImageColumn();
            viewAllOrders = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(viewAllOrders);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tableView);
            panel2.Location = new Point(52, 261);
            panel2.Name = "panel2";
            panel2.Size = new Size(2138, 1059);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 45, 60);
            panel3.Location = new Point(998, 308);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 2);
            panel3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cargo;
            pictureBox1.Location = new Point(1022, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(1, 45, 60);
            label1.Location = new Point(1034, 17);
            label1.Name = "label1";
            label1.Size = new Size(182, 56);
            label1.TabIndex = 2;
            label1.Text = "Orders";
            // 
            // tableView
            // 
            tableView.AllowUserToAddRows = false;
            tableView.AllowUserToDeleteRows = false;
            tableView.AllowUserToResizeColumns = false;
            tableView.AllowUserToResizeRows = false;
            tableView.BackgroundColor = Color.White;
            tableView.BorderStyle = BorderStyle.None;
            tableView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tableView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(1, 45, 60);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(183, 222, 221);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(79, 93, 117);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(183, 222, 221);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableView.Columns.AddRange(new DataGridViewColumn[] { Nº, OrderDate, DeliveryAddress, TotalPrice, User, Status, Info, Send });
            tableView.EnableHeadersVisualStyles = false;
            tableView.Location = new Point(6, 329);
            tableView.Margin = new Padding(6);
            tableView.Name = "tableView";
            tableView.RowHeadersVisible = false;
            tableView.RowHeadersWidth = 82;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            tableView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableView.Size = new Size(2103, 724);
            tableView.TabIndex = 1;
            tableView.CellClick += tableView_CellClick;
            tableView.CellContentClick += tableView_CellContentClick;
            // 
            // Nº
            // 
            Nº.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nº.FillWeight = 25F;
            Nº.HeaderText = "Nº";
            Nº.MinimumWidth = 25;
            Nº.Name = "Nº";
            // 
            // OrderDate
            // 
            OrderDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OrderDate.HeaderText = "Order Date";
            OrderDate.MinimumWidth = 10;
            OrderDate.Name = "OrderDate";
            // 
            // DeliveryAddress
            // 
            DeliveryAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DeliveryAddress.FillWeight = 300F;
            DeliveryAddress.HeaderText = "Delivery Address";
            DeliveryAddress.MinimumWidth = 300;
            DeliveryAddress.Name = "DeliveryAddress";
            // 
            // TotalPrice
            // 
            TotalPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalPrice.HeaderText = "Total Price";
            TotalPrice.MinimumWidth = 100;
            TotalPrice.Name = "TotalPrice";
            // 
            // User
            // 
            User.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            User.FillWeight = 70F;
            User.HeaderText = "User";
            User.MinimumWidth = 10;
            User.Name = "User";
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 10;
            Status.Name = "Status";
            Status.Width = 200;
            // 
            // Info
            // 
            Info.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Info.FillWeight = 50F;
            Info.HeaderText = "Info";
            Info.MinimumWidth = 50;
            Info.Name = "Info";
            // 
            // Send
            // 
            Send.HeaderText = "Send";
            Send.MinimumWidth = 100;
            Send.Name = "Send";
            Send.Width = 200;
            // 
            // viewAllOrders
            // 
            viewAllOrders.BackColor = Color.FromArgb(1, 45, 60);
            viewAllOrders.FlatStyle = FlatStyle.Flat;
            viewAllOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            viewAllOrders.ForeColor = SystemColors.ButtonHighlight;
            viewAllOrders.Location = new Point(1250, 168);
            viewAllOrders.Name = "viewAllOrders";
            viewAllOrders.Size = new Size(274, 72);
            viewAllOrders.TabIndex = 19;
            viewAllOrders.Text = "View All Orders";
            viewAllOrders.UseVisualStyleBackColor = false;
            viewAllOrders.Click += viewAllOrders_Click;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(2223, 1364);
            Controls.Add(panel2);
            Name = "OrdersForm";
            Text = "OrdersForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView tableView;
        private DataGridViewTextBoxColumn Nº;
        private DataGridViewTextBoxColumn OrderDate;
        private DataGridViewTextBoxColumn DeliveryAddress;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewImageColumn Info;
        private DataGridViewImageColumn Send;
        private Button viewAllOrders;
    }
}