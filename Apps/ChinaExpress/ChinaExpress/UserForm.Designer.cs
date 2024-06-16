namespace ChinaExpress.Desktop
{
    partial class UserForm
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
            panel2 = new Panel();
            addUserBtn = new FontAwesome.Sharp.IconButton();
            rolesComboBox = new ComboBox();
            label8 = new Label();
            passwordInput = new TextBox();
            repeatPasswordInput = new TextBox();
            label2 = new Label();
            label7 = new Label();
            phoneTb = new TextBox();
            emailTb = new TextBox();
            label6 = new Label();
            panel7 = new Panel();
            panel5 = new Panel();
            lastNameTb = new TextBox();
            label5 = new Label();
            firstNameTb = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            titleLabel = new Label();
            passwordInputsPanel = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            passwordInputsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(passwordInputsPanel);
            panel2.Controls.Add(addUserBtn);
            panel2.Controls.Add(rolesComboBox);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(phoneTb);
            panel2.Controls.Add(emailTb);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(lastNameTb);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(firstNameTb);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(titleLabel);
            panel2.Location = new Point(77, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1509, 913);
            panel2.TabIndex = 5;
            // 
            // addUserBtn
            // 
            addUserBtn.BackColor = Color.FromArgb(0, 192, 0);
            addUserBtn.FlatStyle = FlatStyle.Flat;
            addUserBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addUserBtn.ForeColor = SystemColors.ActiveCaptionText;
            addUserBtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addUserBtn.IconColor = Color.Black;
            addUserBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addUserBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addUserBtn.Location = new Point(661, 760);
            addUserBtn.Name = "addUserBtn";
            addUserBtn.Size = new Size(212, 54);
            addUserBtn.TabIndex = 63;
            addUserBtn.Text = "Add User";
            addUserBtn.TextAlign = ContentAlignment.MiddleRight;
            addUserBtn.UseVisualStyleBackColor = false;
            addUserBtn.Click += addUserBtn_Click;
            // 
            // rolesComboBox
            // 
            rolesComboBox.FormattingEnabled = true;
            rolesComboBox.Location = new Point(719, 681);
            rolesComboBox.Name = "rolesComboBox";
            rolesComboBox.Size = new Size(242, 40);
            rolesComboBox.TabIndex = 62;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(79, 93, 117);
            label8.Location = new Point(616, 680);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(96, 37);
            label8.TabIndex = 61;
            label8.Text = "Role:";
            // 
            // passwordInput
            // 
            passwordInput.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordInput.Location = new Point(263, 14);
            passwordInput.Margin = new Padding(6);
            passwordInput.Name = "passwordInput";
            passwordInput.PasswordChar = '*';
            passwordInput.Size = new Size(374, 44);
            passwordInput.TabIndex = 60;
            // 
            // repeatPasswordInput
            // 
            repeatPasswordInput.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            repeatPasswordInput.Location = new Point(916, 16);
            repeatPasswordInput.Margin = new Padding(6);
            repeatPasswordInput.Name = "repeatPasswordInput";
            repeatPasswordInput.PasswordChar = '*';
            repeatPasswordInput.Size = new Size(374, 44);
            repeatPasswordInput.TabIndex = 59;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(79, 93, 117);
            label2.Location = new Point(706, 16);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(215, 37);
            label2.TabIndex = 58;
            label2.Text = "Repeat pass:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(79, 93, 117);
            label7.Location = new Point(21, 16);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(177, 37);
            label7.TabIndex = 57;
            label7.Text = "Password:";
            // 
            // phoneTb
            // 
            phoneTb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phoneTb.Location = new Point(341, 510);
            phoneTb.Margin = new Padding(6);
            phoneTb.Name = "phoneTb";
            phoneTb.Size = new Size(374, 44);
            phoneTb.TabIndex = 48;
            // 
            // emailTb
            // 
            emailTb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailTb.Location = new Point(994, 504);
            emailTb.Margin = new Padding(6);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(374, 44);
            emailTb.TabIndex = 47;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(79, 93, 117);
            label6.Location = new Point(784, 512);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 37);
            label6.TabIndex = 46;
            label6.Text = "Email:";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(79, 93, 117);
            panel7.Location = new Point(21, 75);
            panel7.Margin = new Padding(4, 2, 4, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(1272, 2);
            panel7.TabIndex = 45;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(79, 93, 117);
            panel5.Location = new Point(99, 568);
            panel5.Margin = new Padding(4, 2, 4, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1272, 2);
            panel5.TabIndex = 44;
            // 
            // lastNameTb
            // 
            lastNameTb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameTb.Location = new Point(994, 427);
            lastNameTb.Margin = new Padding(6);
            lastNameTb.Name = "lastNameTb";
            lastNameTb.Size = new Size(374, 44);
            lastNameTb.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(79, 93, 117);
            label5.Location = new Point(781, 436);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(189, 37);
            label5.TabIndex = 42;
            label5.Text = "Last Name:";
            // 
            // firstNameTb
            // 
            firstNameTb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameTb.Location = new Point(341, 427);
            firstNameTb.Margin = new Padding(6);
            firstNameTb.Name = "firstNameTb";
            firstNameTb.Size = new Size(374, 44);
            firstNameTb.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(79, 93, 117);
            label4.Location = new Point(99, 436);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(194, 37);
            label4.TabIndex = 36;
            label4.Text = "First Name:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(79, 93, 117);
            panel4.Location = new Point(99, 487);
            panel4.Margin = new Padding(4, 2, 4, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1272, 2);
            panel4.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(79, 93, 117);
            label3.Location = new Point(99, 512);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 37);
            label3.TabIndex = 38;
            label3.Text = "Phone:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 45, 60);
            panel3.Location = new Point(592, 364);
            panel3.Name = "panel3";
            panel3.Size = new Size(320, 2);
            panel3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.team;
            pictureBox1.Location = new Point(649, 137);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.FromArgb(1, 45, 60);
            titleLabel.Location = new Point(637, 56);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(236, 56);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Add User";
            // 
            // passwordInputsPanel
            // 
            passwordInputsPanel.Controls.Add(repeatPasswordInput);
            passwordInputsPanel.Controls.Add(panel7);
            passwordInputsPanel.Controls.Add(label7);
            passwordInputsPanel.Controls.Add(label2);
            passwordInputsPanel.Controls.Add(passwordInput);
            passwordInputsPanel.Location = new Point(71, 571);
            passwordInputsPanel.Name = "passwordInputsPanel";
            passwordInputsPanel.Size = new Size(1311, 89);
            passwordInputsPanel.TabIndex = 64;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(1653, 971);
            Controls.Add(panel2);
            Name = "UserForm";
            Text = "UserForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            passwordInputsPanel.ResumeLayout(false);
            passwordInputsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label titleLabel;
        private ComboBox rolesComboBox;
        private Label label8;
        private TextBox passwordInput;
        private TextBox repeatPasswordInput;
        private Label label2;
        private Label label7;
        private TextBox phoneTb;
        private TextBox emailTb;
        private Label label6;
        private Panel panel7;
        private Panel panel5;
        private TextBox lastNameTb;
        private Label label5;
        private TextBox firstNameTb;
        private Label label4;
        private Panel panel4;
        private Label label3;
        private FontAwesome.Sharp.IconButton addUserBtn;
        private Panel passwordInputsPanel;
    }
}