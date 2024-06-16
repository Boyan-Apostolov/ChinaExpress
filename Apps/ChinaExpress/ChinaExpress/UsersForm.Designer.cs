namespace ChinaExpress.Desktop
{
    partial class UsersForm
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
            addUserBtn = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tableView = new DataGridView();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewImageColumn();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(addUserBtn);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tableView);
            panel2.Location = new Point(22, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(1509, 843);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 45, 60);
            panel3.Location = new Point(495, 287);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 2);
            panel3.TabIndex = 8;
            // 
            // addUserBtn
            // 
            addUserBtn.BackColor = Color.FromArgb(0, 192, 0);
            addUserBtn.FlatStyle = FlatStyle.Flat;
            addUserBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            addUserBtn.ForeColor = SystemColors.ActiveCaptionText;
            addUserBtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addUserBtn.IconColor = Color.Black;
            addUserBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addUserBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addUserBtn.Location = new Point(755, 172);
            addUserBtn.Name = "addUserBtn";
            addUserBtn.Size = new Size(178, 54);
            addUserBtn.TabIndex = 6;
            addUserBtn.Text = "Add User";
            addUserBtn.TextAlign = ContentAlignment.MiddleRight;
            addUserBtn.UseVisualStyleBackColor = false;
            addUserBtn.Click += addUserBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.team;
            pictureBox1.Location = new Point(517, 66);
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
            label1.Location = new Point(765, 81);
            label1.Name = "label1";
            label1.Size = new Size(159, 56);
            label1.TabIndex = 2;
            label1.Text = "Users";
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
            tableView.Columns.AddRange(new DataGridViewColumn[] { FirstName, LastName, Phone, Email, Role, Edit });
            tableView.EnableHeadersVisualStyles = false;
            tableView.Location = new Point(60, 329);
            tableView.Margin = new Padding(6);
            tableView.Name = "tableView";
            tableView.RowHeadersVisible = false;
            tableView.RowHeadersWidth = 82;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            tableView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableView.Size = new Size(1377, 367);
            tableView.TabIndex = 1;
            tableView.CellClick += tableView_CellClick;
            // 
            // FirstName
            // 
            FirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FirstName.HeaderText = "First Name";
            FirstName.MinimumWidth = 100;
            FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            LastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LastName.HeaderText = "Last Name";
            LastName.MinimumWidth = 10;
            LastName.Name = "LastName";
            // 
            // Phone
            // 
            Phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Phone.HeaderText = "Phone";
            Phone.MinimumWidth = 10;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 10;
            Email.Name = "Email";
            // 
            // Role
            // 
            Role.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Role.FillWeight = 70F;
            Role.HeaderText = "Role";
            Role.MinimumWidth = 10;
            Role.Name = "Role";
            // 
            // Edit
            // 
            Edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Edit.FillWeight = 30F;
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 10;
            Edit.Name = "Edit";
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(1609, 906);
            Controls.Add(panel2);
            Name = "UsersForm";
            Text = "UsersForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton addUserBtn;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView tableView;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewImageColumn Edit;
    }
}