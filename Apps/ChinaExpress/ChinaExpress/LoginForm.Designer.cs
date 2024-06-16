namespace ChinaExpress.Desktop
{
    partial class LoginForm
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            emailTxb = new TextBox();
            passwordThx = new TextBox();
            loginBtn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(1, 45, 60);
            label1.Location = new Point(256, 33);
            label1.Name = "label1";
            label1.Size = new Size(153, 56);
            label1.TabIndex = 4;
            label1.Text = "Login";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login;
            pictureBox1.Location = new Point(182, 113);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(304, 310);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // emailTxb
            // 
            emailTxb.BackColor = Color.FromArgb(183, 222, 221);
            emailTxb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailTxb.Location = new Point(130, 471);
            emailTxb.Name = "emailTxb";
            emailTxb.PlaceholderText = "Email...";
            emailTxb.Size = new Size(394, 50);
            emailTxb.TabIndex = 6;
            // 
            // passwordThx
            // 
            passwordThx.BackColor = Color.FromArgb(183, 222, 221);
            passwordThx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordThx.Location = new Point(130, 569);
            passwordThx.Name = "passwordThx";
            passwordThx.PasswordChar = '*';
            passwordThx.PlaceholderText = "Password...";
            passwordThx.Size = new Size(394, 50);
            passwordThx.TabIndex = 7;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.FromArgb(1, 45, 60);
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loginBtn.ForeColor = Color.Snow;
            loginBtn.Location = new Point(182, 666);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(304, 69);
            loginBtn.TabIndex = 8;
            loginBtn.Text = "LOGIN";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(loginBtn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(passwordThx);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(emailTxb);
            panel1.Location = new Point(285, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(651, 758);
            panel1.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 222, 221);
            ClientSize = new Size(1223, 882);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private TextBox emailTxb;
        private TextBox passwordThx;
        private Button loginBtn;
        private Panel panel1;
    }
}