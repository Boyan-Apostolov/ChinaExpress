using System.Windows.Forms;

namespace ChinaExpress.Desktop
{
    partial class DiscountsForm
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
            tableView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            GridColumnName = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewImageColumn();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            discountType = new ComboBox();
            reamainingUses = new NumericUpDown();
            discountValue = new NumericUpDown();
            panel2 = new Panel();
            addCategoryBtn = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label5 = new Label();
            codeInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reamainingUses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)discountValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            tableView.Columns.AddRange(new DataGridViewColumn[] { Id, Code, Value, GridColumnName, Delete });
            tableView.EnableHeadersVisualStyles = false;
            tableView.Location = new Point(193, 340);
            tableView.Margin = new Padding(6);
            tableView.Name = "tableView";
            tableView.RowHeadersVisible = false;
            tableView.RowHeadersWidth = 82;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            tableView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableView.Size = new Size(1022, 503);
            tableView.TabIndex = 1;
            tableView.CellClick += tableView_CellClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 100;
            Id.Name = "Id";
            Id.Width = 200;
            // 
            // Code
            // 
            Code.HeaderText = "Code";
            Code.MinimumWidth = 10;
            Code.Name = "Code";
            Code.Width = 200;
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.MinimumWidth = 10;
            Value.Name = "Value";
            Value.Width = 200;
            // 
            // GridColumnName
            // 
            GridColumnName.HeaderText = "Remainig Uses";
            GridColumnName.MinimumWidth = 10;
            GridColumnName.Name = "GridColumnName";
            GridColumnName.Width = 300;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 10;
            Delete.Name = "Delete";
            Delete.Width = 120;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(codeInput);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(discountType);
            panel1.Controls.Add(reamainingUses);
            panel1.Controls.Add(discountValue);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(addCategoryBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tableView);
            panel1.Location = new Point(60, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1460, 843);
            panel1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(1, 45, 60);
            label4.Location = new Point(637, 189);
            label4.Name = "label4";
            label4.Size = new Size(81, 36);
            label4.TabIndex = 14;
            label4.Text = "Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(1, 45, 60);
            label3.Location = new Point(885, 190);
            label3.Name = "label3";
            label3.Size = new Size(247, 36);
            label3.TabIndex = 13;
            label3.Text = "Remaining Uses";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(1, 45, 60);
            label2.Location = new Point(140, 190);
            label2.Name = "label2";
            label2.Size = new Size(93, 36);
            label2.TabIndex = 12;
            label2.Text = "Value";
            // 
            // discountType
            // 
            discountType.BackColor = Color.FromArgb(183, 222, 221);
            discountType.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            discountType.FormattingEnabled = true;
            discountType.Location = new Point(637, 228);
            discountType.Name = "discountType";
            discountType.Size = new Size(242, 58);
            discountType.TabIndex = 11;
            // 
            // reamainingUses
            // 
            reamainingUses.BackColor = Color.FromArgb(183, 222, 221);
            reamainingUses.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            reamainingUses.Location = new Point(885, 229);
            reamainingUses.Name = "reamainingUses";
            reamainingUses.Size = new Size(240, 57);
            reamainingUses.TabIndex = 10;
            reamainingUses.ValueChanged += reamainingUses_ValueChanged;
            // 
            // discountValue
            // 
            discountValue.BackColor = Color.FromArgb(183, 222, 221);
            discountValue.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            discountValue.Location = new Point(140, 229);
            discountValue.Name = "discountValue";
            discountValue.Size = new Size(240, 57);
            discountValue.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 45, 60);
            panel2.Location = new Point(181, 292);
            panel2.Name = "panel2";
            panel2.Size = new Size(1044, 2);
            panel2.TabIndex = 8;
            // 
            // addCategoryBtn
            // 
            addCategoryBtn.BackColor = Color.FromArgb(0, 192, 0);
            addCategoryBtn.FlatStyle = FlatStyle.Flat;
            addCategoryBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            addCategoryBtn.ForeColor = SystemColors.ActiveCaptionText;
            addCategoryBtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addCategoryBtn.IconColor = Color.Black;
            addCategoryBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addCategoryBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addCategoryBtn.Location = new Point(1131, 232);
            addCategoryBtn.Name = "addCategoryBtn";
            addCategoryBtn.Size = new Size(236, 54);
            addCategoryBtn.TabIndex = 6;
            addCategoryBtn.Text = "Add Discount";
            addCategoryBtn.TextAlign = ContentAlignment.MiddleRight;
            addCategoryBtn.UseVisualStyleBackColor = false;
            addCategoryBtn.Click += addCategoryBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.discount;
            pictureBox1.Location = new Point(383, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(146, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(1, 45, 60);
            label1.Location = new Point(560, 70);
            label1.Name = "label1";
            label1.Size = new Size(256, 56);
            label1.TabIndex = 2;
            label1.Text = "Discounts";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(1, 45, 60);
            label5.Location = new Point(386, 190);
            label5.Name = "label5";
            label5.Size = new Size(89, 36);
            label5.TabIndex = 16;
            label5.Text = "Code";
            // 
            // codeInput
            // 
            codeInput.BackColor = Color.FromArgb(183, 222, 221);
            codeInput.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            codeInput.Location = new Point(386, 230);
            codeInput.Name = "codeInput";
            codeInput.Size = new Size(245, 57);
            codeInput.TabIndex = 17;
            // 
            // DiscountsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(1579, 913);
            Controls.Add(panel1);
            Name = "DiscountsForm";
            Text = "CategoriesForm";
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reamainingUses).EndInit();
            ((System.ComponentModel.ISupportInitialize)discountValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tableView;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton addCategoryBtn;
        private NumericUpDown discountValue;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox discountType;
        private NumericUpDown reamainingUses;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn GridColumnName;
        private DataGridViewImageColumn Delete;
        private TextBox codeInput;
        private Label label5;
    }
}