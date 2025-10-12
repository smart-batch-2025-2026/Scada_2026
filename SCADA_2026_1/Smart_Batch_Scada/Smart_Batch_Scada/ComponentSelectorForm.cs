using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class FormulaComponentSelectForm : Form
    {
        private string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";
        private MySqlConnection externalConn;
        private int? formulaId;

        public FormulaComponentSelectForm(MySqlConnection conn = null, int? formulaId = null)
        {
            InitializeComponent();
            externalConn = conn;
            this.formulaId = formulaId;

            LoadComponentTypes();
        }

        private void LoadComponentTypes()
        {
            cmbType.Items.Clear();
            cmbType.Items.AddRange(new string[]
            {
                "Aggregate", "Cement", "Water", "Additive", "Colour", "Adding", "AggMix"
            });
            cmbType.SelectedIndex = 0;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbType.SelectedItem.ToString();
            LoadComponents(selectedType);
        }

        private void LoadComponents(string type)
        {
            try
            {
                using (MySqlConnection conn = externalConn ?? new MySqlConnection(connString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string query = "SELECT Id, Code, Description FROM Components WHERE Type = @Type";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", type);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading components: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a component.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int componentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            string code = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
            string description = dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString();

            this.Tag = new { ComponentId = componentId, Code = code, Description = description };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
