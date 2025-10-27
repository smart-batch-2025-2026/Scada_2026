using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    public partial class ProductDetailsForm : Form
    {
        public string Code { get => txtCode.Text; set => txtCode.Text = value; }
        public string Description { get => txtDescription.Text; set => txtDescription.Text = value; }
        public string Type { get => cmbType.Text; set => cmbType.Text = value; }
        public string UOM { get => cmbUOM.Text; set => cmbUOM.Text = value; }
        public string Specifications { get => txtSpecifications.Text; set => txtSpecifications.Text = value; }

        private PrintDocument printDocument;

        // Constructor for New
        public ProductDetailsForm()
        {
            InitializeComponent();
            cmbType.Items.AddRange(new[] {"Aggregate","Cement","Water","Additive","Color","Adding","Aggregates mixtures" });
            cmbUOM.Items.AddRange(new[] { "kg", "ton", "m3", "litre" });

            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        // Constructor for Edit
        public ProductDetailsForm(string code, string desc, string type, string uom, string specs) : this()
        {
            Code = code;
            Description = desc;
            Type = type;
            UOM = uom;
            Specifications = specs;
            txtCode.ReadOnly = true; // lock Code when editing
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 🔹 Print single product
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDocument
            };
            preview.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 100;
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 11);

            e.Graphics.DrawString("Product Details", titleFont, Brushes.Black, 100, y);
            y += 40;

            e.Graphics.DrawString($"Code: {Code}", bodyFont, Brushes.Black, 100, y);
            y += 25;

            e.Graphics.DrawString($"Description: {Description}", bodyFont, Brushes.Black, 100, y);
            y += 25;

            e.Graphics.DrawString($"Type: {Type}", bodyFont, Brushes.Black, 100, y);
            y += 25;

            e.Graphics.DrawString($"UOM: {UOM}", bodyFont, Brushes.Black, 100, y);
            y += 25;

            e.Graphics.DrawString("Specifications:", bodyFont, Brushes.Black, 100, y);
            y += 25;

            e.Graphics.DrawString(Specifications, bodyFont, Brushes.Black, 120, y);
        }
    }
}
