namespace ChinaExpress.Desktop
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            categoriesBtn = new FontAwesome.Sharp.IconButton();
            productsBtn = new FontAwesome.Sharp.IconButton();
            panelTitleBar = new Panel();
            ordersBtn = new FontAwesome.Sharp.IconButton();
            logoutBtn = new FontAwesome.Sharp.IconButton();
            usersBtn = new FontAwesome.Sharp.IconButton();
            ClosingAppBtn = new FontAwesome.Sharp.IconPictureBox();
            MinimizeBtn = new FontAwesome.Sharp.IconPictureBox();
            panelDesktop = new Panel();
            footerPanel = new Panel();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            button1 = new Button();
            discountsBtn = new FontAwesome.Sharp.IconButton();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ClosingAppBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinimizeBtn).BeginInit();
            panelDesktop.SuspendLayout();
            footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            SuspendLayout();
            // 
            // categoriesBtn
            // 
            categoriesBtn.Dock = DockStyle.Left;
            categoriesBtn.FlatAppearance.BorderSize = 0;
            categoriesBtn.FlatStyle = FlatStyle.Flat;
            categoriesBtn.ForeColor = Color.FromArgb(183, 222, 221);
            categoriesBtn.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            categoriesBtn.IconColor = Color.FromArgb(115, 210, 222);
            categoriesBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            categoriesBtn.IconSize = 32;
            categoriesBtn.ImageAlign = ContentAlignment.MiddleLeft;
            categoriesBtn.Location = new Point(0, 0);
            categoriesBtn.Margin = new Padding(5);
            categoriesBtn.Name = "categoriesBtn";
            categoriesBtn.Padding = new Padding(16, 0, 32, 0);
            categoriesBtn.Size = new Size(238, 119);
            categoriesBtn.TabIndex = 4;
            categoriesBtn.Text = "Categories";
            categoriesBtn.TextAlign = ContentAlignment.MiddleLeft;
            categoriesBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            categoriesBtn.UseVisualStyleBackColor = true;
            categoriesBtn.Click += categoriesBtn_Click;
            // 
            // productsBtn
            // 
            productsBtn.Dock = DockStyle.Left;
            productsBtn.FlatAppearance.BorderSize = 0;
            productsBtn.FlatStyle = FlatStyle.Flat;
            productsBtn.ForeColor = Color.FromArgb(183, 222, 221);
            productsBtn.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek;
            productsBtn.IconColor = Color.FromArgb(115, 210, 222);
            productsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            productsBtn.IconSize = 32;
            productsBtn.ImageAlign = ContentAlignment.MiddleLeft;
            productsBtn.Location = new Point(238, 0);
            productsBtn.Margin = new Padding(5);
            productsBtn.Name = "productsBtn";
            productsBtn.Padding = new Padding(16, 0, 32, 0);
            productsBtn.Size = new Size(204, 119);
            productsBtn.TabIndex = 3;
            productsBtn.Text = "Products";
            productsBtn.TextAlign = ContentAlignment.MiddleLeft;
            productsBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            productsBtn.UseVisualStyleBackColor = true;
            productsBtn.Click += ScheduleBtn_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(1, 45, 60);
            panelTitleBar.Controls.Add(discountsBtn);
            panelTitleBar.Controls.Add(ordersBtn);
            panelTitleBar.Controls.Add(logoutBtn);
            panelTitleBar.Controls.Add(usersBtn);
            panelTitleBar.Controls.Add(ClosingAppBtn);
            panelTitleBar.Controls.Add(productsBtn);
            panelTitleBar.Controls.Add(categoriesBtn);
            panelTitleBar.Controls.Add(MinimizeBtn);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Margin = new Padding(5);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1521, 119);
            panelTitleBar.TabIndex = 1;
            // 
            // ordersBtn
            // 
            ordersBtn.Dock = DockStyle.Left;
            ordersBtn.FlatAppearance.BorderSize = 0;
            ordersBtn.FlatStyle = FlatStyle.Flat;
            ordersBtn.ForeColor = Color.FromArgb(183, 222, 221);
            ordersBtn.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek;
            ordersBtn.IconColor = Color.FromArgb(115, 210, 222);
            ordersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ordersBtn.IconSize = 32;
            ordersBtn.ImageAlign = ContentAlignment.MiddleLeft;
            ordersBtn.Location = new Point(799, 0);
            ordersBtn.Margin = new Padding(5);
            ordersBtn.Name = "ordersBtn";
            ordersBtn.Padding = new Padding(16, 0, 32, 0);
            ordersBtn.Size = new Size(204, 119);
            ordersBtn.TabIndex = 10;
            ordersBtn.Text = "Orders";
            ordersBtn.TextAlign = ContentAlignment.MiddleLeft;
            ordersBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            ordersBtn.UseVisualStyleBackColor = true;
            ordersBtn.Click += ordersBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Dock = DockStyle.Left;
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.FlatStyle = FlatStyle.Flat;
            logoutBtn.ForeColor = Color.FromArgb(183, 222, 221);
            logoutBtn.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            logoutBtn.IconColor = Color.FromArgb(115, 210, 222);
            logoutBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            logoutBtn.IconSize = 32;
            logoutBtn.ImageAlign = ContentAlignment.MiddleLeft;
            logoutBtn.Location = new Point(610, 0);
            logoutBtn.Margin = new Padding(5);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Padding = new Padding(16, 0, 32, 0);
            logoutBtn.Size = new Size(189, 119);
            logoutBtn.TabIndex = 9;
            logoutBtn.Text = "Logout";
            logoutBtn.TextAlign = ContentAlignment.MiddleLeft;
            logoutBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // usersBtn
            // 
            usersBtn.Dock = DockStyle.Left;
            usersBtn.FlatAppearance.BorderSize = 0;
            usersBtn.FlatStyle = FlatStyle.Flat;
            usersBtn.ForeColor = Color.FromArgb(183, 222, 221);
            usersBtn.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            usersBtn.IconColor = Color.FromArgb(115, 210, 222);
            usersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            usersBtn.IconSize = 32;
            usersBtn.ImageAlign = ContentAlignment.MiddleLeft;
            usersBtn.Location = new Point(442, 0);
            usersBtn.Margin = new Padding(5);
            usersBtn.Name = "usersBtn";
            usersBtn.Padding = new Padding(16, 0, 32, 0);
            usersBtn.Size = new Size(168, 119);
            usersBtn.TabIndex = 8;
            usersBtn.Text = "Users";
            usersBtn.TextAlign = ContentAlignment.MiddleLeft;
            usersBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            usersBtn.UseVisualStyleBackColor = true;
            usersBtn.Click += usersBtn_Click;
            // 
            // ClosingAppBtn
            // 
            ClosingAppBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ClosingAppBtn.BackColor = Color.FromArgb(1, 45, 60);
            ClosingAppBtn.ForeColor = Color.IndianRed;
            ClosingAppBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            ClosingAppBtn.IconColor = Color.IndianRed;
            ClosingAppBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ClosingAppBtn.IconSize = 46;
            ClosingAppBtn.Location = new Point(1460, 35);
            ClosingAppBtn.Margin = new Padding(5);
            ClosingAppBtn.Name = "ClosingAppBtn";
            ClosingAppBtn.Size = new Size(47, 46);
            ClosingAppBtn.TabIndex = 7;
            ClosingAppBtn.TabStop = false;
            ClosingAppBtn.Click += ClosingAppBtn_Click;
            ClosingAppBtn.MouseEnter += ClosingAppBtn_MouseEnter;
            ClosingAppBtn.MouseLeave += ClosingAppBtn_MouseLeave;
            // 
            // MinimizeBtn
            // 
            MinimizeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MinimizeBtn.BackColor = Color.FromArgb(1, 45, 60);
            MinimizeBtn.ForeColor = Color.SandyBrown;
            MinimizeBtn.IconChar = FontAwesome.Sharp.IconChar.Minus;
            MinimizeBtn.IconColor = Color.SandyBrown;
            MinimizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MinimizeBtn.IconSize = 46;
            MinimizeBtn.Location = new Point(1403, 35);
            MinimizeBtn.Margin = new Padding(5);
            MinimizeBtn.Name = "MinimizeBtn";
            MinimizeBtn.Size = new Size(47, 46);
            MinimizeBtn.TabIndex = 5;
            MinimizeBtn.TabStop = false;
            MinimizeBtn.Click += MinimizeBtn_Click;
            MinimizeBtn.MouseEnter += MinimizeBtn_MouseHover;
            MinimizeBtn.MouseLeave += MinimizeBtn_MouseLeave;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(183, 222, 221);
            panelDesktop.Controls.Add(footerPanel);
            panelDesktop.Controls.Add(button1);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(0, 119);
            panelDesktop.Margin = new Padding(5);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1521, 721);
            panelDesktop.TabIndex = 3;
            panelDesktop.Paint += panelDesktop_Paint;
            panelDesktop.MouseEnter += panelDesktop_MouseEnter;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.FromArgb(1, 45, 60);
            footerPanel.Controls.Add(iconPictureBox2);
            footerPanel.Controls.Add(iconPictureBox3);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(0, 610);
            footerPanel.Margin = new Padding(5);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(1521, 111);
            footerPanel.TabIndex = 2;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox2.BackColor = Color.FromArgb(1, 45, 60);
            iconPictureBox2.ErrorImage = null;
            iconPictureBox2.ForeColor = Color.FromArgb(1, 45, 60);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Expand;
            iconPictureBox2.IconColor = Color.FromArgb(1, 45, 60);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 46;
            iconPictureBox2.InitialImage = null;
            iconPictureBox2.Location = new Point(2724, 35);
            iconPictureBox2.Margin = new Padding(5);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(47, 46);
            iconPictureBox2.TabIndex = 6;
            iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox3.BackColor = Color.FromArgb(1, 45, 60);
            iconPictureBox3.ErrorImage = null;
            iconPictureBox3.ForeColor = Color.FromArgb(1, 45, 60);
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Minus;
            iconPictureBox3.IconColor = Color.FromArgb(1, 45, 60);
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 46;
            iconPictureBox3.InitialImage = null;
            iconPictureBox3.Location = new Point(2667, 35);
            iconPictureBox3.Margin = new Padding(5);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(47, 46);
            iconPictureBox3.TabIndex = 5;
            iconPictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.empty1;
            button1.Location = new Point(256, 135);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // discountsBtn
            // 
            discountsBtn.Dock = DockStyle.Left;
            discountsBtn.FlatAppearance.BorderSize = 0;
            discountsBtn.FlatStyle = FlatStyle.Flat;
            discountsBtn.ForeColor = Color.FromArgb(183, 222, 221);
            discountsBtn.IconChar = FontAwesome.Sharp.IconChar.Percentage;
            discountsBtn.IconColor = Color.FromArgb(115, 210, 222);
            discountsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            discountsBtn.IconSize = 32;
            discountsBtn.ImageAlign = ContentAlignment.MiddleLeft;
            discountsBtn.Location = new Point(1003, 0);
            discountsBtn.Margin = new Padding(5);
            discountsBtn.Name = "discountsBtn";
            discountsBtn.Padding = new Padding(16, 0, 32, 0);
            discountsBtn.Size = new Size(215, 119);
            discountsBtn.TabIndex = 11;
            discountsBtn.Text = "Discounts";
            discountsBtn.TextAlign = ContentAlignment.MiddleLeft;
            discountsBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            discountsBtn.UseVisualStyleBackColor = true;
            discountsBtn.Click += discountsBtn_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1521, 840);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaBazaar";
            WindowState = FormWindowState.Maximized;
            panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ClosingAppBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinimizeBtn).EndInit();
            panelDesktop.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton categoriesBtn;
        private FontAwesome.Sharp.IconButton productsBtn;
        private Panel panelTitleBar;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox ClosingAppBtn;
        private FontAwesome.Sharp.IconPictureBox MinimizeBtn;
        private Button button1;
        private Panel footerPanel;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconButton usersBtn;
        private FontAwesome.Sharp.IconButton logoutBtn;
        private FontAwesome.Sharp.IconButton ordersBtn;
        private FontAwesome.Sharp.IconButton discountsBtn;
    }
}
