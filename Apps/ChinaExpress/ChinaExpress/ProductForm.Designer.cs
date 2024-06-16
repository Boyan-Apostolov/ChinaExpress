namespace ChinaExpress.Desktop
{
    partial class ProductForm
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
            pictureBox = new PictureBox();
            titleLabel = new Label();
            label2 = new Label();
            nameTxB = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            descriptionTxb = new RichTextBox();
            panel3 = new Panel();
            photoUrlTxb = new TextBox();
            label4 = new Label();
            priceInput = new NumericUpDown();
            priceLabel = new Label();
            panel6 = new Panel();
            label7 = new Label();
            categoryInput = new ComboBox();
            createProductBtn = new Button();
            panel7 = new Panel();
            discountSelectPanel = new Panel();
            discountTypeSelect = new ComboBox();
            panel9 = new Panel();
            label1 = new Label();
            quantityPanel = new Panel();
            quantityInput = new NumericUpDown();
            panel8 = new Panel();
            label5 = new Label();
            pricePanel = new Panel();
            panel10 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            panel7.SuspendLayout();
            discountSelectPanel.SuspendLayout();
            quantityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quantityInput).BeginInit();
            pricePanel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.logo;
            pictureBox.Location = new Point(345, 115);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(385, 316);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.FromArgb(1, 45, 60);
            titleLabel.Location = new Point(369, 34);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(319, 56);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "New Product";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(1, 45, 60);
            label2.Location = new Point(345, 466);
            label2.Name = "label2";
            label2.Size = new Size(103, 37);
            label2.TabIndex = 4;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // nameTxB
            // 
            nameTxB.BackColor = Color.FromArgb(183, 222, 221);
            nameTxB.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            nameTxB.Location = new Point(521, 464);
            nameTxB.Name = "nameTxB";
            nameTxB.Size = new Size(200, 46);
            nameTxB.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 45, 60);
            panel1.Location = new Point(345, 519);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 2);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 45, 60);
            panel2.Location = new Point(108, 980);
            panel2.Name = "panel2";
            panel2.Size = new Size(806, 2);
            panel2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(1, 45, 60);
            label3.Location = new Point(425, 711);
            label3.Name = "label3";
            label3.Size = new Size(195, 37);
            label3.TabIndex = 7;
            label3.Text = "Description";
            // 
            // descriptionTxb
            // 
            descriptionTxb.BackColor = Color.FromArgb(183, 222, 221);
            descriptionTxb.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionTxb.Location = new Point(119, 766);
            descriptionTxb.Name = "descriptionTxb";
            descriptionTxb.Size = new Size(787, 192);
            descriptionTxb.TabIndex = 10;
            descriptionTxb.Text = "";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 45, 60);
            panel3.Location = new Point(108, 605);
            panel3.Name = "panel3";
            panel3.Size = new Size(385, 2);
            panel3.TabIndex = 9;
            // 
            // photoUrlTxb
            // 
            photoUrlTxb.BackColor = Color.FromArgb(183, 222, 221);
            photoUrlTxb.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            photoUrlTxb.Location = new Point(284, 550);
            photoUrlTxb.Name = "photoUrlTxb";
            photoUrlTxb.Size = new Size(200, 46);
            photoUrlTxb.TabIndex = 8;
            photoUrlTxb.TextChanged += photoUrlTxb_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(1, 45, 60);
            label4.Location = new Point(108, 552);
            label4.Name = "label4";
            label4.Size = new Size(159, 37);
            label4.TabIndex = 7;
            label4.Text = "Photo Url";
            // 
            // priceInput
            // 
            priceInput.BackColor = Color.FromArgb(183, 222, 221);
            priceInput.DecimalPlaces = 2;
            priceInput.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            priceInput.Location = new Point(171, 13);
            priceInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(209, 39);
            priceInput.TabIndex = 16;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            priceLabel.ForeColor = Color.FromArgb(1, 45, 60);
            priceLabel.Location = new Point(15, 13);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(96, 37);
            priceLabel.TabIndex = 14;
            priceLabel.Text = "Price";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(1, 45, 60);
            panel6.Location = new Point(99, 692);
            panel6.Name = "panel6";
            panel6.Size = new Size(385, 2);
            panel6.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(1, 45, 60);
            label7.Location = new Point(99, 639);
            label7.Name = "label7";
            label7.Size = new Size(155, 37);
            label7.TabIndex = 10;
            label7.Text = "Category";
            // 
            // categoryInput
            // 
            categoryInput.BackColor = Color.FromArgb(183, 222, 221);
            categoryInput.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            categoryInput.FormattingEnabled = true;
            categoryInput.Location = new Point(284, 634);
            categoryInput.Name = "categoryInput";
            categoryInput.Size = new Size(200, 48);
            categoryInput.TabIndex = 17;
            // 
            // createProductBtn
            // 
            createProductBtn.BackColor = Color.FromArgb(1, 45, 60);
            createProductBtn.FlatStyle = FlatStyle.Flat;
            createProductBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createProductBtn.ForeColor = SystemColors.ButtonHighlight;
            createProductBtn.Location = new Point(379, 999);
            createProductBtn.Name = "createProductBtn";
            createProductBtn.Size = new Size(274, 72);
            createProductBtn.TabIndex = 18;
            createProductBtn.Text = "Create product";
            createProductBtn.UseVisualStyleBackColor = false;
            createProductBtn.Click += createProductBtn_Click;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.None;
            panel7.Controls.Add(pricePanel);
            panel7.Controls.Add(discountSelectPanel);
            panel7.Controls.Add(quantityPanel);
            panel7.Controls.Add(descriptionTxb);
            panel7.Controls.Add(createProductBtn);
            panel7.Controls.Add(pictureBox);
            panel7.Controls.Add(categoryInput);
            panel7.Controls.Add(titleLabel);
            panel7.Controls.Add(panel6);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(nameTxB);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(panel1);
            panel7.Controls.Add(panel2);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(photoUrlTxb);
            panel7.Controls.Add(panel3);
            panel7.Location = new Point(52, 45);
            panel7.Name = "panel7";
            panel7.Size = new Size(1010, 1096);
            panel7.TabIndex = 19;
            // 
            // discountSelectPanel
            // 
            discountSelectPanel.Controls.Add(discountTypeSelect);
            discountSelectPanel.Controls.Add(panel9);
            discountSelectPanel.Controls.Add(label1);
            discountSelectPanel.Location = new Point(521, 537);
            discountSelectPanel.Name = "discountSelectPanel";
            discountSelectPanel.Size = new Size(400, 88);
            discountSelectPanel.TabIndex = 20;
            // 
            // discountTypeSelect
            // 
            discountTypeSelect.BackColor = Color.FromArgb(183, 222, 221);
            discountTypeSelect.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            discountTypeSelect.FormattingEnabled = true;
            discountTypeSelect.Location = new Point(168, 12);
            discountTypeSelect.Name = "discountTypeSelect";
            discountTypeSelect.Size = new Size(225, 48);
            discountTypeSelect.TabIndex = 21;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(1, 45, 60);
            panel9.Location = new Point(8, 70);
            panel9.Name = "panel9";
            panel9.Size = new Size(385, 2);
            panel9.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(1, 45, 60);
            label1.Location = new Point(8, 17);
            label1.Name = "label1";
            label1.Size = new Size(154, 37);
            label1.TabIndex = 14;
            label1.Text = "Discount";
            // 
            // quantityPanel
            // 
            quantityPanel.Controls.Add(quantityInput);
            quantityPanel.Controls.Add(panel8);
            quantityPanel.Controls.Add(label5);
            quantityPanel.Location = new Point(521, 537);
            quantityPanel.Name = "quantityPanel";
            quantityPanel.Size = new Size(400, 88);
            quantityPanel.TabIndex = 19;
            // 
            // quantityInput
            // 
            quantityInput.BackColor = Color.FromArgb(183, 222, 221);
            quantityInput.Location = new Point(174, 19);
            quantityInput.Name = "quantityInput";
            quantityInput.Size = new Size(209, 39);
            quantityInput.TabIndex = 16;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(1, 45, 60);
            panel8.Location = new Point(8, 70);
            panel8.Name = "panel8";
            panel8.Size = new Size(385, 2);
            panel8.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(1, 45, 60);
            label5.Location = new Point(8, 17);
            label5.Name = "label5";
            label5.Size = new Size(146, 37);
            label5.TabIndex = 14;
            label5.Text = "Quantity";
            // 
            // pricePanel
            // 
            pricePanel.Controls.Add(panel10);
            pricePanel.Controls.Add(priceInput);
            pricePanel.Controls.Add(priceLabel);
            pricePanel.Location = new Point(518, 616);
            pricePanel.Name = "pricePanel";
            pricePanel.Size = new Size(400, 78);
            pricePanel.TabIndex = 22;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(1, 45, 60);
            panel10.Location = new Point(8, 70);
            panel10.Name = "panel10";
            panel10.Size = new Size(385, 2);
            panel10.TabIndex = 15;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(1141, 1198);
            Controls.Add(panel7);
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add new product";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            discountSelectPanel.ResumeLayout(false);
            discountSelectPanel.PerformLayout();
            quantityPanel.ResumeLayout(false);
            quantityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)quantityInput).EndInit();
            pricePanel.ResumeLayout(false);
            pricePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Label titleLabel;
        private Label label2;
        private TextBox nameTxB;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private RichTextBox descriptionTxb;
        private Panel panel3;
        private TextBox photoUrlTxb;
        private Label label4;
        private NumericUpDown priceInput;
        private Label priceLabel;
        private Panel panel6;
        private Label label7;
        private ComboBox categoryInput;
        private Button createProductBtn;
        private Panel panel7;
        private Panel quantityPanel;
        private NumericUpDown quantityInput;
        private Panel panel8;
        private Label label5;
        private Panel discountSelectPanel;
        private ComboBox discountTypeSelect;
        private Panel panel9;
        private Label label1;
        private Panel pricePanel;
        private Panel panel10;
    }
}