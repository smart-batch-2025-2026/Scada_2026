namespace Smart_Batch_Scada
{
    partial class FormulaDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtCode;
        private TextBox txtDescription;
        private TextBox txtRckStrength;
        private TextBox txtSlump;
        private NumericUpDown numWaterCementRatio;
        private TextBox txtProductCode;
        private NumericUpDown numTimeLimit;

        private DataGridView dgvComponents;
        private Button btnAddComponent;
        private Button btnRemoveComponent;
        private Button btnSave;
        private Button btnCancel;

        private Label lblCode;
        private Label lblDescription;
        private Label lblRckStrength;
        private Label lblSlump;
        private Label lblWaterCementRatio;
        private Label lblProductCode;
        private Label lblTimeLimit;
        private Label lblTotalWeight;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Form Setup
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(900, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Formula Edit";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            lblCode = CreateLabel("Code:", 20, 20);
            lblDescription = CreateLabel("Description:", 20, 50);
            lblRckStrength = CreateLabel("Rck/Strength:", 20, 80);
            lblSlump = CreateLabel("Slump:", 20, 110);
            lblWaterCementRatio = CreateLabel("Water/Cement Ratio:", 20, 140);
            lblProductCode = CreateLabel("Product Code:", 20, 170);
            lblTimeLimit = CreateLabel("Time Limit (min):", 20, 200);
            lblTotalWeight = CreateLabel("Total Weight: 0 kg/m³", 20, 230);
            lblTotalWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalWeight.ForeColor = Color.DarkBlue;

            // TextBoxes and Numeric Controls
            txtCode = CreateTextBox(150, 18, 200);
            txtDescription = CreateTextBox(150, 48, 400);
            txtRckStrength = CreateTextBox(150, 78, 150);
            txtSlump = CreateTextBox(150, 108, 150);
            numWaterCementRatio = CreateNumeric(150, 138, 100, 0, 10, 4);
            txtProductCode = CreateTextBox(150, 168, 150);
            numTimeLimit = CreateNumeric(150, 198, 150, 0, 1000, 0);

            // Components DataGridView
            dgvComponents = new DataGridView();
            dgvComponents.Location = new Point(20, 260);
            dgvComponents.Size = new Size(840, 250);
            dgvComponents.AllowUserToAddRows = false;
            dgvComponents.ReadOnly = false;
            dgvComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComponents.RowHeadersVisible = false;
            dgvComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add columns
            dgvComponents.Columns.Add("colType", "Type");
            dgvComponents.Columns.Add("colDescription", "Description");
            dgvComponents.Columns.Add("colUOM", "UOM");
            dgvComponents.Columns.Add("colQuantity", "Quantity");
            dgvComponents.Columns.Add("colPercentOnCement", "% on Cement");
            dgvComponents.Columns.Add("colSpecificWeight", "S.W.");

            // Style quantity columns
            dgvComponents.Columns["colQuantity"].DefaultCellStyle.Format = "F4";
            dgvComponents.Columns["colPercentOnCement"].DefaultCellStyle.Format = "F2";
            dgvComponents.Columns["colSpecificWeight"].DefaultCellStyle.Format = "F4";

            // Buttons
            btnAddComponent = CreateButton("Add Component", 20, 520, 120, 35, Color.LightBlue);
            btnRemoveComponent = CreateButton("Remove Component", 150, 520, 120, 35, Color.LightCoral);
            btnSave = CreateButton("Save", 650, 520, 100, 35, Color.LightGreen);
            btnCancel = CreateButton("Cancel", 760, 520, 100, 35, Color.LightCoral);

            // Event handlers
            btnAddComponent.Click += btnAddComponent_Click;
            btnRemoveComponent.Click += btnRemoveComponent_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            dgvComponents.CellEndEdit += dgvComponents_CellEndEdit;

            // Add all controls to form
            this.Controls.AddRange(new Control[] {
                lblCode, txtCode,
                lblDescription, txtDescription,
                lblRckStrength, txtRckStrength,
                lblSlump, txtSlump,
                lblWaterCementRatio, numWaterCementRatio,
                lblProductCode, txtProductCode,
                lblTimeLimit, numTimeLimit,
                lblTotalWeight,
                dgvComponents,
                btnAddComponent, btnRemoveComponent,
                btnSave, btnCancel
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
        }

        private TextBox CreateTextBox(int x, int y, int width)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 23),
                Font = new Font("Segoe UI", 9F)
            };
        }

        private NumericUpDown CreateNumeric(int x, int y, int width, decimal min, decimal max, int decimalPlaces)
        {
            return new NumericUpDown
            {
                Location = new Point(x, y),
                Size = new Size(width, 23),
                Minimum = min,
                Maximum = max,
                DecimalPlaces = decimalPlaces,
                Font = new Font("Segoe UI", 9F)
            };
        }

        private Button CreateButton(string text, int x, int y, int width, int height, Color backColor)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = backColor,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };
        }
    }
}