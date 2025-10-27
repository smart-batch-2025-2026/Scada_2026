using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SCADA.Domain;
using SCADA.Application;
using SCADA.Infrastructure;


namespace Smart_Batch_Scada
{
    public partial class ComponentsForm : Form
    {
        private readonly MaterialDataService service;
        private string currentFilterType = "Aggregate";

        public ComponentsForm()
        {
            InitializeComponent();

            // ✅ Correct initialization (Infrastructure → Application)
            var repo = new ComponentsRepository("server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;");
            service = new MaterialDataService(repo);
        }

        private void ComponentsForm_Load(object sender, EventArgs e)
        {
            LoadComponents(currentFilterType);
            HighlightActiveButton(btnAggregate);
        }

        // ---------------- CORE FUNCTIONS ----------------
        private void LoadComponents(string type)
        {
            var result = service.GetAllMaterials();
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filtered = result.data
                .Where(c => c.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();

            dataGridView1.DataSource = filtered;
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
            using var form = new ComponentDetailsForm(currentFilterType);
            if (form.ShowDialog() == DialogResult.OK)
                LoadComponents(currentFilterType);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            string code = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
            using var form = new ComponentDetailsForm(code);
            if (form.ShowDialog() == DialogResult.OK)
                LoadComponents(currentFilterType);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string code = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();

            if (MessageBox.Show($"Delete component {code}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var allMaterialsResult = service.GetAllMaterials();

                if (!allMaterialsResult.Success || allMaterialsResult.data == null)
                {
                    MessageBox.Show("Failed to load materials list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var material = allMaterialsResult.data.FirstOrDefault(m => m.Code == code);

                if (material == null)
                {
                    MessageBox.Show($"Material with code '{code}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = service.RemoveMaterial(material);

                if (!result.Success)
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    LoadComponents(currentFilterType);
            }
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV File|*.csv" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string[] lines = File.ReadAllLines(ofd.FileName);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 5) continue;

                var material = new MaterialsData
                {
                    Code = parts[0],
                    Description = parts[1],
                    UOM = parts[2],
                    Gravity = float.Parse(parts[3]),
                    Color = parts[4],
                    Type = currentFilterType
                };

                service.AddNewData(material);
            }

            LoadComponents(currentFilterType);
            MessageBox.Show("Import completed.");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV File|*.csv" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using var sw = new StreamWriter(sfd.FileName);
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

        // ---------------- FILTER BUTTONS ----------------
        private void btnAggregate_Click(object sender, EventArgs e) { currentFilterType = "Aggregate"; LoadComponents(currentFilterType); HighlightActiveButton(btnAggregate); }
        private void btnCement_Click(object sender, EventArgs e) { currentFilterType = "Cement"; LoadComponents(currentFilterType); HighlightActiveButton(btnCement); }
        private void btnWater_Click(object sender, EventArgs e) { currentFilterType = "Water"; LoadComponents(currentFilterType); HighlightActiveButton(btnWater); }
        private void btnAdditive_Click(object sender, EventArgs e) { currentFilterType = "Additive"; LoadComponents(currentFilterType); HighlightActiveButton(btnAdditive); }
        private void btnColour_Click(object sender, EventArgs e) { currentFilterType = "Colour"; LoadComponents(currentFilterType); HighlightActiveButton(btnColour); }
        private void btnAdding_Click(object sender, EventArgs e) { currentFilterType = "Adding"; LoadComponents(currentFilterType); HighlightActiveButton(btnAdding); }
    }
}
