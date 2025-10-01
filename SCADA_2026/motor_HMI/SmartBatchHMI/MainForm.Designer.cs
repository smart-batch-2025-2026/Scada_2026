namespace SmartBatchHMI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            picMotor = new PictureBox();
            picGreen = new PictureBox();
            picRed = new PictureBox();
            lblStatus = new Label();
            btnToggleMotor = new Button();
            ((System.ComponentModel.ISupportInitialize)picMotor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRed).BeginInit();
            SuspendLayout();
            // 
            // picMotor
            // 
            picMotor.BackColor = Color.LightGray;
            picMotor.Image = (Image)resources.GetObject("picMotor.Image");
            picMotor.Location = new Point(26, 15);
            picMotor.Margin = new Padding(3, 2, 3, 2);
            picMotor.Name = "picMotor";
            picMotor.Size = new Size(105, 90);
            picMotor.SizeMode = PictureBoxSizeMode.StretchImage;
            picMotor.TabIndex = 0;
            picMotor.TabStop = false;
            // 
            // picGreen
            // 
            picGreen.BackColor = Color.Transparent;
            picGreen.Image = (Image)resources.GetObject("picGreen.Image");
            picGreen.Location = new Point(158, 15);
            picGreen.Margin = new Padding(3, 2, 3, 2);
            picGreen.Name = "picGreen";
            picGreen.Size = new Size(42, 36);
            picGreen.SizeMode = PictureBoxSizeMode.StretchImage;
            picGreen.TabIndex = 1;
            picGreen.TabStop = false;
            picGreen.Visible = false;
            picGreen.Click += picGreen_Click;
            // 
            // picRed
            // 
            picRed.BackColor = Color.Transparent;
            picRed.Image = (Image)resources.GetObject("picRed.Image");
            picRed.Location = new Point(158, 68);
            picRed.Margin = new Padding(3, 2, 3, 2);
            picRed.Name = "picRed";
            picRed.Size = new Size(42, 36);
            picRed.SizeMode = PictureBoxSizeMode.StretchImage;
            picRed.TabIndex = 2;
            picRed.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(26, 120);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Motor is OFF";
            // 
            // btnToggleMotor
            // 
            btnToggleMotor.Location = new Point(26, 142);
            btnToggleMotor.Margin = new Padding(3, 2, 3, 2);
            btnToggleMotor.Name = "btnToggleMotor";
            btnToggleMotor.Size = new Size(88, 34);
            btnToggleMotor.TabIndex = 4;
            btnToggleMotor.Text = "Toggle Motor";
            btnToggleMotor.UseVisualStyleBackColor = true;
            btnToggleMotor.Click += btnToggleMotor_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 187);
            Controls.Add(btnToggleMotor);
            Controls.Add(lblStatus);
            Controls.Add(picRed);
            Controls.Add(picGreen);
            Controls.Add(picMotor);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmartBatch HMI";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)picMotor).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRed).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMotor;
        private System.Windows.Forms.PictureBox picGreen;
        private System.Windows.Forms.PictureBox picRed;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnToggleMotor;
    }
}
