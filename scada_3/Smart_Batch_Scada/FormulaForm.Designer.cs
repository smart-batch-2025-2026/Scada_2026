namespace Smart_Batch_Scada
{
    partial class FormulasForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvFormulas;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvFormulas = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulas)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Formulas (Mix Designs)";

            // 
            // dgvFormulas
            // 
            this.dgvFormulas.AllowUserToAddRows = false;
            this.dgvFormulas.AllowUserToDeleteRows = false;
            this.dgvFormulas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFormulas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulas.Location = new System.Drawing.Point(20, 60);
            this.dgvFormulas.MultiSelect = false;
            this.dgvFormulas.Name = "dgvFormulas";
            this.dgvFormulas.ReadOnly = true;
            this.dgvFormulas.RowHeadersVisible = false;
            this.dgvFormulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormulas.Size = new System.Drawing.Size(860, 400);
            this.dgvFormulas.TabIndex = 1;
            this.dgvFormulas.DoubleClick += new System.EventHandler(this.dgvFormulas_DoubleClick);

            // 
            // Action Buttons
            // 
            SetupActionButton(this.btnNew, "New", Properties.Resources.icon_new, new System.Drawing.Point(20, 480), this.btnNew_Click);
            SetupActionButton(this.btnEdit, "Edit", Properties.Resources.modife, new System.Drawing.Point(120, 480), this.btnEdit_Click);
            SetupActionButton(this.btnDelete, "Delete", Properties.Resources.icon_delete, new System.Drawing.Point(220, 480), this.btnDelete_Click);
            SetupActionButton(this.btnCopy, "Copy", Properties.Resources.copying_icon, new System.Drawing.Point(320, 480), this.btnCopy_Click);
            SetupActionButton(this.btnImport, "Import", Properties.Resources.importing_componants, new System.Drawing.Point(440, 480), this.btnImport_Click);
            SetupActionButton(this.btnExport, "Export", Properties.Resources.exporting_componants, new System.Drawing.Point(540, 480), this.btnExport_Click);
            SetupActionButton(this.btnPrint, "Print", Properties.Resources.printing_icon, new System.Drawing.Point(640, 480), this.btnPrint_Click);
            SetupActionButton(this.btnExit, "Exit", Properties.Resources.exit_icon, new System.Drawing.Point(760, 480), this.btnExit_Click);

            // 
            // FormulasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvFormulas);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormulasForm";
            this.Text = "Formulas Management";
            this.Load += new System.EventHandler(this.FormulasForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulas)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupActionButton(System.Windows.Forms.Button btn, string text, System.Drawing.Image icon, System.Drawing.Point location, EventHandler handler)
        {
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.Image = icon;
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btn.Text = text;
            btn.Size = new System.Drawing.Size(90, 35);
            btn.Location = location;
            btn.UseVisualStyleBackColor = true;
            btn.Click += handler;
        }
    }
}
