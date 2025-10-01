using System.Drawing;
using System.Windows.Forms;

namespace UserFlowAppWinForms
{
    partial class Form1
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
            this.panelCustomerLogin = new System.Windows.Forms.Panel();
            this.lblCustomerMessage = new System.Windows.Forms.Label();
            this.btnCustomerLogin = new System.Windows.Forms.Button();
            this.txtCustomerPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAuthorLogin = new System.Windows.Forms.Panel();
            this.lblAuthorMessage = new System.Windows.Forms.Label();
            this.btnAuthorLogin = new System.Windows.Forms.Button();
            this.txtAuthorPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthorUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelAuthorMenu = new System.Windows.Forms.Panel();
            this.lblAnalysis = new System.Windows.Forms.Label();
            this.btnAnalyzeLogs = new System.Windows.Forms.Button();
            this.btnAuthorEdit = new System.Windows.Forms.Button();
            this.btnAuthorDelete = new System.Windows.Forms.Button();
            this.btnAuthorAdd = new System.Windows.Forms.Button();
            this.panelAddCustomer = new System.Windows.Forms.Panel();
            this.lblAddMessage = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.txtAddPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelDeleteCustomer = new System.Windows.Forms.Panel();
            this.lblDeleteMessage = new System.Windows.Forms.Label();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.txtDeleteUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelEditCustomer = new System.Windows.Forms.Panel();
            this.lblEditMessage = new System.Windows.Forms.Label();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.btnAuthorRole = new System.Windows.Forms.Button();
            this.btnCustomerRole = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panelCustomerLogin.SuspendLayout();
            this.panelAuthorLogin.SuspendLayout();
            this.panelAuthorMenu.SuspendLayout();
            this.panelAddCustomer.SuspendLayout();
            this.panelDeleteCustomer.SuspendLayout();
            this.panelEditCustomer.SuspendLayout();
            this.panelMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCustomerLogin
            // 
            this.panelCustomerLogin.Controls.Add(this.lblCustomerMessage);
            this.panelCustomerLogin.Controls.Add(this.btnCustomerLogin);
            this.panelCustomerLogin.Controls.Add(this.txtCustomerPassword);
            this.panelCustomerLogin.Controls.Add(this.label2);
            this.panelCustomerLogin.Controls.Add(this.txtCustomerUsername);
            this.panelCustomerLogin.Controls.Add(this.label1);
            this.panelCustomerLogin.Location = new System.Drawing.Point(16, 18);
            this.panelCustomerLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelCustomerLogin.Name = "panelCustomerLogin";
            this.panelCustomerLogin.Size = new System.Drawing.Size(400, 308);
            this.panelCustomerLogin.TabIndex = 0;
            this.panelCustomerLogin.Visible = false;
            // 
            // lblCustomerMessage
            // 
            this.lblCustomerMessage.AutoSize = true;
            this.lblCustomerMessage.ForeColor = System.Drawing.Color.Red;
            this.lblCustomerMessage.Location = new System.Drawing.Point(17, 260);
            this.lblCustomerMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerMessage.Name = "lblCustomerMessage";
            this.lblCustomerMessage.Size = new System.Drawing.Size(0, 20);
            this.lblCustomerMessage.TabIndex = 5;
            // 
            // btnCustomerLogin
            // 
            this.btnCustomerLogin.Location = new System.Drawing.Point(21, 202);
            this.btnCustomerLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomerLogin.Name = "btnCustomerLogin";
            this.btnCustomerLogin.Size = new System.Drawing.Size(357, 35);
            this.btnCustomerLogin.TabIndex = 4;
            this.btnCustomerLogin.Text = "Login";
            this.btnCustomerLogin.UseVisualStyleBackColor = true;
            this.btnCustomerLogin.Click += new System.EventHandler(this.btnCustomerLogin_Click);
            // 
            // txtCustomerPassword
            // 
            this.txtCustomerPassword.Location = new System.Drawing.Point(21, 146);
            this.txtCustomerPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerPassword.Name = "txtCustomerPassword";
            this.txtCustomerPassword.PasswordChar = '*';
            this.txtCustomerPassword.Size = new System.Drawing.Size(356, 27);
            this.txtCustomerPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtCustomerUsername
            // 
            this.txtCustomerUsername.Location = new System.Drawing.Point(21, 68);
            this.txtCustomerUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerUsername.Name = "txtCustomerUsername";
            this.txtCustomerUsername.Size = new System.Drawing.Size(356, 27);
            this.txtCustomerUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // panelAuthorLogin
            // 
            this.panelAuthorLogin.Controls.Add(this.lblAuthorMessage);
            this.panelAuthorLogin.Controls.Add(this.btnAuthorLogin);
            this.panelAuthorLogin.Controls.Add(this.txtAuthorPassword);
            this.panelAuthorLogin.Controls.Add(this.label3);
            this.panelAuthorLogin.Controls.Add(this.txtAuthorUsername);
            this.panelAuthorLogin.Controls.Add(this.label4);
            this.panelAuthorLogin.Location = new System.Drawing.Point(436, 18);
            this.panelAuthorLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelAuthorLogin.Name = "panelAuthorLogin";
            this.panelAuthorLogin.Size = new System.Drawing.Size(400, 308);
            this.panelAuthorLogin.TabIndex = 6;
            this.panelAuthorLogin.Visible = false;
            // 
            // lblAuthorMessage
            // 
            this.lblAuthorMessage.AutoSize = true;
            this.lblAuthorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblAuthorMessage.Location = new System.Drawing.Point(17, 260);
            this.lblAuthorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthorMessage.Name = "lblAuthorMessage";
            this.lblAuthorMessage.Size = new System.Drawing.Size(0, 20);
            this.lblAuthorMessage.TabIndex = 5;
            // 
            // btnAuthorLogin
            // 
            this.btnAuthorLogin.Location = new System.Drawing.Point(21, 202);
            this.btnAuthorLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAuthorLogin.Name = "btnAuthorLogin";
            this.btnAuthorLogin.Size = new System.Drawing.Size(357, 35);
            this.btnAuthorLogin.TabIndex = 4;
            this.btnAuthorLogin.Text = "Login";
            this.btnAuthorLogin.UseVisualStyleBackColor = true;
            this.btnAuthorLogin.Click += new System.EventHandler(this.btnAuthorLogin_Click);
            // 
            // txtAuthorPassword
            // 
            this.txtAuthorPassword.Location = new System.Drawing.Point(21, 146);
            this.txtAuthorPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAuthorPassword.Name = "txtAuthorPassword";
            this.txtAuthorPassword.PasswordChar = '*';
            this.txtAuthorPassword.Size = new System.Drawing.Size(356, 27);
            this.txtAuthorPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtAuthorUsername
            // 
            this.txtAuthorUsername.Location = new System.Drawing.Point(21, 68);
            this.txtAuthorUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAuthorUsername.Name = "txtAuthorUsername";
            this.txtAuthorUsername.Size = new System.Drawing.Size(356, 27);
            this.txtAuthorUsername.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Username";
            // 
            // panelAuthorMenu
            // 
            this.panelAuthorMenu.Controls.Add(this.lblAnalysis);
            this.panelAuthorMenu.Controls.Add(this.btnAnalyzeLogs);
            this.panelAuthorMenu.Controls.Add(this.btnAuthorEdit);
            this.panelAuthorMenu.Controls.Add(this.btnAuthorDelete);
            this.panelAuthorMenu.Controls.Add(this.btnAuthorAdd);
            this.panelAuthorMenu.Location = new System.Drawing.Point(16, 351);
            this.panelAuthorMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelAuthorMenu.Name = "panelAuthorMenu";
            this.panelAuthorMenu.Size = new System.Drawing.Size(400, 385);
            this.panelAuthorMenu.TabIndex = 7;
            this.panelAuthorMenu.Visible = false;
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.Location = new System.Drawing.Point(20, 262);
            this.lblAnalysis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(360, 92);
            this.lblAnalysis.TabIndex = 4;
            this.lblAnalysis.Text = "Analysis will appear here...";
            // 
            // btnAnalyzeLogs
            // 
            this.btnAnalyzeLogs.Location = new System.Drawing.Point(20, 205);
            this.btnAnalyzeLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnalyzeLogs.Name = "btnAnalyzeLogs";
            this.btnAnalyzeLogs.Size = new System.Drawing.Size(360, 35);
            this.btnAnalyzeLogs.TabIndex = 3;
            this.btnAnalyzeLogs.Text = "Analyze Logs";
            this.btnAnalyzeLogs.UseVisualStyleBackColor = true;
            this.btnAnalyzeLogs.Click += new System.EventHandler(this.btnAnalyzeLogs_Click);
            // 
            // btnAuthorEdit
            // 
            this.btnAuthorEdit.Location = new System.Drawing.Point(20, 143);
            this.btnAuthorEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAuthorEdit.Name = "btnAuthorEdit";
            this.btnAuthorEdit.Size = new System.Drawing.Size(360, 35);
            this.btnAuthorEdit.TabIndex = 2;
            this.btnAuthorEdit.Text = "Edit Customer";
            this.btnAuthorEdit.UseVisualStyleBackColor = true;
            this.btnAuthorEdit.Click += new System.EventHandler(this.btnAuthorEdit_Click);
            // 
            // btnAuthorDelete
            // 
            this.btnAuthorDelete.Location = new System.Drawing.Point(20, 82);
            this.btnAuthorDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAuthorDelete.Name = "btnAuthorDelete";
            this.btnAuthorDelete.Size = new System.Drawing.Size(360, 35);
            this.btnAuthorDelete.TabIndex = 1;
            this.btnAuthorDelete.Text = "Delete Customer";
            this.btnAuthorDelete.UseVisualStyleBackColor = true;
            this.btnAuthorDelete.Click += new System.EventHandler(this.btnAuthorDelete_Click);
            // 
            // btnAuthorAdd
            // 
            this.btnAuthorAdd.Location = new System.Drawing.Point(20, 20);
            this.btnAuthorAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAuthorAdd.Name = "btnAuthorAdd";
            this.btnAuthorAdd.Size = new System.Drawing.Size(360, 35);
            this.btnAuthorAdd.TabIndex = 0;
            this.btnAuthorAdd.Text = "Add New Customer";
            this.btnAuthorAdd.UseVisualStyleBackColor = true;
            this.btnAuthorAdd.Click += new System.EventHandler(this.btnAuthorAdd_Click);
            // 
            // panelAddCustomer
            // 
            this.panelAddCustomer.Controls.Add(this.lblAddMessage);
            this.panelAddCustomer.Controls.Add(this.btnAddCustomer);
            this.panelAddCustomer.Controls.Add(this.txtAddPassword);
            this.panelAddCustomer.Controls.Add(this.label5);
            this.panelAddCustomer.Controls.Add(this.txtAddUsername);
            this.panelAddCustomer.Controls.Add(this.label6);
            this.panelAddCustomer.Location = new System.Drawing.Point(436, 351);
            this.panelAddCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelAddCustomer.Name = "panelAddCustomer";
            this.panelAddCustomer.Size = new System.Drawing.Size(400, 308);
            this.panelAddCustomer.TabIndex = 8;
            this.panelAddCustomer.Visible = false;
            // 
            // lblAddMessage
            // 
            this.lblAddMessage.AutoSize = true;
            this.lblAddMessage.ForeColor = System.Drawing.Color.Red;
            this.lblAddMessage.Location = new System.Drawing.Point(17, 260);
            this.lblAddMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddMessage.Name = "lblAddMessage";
            this.lblAddMessage.Size = new System.Drawing.Size(0, 20);
            this.lblAddMessage.TabIndex = 5;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(21, 202);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(357, 35);
            this.btnAddCustomer.TabIndex = 4;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // txtAddPassword
            // 
            this.txtAddPassword.Location = new System.Drawing.Point(21, 146);
            this.txtAddPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddPassword.Name = "txtAddPassword";
            this.txtAddPassword.PasswordChar = '*';
            this.txtAddPassword.Size = new System.Drawing.Size(356, 27);
            this.txtAddPassword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // txtAddUsername
            // 
            this.txtAddUsername.Location = new System.Drawing.Point(21, 68);
            this.txtAddUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddUsername.Name = "txtAddUsername";
            this.txtAddUsername.Size = new System.Drawing.Size(356, 27);
            this.txtAddUsername.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Username";
            // 
            // panelDeleteCustomer
            // 
            this.panelDeleteCustomer.Controls.Add(this.lblDeleteMessage);
            this.panelDeleteCustomer.Controls.Add(this.btnDeleteCustomer);
            this.panelDeleteCustomer.Controls.Add(this.txtDeleteUsername);
            this.panelDeleteCustomer.Controls.Add(this.label7);
            this.panelDeleteCustomer.Location = new System.Drawing.Point(856, 18);
            this.panelDeleteCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelDeleteCustomer.Name = "panelDeleteCustomer";
            this.panelDeleteCustomer.Size = new System.Drawing.Size(400, 231);
            this.panelDeleteCustomer.TabIndex = 9;
            this.panelDeleteCustomer.Visible = false;
            // 
            // lblDeleteMessage
            // 
            this.lblDeleteMessage.AutoSize = true;
            this.lblDeleteMessage.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteMessage.Location = new System.Drawing.Point(17, 183);
            this.lblDeleteMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeleteMessage.Name = "lblDeleteMessage";
            this.lblDeleteMessage.Size = new System.Drawing.Size(0, 20);
            this.lblDeleteCustomer.TabIndex = 5;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(21, 125);
            this.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(357, 35);
            this.btnDeleteCustomer.TabIndex = 4;
            this.btnDeleteCustomer.Text = "Delete Customer";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // txtDeleteUsername
            // 
            this.txtDeleteUsername.Location = new System.Drawing.Point(21, 68);
            this.txtDeleteUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeleteUsername.Name = "txtDeleteUsername";
            this.txtDeleteUsername.Size = new System.Drawing.Size(356, 27);
            this.txtDeleteUsername.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Username";
            // 
            // panelEditCustomer
            // 
            this.panelEditCustomer.Controls.Add(this.lblEditMessage);
            this.panelEditCustomer.Controls.Add(this.btnEditCustomer);
            this.panelEditCustomer.Controls.Add(this.txtEditPassword);
            this.panelEditCustomer.Controls.Add(this.label8);
            this.panelEditCustomer.Controls.Add(this.txtEditUsername);
            this.panelEditCustomer.Controls.Add(this.label9);
            this.panelEditCustomer.Location = new System.Drawing.Point(856, 274);
            this.panelEditCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelEditCustomer.Name = "panelEditCustomer";
            this.panelEditCustomer.Size = new System.Drawing.Size(400, 308);
            this.panelEditCustomer.TabIndex = 10;
            this.panelEditCustomer.Visible = false;
            // 
            // lblEditMessage
            // 
            this.lblEditMessage.AutoSize = true;
            this.lblEditMessage.ForeColor = System.Drawing.Color.Red;
            this.lblEditMessage.Location = new System.Drawing.Point(17, 260);
            this.lblEditMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEditMessage.Name = "lblEditMessage";
            this.lblEditMessage.Size = new System.Drawing.Size(0, 20);
            this.lblEditMessage.TabIndex = 5;
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(21, 202);
            this.btnEditCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(357, 35);
            this.btnEditCustomer.TabIndex = 4;
            this.btnEditCustomer.Text = "Update Password";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // txtEditPassword
            // 
            this.txtEditPassword.Location = new System.Drawing.Point(21, 146);
            this.txtEditPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.PasswordChar = '*';
            this.txtEditPassword.Size = new System.Drawing.Size(356, 27);
            this.txtEditPassword.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "New Password:";
            // 
            // txtEditUsername
            // 
            this.txtEditUsername.Location = new System.Drawing.Point(21, 68);
            this.txtEditUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEditUsername.Name = "txtEditUsername";
            this.txtEditUsername.Size = new System.Drawing.Size(356, 27);
            this.txtEditUsername.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Username";
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Controls.Add(this.label10);
            this.panelMainMenu.Controls.Add(this.btnAuthorRole);
            this.panelMainMenu.Controls.Add(this.btnCustomerRole);
            this.panelMainMenu.Location = new System.Drawing.Point(16, 760);
            this.panelMainMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(400, 231);
            this.panelMainMenu.TabIndex = 11;
            this.panelMainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMainMenu_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Hi, Please select the desired Mode";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // btnAuthorRole
            // 
            this.btnAuthorRole.Location = new System.Drawing.Point(20, 123);
            this.btnAuthorRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAuthorRole.Name = "btnAuthorRole";
            this.btnAuthorRole.Size = new System.Drawing.Size(360, 62);
            this.btnAuthorRole.TabIndex = 1;
            this.btnAuthorRole.Text = "Author mode";
            this.btnAuthorRole.UseVisualStyleBackColor = true;
            this.btnAuthorRole.Click += new System.EventHandler(this.btnAuthorRole_Click);
            // 
            // btnCustomerRole
            // 
            this.btnCustomerRole.Location = new System.Drawing.Point(20, 31);
            this.btnCustomerRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomerRole.Name = "btnCustomerRole";
            this.btnCustomerRole.Size = new System.Drawing.Size(360, 62);
            this.btnCustomerRole.TabIndex = 0;
            this.btnCustomerRole.Text = "Customer mode";
            this.btnCustomerRole.UseVisualStyleBackColor = true;
            this.btnCustomerRole.Click += new System.EventHandler(this.btnCustomerRole_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 1017);
            this.Controls.Add(this.panelMainMenu);
            this.Controls.Add(this.panelEditCustomer);
            this.Controls.Add(this.panelDeleteCustomer);
            this.Controls.Add(this.panelAddCustomer);
            this.Controls.Add(this.panelAuthorMenu);
            this.Controls.Add(this.panelAuthorLogin);
            this.Controls.Add(this.panelCustomerLogin);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "User Flow App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCustomerLogin.ResumeLayout(false);
            this.panelCustomerLogin.PerformLayout();
            this.panelAuthorLogin.ResumeLayout(false);
            this.panelAuthorLogin.PerformLayout();
            this.panelAuthorMenu.ResumeLayout(false);
            this.panelAddCustomer.ResumeLayout(false);
            this.panelAddCustomer.PerformLayout();
            this.panelDeleteCustomer.ResumeLayout(false);
            this.panelDeleteCustomer.PerformLayout();
            this.panelEditCustomer.ResumeLayout(false);
            this.panelEditCustomer.PerformLayout();
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            this.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnAnalyzeLogs;
        private System.Windows.Forms.Label lblAnalysis;
        private Label label10;
    }
}
