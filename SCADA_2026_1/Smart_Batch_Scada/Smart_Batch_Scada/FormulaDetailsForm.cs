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
            this.Shown += (_, __) => LoadComponentsGrid();

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
                dgvComponents.Cursor = Cursors.WaitCursor;

                if (!formulaId.HasValue)
                {
                    // No formula yet -> empty grid
                    dgvComponents.DataSource = null;
                    return;
                }

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                const string sql = @"
            SELECT 
                fc.id            AS fc_id,
                fc.component_id  AS component_id,
                c.code           AS Code,
                c.description    AS Description,
                fc.quantity      AS Quantity,
                fc.percent_on_cement AS PercentOnCement
            FROM formula_components fc
            JOIN components c ON c.id = fc.component_id
            WHERE fc.formula_id = @fid
            ORDER BY c.code;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", formulaId.Value);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);

                        // Force a hard refresh
                        dgvComponents.AutoGenerateColumns = true;       // or keep false if you added bound columns
                        dgvComponents.DataSource = null;                 // <- important so the grid doesn’t cache
                        dgvComponents.DataSource = dt;

                        // Optional: nicer selection behavior
                        dgvComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvComponents.ReadOnly = true;
                        dgvComponents.MultiSelect = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading formula components:\n" + ex.Message,
                                "Load Components", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                dgvComponents.Cursor = Cursors.Default;
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

            using (var selectForm = new FormulaComponentSelectForm(conn, formulaId.Value))
            {
                if (selectForm.ShowDialog() == DialogResult.OK && selectForm.Tag != null)
                {
                    dynamic chosen = selectForm.Tag;      // set in picker dialog
                    int componentId = (int)chosen.ComponentId;

                    try
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        string insert =
                            @"INSERT INTO formula_components
                      (formula_id, component_id, quantity, percent_on_cement)
                      VALUES (@fid, @cid, 0, NULL)";

                        using (var cmd = new MySqlCommand(insert, conn))
                        {
                            cmd.Parameters.AddWithValue("@fid", formulaId.Value);
                            cmd.Parameters.AddWithValue("@cid", componentId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding component:\n" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                    LoadComponentsGrid(); // refresh list
                }
            }
        }


        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow == null)
                return;

            // Get the selected DataGridViewRow
            var row = dgvComponents.CurrentRow;

            // Safely get the formula_components.id -> alias is fc_id in the grid
            int formulaComponentId;
            try
            {
                // works when AutoGenerateColumns = true and the column name is "fc_id"
                var cellValue = row.Cells["fc_id"].Value;
                if (cellValue == null || cellValue == DBNull.Value)
                {
                    MessageBox.Show("Could not determine the selected component id (fc_id).");
                    return;
                }
                formulaComponentId = Convert.ToInt32(cellValue);
            }
            catch
            {
                // fallback if needed when bound to DataRowView
                if (row.DataBoundItem is DataRowView drv && drv.Row.Table.Columns.Contains("fc_id"))
                    formulaComponentId = Convert.ToInt32(drv["fc_id"]);
                else
                {
                    MessageBox.Show("Could not determine the selected component id (fc_id).");
                    return;
                }
            }

            var confirm = MessageBox.Show("Delete selected component?", "Confirm",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = new MySqlCommand(
                    "DELETE FROM formula_components WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", formulaComponentId);
                    cmd.ExecuteNonQuery();
                }

                // Refresh the grid after deleting
                LoadComponentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                this.Cursor = Cursors.Default;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
