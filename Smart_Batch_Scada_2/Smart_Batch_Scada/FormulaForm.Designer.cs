namespace Smart_Batch_Scada
{
    partial class FormulasForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button btnNew, btnEdit, btnCopy, btnDelete, btnFind;
        private Button btnImport, btnExport, btnPrint, btnExit;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            dataGridView1 = new DataGridView();
            btnNew = new Button(); btnEdit = new Button(); btnCopy = new Button();
            btnDelete = new Button(); btnFind = new Button(); btnImport = new Button();
            btnExport = new Button(); btnPrint = new Button(); btnExit = new Button();
            lblTitle = new Label();

            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.SuspendLayout();

            // Title Label
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(300, 30);
            lblTitle.Text = "Formulas (Mix Designs)";
            lblTitle.ForeColor = Color.DarkBlue;

            // DataGridView
            dataGridView1.Location = new Point(20, 60);
            dataGridView1.Size = new Size(860, 380);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            dataGridView1.KeyPress += dataGridView1_KeyPress;

            // Helper for action buttons
            void SetupActionButton(Button btn, string text, Image img, Point loc, EventHandler handler)
            {
                btn.Location = loc;
                btn.Size = new Size(100, 44);
                btn.Text = " " + text;
                btn.Image = img;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleRight;
                btn.Click += handler;
                btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            }

            // Action buttons - using same icons as Components form
            SetupActionButton(btnNew, "New", Properties.Resources.icon_new, new Point(20, 460), btnNew_Click);
            SetupActionButton(btnEdit, "Edit", Properties.Resources.modife, new Point(130, 460), btnEdit_Click);
            SetupActionButton(btnCopy, "Copy", Properties.Resources.copying_icon, new Point(240, 460), btnCopy_Click);
            SetupActionButton(btnDelete, "Delete", Properties.Resources.icon_delete, new Point(350, 460), btnDelete_Click);
            SetupActionButton(btnFind, "Find", Properties.Resources.modife, new Point(460, 460), btnFind_Click);
            SetupActionButton(btnImport, "Import", Properties.Resources.importing_componants, new Point(570, 460), btnImport_Click);
            SetupActionButton(btnExport, "Export", Properties.Resources.exporting_componants, new Point(680, 460), btnExport_Click);
            SetupActionButton(btnPrint, "Print", Properties.Resources.printing_icon, new Point(790, 460), btnPrint_Click);

            // Exit button
            btnExit.Location = new Point(900, 460);
            btnExit.Size = new Size(80, 44);
            btnExit.Text = " Exit";
            btnExit.Image = Properties.Resources.exit_icon;
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.TextAlign = ContentAlignment.MiddleRight;
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Click += btnExit_Click;

            // Form setup
            this.ClientSize = new Size(1000, 520);
            this.Controls.Add(lblTitle);
            this.Controls.Add(dataGridView1);
            this.Controls.AddRange(new Control[]
            {
                btnNew, btnEdit, btnCopy, btnDelete, btnFind,
                btnImport, btnExport, btnPrint, btnExit
            });
            this.Text = "Formulas Management";
            this.Load += new EventHandler(this.FormulasForm_Load);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}