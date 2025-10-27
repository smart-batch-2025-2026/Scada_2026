using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    partial class FormulaDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblCode;
        private Label lblDescription;
        private Label lblStrength;
        private Label lblSlump;
        private Label lblExposure;
        private Label lblWC;

        private TextBox txtCode;
        private TextBox txtDescription;
        private TextBox txtStrength;
        private TextBox txtSlump;
        private TextBox txtExposure;
        private NumericUpDown numWC;

        private DataGridView dgvComponents;

        private Button btnSave;
        private Button btnAddComponent;
        private Button btnDeleteComponent;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblCode = new Label();
            lblDescription = new Label();
            lblStrength = new Label();
            lblSlump = new Label();
            lblExposure = new Label();
            lblWC = new Label();

            txtCode = new TextBox();
            txtDescription = new TextBox();
            txtStrength = new TextBox();
            txtSlump = new TextBox();
            txtExposure = new TextBox();
            numWC = new NumericUpDown();

            dgvComponents = new DataGridView();

            btnSave = new Button();
            btnAddComponent = new Button();
            btnDeleteComponent = new Button();
            btnCancel = new Button();

            ((System.ComponentModel.ISupportInitialize)(numWC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvComponents)).BeginInit();
            SuspendLayout();

            // Labels
            lblCode.AutoSize = true;
            lblCode.Location = new Point(20, 20);
            lblCode.Text = "Code:";

            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Text = "Description:";

            lblStrength.AutoSize = true;
            lblStrength.Location = new Point(20, 90);
            lblStrength.Text = "RCK Strength:";

            lblSlump.AutoSize = true;
            lblSlump.Location = new Point(20, 125);
            lblSlump.Text = "Slump Class:";

            lblExposure.AutoSize = true;
            lblExposure.Location = new Point(20, 160);
            lblExposure.Text = "Exposure Class:";

            lblWC.AutoSize = true;
            lblWC.Location = new Point(20, 195);
            lblWC.Text = "W/C Ratio:";

            // Inputs
            txtCode.Location = new Point(130, 17);
            txtCode.Size = new Size(220, 23);

            txtDescription.Location = new Point(130, 52);
            txtDescription.Size = new Size(340, 23);

            txtStrength.Location = new Point(130, 87);
            txtStrength.Size = new Size(100, 23);

            txtSlump.Location = new Point(130, 122);
            txtSlump.Size = new Size(100, 23);

            txtExposure.Location = new Point(130, 157);
            txtExposure.Size = new Size(100, 23);

            numWC.DecimalPlaces = 2;
            numWC.Increment = 0.05M;
            numWC.Minimum = 0M;
            numWC.Maximum = 10M;
            numWC.Location = new Point(130, 192);
            numWC.Size = new Size(100, 23);

            // Grid
            dgvComponents.Location = new Point(20, 235);
            dgvComponents.Size = new Size(760, 230);
            dgvComponents.AllowUserToAddRows = false;
            dgvComponents.AllowUserToDeleteRows = false;
            dgvComponents.RowHeadersVisible = false;
            dgvComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComponents.MultiSelect = false;
            dgvComponents.BackgroundColor = Color.White;
            dgvComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // columns
            var colFormulaComponentId = new DataGridViewTextBoxColumn
            {
                Name = "FormulaComponentId",
                HeaderText = "fc_id",
                Visible = false
            };
            var colComponentId = new DataGridViewTextBoxColumn
            {
                Name = "ComponentId",
                HeaderText = "component_id",
                Visible = false
            };
            var colCode = new DataGridViewTextBoxColumn
            {
                Name = "Code",
                HeaderText = "Code",
                ReadOnly = true,
                FillWeight = 20
            };
            var colDescription = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                ReadOnly = true,
                FillWeight = 45
            };
            var colPercentage = new DataGridViewTextBoxColumn
            {
                Name = "Percentage",
                HeaderText = "Percentage (%)",
                FillWeight = 20
            };

            dgvComponents.Columns.AddRange(new DataGridViewColumn[]
            {
                colFormulaComponentId, colComponentId, colCode, colDescription, colPercentage
            });

            dgvComponents.CellEndEdit += dgvComponents_CellEndEdit;

            // Buttons
            btnSave.Text = "Save";
            btnSave.Location = new Point(20, 480);
            btnSave.Size = new Size(100, 30);
            btnSave.Click += btnSave_Click;

            btnAddComponent.Text = "Add Component";
            btnAddComponent.Location = new Point(130, 480);
            btnAddComponent.Size = new Size(140, 30);
            btnAddComponent.Click += btnAddComponent_Click;

            btnDeleteComponent.Text = "Delete";
            btnDeleteComponent.Location = new Point(280, 480);
            btnDeleteComponent.Size = new Size(100, 30);
            btnDeleteComponent.Click += btnDeleteComponent_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(390, 480);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Click += btnCancel_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(lblCode);
            Controls.Add(lblDescription);
            Controls.Add(lblStrength);
            Controls.Add(lblSlump);
            Controls.Add(lblExposure);
            Controls.Add(lblWC);

            Controls.Add(txtCode);
            Controls.Add(txtDescription);
            Controls.Add(txtStrength);
            Controls.Add(txtSlump);
            Controls.Add(txtExposure);
            Controls.Add(numWC);

            Controls.Add(dgvComponents);
            Controls.Add(btnSave);
            Controls.Add(btnAddComponent);
            Controls.Add(btnDeleteComponent);
            Controls.Add(btnCancel);

            Name = "FormulaDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Formula Details";
            Load += FormulaDetailsForm_Load;

            ((System.ComponentModel.ISupportInitialize)(numWC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvComponents)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
