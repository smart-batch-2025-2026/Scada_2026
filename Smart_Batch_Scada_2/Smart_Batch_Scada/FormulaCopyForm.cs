using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class FormulaCopyForm : Form
    {
        private string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";
        private MySqlConnection externalConn;
        private int sourceFormulaId;

        private TextBox txtNewCode;
        private TextBox txtNewDescription;
        private Button btnOK;
        private Button btnCancel;
        private Label lblNewCode;
        private Label lblNewDescription;

        public FormulaCopyForm(MySqlConnection conn = null, int sourceFormulaId = 0)
        {
            InitializeComponent();
            externalConn = conn;
            this.sourceFormulaId = sourceFormulaId;

            // Auto-generate a new code
            txtNewCode.Text = $"COPY_{DateTime.Now:yyyyMMddHHmmss}";
            txtNewDescription.Text = $"Copy of formula {sourceFormulaId}";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form Setup
            this.Size = new Size(400, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Copy Formula";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            // Labels
            lblNewCode = new Label
            {
                Text = "New Code:",
                Location = new Point(20, 25),
                Size = new Size(80, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            lblNewDescription = new Label
            {
                Text = "Description:",
                Location = new Point(20, 55),
                Size = new Size(80, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            // TextBoxes
            txtNewCode = new TextBox
            {
                Location = new Point(110, 22),
                Size = new Size(250, 23),
                Font = new Font("Segoe UI", 9F)
            };

            txtNewDescription = new TextBox
            {
                Location = new Point(110, 52),
                Size = new Size(250, 23),
                Font = new Font("Segoe UI", 9F)
            };

            // Buttons
            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(120, 95),
                Size = new Size(80, 30),
                BackColor = Color.LightGreen,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(210, 95),
                Size = new Size(80, 30),
                BackColor = Color.LightCoral,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };

            // Event handlers
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                lblNewCode, txtNewCode,
                lblNewDescription, txtNewDescription,
                btnOK, btnCancel
            });

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewCode.Text))
            {
                MessageBox.Show("Please enter a new code for the formula.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewDescription.Text))
            {
                MessageBox.Show("Please enter a new description for the formula.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewDescription.Focus();
                return;
            }

            // Check if code already exists
            if (CheckCodeExists(txtNewCode.Text.Trim()))
            {
                MessageBox.Show("This formula code already exists. Please use a different code.", "Duplicate Code",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewCode.Focus();
                return;
            }

            try
            {
                CopyFormula();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying formula: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckCodeExists(string code)
        {
            try
            {
                using (MySqlConnection conn = externalConn ?? new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM formulas WHERE code = @Code";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", code);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CopyFormula()
        {
            using (MySqlConnection conn = externalConn ?? new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Copy formula header
                        string copyHeaderQuery = @"
                            INSERT INTO formulas 
                            (code, description, rck_strength, slump, water_cement_ratio, product_code, time_limit)
                            SELECT @NewCode, @NewDescription, rck_strength, slump, water_cement_ratio, product_code, time_limit
                            FROM formulas 
                            WHERE id = @SourceId";

                        using (MySqlCommand cmd = new MySqlCommand(copyHeaderQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@NewCode", txtNewCode.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewDescription", txtNewDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@SourceId", sourceFormulaId);
                            cmd.ExecuteNonQuery();
                        }

                        // Get the new formula ID
                        int newFormulaId;
                        string getNewIdQuery = "SELECT LAST_INSERT_ID()";
                        using (MySqlCommand cmd = new MySqlCommand(getNewIdQuery, conn))
                        {
                            newFormulaId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Copy formula components
                        string copyComponentsQuery = @"
                            INSERT INTO formula_components 
                            (formula_id, component_id, component_type, component_name, quantity, 
                             percent_on_cement, specific_weight, display_order)
                            SELECT @NewFormulaId, component_id, component_type, component_name, quantity,
                                   percent_on_cement, specific_weight, display_order
                            FROM formula_components 
                            WHERE formula_id = @SourceId";

                        using (MySqlCommand cmd = new MySqlCommand(copyComponentsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@NewFormulaId", newFormulaId);
                            cmd.Parameters.AddWithValue("@SourceId", sourceFormulaId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show($"Formula copied successfully!\nNew code: {txtNewCode.Text}", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Override the Dispose method if needed
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Clean up any managed resources if needed
            }
            base.Dispose(disposing);
        }
    }
}