namespace ChinaExpress.Desktop
{
    partial class ProductsForm
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
            panel1 = new Panel();
            searchBtn = new FontAwesome.Sharp.IconButton();
            searchBox = new TextBox();
            addComboBoxBtn = new FontAwesome.Sharp.IconButton();
            addProductBtn = new FontAwesome.Sharp.IconButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cardListItem1 = new CardListItem();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(searchBtn);
            panel1.Controls.Add(searchBox);
            panel1.Controls.Add(addComboBoxBtn);
            panel1.Controls.Add(addProductBtn);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(58, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(2804, 1101);
            panel1.TabIndex = 0;
            // 
            // searchBtn
            // 
            searchBtn.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            searchBtn.IconColor = Color.Black;
            searchBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchBtn.Location = new Point(1469, 230);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(57, 57);
            searchBtn.TabIndex = 13;
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchBox
            // 
            searchBox.BackColor = Color.FromArgb(183, 222, 221);
            searchBox.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            searchBox.Location = new Point(1151, 230);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(312, 57);
            searchBox.TabIndex = 12;
            searchBox.KeyUp += searchBox_KeyUp;
            // 
            // addComboBoxBtn
            // 
            addComboBoxBtn.BackColor = Color.Coral;
            addComboBoxBtn.FlatStyle = FlatStyle.Flat;
            addComboBoxBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            addComboBoxBtn.ForeColor = SystemColors.ActiveCaptionText;
            addComboBoxBtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addComboBoxBtn.IconColor = Color.Black;
            addComboBoxBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addComboBoxBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addComboBoxBtn.Location = new Point(1273, 143);
            addComboBoxBtn.Name = "addComboBoxBtn";
            addComboBoxBtn.Size = new Size(275, 54);
            addComboBoxBtn.TabIndex = 11;
            addComboBoxBtn.Text = "Add Combo Box";
            addComboBoxBtn.TextAlign = ContentAlignment.MiddleRight;
            addComboBoxBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            addComboBoxBtn.UseVisualStyleBackColor = false;
            addComboBoxBtn.Click += addComboBoxBtn_Click;
            // 
            // addProductBtn
            // 
            addProductBtn.BackColor = Color.FromArgb(0, 192, 0);
            addProductBtn.FlatStyle = FlatStyle.Flat;
            addProductBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            addProductBtn.ForeColor = SystemColors.ActiveCaptionText;
            addProductBtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addProductBtn.IconColor = Color.Black;
            addProductBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addProductBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addProductBtn.Location = new Point(1298, 83);
            addProductBtn.Name = "addProductBtn";
            addProductBtn.Size = new Size(237, 54);
            addProductBtn.TabIndex = 10;
            addProductBtn.Text = "Add Product";
            addProductBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            addProductBtn.UseVisualStyleBackColor = false;
            addProductBtn.Click += addProductBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(cardListItem1);
            flowLayoutPanel1.Location = new Point(23, 327);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(2773, 736);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // cardListItem1
            // 
            cardListItem1.Image = null;
            cardListItem1.ItemId = 0;
            cardListItem1.Location = new Point(3, 3);
            cardListItem1.Name = "cardListItem1";
            cardListItem1.Price = "0.00 $";
            cardListItem1.ProductId = 0;
            cardListItem1.Quantity = null;
            cardListItem1.Size = new Size(447, 555);
            cardListItem1.TabIndex = 1;
            cardListItem1.Title = "Product name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(1, 45, 60);
            label1.Location = new Point(1298, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 56);
            label1.TabIndex = 7;
            label1.Text = "Products";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.shopping_bag;
            pictureBox1.Location = new Point(1093, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(146, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(2939, 1211);
            Controls.Add(panel1);
            Name = "ProductsForm";
            Text = "ProductsForm";
            Load += ProductsForm_Load;
            MouseEnter += ProductsForm_MouseEnter;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton addComboBoxBtn;
        private FontAwesome.Sharp.IconButton addProductBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private CardListItem cardListItem1;
        private Label label1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton searchBtn;
        private TextBox searchBox;
    }
}