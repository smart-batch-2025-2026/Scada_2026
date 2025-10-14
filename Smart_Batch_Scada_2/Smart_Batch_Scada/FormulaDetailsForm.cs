using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    public partial class FormulaDetailsForm : Form
    {
        private MySqlConnection conn;
        private int? formulaId;
        private bool isEditMode = false;
        private DataTable componentsDt;

        // For automatic calculations
        private decimal totalCement = 0;
        private decimal totalWater = 0;
        private bool isCalculating = false;

        public FormulaDetailsForm(MySqlConnection connection, int? id = null)
        {
            InitializeComponent();
            conn = connection;
            formulaId = id;
            isEditMode = id.HasValue;

            if (isEditMode)
            {
                this.Text = "Edit Formula";
                LoadFormulaData();
            }
            else
            {
                this.Text = "New Formula";
            }

            SetupCalculations();
            LoadAvailableComponents();
        }

        private void SetupCalculations()
        {
            numWaterCementRatio.ValueChanged += (s, e) => CalculateWaterFromRatio();
        }

        private void LoadFormulaData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM formulas WHERE id=@id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", formulaId);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtCode.Text = rdr["code"].ToString();
                            txtDescription.Text = rdr["description"].ToString();
                            txtRckStrength.Text = rdr["rck_strength"].ToString();
                            txtSlump.Text = rdr["slump"].ToString();
                            numWaterCementRatio.Value = rdr["water_cement_ratio"] != DBNull.Value ?
                                Convert.ToDecimal(rdr["water_cement_ratio"]) : 0;
                            txtProductCode.Text = rdr["product_code"].ToString();
                            numTimeLimit.Value = rdr["time_limit"] != DBNull.Value ?
                                Convert.ToInt32(rdr["time_limit"]) : 0;
                        }
                    }
                }

                LoadFormulaComponents();
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

        private void LoadFormulaComponents()
        {
            dgvComponents.Rows.Clear();
            totalCement = 0;
            totalWater = 0;

            try
            {
                conn.Open();
                string query = @"SELECT fc.*, c.Code as ComponentCode, c.Description as ComponentDescription, c.UOM, c.Type
                                FROM formula_components fc 
                                LEFT JOIN Components c ON fc.component_id = c.Id 
                                WHERE fc.formula_id = @FormulaId 
                                ORDER BY fc.display_order";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FormulaId", formulaId);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string componentType = rdr["Type"].ToString();
                            string componentName = rdr["ComponentDescription"].ToString();
                            decimal quantity = Convert.ToDecimal(rdr["quantity"]);
                            decimal percentOnCement = rdr["percent_on_cement"] != DBNull.Value ?
                                Convert.ToDecimal(rdr["percent_on_cement"]) : 0;
                            decimal specificWeight = rdr["specific_weight"] != DBNull.Value ?
                                Convert.ToDecimal(rdr["specific_weight"]) : 0;

                            // Track cement and water for calculations
                            if (componentType == "Cement") totalCement += quantity;
                            if (componentType == "Water") totalWater += quantity;

                            dgvComponents.Rows.Add(
                                rdr["id"],
                                componentType,
                                componentName,
                                rdr["UOM"]?.ToString() ?? "",
                                quantity,
                                percentOnCement,
                                specificWeight
                            );
                        }
                    }
                }

                UpdateCalculations();
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

        private void LoadAvailableComponents()
        {
            try
            {
                conn.Open();
                string query = "SELECT Id, Code, Description, Type, UOM FROM Components ORDER BY Type, Code";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                componentsDt = new DataTable();
                da.Fill(componentsDt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available components: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void CalculateWaterFromRatio()
        {
            if (isCalculating || totalCement == 0) return;

            isCalculating = true;
            decimal newWater = totalCement * numWaterCementRatio.Value;

            // Update water component quantity
            foreach (DataGridViewRow row in dgvComponents.Rows)
            {
                if (row.Cells["colType"].Value?.ToString() == "Water")
                {
                    row.Cells["colQuantity"].Value = newWater;
                    totalWater = newWater;
                    break;
                }
            }

            isCalculating = false;
            UpdateTotalWeight();
        }

        private void UpdateCalculations()
        {
            // Recalculate totals
            totalCement = 0;
            totalWater = 0;

            foreach (DataGridViewRow row in dgvComponents.Rows)
            {
                if (row.Cells["colQuantity"].Value != null)
                {
                    decimal quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                    string type = row.Cells["colType"].Value?.ToString();

                    if (type == "Cement") totalCement += quantity;
                    if (type == "Water") totalWater += quantity;
                }
            }

            // Update % on cement for additive components
            foreach (DataGridViewRow row in dgvComponents.Rows)
            {
                string type = row.Cells["colType"].Value?.ToString();
                if ((type == "Additive" || type == "Adding") && totalCement > 0 && row.Cells["colQuantity"].Value != null)
                {
                    decimal quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                    row.Cells["colPercentOnCement"].Value = (quantity / totalCement) * 100;
                }
            }

            UpdateTotalWeight();
        }

        private void UpdateTotalWeight()
        {
            decimal totalWeight = 0;
            foreach (DataGridViewRow row in dgvComponents.Rows)
            {
                if (row.Cells["colQuantity"].Value != null && row.Cells["colSpecificWeight"].Value != null)
                {
                    decimal quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                    decimal specificWeight = Convert.ToDecimal(row.Cells["colSpecificWeight"].Value);
                    totalWeight += quantity * specificWeight;
                }
            }
            lblTotalWeight.Text = $"Total Weight: {totalWeight:F2} kg/m³";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int savedFormulaId = SaveFormulaHeader(conn);
                        SaveFormulaComponents(conn, savedFormulaId);
                        transaction.Commit();

                        MessageBox.Show("Formula saved successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving formula: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Formula Code is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Formula Description is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private int SaveFormulaHeader(MySqlConnection conn)
        {
            string query = isEditMode ?
                @"UPDATE formulas SET 
                    code = @Code, description = @Description, rck_strength = @RckStrength,
                    slump = @Slump, water_cement_ratio = @WaterCementRatio, 
                    product_code = @ProductCode, time_limit = @TimeLimit 
                  WHERE id = @Id" :
                @"INSERT INTO formulas 
                    (code, description, rck_strength, slump, water_cement_ratio, product_code, time_limit)
                  VALUES 
                    (@Code, @Description, @RckStrength, @Slump, @WaterCementRatio, @ProductCode, @TimeLimit)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@RckStrength", txtRckStrength.Text.Trim());
                cmd.Parameters.AddWithValue("@Slump", txtSlump.Text.Trim());
                cmd.Parameters.AddWithValue("@WaterCementRatio", numWaterCementRatio.Value);
                cmd.Parameters.AddWithValue("@ProductCode", txtProductCode.Text.Trim());
                cmd.Parameters.AddWithValue("@TimeLimit", (int)numTimeLimit.Value);

                if (isEditMode)
                {
                    cmd.Parameters.AddWithValue("@Id", formulaId);
                    cmd.ExecuteNonQuery();
                    return formulaId.Value;
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    return (int)cmd.LastInsertedId;
                }
            }
        }

        private void SaveFormulaComponents(MySqlConnection conn, int formulaId)
        {
            // Delete existing components
            string deleteQuery = "DELETE FROM formula_components WHERE formula_id = @FormulaId";
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@FormulaId", formulaId);
                cmd.ExecuteNonQuery();
            }

            // Insert new components
            string insertQuery = @"INSERT INTO formula_components 
                (formula_id, component_id, component_type, component_name, quantity, 
                 percent_on_cement, specific_weight, display_order)
                VALUES (@FormulaId, @ComponentId, @ComponentType, @ComponentName, @Quantity,
                        @PercentOnCement, @SpecificWeight, @DisplayOrder)";

            int displayOrder = 1;
            foreach (DataGridViewRow row in dgvComponents.Rows)
            {
                if (row.Cells["colQuantity"].Value != null)
                {
                    // Find component ID from available components
                    int? componentId = FindComponentId(row.Cells["colDescription"].Value?.ToString());

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FormulaId", formulaId);
                        cmd.Parameters.AddWithValue("@ComponentId", componentId.HasValue ? (object)componentId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@ComponentType", row.Cells["colType"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@ComponentName", row.Cells["colDescription"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(row.Cells["colQuantity"].Value));
                        cmd.Parameters.AddWithValue("@PercentOnCement",
                            row.Cells["colPercentOnCement"].Value != null ?
                            Convert.ToDecimal(row.Cells["colPercentOnCement"].Value) : 0);
                        cmd.Parameters.AddWithValue("@SpecificWeight",
                            row.Cells["colSpecificWeight"].Value != null ?
                            Convert.ToDecimal(row.Cells["colSpecificWeight"].Value) : 1);
                        cmd.Parameters.AddWithValue("@DisplayOrder", displayOrder++);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private int? FindComponentId(string componentName)
        {
            if (string.IsNullOrEmpty(componentName) || componentsDt == null) return null;

            foreach (DataRow row in componentsDt.Rows)
            {
                if (row["Description"].ToString().Equals(componentName, StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(row["Id"]);
                }
            }
            return null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            using (var quantityForm = new ComponentQuantityForm())
            {
                if (quantityForm.ShowDialog() == DialogResult.OK)
                {
                    // For now, add a placeholder component - you can extend this to select from available components
                    int displayOrder = dgvComponents.Rows.Count + 1;
                    dgvComponents.Rows.Add(
                        null,
                        "Aggregate", // Default type
                        "New Component",
                        "kg",
                        quantityForm.Quantity,
                        quantityForm.PercentOnCement,
                        quantityForm.SpecificWeight
                    );
                    UpdateCalculations();
                }
            }
        }

        private void btnRemoveComponent_Click(object sender, EventArgs e)
        {
            if (dgvComponents.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Remove selected component from formula?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvComponents.SelectedRows)
                    {
                        dgvComponents.Rows.Remove(row);
                    }
                    UpdateCalculations();
                }
            }
            else
            {
                MessageBox.Show("Please select a component to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvComponents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCalculations();
        }
    }

    // Component Quantity Form (same as before)
    public class ComponentQuantityForm : Form
    {
        public decimal Quantity { get; private set; }
        public decimal PercentOnCement { get; private set; }
        public decimal SpecificWeight { get; private set; }

        private NumericUpDown numQuantity;
        private NumericUpDown numPercentOnCement;
        private NumericUpDown numSpecificWeight;
        private Button btnOK;
        private Button btnCancel;

        public ComponentQuantityForm()
        {
            InitializeComponent();
            Quantity = 0;
            PercentOnCement = 0;
            SpecificWeight = 1;
        }

        private void InitializeComponent()
        {
            this.Size = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Enter Component Quantity";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblQuantity = new Label { Text = "Quantity:", Location = new Point(20, 20), AutoSize = true };
            numQuantity = new NumericUpDown
            {
                Location = new Point(120, 18),
                Size = new Size(100, 20),
                DecimalPlaces = 4,
                Minimum = 0,
                Maximum = 10000
            };

            var lblPercent = new Label { Text = "% on Cement:", Location = new Point(20, 50), AutoSize = true };
            numPercentOnCement = new NumericUpDown
            {
                Location = new Point(120, 48),
                Size = new Size(100, 20),
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 100
            };

            var lblWeight = new Label { Text = "Specific Weight:", Location = new Point(20, 80), AutoSize = true };
            numSpecificWeight = new NumericUpDown
            {
                Location = new Point(120, 78),
                Size = new Size(100, 20),
                DecimalPlaces = 4,
                Minimum = 0.1m,
                Maximum = 10,
                Value = 1
            };

            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(60, 120),
                Size = new Size(75, 30),
                DialogResult = DialogResult.OK
            };
            btnOK.Click += (s, e) => {
                Quantity = numQuantity.Value;
                PercentOnCement = numPercentOnCement.Value;
                SpecificWeight = numSpecificWeight.Value;
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(150, 120),
                Size = new Size(75, 30),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] {
                lblQuantity, numQuantity,
                lblPercent, numPercentOnCement,
                lblWeight, numSpecificWeight,
                btnOK, btnCancel
            });

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
    }
}