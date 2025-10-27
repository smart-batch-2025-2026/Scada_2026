using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    partial class ProductDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCode, txtDescription, txtSpecifications;
        private ComboBox cmbType, cmbUOM;
        private Button btnOK, btnCancel, btnPrint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCode = new TextBox();
            this.txtDescription = new TextBox();
            this.txtSpecifications = new TextBox();
            this.cmbType = new ComboBox();
            this.cmbUOM = new ComboBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.btnPrint = new Button();

            this.SuspendLayout();

            // txtCode
            this.txtCode.Location = new Point(120, 30);
            this.txtCode.Size = new Size(250, 23);

            // txtDescription
            this.txtDescription.Location = new Point(120, 70);
            this.txtDescription.Size = new Size(250, 23);

            // cmbType
            this.cmbType.Location = new Point(120, 110);
            this.cmbType.Size = new Size(250, 23);

            // cmbUOM
            this.cmbUOM.Location = new Point(120, 150);
            this.cmbUOM.Size = new Size(250, 23);

            // txtSpecifications
            this.txtSpecifications.Location = new Point(120, 190);
            this.txtSpecifications.Size = new Size(250, 80);
            this.txtSpecifications.Multiline = true;

            // btnOK
            this.btnOK.Text = "OK";
            this.btnOK.Location = new Point(120, 300);
            this.btnOK.Size = new Size(100, 40);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(230, 300);
            this.btnCancel.Size = new Size(100, 40);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // btnPrint
            this.btnPrint.Image = Properties.Resources.icon_printing_preview;
            this.btnPrint.Location = new Point(340, 300);
            this.btnPrint.Size = new Size(40, 40);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // ProductDetailsForm
            this.ClientSize = new Size(420, 380);
            this.Controls.Add(new Label { Text = "Code", Location = new Point(20, 30) });
            this.Controls.Add(this.txtCode);
            this.Controls.Add(new Label { Text = "Description", Location = new Point(20, 70) });
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(new Label { Text = "Type", Location = new Point(20, 110) });
            this.Controls.Add(this.cmbType);
            this.Controls.Add(new Label { Text = "UOM", Location = new Point(20, 150) });
            this.Controls.Add(this.cmbUOM);
            this.Controls.Add(new Label { Text = "Specifications", Location = new Point(20, 190) });
            this.Controls.Add(this.txtSpecifications);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Product Details";
            this.ResumeLayout(false);
        }
    }
}
