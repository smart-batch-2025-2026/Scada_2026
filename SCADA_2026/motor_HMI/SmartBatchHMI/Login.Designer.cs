namespace SmartBatchHMI
{
    partial class Login
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
            txtUsername1 = new TextBox();
            txtPassword = new TextBox();
            Username = new Label();
            Password = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtUsername1
            // 
            txtUsername1.Location = new Point(374, 80);
            txtUsername1.Name = "txtUsername";
            txtUsername1.Size = new Size(160, 23);
            txtUsername1.TabIndex = 0;
            txtUsername1.TextChanged += textBox1_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(374, 132);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(160, 23);
            txtPassword.TabIndex = 1;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Location = new Point(209, 80);
            Username.Name = "Username";
            Username.Size = new Size(60, 15);
            Username.TabIndex = 2;
            Username.Text = "Username";
            Username.Click += label1_Click;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(209, 132);
            Password.Name = "Password";
            Password.Size = new Size(57, 15);
            Password.TabIndex = 3;
            Password.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(260, 217);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(92, 32);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername1);
            Name = "Login";
            Text = "Form1";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername1;
        private TextBox txtPassword;
        private Label Username;
        private Label Password;
        private Button btnLogin;
    }
}