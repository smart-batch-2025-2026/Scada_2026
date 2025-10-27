using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    public partial class FormulasForm : Form
    {
        private MySqlConnection conn;
        private string connString = "server=localhost;user id=root;password=Mohammed10.;database=hary_data_0;";

        public FormulasForm()
        {
            InitializeComponent();
            conn = new MySqlConnection(connString);
        }


        // 🔹 Load Formulas when window opens
        private void FormulasForm_Load(object sender, EventArgs e)
        {
            LoadFormulas();
        }

        // 🔹 Load formulas list from database
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
                exposure_class AS 'Exposure',
                agg_max_diameter AS 'Max Diameter',
                granulometric_curve AS 'Granulometric Curve',
                oversanded AS 'Oversanded',
                water_cement_ratio AS 'W/C Ratio',
                wc_tolerance AS '+/- %',
                product_code AS 'Product Code',
                time_limit AS 'Time Limit',
                certificate AS 'Certificate'
            FROM formulas
            ORDER BY id DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvFormulas.DataSource = dt;

                dgvFormulas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvFormulas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFormulas.MultiSelect = false;
                dgvFormulas.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading formulas:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        // 🔹 Create a new formula
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormulaDetailsForm form = new FormulaDetailsForm(conn, null);
            if (form.ShowDialog() == DialogResult.OK)
                LoadFormulas();
        }

        // 🔹 Edit selected formula
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFormulas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a formula to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int formulaId = Convert.ToInt32(dgvFormulas.SelectedRows[0].Cells["ID"].Value);
            FormulaDetailsForm form = new FormulaDetailsForm(conn, formulaId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadFormulas();
        }

        // 🔹 Delete selected formula
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFormulas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a formula to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int formulaId = Convert.ToInt32(dgvFormulas.SelectedRows[0].Cells["ID"].Value);
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this formula?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM formulas WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", formulaId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Formula deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFormulas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting formula:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // 🔹 Copy selected formula
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dgvFormulas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a formula to copy.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int formulaId = Convert.ToInt32(dgvFormulas.SelectedRows[0].Cells["ID"].Value);
            FormulaDetailsForm form = new FormulaDetailsForm(conn, formulaId, copyMode: true);
            if (form.ShowDialog() == DialogResult.OK)
                LoadFormulas();
        }

        // 🔹 Import formulas (placeholder)
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string filePath = ofd.FileName;
                // For CSV (simple example)
                var lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines.Skip(1)) // skip header
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 5) // ensure enough columns
                    {
                        conn.Open();
                        string query = @"INSERT INTO formulas (code, description, rck_strength, slump, exposure_class, water_cement_ratio)
                                 VALUES (@code, @desc, @rck, @slump, @expo, @wcr)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@code", parts[0]);
                        cmd.Parameters.AddWithValue("@desc", parts[1]);
                        cmd.Parameters.AddWithValue("@rck", parts[2]);
                        cmd.Parameters.AddWithValue("@slump", parts[3]);
                        cmd.Parameters.AddWithValue("@expo", parts[4]);
                        cmd.Parameters.AddWithValue("@wcr", parts.Length > 5 ? Convert.ToDecimal(parts[5]) : 0);
                        cmd.ExecuteNonQuery();
                        conn.Close();
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


        // 🔹 Export formulas (placeholder)
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = "FormulasExport.csv";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                DataTable dt = (DataTable)dgvFormulas.DataSource;
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


        // 🔹 Print formulas list
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                Bitmap bmp = new Bitmap(dgvFormulas.Width, dgvFormulas.Height);
                dgvFormulas.DrawToBitmap(bmp, new Rectangle(0, 0, dgvFormulas.Width, dgvFormulas.Height));
                ev.Graphics.DrawImage(bmp, 0, 0);
            };

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDoc;
            ppd.ShowDialog();
        }


        // 🔹 Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 🔹 Double click formula to edit
        private void dgvFormulas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFormulas.SelectedRows.Count > 0)
            {
                int formulaId = Convert.ToInt32(dgvFormulas.SelectedRows[0].Cells["ID"].Value);
                FormulaDetailsForm form = new FormulaDetailsForm(conn, formulaId);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadFormulas();
            }
        }
    }
}
