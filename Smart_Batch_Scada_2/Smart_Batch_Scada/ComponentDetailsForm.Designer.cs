namespace Smart_Batch_Scada
{
    partial class ComponentDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblCode;
        private TextBox txtCode;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblUOM;
        private TextBox txtUOM;
        private Label lblGravity;
        private TextBox txtGravity;
        private Label lblColor;
        private Button btnColor;
        private Panel pnlColorPreview;

        private Label lblAltCode;
        private TextBox txtAltCode;

        private Label lblAbsorption;
        private TextBox txtAbsorption;
        private Label lblMaxDiameter;
        private TextBox txtMaxDiameter;

        private Label lblClass;
        private TextBox txtClass;

        private Label lblWaterContent;
        private TextBox txtWaterContent;
        private CheckBox chkIce;

        private Label lblPercentOnCement;
        private TextBox txtPercentOnCement;

        private Label lblInfluenceWC;
        private TextBox txtInfluenceWC;

        private Button btnOK;
        private Button btnCancel;

        private ComboBox cmbComponentType;
        private DataGridView dgvComponents;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Labels and TextBoxes
            lblCode = new Label() { Location = new Point(16, 12), Size = new Size(80, 20), Text = "Code:" };
            txtCode = new TextBox() { Location = new Point(110, 10), Size = new Size(260, 27) };

            lblDescription = new Label() { Location = new Point(16, 44), Size = new Size(88, 25), Text = "Description:" };
            txtDescription = new TextBox() { Location = new Point(110, 42), Size = new Size(260, 27) };

            lblUOM = new Label() { Location = new Point(16, 76), Size = new Size(80, 20), Text = "UOM:" };
            txtUOM = new TextBox() { Location = new Point(110, 74), Size = new Size(120, 27) };

            lblGravity = new Label() { Location = new Point(240, 76), Size = new Size(80, 20), Text = "Gravity:" };
            txtGravity = new TextBox() { Location = new Point(320, 74), Size = new Size(50, 27) };

            lblColor = new Label() { Location = new Point(16, 108), Size = new Size(80, 20), Text = "Color:" };
            btnColor = new Button() { Location = new Point(110, 104), Size = new Size(120, 28), Text = "Choose..." };
            btnColor.Click += btnColor_Click;
            pnlColorPreview = new Panel() { Location = new Point(240, 104), Size = new Size(24, 24), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };

            // AltCode
            lblAltCode = new Label() { Location = new Point(16, 140), Size = new Size(120, 20), Text = "Alt Code:" };
            txtAltCode = new TextBox() { Location = new Point(140, 138), Size = new Size(120, 27) };

            // Aggregate
            lblAbsorption = new Label() { Location = new Point(16, 176), Size = new Size(120, 20), Text = "Absorption %:" };
            txtAbsorption = new TextBox() { Location = new Point(140, 174), Size = new Size(80, 27) };

            lblMaxDiameter = new Label() { Location = new Point(240, 176), Size = new Size(113, 25), Text = "Max Diameter:" };
            txtMaxDiameter = new TextBox() { Location = new Point(350, 174), Size = new Size(80, 27) };

            // Cement
            lblClass = new Label() { Location = new Point(16, 212), Size = new Size(80, 20), Text = "Class:" };
            txtClass = new TextBox() { Location = new Point(110, 210), Size = new Size(120, 27) };

            // Water / Additive
            lblWaterContent = new Label() { Location = new Point(16, 248), Size = new Size(120, 20), Text = "% Water:" };
            txtWaterContent = new TextBox() { Location = new Point(140, 246), Size = new Size(80, 27) };
            chkIce = new CheckBox() { Location = new Point(240, 246), Size = new Size(80, 27), Text = "Ice" };

            lblPercentOnCement = new Label() { Location = new Point(16, 284), Size = new Size(120, 20), Text = "% on Cement:" };
            txtPercentOnCement = new TextBox() { Location = new Point(140, 282), Size = new Size(80, 27) };

            lblInfluenceWC = new Label() { Location = new Point(240, 284), Size = new Size(150, 25), Text = "% Influence W/C:" };
            txtInfluenceWC = new TextBox() { Location = new Point(380, 282), Size = new Size(80, 27) };

            // Buttons
            btnOK = new Button() { Location = new Point(180, 320), Size = new Size(100, 36), Text = "OK" };
            btnOK.Click += btnOK_Click;
            btnCancel = new Button() { Location = new Point(300, 320), Size = new Size(100, 36), Text = "Cancel" };
            btnCancel.Click += btnCancel_Click;

            // ComboBox
            cmbComponentType = new ComboBox() { Location = new Point(16, 360), Size = new Size(200, 27), DropDownStyle = ComboBoxStyle.DropDownList };

            // DataGridView
            dgvComponents = new DataGridView()
            {
                Location = new Point(16, 400),
                Size = new Size(555, 200),
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvComponents.Columns.Add("Code", "Code");
            dgvComponents.Columns.Add("Description", "Description");
            dgvComponents.Columns.Add("UOM", "UOM");
            dgvComponents.Columns.Add("Type", "Type");

            // Add controls
            Controls.AddRange(new Control[] {
                lblCode, txtCode, lblDescription, txtDescription, lblUOM, txtUOM, lblGravity, txtGravity,
                lblColor, btnColor, pnlColorPreview,
                lblAltCode, txtAltCode,
                lblAbsorption, txtAbsorption, lblMaxDiameter, txtMaxDiameter,
                lblClass, txtClass,
                lblWaterContent, txtWaterContent, chkIce,
                lblPercentOnCement, txtPercentOnCement,
                lblInfluenceWC, txtInfluenceWC,
                btnOK, btnCancel,
                cmbComponentType, dgvComponents
            });

            // Form settings
            ClientSize = new Size(600, 650);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Component Details";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}