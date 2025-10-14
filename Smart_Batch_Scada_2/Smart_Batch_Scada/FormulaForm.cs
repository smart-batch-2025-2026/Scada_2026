using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    public partial class FormulasForm : Form
    {
        private MySqlConnection conn;
        private string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";

        public FormulasForm()
        {
            InitializeComponent();
            conn = new MySqlConnection(connString);
        }

        private void FormulasForm_Load(object sender, EventArgs e)
        {
            LoadFormulas();
        }

        private void LoadFormulas()
        {
            try
            {
                conn.Open();
                string query = @"
                    SELECT 
                        id AS 'ID',
                        code AS 'Code',
                        description AS 'Description',
                        rck_strength AS 'Rck/Strength',
                        slump AS 'Slump',
                        water_cement_ratio AS 'W/C Ratio',
                        product_code AS 'Product Code',
                        time_limit AS 'Time Limit'
                    FROM formulas
                    ORDER BY code";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading formulas:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (var form = new FormulaDetailsForm(conn, null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadFormulas();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a formula to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int formulaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            using (var form = new FormulaDetailsForm(conn, formulaId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadFormulas();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a formula to copy.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int formulaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            using (var form = new FormulaCopyForm(conn, formulaId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadFormulas();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a formula to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string formulaCode = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete formula '{formulaCode}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM formulas WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id",
                        Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Formula deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFormulas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting formula:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string searchText = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter formula code to find:", "Find Formula", "");

            if (!string.IsNullOrEmpty(searchText))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Code"].Value?.ToString().ToLower().Contains(searchText.ToLower()) == true)
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string[] lines = System.IO.File.ReadAllLines(ofd.FileName);
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    foreach (var line in lines.Skip(1)) // skip header
                    {
                        var parts = line.Split(',');
                        if (parts.Length >= 3)
                        {
                            string query = @"INSERT INTO formulas (code, description, rck_strength, slump, water_cement_ratio, product_code, time_limit)
                                     VALUES (@code, @desc, @rck, @slump, @wcr, @product, @time)";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@code", parts[0]);
                            cmd.Parameters.AddWithValue("@desc", parts[1]);
                            cmd.Parameters.AddWithValue("@rck", parts.Length > 2 ? parts[2] : "");
                            cmd.Parameters.AddWithValue("@slump", parts.Length > 3 ? parts[3] : "");
                            cmd.Parameters.AddWithValue("@wcr", parts.Length > 4 ? Convert.ToDecimal(parts[4]) : 0);
                            cmd.Parameters.AddWithValue("@product", parts.Length > 5 ? parts[5] : "");
                            cmd.Parameters.AddWithValue("@time", parts.Length > 6 ? Convert.ToInt32(parts[6]) : 0);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                LoadFormulas();
                MessageBox.Show("Formulas imported successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing formulas:\n" + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv" };
            sfd.FileName = "FormulasExport.csv";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                using (var sw = new System.IO.StreamWriter(sfd.FileName))
                {
                    // Write header
                    sw.WriteLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                    // Write rows
                    foreach (DataRow row in dt.Rows)
                    {
                        sw.WriteLine(string.Join(",", row.ItemArray));
                    }
                }
                MessageBox.Show("Export completed!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting formulas:\n" + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            var doc = new PrintDocument();
            doc.PrintPage += (s, ev) =>
            {
                int y = 50;
                ev.Graphics.DrawString("Formulas List", new Font("Arial", 16, FontStyle.Bold),
                    Brushes.Black, new PointF(50, y));
                y += 40;

                // Draw headers
                ev.Graphics.DrawString("Code", new Font("Arial", 10, FontStyle.Bold),
                    Brushes.Black, new PointF(50, y));
                ev.Graphics.DrawString("Description", new Font("Arial", 10, FontStyle.Bold),
                    Brushes.Black, new PointF(150, y));
                ev.Graphics.DrawString("W/C Ratio", new Font("Arial", 10, FontStyle.Bold),
                    Brushes.Black, new PointF(400, y));
                y += 20;

                // Draw data
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    ev.Graphics.DrawString(row.Cells["Code"].Value?.ToString(),
                        new Font("Arial", 9), Brushes.Black, new PointF(50, y));
                    ev.Graphics.DrawString(row.Cells["Description"].Value?.ToString(),
                        new Font("Arial", 9), Brushes.Black, new PointF(150, y));
                    ev.Graphics.DrawString(row.Cells["W/C Ratio"].Value?.ToString(),
                        new Font("Arial", 9), Brushes.Black, new PointF(400, y));
                    y += 15;
                }
            };
            preview.Document = doc;
            preview.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Quick find feature
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                string searchChar = e.KeyChar.ToString();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Code"].Value?.ToString().ToLower().StartsWith(searchChar.ToLower()) == true)
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }
    }
}