using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    public partial class ProductsForm : Form
    {
        private MySqlConnection conn;
        private string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";
        private DataTable productsTable;

        public ProductsForm()
        {
            InitializeComponent();
            conn = new MySqlConnection(connString);
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                conn.Open();
                string query = @"SELECT Code, Description, Type, UOM, Specifications FROM Products ORDER BY Code ASC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                productsTable = new DataTable();
                da.Fill(productsTable);
                dgvProducts.DataSource = productsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (ProductDetailsForm form = new ProductDetailsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            string code = dgvProducts.SelectedRows[0].Cells["Code"].Value.ToString();
            string desc = dgvProducts.SelectedRows[0].Cells["Description"].Value.ToString();
            string type = dgvProducts.SelectedRows[0].Cells["Type"].Value.ToString();
            string uom = dgvProducts.SelectedRows[0].Cells["UOM"].Value.ToString();
            string specs = dgvProducts.SelectedRows[0].Cells["Specifications"].Value.ToString();

            using (ProductDetailsForm form = new ProductDetailsForm(code, desc, type, uom, specs))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            string code = dgvProducts.SelectedRows[0].Cells["Code"].Value.ToString();
            DialogResult dr = MessageBox.Show($"Delete product {code}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Products WHERE Code=@Code", conn);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.ExecuteNonQuery();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product:\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string[] lines = File.ReadAllLines(ofd.FileName);
                conn.Open();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 5) continue;

                    string query = "INSERT INTO Products (Code, Description, Type, UOM, Specifications) VALUES (@Code,@Description,@Type,@UOM,@Specifications)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Code", parts[0]);
                    cmd.Parameters.AddWithValue("@Description", parts[1]);
                    cmd.Parameters.AddWithValue("@Type", parts[2]);
                    cmd.Parameters.AddWithValue("@UOM", parts[3]);
                    cmd.Parameters.AddWithValue("@Specifications", parts[4]);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Import successful.");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing products:\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "ProductsExport.csv" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (DataRow row in productsTable.Rows)
                    {
                        sw.WriteLine($"{row["Code"]},{row["Description"]},{row["Type"]},{row["UOM"]},{row["Specifications"]}");
                    }
                }
                MessageBox.Show("Export completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting products:\n" + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                Bitmap bmp = new Bitmap(dgvProducts.Width, dgvProducts.Height);
                dgvProducts.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, dgvProducts.Width, dgvProducts.Height));
                ev.Graphics.DrawImage(bmp, 0, 0);
            };

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = printDoc };
            ppd.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
