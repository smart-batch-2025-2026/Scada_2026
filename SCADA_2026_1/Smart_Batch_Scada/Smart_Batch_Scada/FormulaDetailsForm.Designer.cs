namespace Smart_Batch_Scada
{
    partial class FormulaDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblSlump = new System.Windows.Forms.Label();
            this.lblExposure = new System.Windows.Forms.Label();
            this.lblWC = new System.Windows.Forms.Label();

            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.txtSlump = new System.Windows.Forms.TextBox();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.numWC = new System.Windows.Forms.NumericUpDown();

            this.dgvComponents = new System.Windows.Forms.DataGridView();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnDeleteComponent = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numWC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.SuspendLayout();

            // 
            // Labels
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(20, 20);
            this.lblCode.Text = "Code:";

            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 55);
            this.lblDescription.Text = "Description:";

            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(20, 90);
            this.lblStrength.Text = "RCK Strength:";

            this.lblSlump.AutoSize = true;
            this.lblSlump.Location = new System.Drawing.Point(20, 125);
            this.lblSlump.Text = "Slump Class:";

            this.lblExposure.AutoSize = true;
            this.lblExposure.Location = new System.Drawing.Point(20, 160);
            this.lblExposure.Text = "Exposure Class:";

            this.lblWC.AutoSize = true;
            this.lblWC.Location = new System.Drawing.Point(20, 195);
            this.lblWC.Text = "W/C Ratio:";

            // 
            // Textboxes
            // 
            this.txtCode.Location = new System.Drawing.Point(130, 17);
            this.txtCode.Size = new System.Drawing.Size(200, 23);

            this.txtDescription.Location = new System.Drawing.Point(130, 52);
            this.txtDescription.Size = new System.Drawing.Size(300, 23);

            this.txtStrength.Location = new System.Drawing.Point(130, 87);
            this.txtStrength.Size = new System.Drawing.Size(100, 23);

            this.txtSlump.Location = new System.Drawing.Point(130, 122);
            this.txtSlump.Size = new System.Drawing.Size(100, 23);

            this.txtExposure.Location = new System.Drawing.Point(130, 157);
            this.txtExposure.Size = new System.Drawing.Size(100, 23);

            this.numWC.DecimalPlaces = 2;
            this.numWC.Location = new System.Drawing.Point(130, 192);
            this.numWC.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numWC.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numWC.Size = new System.Drawing.Size(80, 23);

            // 
            // DataGridView
            // 
            this.dgvComponents.Location = new System.Drawing.Point(20, 240);
            this.dgvComponents.Size = new System.Drawing.Size(760, 200);
            this.dgvComponents.AllowUserToAddRows = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            this.dgvComponents.ReadOnly = true;
            this.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // 
            // Buttons (with icons)
            // 
            SetupActionButton(this.btnSave, "Save", Properties.Resources.icon_new, new System.Drawing.Point(20, 470), this.btnSave_Click);
            SetupActionButton(this.btnAddComponent, "Add Comp.", Properties.Resources.icon_new, new System.Drawing.Point(130, 470), this.btnAddComponent_Click);
            SetupActionButton(this.btnDeleteComponent, "Delete", Properties.Resources.icon_delete, new System.Drawing.Point(240, 470), this.btnDeleteComponent_Click);
            SetupActionButton(this.btnCancel, "Cancel", Properties.Resources.exit_icon, new System.Drawing.Point(350, 470), this.btnCancel_Click);

            // 
            // FormulaDetailsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.lblSlump);
            this.Controls.Add(this.lblExposure);
            this.Controls.Add(this.lblWC);

            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtStrength);
            this.Controls.Add(this.txtSlump);
            this.Controls.Add(this.txtExposure);
            this.Controls.Add(this.numWC);

            this.Controls.Add(this.dgvComponents);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddComponent);
            this.Controls.Add(this.btnDeleteComponent);
            this.Controls.Add(this.btnCancel);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formula Details";
            this.Load += new System.EventHandler(this.FormulaDetailsForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.numWC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupActionButton(Button btn, string text, Image icon, Point location, EventHandler handler)
        {
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.Image = icon;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Text = "   " + text;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.Size = new System.Drawing.Size(100, 30);
            btn.Location = location;
            btn.UseVisualStyleBackColor = true;
            btn.Click += handler;
        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblSlump;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.Label lblWC;

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.TextBox txtSlump;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.NumericUpDown numWC;

        private System.Windows.Forms.DataGridView dgvComponents;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnDeleteComponent;
        private System.Windows.Forms.Button btnCancel;
    }
}
