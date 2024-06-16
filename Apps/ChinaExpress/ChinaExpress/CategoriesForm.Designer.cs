using System.Windows.Forms;

namespace ChinaExpress.Desktop
{
    partial class CategoriesForm
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
            GridColumnName = new DataGridViewTextBoxColumn();
            Items = new DataGridViewTextBoxColumn();
            Features = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewImageColumn();
            panel1 = new Panel();
            label3 = new Label();
            featuresCheckedBox = new CheckedListBox();
            label2 = new Label();
            panel2 = new Panel();
            newCategoryText = new TextBox();
            addCategoryBtn = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            panel1.SuspendLayout();
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
            tableView.Columns.AddRange(new DataGridViewColumn[] { Id, GridColumnName, Items, Features, Delete });
            tableView.EnableHeadersVisualStyles = false;
            tableView.Location = new Point(33, 316);
            tableView.Margin = new Padding(6);
            tableView.Name = "tableView";
            tableView.RowHeadersVisible = false;
            tableView.RowHeadersWidth = 82;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            tableView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableView.Size = new Size(1123, 509);
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
            // GridColumnName
            // 
            GridColumnName.HeaderText = "Name";
            GridColumnName.MinimumWidth = 10;
            GridColumnName.Name = "GridColumnName";
            GridColumnName.Width = 300;
            // 
            // Items
            // 
            Items.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Items.HeaderText = "№ Items";
            Items.MinimumWidth = 100;
            Items.Name = "Items";
            Items.Width = 200;
            // 
            // Features
            // 
            Features.HeaderText = "Features";
            Features.MinimumWidth = 10;
            Features.Name = "Features";
            Features.Width = 300;
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
            panel1.Controls.Add(label3);
            panel1.Controls.Add(featuresCheckedBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(newCategoryText);
            panel1.Controls.Add(addCategoryBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tableView);
            panel1.Location = new Point(40, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(1683, 914);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1246, 440);
            label3.Name = "label3";
            label3.Size = new Size(109, 32);
            label3.TabIndex = 11;
            label3.Text = "Features:";
            // 
            // featuresCheckedBox
            // 
            featuresCheckedBox.BackColor = Color.FromArgb(183, 222, 221);
            featuresCheckedBox.FormattingEnabled = true;
            featuresCheckedBox.Location = new Point(1246, 486);
            featuresCheckedBox.Name = "featuresCheckedBox";
            featuresCheckedBox.Size = new Size(290, 184);
            featuresCheckedBox.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1246, 311);
            label2.Name = "label2";
            label2.Size = new Size(83, 32);
            label2.TabIndex = 9;
            label2.Text = "Name:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 45, 60);
            panel2.Location = new Point(1209, 314);
            panel2.Name = "panel2";
            panel2.Size = new Size(2, 509);
            panel2.TabIndex = 8;
            // 
            // newCategoryText
            // 
            newCategoryText.BackColor = Color.FromArgb(183, 222, 221);
            newCategoryText.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            newCategoryText.Location = new Point(1246, 360);
            newCategoryText.Name = "newCategoryText";
            newCategoryText.Size = new Size(290, 57);
            newCategoryText.TabIndex = 7;
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
            addCategoryBtn.Location = new Point(1246, 741);
            addCategoryBtn.Name = "addCategoryBtn";
            addCategoryBtn.Size = new Size(236, 54);
            addCategoryBtn.TabIndex = 6;
            addCategoryBtn.Text = "Add Category";
            addCategoryBtn.TextAlign = ContentAlignment.MiddleRight;
            addCategoryBtn.UseVisualStyleBackColor = false;
            addCategoryBtn.Click += addCategoryBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bookmark;
            pictureBox1.Location = new Point(706, 50);
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
            label1.Location = new Point(883, 101);
            label1.Name = "label1";
            label1.Size = new Size(273, 56);
            label1.TabIndex = 2;
            label1.Text = "Categories";
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(1758, 1014);
            Controls.Add(panel1);
            Name = "CategoriesForm";
            Text = "CategoriesForm";
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tableView;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private TextBox newCategoryText;
        private FontAwesome.Sharp.IconButton addCategoryBtn;
        private Label label3;
        private CheckedListBox featuresCheckedBox;
        private Label label2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn GridColumnName;
        private DataGridViewTextBoxColumn Items;
        private DataGridViewTextBoxColumn Features;
        private DataGridViewImageColumn Delete;
    }
}