using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    public partial class FormulaDetailsForm : Form
    {
        private MySqlConnection conn;
        private int? formulaId;
        private bool copyMode;

        public FormulaDetailsForm(MySqlConnection connection, int? id = null, bool copyMode = false)
        {
            InitializeComponent();
            conn = connection;
            formulaId = id;
            this.copyMode = copyMode;
        }

        private void FormulaDetailsForm_Load(object sender, EventArgs e)
        {
            if (formulaId.HasValue)
                LoadFormulaData();
        }

        private void LoadFormulaData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM formulas WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", formulaId.Value);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtCode.Text = copyMode ? "" : reader["code"].ToString();
                        txtDescription.Text = reader["description"].ToString();
                        txtStrength.Text = reader["rck_strength"].ToString();
                        txtSlump.Text = reader["slump"].ToString();
                        txtExposure.Text = reader["exposure_class"].ToString();
                        numWC.Value = reader["water_cement_ratio"] != DBNull.Value ? Convert.ToDecimal(reader["water_cement_ratio"]) : 0;
                    }
                }

                LoadComponentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading formula data:\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadComponentsGrid()
        {
            try
            {
                conn.Open();
                string query = @"SELECT fc.id AS 'ID',
                                        c.Code AS 'Component Code',
                                        c.Description AS 'Component',
                                        c.UOM AS 'UOM',
                                        fc.quantity AS 'Quantity',
                                        fc.percent_on_cement AS '% on Cement',
                                        c.Gravity AS 'S.W.'
                                 FROM formula_components fc
                                 JOIN Components c ON fc.component_id = c.Id
                                 WHERE fc.formula_id = @fid";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fid", formulaId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvComponents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading components:\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Code is required.");
                return;
            }

            try
            {
                conn.Open();

                string query;
                if (formulaId.HasValue && !copyMode)
                    query = @"UPDATE formulas SET code=@code, description=@desc, rck_strength=@rck, 
                              slump=@slump, exposure_class=@expo, water_cement_ratio=@wcr 
                              WHERE id=@id";
                else
                    query = @"INSERT INTO formulas (code, description, rck_strength, slump, exposure_class, water_cement_ratio)
                              VALUES (@code, @desc, @rck, @slump, @expo, @wcr)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", txtCode.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@rck", txtStrength.Text);
                cmd.Parameters.AddWithValue("@slump", txtSlump.Text);
                cmd.Parameters.AddWithValue("@expo", txtExposure.Text);
                cmd.Parameters.AddWithValue("@wcr", numWC.Value);

                if (formulaId.HasValue && !copyMode)
                    cmd.Parameters.AddWithValue("@id", formulaId);

                cmd.ExecuteNonQuery();

                if (!formulaId.HasValue || copyMode)
                    formulaId = (int)cmd.LastInsertedId;

                MessageBox.Show("Formula saved successfully.", "Success");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving formula:\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            if (!formulaId.HasValue)
            {
                MessageBox.Show("Please save the formula first.");
                return;
            }

            FormulaComponentSelectForm selectForm = new FormulaComponentSelectForm(conn, formulaId.Value);
            if (selectForm.ShowDialog() == DialogResult.OK)
                LoadComponentsGrid();
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            if (dgvComponents.SelectedRows.Count == 0)
                return;

            int compId = Convert.ToInt32(dgvComponents.SelectedRows[0].Cells["ID"].Value);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM formula_components WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", compId);
                cmd.ExecuteNonQuery();
                LoadComponentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting component:\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
