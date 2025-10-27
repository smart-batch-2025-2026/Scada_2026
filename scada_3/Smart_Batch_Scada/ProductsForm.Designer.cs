using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProducts;
        private Label lblTitle;
        private Button btnNew, btnEdit, btnDelete, btnImport, btnExport, btnPrint, btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProducts = new DataGridView();
            this.lblTitle = new Label();
            this.btnNew = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnImport = new Button();
            this.btnExport = new Button();
            this.btnPrint = new Button();
            this.btnExit = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // Title Label
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Text = "Products Management";

            // DataGridView
            dgvProducts.Location = new Point(20, 60);
            dgvProducts.Size = new Size(860, 400);
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.WhiteSmoke;
            dgvProducts.MultiSelect = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.DoubleClick += dgvProducts_DoubleClick;

            // Buttons Layout
            SetupActionButton(btnNew, "New", Properties.Resources.icon_new, new Point(20, 480), btnNew_Click);
            SetupActionButton(btnEdit, "Edit", Properties.Resources.modife, new Point(120, 480), btnEdit_Click);
            SetupActionButton(btnDelete, "Delete", Properties.Resources.icon_delete, new Point(220, 480), btnDelete_Click);
            SetupActionButton(btnImport, "Import", Properties.Resources.icon_Importing, new Point(340, 480), btnImport_Click);
            SetupActionButton(btnExport, "Export", Properties.Resources.icon_Exporting, new Point(440, 480), btnExport_Click);
            SetupActionButton(btnPrint, "Print", Properties.Resources.icon_printing, new Point(540, 480), btnPrint_Click);
            SetupActionButton(btnExit, "Exit", Properties.Resources.icon_Exit, new Point(640, 480), btnExit_Click);

            // Form
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 530);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Products Management";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Load += ProductsForm_Load;

            this.Controls.Add(lblTitle);
            this.Controls.Add(dgvProducts);
            this.Controls.Add(btnNew);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnImport);
            this.Controls.Add(btnExport);
            this.Controls.Add(btnPrint);
            this.Controls.Add(btnExit);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupActionButton(Button btn, string text, Image icon, Point location, EventHandler handler)
        {
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Image = icon;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.Text = text;
            btn.Size = new Size(90, 35);
            btn.Location = location;
            btn.UseVisualStyleBackColor = true;
            btn.Click += handler;
        }
    }
}
