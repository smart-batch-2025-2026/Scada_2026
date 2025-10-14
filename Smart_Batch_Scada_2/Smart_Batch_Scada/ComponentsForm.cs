using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class ComponentsForm : Form
    {
        private string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";
        private string currentFilterType = "Aggregate";

        public ComponentsForm()
        {
            InitializeComponent();
        }

        private void ComponentsForm_Load(object sender, EventArgs e)
        {
            LoadComponents(currentFilterType);
            HighlightActiveButton(btnAggregate);
        }

        private void LoadComponents(string type)
        {
            using (var conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Code, Description, UOM, Gravity, Color FROM Components WHERE Type=@Type";
                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Type", type);
                    using var adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading components: " + ex.Message);
                }
            }
        }

        private void HighlightActiveButton(Button activeBtn)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn && btn.Tag?.ToString() == "filter")
                {
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }
            activeBtn.BackColor = Color.Black;
            activeBtn.ForeColor = Color.White;
        }

        // ---------------- ACTION BUTTONS ----------------
        private void btnNew_Click(object sender, EventArgs e)
        {
            using var form = new ComponentDetailsForm(null, currentFilterType);
            if (form.ShowDialog() == DialogResult.OK)
                LoadComponents(currentFilterType);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            string code = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
            using var form = new ComponentDetailsForm(code, currentFilterType);
            if (form.ShowDialog() == DialogResult.OK)
                LoadComponents(currentFilterType);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            string code = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
            if (MessageBox.Show($"Delete component {code}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();
                using var cmd = new MySqlCommand("DELETE FROM Components WHERE Code=@Code", conn);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.ExecuteNonQuery();
                LoadComponents(currentFilterType);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV File|*.csv" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string[] lines = System.IO.File.ReadAllLines(ofd.FileName);
            using var conn = new MySqlConnection(connString);
            conn.Open();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var cmd = new MySqlCommand("INSERT INTO Components (Code,Description,UOM,Gravity,Color,Type) VALUES (@Code,@Desc,@UOM,@Grav,@Color,@Type)", conn);
                cmd.Parameters.AddWithValue("@Code", parts[0]);
                cmd.Parameters.AddWithValue("@Desc", parts[1]);
                cmd.Parameters.AddWithValue("@UOM", parts[2]);
                cmd.Parameters.AddWithValue("@Grav", parts[3]);
                cmd.Parameters.AddWithValue("@Color", parts[4]);
                cmd.Parameters.AddWithValue("@Type", currentFilterType);
                cmd.ExecuteNonQuery();
            }
            LoadComponents(currentFilterType);
            MessageBox.Show("Import completed.");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV File|*.csv" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using var sw = new System.IO.StreamWriter(sfd.FileName);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                sw.WriteLine($"{row.Cells["Code"].Value},{row.Cells["Description"].Value},{row.Cells["UOM"].Value},{row.Cells["Gravity"].Value},{row.Cells["Color"].Value}");
            }
            MessageBox.Show("Export completed.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            var doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += (s, ev) =>
            {
                int y = 50;
                ev.Graphics.DrawString($"Component Type: {currentFilterType}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(50, y));
                y += 30;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    string line = $"{row.Cells["Code"].Value} - {row.Cells["Description"].Value}";
                    ev.Graphics.DrawString(line, new Font("Arial", 10), Brushes.Black, new PointF(50, y));
                    y += 20;
                }
            };
            preview.Document = doc;
            preview.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();

        // ----------- FILTER BUTTONS -----------
        private void btnAggregate_Click(object sender, EventArgs e) { currentFilterType = "Aggregate"; LoadComponents(currentFilterType); HighlightActiveButton(btnAggregate); }
        private void btnCement_Click(object sender, EventArgs e) { currentFilterType = "Cement"; LoadComponents(currentFilterType); HighlightActiveButton(btnCement); }
        private void btnWater_Click(object sender, EventArgs e) { currentFilterType = "Water"; LoadComponents(currentFilterType); HighlightActiveButton(btnWater); }
        private void btnAdditive_Click(object sender, EventArgs e) { currentFilterType = "Additive"; LoadComponents(currentFilterType); HighlightActiveButton(btnAdditive); }
        private void btnColour_Click(object sender, EventArgs e) { currentFilterType = "Colour"; LoadComponents(currentFilterType); HighlightActiveButton(btnColour); }
        private void btnAdding_Click(object sender, EventArgs e) { currentFilterType = "Adding"; LoadComponents(currentFilterType); HighlightActiveButton(btnAdding); }
    }
}