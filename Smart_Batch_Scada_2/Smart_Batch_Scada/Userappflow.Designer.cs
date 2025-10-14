using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    partial class Userappflow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelCustomerLogin = new Panel();
            lblCustomerMessage = new Label();
            btnCustomerLogin = new Button();
            txtCustomerPassword = new TextBox();
            label2 = new Label();
            txtCustomerUsername = new TextBox();
            label1 = new Label();
            btnBackToMainMenuFromCustomer = new Button();
            panelAuthorLogin = new Panel();
            lblAuthorMessage = new Label();
            btnAuthorLogin = new Button();
            txtAuthorPassword = new TextBox();
            label3 = new Label();
            txtAuthorUsername = new TextBox();
            label4 = new Label();
            btnBackToMainMenuFromAuthorLogin = new Button();
            panelAuthorMenu = new Panel();
            btnBackToMainMenuFromAuthor = new Button();
            btnAuthorEdit = new Button();
            btnAuthorDelete = new Button();
            btnAuthorAdd = new Button();
            panelAddCustomer = new Panel();
            btnBackToAddCustomerMenu = new Button();
            lblAddMessage = new Label();
            btnAddCustomer = new Button();
            txtAddPassword = new TextBox();
            label5 = new Label();
            txtAddUsername = new TextBox();
            label6 = new Label();
            panelDeleteCustomer = new Panel();
            btnBackToDeleteCustomerMenu = new Button();
            lblDeleteMessage = new Label();
            btnDeleteCustomer = new Button();
            txtDeleteUsername = new TextBox();
            label7 = new Label();
            panelEditCustomer = new Panel();
            btnBackToEditCustomerMenu = new Button();
            lblEditMessage = new Label();
            btnEditCustomer = new Button();
            txtEditPassword = new TextBox();
            label8 = new Label();
            txtEditUsername = new TextBox();
            label9 = new Label();
            panelMainMenu = new Panel();
            label10 = new Label();
            btnAuthorRole = new Button();
            btnCustomerRole = new Button();
            panelCustomerLogin.SuspendLayout();
            panelAuthorLogin.SuspendLayout();
            panelAuthorMenu.SuspendLayout();
            panelAddCustomer.SuspendLayout();
            panelDeleteCustomer.SuspendLayout();
            panelEditCustomer.SuspendLayout();
            panelMainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelCustomerLogin
            // 
            panelCustomerLogin.Controls.Add(lblCustomerMessage);
            panelCustomerLogin.Controls.Add(btnCustomerLogin);
            panelCustomerLogin.Controls.Add(txtCustomerPassword);
            panelCustomerLogin.Controls.Add(label2);
            panelCustomerLogin.Controls.Add(txtCustomerUsername);
            panelCustomerLogin.Controls.Add(label1);
            panelCustomerLogin.Controls.Add(btnBackToMainMenuFromCustomer);
            panelCustomerLogin.Location = new Point(0, 0);
            panelCustomerLogin.Name = "panelCustomerLogin";
            panelCustomerLogin.Size = new Size(400, 308);
            panelCustomerLogin.TabIndex = 0;
            panelCustomerLogin.Visible = false;
            // 
            // lblCustomerMessage
            // 
            lblCustomerMessage.AutoSize = true;
            lblCustomerMessage.ForeColor = Color.Red;
            lblCustomerMessage.Location = new Point(17, 260);
            lblCustomerMessage.Name = "lblCustomerMessage";
            lblCustomerMessage.Size = new Size(0, 20);
            lblCustomerMessage.TabIndex = 5;
            // 
            // btnCustomerLogin
            // 
            btnCustomerLogin.Location = new Point(21, 202);
            btnCustomerLogin.Name = "btnCustomerLogin";
            btnCustomerLogin.Size = new Size(357, 35);
            btnCustomerLogin.TabIndex = 4;
            btnCustomerLogin.Text = "Login";
            btnCustomerLogin.UseVisualStyleBackColor = true;
            btnCustomerLogin.Click += btnCustomerLogin_Click;
            // 
            // txtCustomerPassword
            // 
            txtCustomerPassword.Location = new Point(21, 146);
            txtCustomerPassword.Name = "txtCustomerPassword";
            txtCustomerPassword.PasswordChar = '*';
            txtCustomerPassword.Size = new Size(356, 27);
            txtCustomerPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 122);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // txtCustomerUsername
            // 
            txtCustomerUsername.Location = new Point(21, 68);
            txtCustomerUsername.Name = "txtCustomerUsername";
            txtCustomerUsername.Size = new Size(356, 27);
            txtCustomerUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 43);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // btnBackToMainMenuFromCustomer
            // 
            btnBackToMainMenuFromCustomer.Location = new Point(21, 10);
            btnBackToMainMenuFromCustomer.Name = "btnBackToMainMenuFromCustomer";
            btnBackToMainMenuFromCustomer.Size = new Size(120, 30);
            btnBackToMainMenuFromCustomer.TabIndex = 6;
            btnBackToMainMenuFromCustomer.Text = "Back";
            btnBackToMainMenuFromCustomer.UseVisualStyleBackColor = true;
            btnBackToMainMenuFromCustomer.Click += btnBackToMainMenu_Click;
            // 
            // panelAuthorLogin
            // 
            panelAuthorLogin.Controls.Add(lblAuthorMessage);
            panelAuthorLogin.Controls.Add(btnAuthorLogin);
            panelAuthorLogin.Controls.Add(txtAuthorPassword);
            panelAuthorLogin.Controls.Add(label3);
            panelAuthorLogin.Controls.Add(txtAuthorUsername);
            panelAuthorLogin.Controls.Add(label4);
            panelAuthorLogin.Controls.Add(btnBackToMainMenuFromAuthorLogin);
            panelAuthorLogin.Location = new Point(0, 0);
            panelAuthorLogin.Name = "panelAuthorLogin";
            panelAuthorLogin.Size = new Size(400, 308);
            panelAuthorLogin.TabIndex = 6;
            panelAuthorLogin.Visible = false;
            // 
            // lblAuthorMessage
            // 
            lblAuthorMessage.AutoSize = true;
            lblAuthorMessage.ForeColor = Color.Red;
            lblAuthorMessage.Location = new Point(17, 260);
            lblAuthorMessage.Name = "lblAuthorMessage";
            lblAuthorMessage.Size = new Size(0, 20);
            lblAuthorMessage.TabIndex = 5;
            // 
            // btnAuthorLogin
            // 
            btnAuthorLogin.Location = new Point(21, 202);
            btnAuthorLogin.Name = "btnAuthorLogin";
            btnAuthorLogin.Size = new Size(357, 35);
            btnAuthorLogin.TabIndex = 4;
            btnAuthorLogin.Text = "Login";
            btnAuthorLogin.UseVisualStyleBackColor = true;
            btnAuthorLogin.Click += btnAuthorLogin_Click;
            // 
            // txtAuthorPassword
            // 
            txtAuthorPassword.Location = new Point(21, 146);
            txtAuthorPassword.Name = "txtAuthorPassword";
            txtAuthorPassword.PasswordChar = '*';
            txtAuthorPassword.Size = new Size(356, 27);
            txtAuthorPassword.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 122);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // txtAuthorUsername
            // 
            txtAuthorUsername.Location = new Point(21, 68);
            txtAuthorUsername.Name = "txtAuthorUsername";
            txtAuthorUsername.Size = new Size(356, 27);
            txtAuthorUsername.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 43);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 0;
            label4.Text = "Username";
            // 
            // btnBackToMainMenuFromAuthorLogin
            // 
            btnBackToMainMenuFromAuthorLogin.Location = new Point(21, 10);
            btnBackToMainMenuFromAuthorLogin.Name = "btnBackToMainMenuFromAuthorLogin";
            btnBackToMainMenuFromAuthorLogin.Size = new Size(120, 30);
            btnBackToMainMenuFromAuthorLogin.TabIndex = 6;
            btnBackToMainMenuFromAuthorLogin.Text = "Back";
            btnBackToMainMenuFromAuthorLogin.UseVisualStyleBackColor = true;
            btnBackToMainMenuFromAuthorLogin.Click += btnBackToMainMenu_Click;
            // 
            // panelAuthorMenu
            // 
            panelAuthorMenu.Controls.Add(btnBackToMainMenuFromAuthor);
            panelAuthorMenu.Controls.Add(btnAuthorEdit);
            panelAuthorMenu.Controls.Add(btnAuthorDelete);
            panelAuthorMenu.Controls.Add(btnAuthorAdd);
            panelAuthorMenu.Location = new Point(0, 0);
            panelAuthorMenu.Name = "panelAuthorMenu";
            panelAuthorMenu.Size = new Size(400, 385);
            panelAuthorMenu.TabIndex = 7;
            panelAuthorMenu.Visible = false;
            // 
            // btnBackToMainMenuFromAuthor
            // 
            btnBackToMainMenuFromAuthor.Location = new Point(20, 205);
            btnBackToMainMenuFromAuthor.Name = "btnBackToMainMenuFromAuthor";
            btnBackToMainMenuFromAuthor.Size = new Size(360, 35);
            btnBackToMainMenuFromAuthor.TabIndex = 4;
            btnBackToMainMenuFromAuthor.Text = "Back to Main Menu";
            btnBackToMainMenuFromAuthor.UseVisualStyleBackColor = true;
            btnBackToMainMenuFromAuthor.Click += btnBackToMainMenu_Click;
            // 
            // btnAuthorEdit
            // 
            btnAuthorEdit.Location = new Point(20, 143);
            btnAuthorEdit.Name = "btnAuthorEdit";
            btnAuthorEdit.Size = new Size(360, 35);
            btnAuthorEdit.TabIndex = 2;
            btnAuthorEdit.Text = "Edit Customer";
            btnAuthorEdit.UseVisualStyleBackColor = true;
            btnAuthorEdit.Click += btnAuthorEdit_Click;
            // 
            // btnAuthorDelete
            // 
            btnAuthorDelete.Location = new Point(20, 82);
            btnAuthorDelete.Name = "btnAuthorDelete";
            btnAuthorDelete.Size = new Size(360, 35);
            btnAuthorDelete.TabIndex = 1;
            btnAuthorDelete.Text = "Delete Customer";
            btnAuthorDelete.UseVisualStyleBackColor = true;
            btnAuthorDelete.Click += btnAuthorDelete_Click;
            // 
            // btnAuthorAdd
            // 
            btnAuthorAdd.Location = new Point(20, 20);
            btnAuthorAdd.Name = "btnAuthorAdd";
            btnAuthorAdd.Size = new Size(360, 35);
            btnAuthorAdd.TabIndex = 0;
            btnAuthorAdd.Text = "Add New Customer";
            btnAuthorAdd.UseVisualStyleBackColor = true;
            btnAuthorAdd.Click += btnAuthorAdd_Click;
            // 
            // panelAddCustomer
            // 
            panelAddCustomer.Controls.Add(btnBackToAddCustomerMenu);
            panelAddCustomer.Controls.Add(lblAddMessage);
            panelAddCustomer.Controls.Add(btnAddCustomer);
            panelAddCustomer.Controls.Add(txtAddPassword);
            panelAddCustomer.Controls.Add(label5);
            panelAddCustomer.Controls.Add(txtAddUsername);
            panelAddCustomer.Controls.Add(label6);
            panelAddCustomer.Location = new Point(0, 0);
            panelAddCustomer.Name = "panelAddCustomer";
            panelAddCustomer.Size = new Size(400, 308);
            panelAddCustomer.TabIndex = 8;
            panelAddCustomer.Visible = false;
            // 
            // btnBackToAddCustomerMenu
            // 
            btnBackToAddCustomerMenu.Location = new Point(21, 250);
            btnBackToAddCustomerMenu.Name = "btnBackToAddCustomerMenu";
            btnBackToAddCustomerMenu.Size = new Size(357, 35);
            btnBackToAddCustomerMenu.TabIndex = 5;
            btnBackToAddCustomerMenu.Text = "Back to Author Menu";
            btnBackToAddCustomerMenu.UseVisualStyleBackColor = true;
            btnBackToAddCustomerMenu.Click += btnBackToAuthorMenu_Click;
            // 
            // lblAddMessage
            // 
            lblAddMessage.AutoSize = true;
            lblAddMessage.ForeColor = Color.Red;
            lblAddMessage.Location = new Point(17, 260);
            lblAddMessage.Name = "lblAddMessage";
            lblAddMessage.Size = new Size(0, 20);
            lblAddMessage.TabIndex = 5;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(21, 202);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(357, 35);
            btnAddCustomer.TabIndex = 4;
            btnAddCustomer.Text = "Add Customer";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // txtAddPassword
            // 
            txtAddPassword.Location = new Point(21, 146);
            txtAddPassword.Name = "txtAddPassword";
            txtAddPassword.PasswordChar = '*';
            txtAddPassword.Size = new Size(356, 27);
            txtAddPassword.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 122);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 2;
            label5.Text = "Password";
            // 
            // txtAddUsername
            // 
            txtAddUsername.Location = new Point(21, 68);
            txtAddUsername.Name = "txtAddUsername";
            txtAddUsername.Size = new Size(356, 27);
            txtAddUsername.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 43);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 0;
            label6.Text = "Username";
            // 
            // panelDeleteCustomer
            // 
            panelDeleteCustomer.Controls.Add(btnBackToDeleteCustomerMenu);
            panelDeleteCustomer.Controls.Add(lblDeleteMessage);
            panelDeleteCustomer.Controls.Add(btnDeleteCustomer);
            panelDeleteCustomer.Controls.Add(txtDeleteUsername);
            panelDeleteCustomer.Controls.Add(label7);
            panelDeleteCustomer.Location = new Point(0, 0);
            panelDeleteCustomer.Name = "panelDeleteCustomer";
            panelDeleteCustomer.Size = new Size(400, 231);
            panelDeleteCustomer.TabIndex = 9;
            panelDeleteCustomer.Visible = false;
            // 
            // btnBackToDeleteCustomerMenu
            // 
            btnBackToDeleteCustomerMenu.Location = new Point(21, 173);
            btnBackToDeleteCustomerMenu.Name = "btnBackToDeleteCustomerMenu";
            btnBackToDeleteCustomerMenu.Size = new Size(357, 35);
            btnBackToDeleteCustomerMenu.TabIndex = 6;
            btnBackToDeleteCustomerMenu.Text = "Back to Author Menu";
            btnBackToDeleteCustomerMenu.UseVisualStyleBackColor = true;
            btnBackToDeleteCustomerMenu.Click += btnBackToAuthorMenu_Click;
            // 
            // lblDeleteMessage
            // 
            lblDeleteMessage.AutoSize = true;
            lblDeleteMessage.ForeColor = Color.Red;
            lblDeleteMessage.Location = new Point(17, 183);
            lblDeleteMessage.Name = "lblDeleteMessage";
            lblDeleteMessage.Size = new Size(0, 20);
            lblDeleteMessage.TabIndex = 5;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(21, 125);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(357, 35);
            btnDeleteCustomer.TabIndex = 4;
            btnDeleteCustomer.Text = "Delete Customer";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // txtDeleteUsername
            // 
            txtDeleteUsername.Location = new Point(21, 68);
            txtDeleteUsername.Name = "txtDeleteUsername";
            txtDeleteUsername.Size = new Size(356, 27);
            txtDeleteUsername.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 43);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 0;
            label7.Text = "Username";
            // 
            // panelEditCustomer
            // 
            panelEditCustomer.Controls.Add(btnBackToEditCustomerMenu);
            panelEditCustomer.Controls.Add(lblEditMessage);
            panelEditCustomer.Controls.Add(btnEditCustomer);
            panelEditCustomer.Controls.Add(txtEditPassword);
            panelEditCustomer.Controls.Add(label8);
            panelEditCustomer.Controls.Add(txtEditUsername);
            panelEditCustomer.Controls.Add(label9);
            panelEditCustomer.Location = new Point(0, 0);
            panelEditCustomer.Name = "panelEditCustomer";
            panelEditCustomer.Size = new Size(400, 308);
            panelEditCustomer.TabIndex = 10;
            panelEditCustomer.Visible = false;
            // 
            // btnBackToEditCustomerMenu
            // 
            btnBackToEditCustomerMenu.Location = new Point(21, 250);
            btnBackToEditCustomerMenu.Name = "btnBackToEditCustomerMenu";
            btnBackToEditCustomerMenu.Size = new Size(357, 35);
            btnBackToEditCustomerMenu.TabIndex = 6;
            btnBackToEditCustomerMenu.Text = "Back to Author Menu";
            btnBackToEditCustomerMenu.UseVisualStyleBackColor = true;
            btnBackToEditCustomerMenu.Click += btnBackToAuthorMenu_Click;
            // 
            // lblEditMessage
            // 
            lblEditMessage.AutoSize = true;
            lblEditMessage.ForeColor = Color.Red;
            lblEditMessage.Location = new Point(17, 260);
            lblEditMessage.Name = "lblEditMessage";
            lblEditMessage.Size = new Size(0, 20);
            lblEditMessage.TabIndex = 5;
            // 
            // btnEditCustomer
            // 
            btnEditCustomer.Location = new Point(21, 202);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(357, 35);
            btnEditCustomer.TabIndex = 4;
            btnEditCustomer.Text = "Update Password";
            btnEditCustomer.UseVisualStyleBackColor = true;
            btnEditCustomer.Click += btnEditCustomer_Click;
            // 
            // txtEditPassword
            // 
            txtEditPassword.Location = new Point(21, 146);
            txtEditPassword.Name = "txtEditPassword";
            txtEditPassword.PasswordChar = '*';
            txtEditPassword.Size = new Size(356, 27);
            txtEditPassword.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 122);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 2;
            label8.Text = "New Password:";
            // 
            // txtEditUsername
            // 
            txtEditUsername.Location = new Point(21, 68);
            txtEditUsername.Name = "txtEditUsername";
            txtEditUsername.Size = new Size(356, 27);
            txtEditUsername.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 43);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 0;
            label9.Text = "Username";
            // 
            // panelMainMenu
            // 
            panelMainMenu.Controls.Add(label10);
            panelMainMenu.Controls.Add(btnAuthorRole);
            panelMainMenu.Controls.Add(btnCustomerRole);
            panelMainMenu.Location = new Point(0, 0);
            panelMainMenu.Name = "panelMainMenu";
            panelMainMenu.Size = new Size(400, 231);
            panelMainMenu.TabIndex = 11;
            panelMainMenu.Paint += panelMainMenu_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(76, 6);
            label10.Name = "label10";
            label10.Size = new Size(236, 20);
            label10.TabIndex = 2;
            label10.Text = "Hi, Please select the desired Mode";
            label10.Click += label10_Click;
            // 
            // btnAuthorRole
            // 
            btnAuthorRole.Location = new Point(20, 123);
            btnAuthorRole.Name = "btnAuthorRole";
            btnAuthorRole.Size = new Size(360, 62);
            btnAuthorRole.TabIndex = 1;
            btnAuthorRole.Text = "Author mode";
            btnAuthorRole.UseVisualStyleBackColor = true;
            btnAuthorRole.Click += btnAuthorRole_Click;
            // 
            // btnCustomerRole
            // 
            btnCustomerRole.Location = new Point(20, 31);
            btnCustomerRole.Name = "btnCustomerRole";
            btnCustomerRole.Size = new Size(360, 62);
            btnCustomerRole.TabIndex = 0;
            btnCustomerRole.Text = "Customer mode";
            btnCustomerRole.UseVisualStyleBackColor = true;
            btnCustomerRole.Click += btnCustomerRole_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(400, 400);
            Controls.Add(panelMainMenu);
            Controls.Add(panelEditCustomer);
            Controls.Add(panelDeleteCustomer);
            Controls.Add(panelAddCustomer);
            Controls.Add(panelAuthorMenu);
            Controls.Add(panelAuthorLogin);
            Controls.Add(panelCustomerLogin);
            Name = "Form1";
            Text = "User Flow App";
            Load += Form1_Load;
            panelCustomerLogin.ResumeLayout(false);
            panelCustomerLogin.PerformLayout();
            panelAuthorLogin.ResumeLayout(false);
            panelAuthorLogin.PerformLayout();
            panelAuthorMenu.ResumeLayout(false);
            panelAddCustomer.ResumeLayout(false);
            panelAddCustomer.PerformLayout();
            panelDeleteCustomer.ResumeLayout(false);
            panelDeleteCustomer.PerformLayout();
            panelEditCustomer.ResumeLayout(false);
            panelEditCustomer.PerformLayout();
            panelMainMenu.ResumeLayout(false);
            panelMainMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCustomerLogin;
        private System.Windows.Forms.Label lblCustomerMessage;
        private System.Windows.Forms.Button btnCustomerLogin;
        private System.Windows.Forms.TextBox txtCustomerPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAuthorLogin;
        private System.Windows.Forms.Label lblAuthorMessage;
        private System.Windows.Forms.Button btnAuthorLogin;
        private System.Windows.Forms.TextBox txtAuthorPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthorUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelAuthorMenu;
        private System.Windows.Forms.Button btnAuthorEdit;
        private System.Windows.Forms.Button btnAuthorDelete;
        private System.Windows.Forms.Button btnAuthorAdd;
        private System.Windows.Forms.Panel panelAddCustomer;
        private System.Windows.Forms.Label lblAddMessage;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox txtAddPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelDeleteCustomer;
        private System.Windows.Forms.Label lblDeleteMessage;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.TextBox txtDeleteUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelEditCustomer;
        private System.Windows.Forms.Label lblEditMessage;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Button btnAuthorRole;
        private System.Windows.Forms.Button btnCustomerRole;
        private System.Windows.Forms.Button btnBackToMainMenuFromAuthor;
        private System.Windows.Forms.Button btnBackToAddCustomerMenu;
        private System.Windows.Forms.Button btnBackToDeleteCustomerMenu;
        private System.Windows.Forms.Button btnBackToEditCustomerMenu;
        private System.Windows.Forms.Button btnBackToMainMenuFromCustomer;
        private System.Windows.Forms.Button btnBackToMainMenuFromAuthorLogin;
        private Label label10;
    }
}
                                               