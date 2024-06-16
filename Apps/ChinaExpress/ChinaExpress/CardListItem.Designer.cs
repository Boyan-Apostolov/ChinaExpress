namespace ChinaExpress.Desktop
{
    partial class CardListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            TitleLabel = new Label();
            priceLabel = new Label();
            editBtn = new Button();
            deleteBtn = new Button();
            panel2 = new Panel();
            quantityLabel = new Label();
            selectItemCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.logo;
            pictureBox.Location = new Point(62, 30);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(366, 295);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.AllowDrop = true;
            TitleLabel.Font = new Font("Arial", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.ForeColor = Color.FromArgb(1, 45, 60);
            TitleLabel.Location = new Point(41, 345);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(423, 56);
            TitleLabel.TabIndex = 3;
            TitleLabel.Text = "Title";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Arial", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            priceLabel.ForeColor = Color.FromArgb(1, 45, 60);
            priceLabel.Location = new Point(48, 418);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(82, 33);
            priceLabel.TabIndex = 5;
            priceLabel.Text = "Price";
            // 
            // editBtn
            // 
            editBtn.BackColor = Color.FromArgb(255, 128, 0);
            editBtn.FlatStyle = FlatStyle.Flat;
            editBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            editBtn.ForeColor = SystemColors.ButtonFace;
            editBtn.Location = new Point(48, 485);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(150, 46);
            editBtn.TabIndex = 6;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = false;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.IndianRed;
            deleteBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            deleteBtn.ForeColor = SystemColors.ButtonFace;
            deleteBtn.Location = new Point(297, 485);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(150, 46);
            deleteBtn.TabIndex = 6;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 45, 60);
            panel2.Location = new Point(3, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(425, 2);
            panel2.TabIndex = 8;
            // 
            // quantityLabel
            // 
            quantityLabel.Font = new Font("Arial", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            quantityLabel.Location = new Point(297, 418);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(156, 53);
            quantityLabel.TabIndex = 9;
            quantityLabel.Text = "Quantity";
            quantityLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // selectItemCheckbox
            // 
            selectItemCheckbox.AutoSize = true;
            selectItemCheckbox.Location = new Point(16, 30);
            selectItemCheckbox.Name = "selectItemCheckbox";
            selectItemCheckbox.Size = new Size(28, 27);
            selectItemCheckbox.TabIndex = 10;
            selectItemCheckbox.UseVisualStyleBackColor = true;
            selectItemCheckbox.CheckedChanged += selectItemCheckbox_CheckedChanged;
            // 
            // CardListItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(selectItemCheckbox);
            Controls.Add(quantityLabel);
            Controls.Add(panel2);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(priceLabel);
            Controls.Add(TitleLabel);
            Controls.Add(pictureBox);
            Name = "CardListItem";
            Size = new Size(503, 575);
            Load += CardListItem_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label TitleLabel;
        private Label priceLabel;
        private Button editBtn;
        private Button deleteBtn;
        private Panel panel2;
        private Label quantityLabel;
        private CheckBox selectItemCheckbox;
    }
}
