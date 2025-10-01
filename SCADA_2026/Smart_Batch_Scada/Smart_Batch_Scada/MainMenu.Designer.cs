using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            panelProduction = new Panel();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox15 = new PictureBox();
            pictureBox14 = new PictureBox();
            pictureBox13 = new PictureBox();
            pictureBox12 = new PictureBox();
            pictureBox11 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panelFiles = new Panel();
            button19 = new Button();
            button18 = new Button();
            button17 = new Button();
            button16 = new Button();
            pictureBox19 = new PictureBox();
            pictureBox18 = new PictureBox();
            pictureBox17 = new PictureBox();
            pictureBox16 = new PictureBox();
            panelSystem = new Panel();
            button24 = new Button();
            button23 = new Button();
            button22 = new Button();
            button21 = new Button();
            button20 = new Button();
            pictureBox24 = new PictureBox();
            pictureBox23 = new PictureBox();
            pictureBox22 = new PictureBox();
            pictureBox21 = new PictureBox();
            pictureBox20 = new PictureBox();
            panelNavigator = new Panel();
            btnLogout = new Button();
            lblUser = new Label();
            btnSystem = new Button();
            btnFiles = new Button();
            btnProduction = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            panelProduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox19).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox18).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).BeginInit();
            panelSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox24).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox20).BeginInit();
            panelNavigator.SuspendLayout();
            SuspendLayout();
            // 
            // panelProduction
            // 
            panelProduction.BackgroundImageLayout = ImageLayout.Stretch;
            panelProduction.Controls.Add(button15);
            panelProduction.Controls.Add(button14);
            panelProduction.Controls.Add(button13);
            panelProduction.Controls.Add(button12);
            panelProduction.Controls.Add(button11);
            panelProduction.Controls.Add(button10);
            panelProduction.Controls.Add(button9);
            panelProduction.Controls.Add(button8);
            panelProduction.Controls.Add(button7);
            panelProduction.Controls.Add(button6);
            panelProduction.Controls.Add(button5);
            panelProduction.Controls.Add(button4);
            panelProduction.Controls.Add(button3);
            panelProduction.Controls.Add(button2);
            panelProduction.Controls.Add(button1);
            panelProduction.Controls.Add(pictureBox15);
            panelProduction.Controls.Add(pictureBox14);
            panelProduction.Controls.Add(pictureBox13);
            panelProduction.Controls.Add(pictureBox12);
            panelProduction.Controls.Add(pictureBox11);
            panelProduction.Controls.Add(pictureBox10);
            panelProduction.Controls.Add(pictureBox9);
            panelProduction.Controls.Add(pictureBox8);
            panelProduction.Controls.Add(pictureBox7);
            panelProduction.Controls.Add(pictureBox6);
            panelProduction.Controls.Add(pictureBox5);
            panelProduction.Controls.Add(pictureBox4);
            panelProduction.Controls.Add(pictureBox3);
            panelProduction.Controls.Add(pictureBox2);
            panelProduction.Controls.Add(pictureBox1);
            panelProduction.Dock = DockStyle.Fill;
            panelProduction.Location = new Point(0, 0);
            panelProduction.Name = "panelProduction";
            panelProduction.Size = new Size(820, 500);
            panelProduction.TabIndex = 0;
            panelProduction.Paint += panelProduction_Paint;
            // 
            // button15
            // 
            button15.Location = new Point(159, 462);
            button15.Name = "button15";
            button15.Size = new Size(75, 35);
            button15.TabIndex = 46;
            button15.Text = "Storage";
            button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.Location = new Point(33, 462);
            button14.Name = "button14";
            button14.Size = new Size(75, 35);
            button14.TabIndex = 45;
            button14.Text = "Stock";
            button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(395, 424);
            button13.Name = "button13";
            button13.Size = new Size(90, 32);
            button13.TabIndex = 44;
            button13.Text = "Statistics";
            button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Location = new Point(590, 326);
            button12.Name = "button12";
            button12.Size = new Size(98, 31);
            button12.TabIndex = 43;
            button12.Text = "Consumpt.";
            button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(468, 326);
            button11.Name = "button11";
            button11.Size = new Size(75, 28);
            button11.TabIndex = 42;
            button11.Text = "Reports";
            button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(168, 366);
            button10.Name = "button10";
            button10.Size = new Size(75, 31);
            button10.TabIndex = 41;
            button10.Text = "Suppliers";
            button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(33, 360);
            button9.Name = "button9";
            button9.Size = new Size(104, 29);
            button9.TabIndex = 40;
            button9.Text = "Raw Material";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(143, 232);
            button8.Name = "button8";
            button8.Size = new Size(112, 49);
            button8.TabIndex = 39;
            button8.Text = "Components\r\nexhange";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(23, 236);
            button7.Name = "button7";
            button7.Size = new Size(114, 38);
            button7.TabIndex = 38;
            button7.Text = "Components";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(572, 113);
            button6.Name = "button6";
            button6.Size = new Size(75, 30);
            button6.TabIndex = 37;
            button6.Text = "Orders";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(477, 216);
            button5.Name = "button5";
            button5.Size = new Size(92, 30);
            button5.TabIndex = 36;
            button5.Text = "Production";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(395, 115);
            button4.Name = "button4";
            button4.Size = new Size(78, 28);
            button4.TabIndex = 35;
            button4.Text = "Trucks";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(283, 120);
            button3.Name = "button3";
            button3.Size = new Size(100, 57);
            button3.TabIndex = 34;
            button3.Text = "Client\r\nDestinations\r\n\r\n";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(151, 80);
            button2.Name = "button2";
            button2.Size = new Size(75, 29);
            button2.TabIndex = 33;
            button2.Text = "Products";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(31, 80);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 32;
            button1.Text = "Formula";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox15
            // 
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(381, 360);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(104, 62);
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox15.TabIndex = 16;
            pictureBox15.TabStop = false;
            // 
            // pictureBox14
            // 
            pictureBox14.Image = (Image)resources.GetObject("pictureBox14.Image");
            pictureBox14.Location = new Point(33, 395);
            pictureBox14.Name = "pictureBox14";
            pictureBox14.Size = new Size(73, 61);
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.TabIndex = 15;
            pictureBox14.TabStop = false;
            // 
            // pictureBox13
            // 
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(33, 300);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(73, 57);
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.TabIndex = 14;
            pictureBox13.TabStop = false;
            // 
            // pictureBox12
            // 
            pictureBox12.Image = (Image)resources.GetObject("pictureBox12.Image");
            pictureBox12.Location = new Point(159, 300);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(84, 61);
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.TabIndex = 13;
            pictureBox12.TabStop = false;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(595, 252);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(70, 68);
            pictureBox11.TabIndex = 12;
            pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(467, 252);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(76, 68);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 11;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(158, 395);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(71, 61);
            pictureBox9.TabIndex = 10;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(143, 168);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(86, 58);
            pictureBox8.TabIndex = 9;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(572, 39);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(93, 68);
            pictureBox7.TabIndex = 8;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(477, 143);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(66, 67);
            pictureBox6.TabIndex = 7;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(395, 50);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(78, 57);
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(293, 50);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(65, 57);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(33, 168);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(66, 58);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(158, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 62);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 60);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panelFiles
            // 
            panelFiles.BackgroundImageLayout = ImageLayout.Stretch;
            panelFiles.Controls.Add(button19);
            panelFiles.Controls.Add(button18);
            panelFiles.Controls.Add(button17);
            panelFiles.Controls.Add(button16);
            panelFiles.Controls.Add(pictureBox19);
            panelFiles.Controls.Add(pictureBox18);
            panelFiles.Controls.Add(pictureBox17);
            panelFiles.Controls.Add(pictureBox16);
            panelFiles.Location = new Point(120, 0);
            panelFiles.Name = "panelFiles";
            panelFiles.Size = new Size(700, 500);
            panelFiles.TabIndex = 1;
            panelFiles.Visible = false;
            panelFiles.Paint += panelFiles_Paint;
            // 
            // button19
            // 
            button19.Location = new Point(349, 287);
            button19.Name = "button19";
            button19.Size = new Size(113, 53);
            button19.TabIndex = 10;
            button19.Text = "Restore plant data and Configuration";
            button19.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            button18.Location = new Point(87, 287);
            button18.Name = "button18";
            button18.Size = new Size(142, 53);
            button18.TabIndex = 9;
            button18.Text = "Save plant data and Configuration";
            button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            button17.Location = new Point(362, 130);
            button17.Name = "button17";
            button17.Size = new Size(123, 47);
            button17.TabIndex = 8;
            button17.Text = "Assisted restore";
            button17.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            button16.Location = new Point(116, 130);
            button16.Name = "button16";
            button16.Size = new Size(71, 60);
            button16.TabIndex = 7;
            button16.Text = "Assisted backup";
            button16.UseVisualStyleBackColor = true;
            // 
            // pictureBox19
            // 
            pictureBox19.Image = (Image)resources.GetObject("pictureBox19.Image");
            pictureBox19.Location = new Point(116, 59);
            pictureBox19.Name = "pictureBox19";
            pictureBox19.Size = new Size(87, 62);
            pictureBox19.TabIndex = 6;
            pictureBox19.TabStop = false;
            // 
            // pictureBox18
            // 
            pictureBox18.Image = (Image)resources.GetObject("pictureBox18.Image");
            pictureBox18.Location = new Point(116, 219);
            pictureBox18.Name = "pictureBox18";
            pictureBox18.Size = new Size(87, 62);
            pictureBox18.TabIndex = 5;
            pictureBox18.TabStop = false;
            // 
            // pictureBox17
            // 
            pictureBox17.Image = (Image)resources.GetObject("pictureBox17.Image");
            pictureBox17.Location = new Point(362, 219);
            pictureBox17.Name = "pictureBox17";
            pictureBox17.Size = new Size(89, 62);
            pictureBox17.TabIndex = 4;
            pictureBox17.TabStop = false;
            // 
            // pictureBox16
            // 
            pictureBox16.Image = (Image)resources.GetObject("pictureBox16.Image");
            pictureBox16.Location = new Point(362, 59);
            pictureBox16.Name = "pictureBox16";
            pictureBox16.Size = new Size(89, 62);
            pictureBox16.TabIndex = 3;
            pictureBox16.TabStop = false;
            // 
            // panelSystem
            // 
            panelSystem.BackgroundImageLayout = ImageLayout.Stretch;
            panelSystem.Controls.Add(button24);
            panelSystem.Controls.Add(button23);
            panelSystem.Controls.Add(button22);
            panelSystem.Controls.Add(button21);
            panelSystem.Controls.Add(button20);
            panelSystem.Controls.Add(pictureBox24);
            panelSystem.Controls.Add(pictureBox23);
            panelSystem.Controls.Add(pictureBox22);
            panelSystem.Controls.Add(pictureBox21);
            panelSystem.Controls.Add(pictureBox20);
            panelSystem.Location = new Point(120, 0);
            panelSystem.Name = "panelSystem";
            panelSystem.Size = new Size(700, 500);
            panelSystem.TabIndex = 2;
            panelSystem.Visible = false;
            // 
            // button24
            // 
            button24.Location = new Point(66, 403);
            button24.Name = "button24";
            button24.Size = new Size(82, 32);
            button24.TabIndex = 11;
            button24.Text = "Operator";
            button24.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            button23.Location = new Point(288, 266);
            button23.Name = "button23";
            button23.Size = new Size(95, 34);
            button23.TabIndex = 10;
            button23.Text = "Alarm history";
            button23.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            button22.Location = new Point(66, 266);
            button22.Name = "button22";
            button22.Size = new Size(93, 34);
            button22.TabIndex = 9;
            button22.Text = "Plant's data";
            button22.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            button21.Location = new Point(288, 115);
            button21.Name = "button21";
            button21.Size = new Size(112, 49);
            button21.TabIndex = 8;
            button21.Text = "Comunication data";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // button20
            // 
            button20.Location = new Point(66, 115);
            button20.Name = "button20";
            button20.Size = new Size(107, 62);
            button20.TabIndex = 7;
            button20.Text = "GenYx configuration";
            button20.UseVisualStyleBackColor = true;
            // 
            // pictureBox24
            // 
            pictureBox24.Image = (Image)resources.GetObject("pictureBox24.Image");
            pictureBox24.Location = new Point(66, 335);
            pictureBox24.Name = "pictureBox24";
            pictureBox24.Size = new Size(93, 62);
            pictureBox24.TabIndex = 6;
            pictureBox24.TabStop = false;
            // 
            // pictureBox23
            // 
            pictureBox23.Image = (Image)resources.GetObject("pictureBox23.Image");
            pictureBox23.Location = new Point(66, 36);
            pictureBox23.Name = "pictureBox23";
            pictureBox23.Size = new Size(93, 73);
            pictureBox23.TabIndex = 5;
            pictureBox23.TabStop = false;
            pictureBox23.Click += pictureBox23_Click;
            // 
            // pictureBox22
            // 
            pictureBox22.Image = (Image)resources.GetObject("pictureBox22.Image");
            pictureBox22.Location = new Point(66, 198);
            pictureBox22.Name = "pictureBox22";
            pictureBox22.Size = new Size(93, 62);
            pictureBox22.TabIndex = 4;
            pictureBox22.TabStop = false;
            // 
            // pictureBox21
            // 
            pictureBox21.Image = (Image)resources.GetObject("pictureBox21.Image");
            pictureBox21.Location = new Point(288, 198);
            pictureBox21.Name = "pictureBox21";
            pictureBox21.Size = new Size(95, 62);
            pictureBox21.TabIndex = 3;
            pictureBox21.TabStop = false;
            // 
            // pictureBox20
            // 
            pictureBox20.Image = (Image)resources.GetObject("pictureBox20.Image");
            pictureBox20.Location = new Point(288, 36);
            pictureBox20.Name = "pictureBox20";
            pictureBox20.Size = new Size(95, 73);
            pictureBox20.TabIndex = 2;
            pictureBox20.TabStop = false;
            // 
            // panelNavigator
            // 
            panelNavigator.BackColor = SystemColors.ControlDark;
            panelNavigator.Controls.Add(btnLogout);
            panelNavigator.Controls.Add(lblUser);
            panelNavigator.Controls.Add(btnSystem);
            panelNavigator.Controls.Add(btnFiles);
            panelNavigator.Controls.Add(btnProduction);
            panelNavigator.Dock = DockStyle.Left;
            panelNavigator.Location = new Point(0, 0);
            panelNavigator.Name = "panelNavigator";
            panelNavigator.Size = new Size(120, 500);
            panelNavigator.TabIndex = 3;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.Control;
            btnLogout.Location = new Point(0, 460);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 40);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(10, 10);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(41, 20);
            lblUser.TabIndex = 3;
            lblUser.Text = "User:";
            // 
            // btnSystem
            // 
            btnSystem.Location = new Point(0, 200);
            btnSystem.Name = "btnSystem";
            btnSystem.Size = new Size(120, 60);
            btnSystem.TabIndex = 2;
            btnSystem.Text = "System";
            btnSystem.UseVisualStyleBackColor = true;
            btnSystem.Click += btnSystem_Click;
            // 
            // btnFiles
            // 
            btnFiles.Location = new Point(0, 130);
            btnFiles.Name = "btnFiles";
            btnFiles.Size = new Size(120, 60);
            btnFiles.TabIndex = 1;
            btnFiles.Text = "Files";
            btnFiles.UseVisualStyleBackColor = true;
            btnFiles.Click += btnFiles_Click;
            // 
            // btnProduction
            // 
            btnProduction.Location = new Point(0, 60);
            btnProduction.Name = "btnProduction";
            btnProduction.Size = new Size(120, 60);
            btnProduction.TabIndex = 0;
            btnProduction.Text = "Production";
            btnProduction.UseVisualStyleBackColor = true;
            btnProduction.Click += btnProduction_Click;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // MainMenu
            // 
            ClientSize = new Size(820, 500);
            Controls.Add(panelNavigator);
            Controls.Add(panelProduction);
            Controls.Add(panelFiles);
            Controls.Add(panelSystem);
            Name = "MainMenu";
            Text = "Navigator";
            Load += MainMenu_Load;
            panelProduction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox19).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox18).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox17).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).EndInit();
            panelSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox24).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox23).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox22).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox21).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox20).EndInit();
            panelNavigator.ResumeLayout(false);
            panelNavigator.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelProduction;
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.Panel panelSystem;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Button btnProduction;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private PictureBox pictureBox1;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private PictureBox pictureBox11;
        private PictureBox pictureBox10;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox14;
        private PictureBox pictureBox13;
        private PictureBox pictureBox12;
        private PictureBox pictureBox15;
        private PictureBox pictureBox19;
        private PictureBox pictureBox18;
        private PictureBox pictureBox17;
        private PictureBox pictureBox16;
        private PictureBox pictureBox24;
        private PictureBox pictureBox23;
        private PictureBox pictureBox22;
        private PictureBox pictureBox21;
        private PictureBox pictureBox20;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button11;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button12;
        private Button button19;
        private Button button18;
        private Button button17;
        private Button button16;
        private Button button22;
        private Button button21;
        private Button button20;
        private Button button24;
        private Button button23;
    }
}
