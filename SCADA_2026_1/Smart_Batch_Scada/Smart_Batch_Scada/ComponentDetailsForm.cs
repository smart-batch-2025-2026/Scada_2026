using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class ComponentDetailsForm : Form
    {
        private readonly string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";
        private string? _editCode;

        public ComponentDetailsForm(string? codeToEdit = null)
        {
            InitializeComponent();
            _editCode = codeToEdit;

            cmbComponentType.Items.AddRange(new string[]
            {
                "Aggregate","Cement","Water","Additive","Color","Adding","Aggregates Mix"
            });
            cmbComponentType.SelectedIndex = 0;
            cmbComponentType.SelectedIndexChanged += CmbComponentType_SelectedIndexChanged;
            dgvComponents.CellDoubleClick += DgvComponents_CellDoubleClick;

            LoadComponentsGrid();
            UpdateFieldState();
        }

        private void CmbComponentType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateFieldState();
            LoadComponentsGrid();

            if (cmbComponentType.SelectedItem?.ToString() == "Aggregates Mix")
            {
                try
                {
                    using var mixtureForm = new AggregateMixtureForm();
                    if (mixtureForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadComponentsGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening Aggregate Mixture form: " + ex.Message);
                }
            }
        }

        private void UpdateFieldState()
        {
            string type = cmbComponentType.SelectedItem?.ToString() ?? "";

            // Always enabled
            txtCode.Enabled = true;
            txtDescription.Enabled = true;
            txtUOM.Enabled = true;
            txtGravity.Enabled = true;
            btnColor.Enabled = true;
            txtAltCode.Enabled = true;

            // Disable all optionals
            txtAbsorption.Enabled = false;
            txtMaxDiameter.Enabled = false;
            txtClass.Enabled = false;
            txtWaterContent.Enabled = false;
            chkIce.Enabled = false;
            txtPercentOnCement.Enabled = false;
            txtInfluenceWC.Enabled = false;

            switch (type)
            {
                case "Aggregate":
                    txtAbsorption.Enabled = true;
                    txtMaxDiameter.Enabled = true;
                    break;
                case "Cement":
                    txtClass.Enabled = true;
                    break;
                case "Water":
                    txtWaterContent.Enabled = true;
                    chkIce.Enabled = true;
                    break;
                case "Additive":
                    txtWaterContent.Enabled = true;
                    txtPercentOnCement.Enabled = true;
                    break;
                case "Color":
                    txtWaterContent.Enabled = true;
                    break;
                case "Adding":
                    txtPercentOnCement.Enabled = true;
                    txtInfluenceWC.Enabled = true;
                    break;
                case "Aggregates Mix":
                    // All disabled
                    break;
            }
        }

        private void LoadComponentsGrid()
        {
            string type = cmbComponentType.SelectedItem?.ToString() ?? "";
            dgvComponents.Rows.Clear();

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();
                string query = "SELECT Code, Description, UOM, Type FROM Components WHERE Type=@Type";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Type", GetDbComponentType(type));

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dgvComponents.Rows.Add(
                        rdr["Code"]?.ToString(),
                        rdr["Description"]?.ToString(),
                        rdr["UOM"]?.ToString(),
                        rdr["Type"]?.ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading components: " + ex.Message);
            }
        }

        private void DgvComponents_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string code = dgvComponents.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(code)) return;

            LoadComponent(code);
            _editCode = code;
            txtCode.Enabled = false;

            if (cmbComponentType.SelectedItem?.ToString() == "Aggregates Mix")
            {
                try
                {
                    using var mixForm = new AggregateMixtureForm();
                    mixForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening mixture editor: " + ex.Message);
                }
            }
        }

        private void LoadComponent(string code)
        {
            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();
                string query = @"SELECT * FROM Components WHERE Code=@Code LIMIT 1";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Code", code);

                using var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtCode.Text = rdr["Code"]?.ToString() ?? "";
                    txtDescription.Text = rdr["Description"]?.ToString() ?? "";
                    txtUOM.Text = rdr["UOM"]?.ToString() ?? "";
                    txtGravity.Text = rdr["Gravity"]?.ToString() ?? "";
                    txtAltCode.Text = rdr["AltCode"]?.ToString() ?? "";
                    pnlColorPreview.BackColor = ColorTranslator.FromHtml(rdr["Color"]?.ToString() ?? "#FFFFFF");

                    txtAbsorption.Text = rdr["Absorption"]?.ToString() ?? "";
                    txtMaxDiameter.Text = rdr["MaxDiameter"]?.ToString() ?? "";
                    txtClass.Text = rdr["Class"]?.ToString() ?? "";
                    txtWaterContent.Text = rdr["WaterContent"]?.ToString() ?? "";
                    chkIce.Checked = rdr["Ice"] != DBNull.Value && Convert.ToBoolean(rdr["Ice"]);
                    txtPercentOnCement.Text = rdr["PercentOnCement"]?.ToString() ?? "";
                    txtInfluenceWC.Text = rdr["InfluenceWC"]?.ToString() ?? "";

                    string typeDb = rdr["Type"]?.ToString() ?? "";
                    cmbComponentType.SelectedItem = GetComboComponentType(typeDb);
                    UpdateFieldState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading component: " + ex.Message);
            }
        }

        private decimal? ParseNullableDecimal(string text)
        {
            if (decimal.TryParse(text, out decimal val)) return val;
            return null;
        }

        private object ToDbValue(decimal? value) => value.HasValue ? (object)value.Value : DBNull.Value;

        private void btnOK_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Code and Description are required.");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                string typeValue = GetDbComponentType(cmbComponentType.SelectedItem!.ToString());

                if (string.IsNullOrEmpty(_editCode)) // Insert
                {
                    string ins = @"INSERT INTO Components
(Code, Description, UOM, Gravity, AltCode, Color, Type, Absorption, MaxDiameter, Class, WaterContent, Ice, PercentOnCement, InfluenceWC)
VALUES (@Code,@Description,@UOM,@Gravity,@AltCode,@Color,@Type,@Absorption,@MaxDiameter,@Class,@WaterContent,@Ice,@PercentOnCement,@InfluenceWC)";

                    using var cmd = new MySqlCommand(ins, conn);
                    cmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@UOM", txtUOM.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gravity", ToDbValue(ParseNullableDecimal(txtGravity.Text)));
                    cmd.Parameters.AddWithValue("@AltCode", txtAltCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Color", ColorTranslator.ToHtml(pnlColorPreview.BackColor));
                    cmd.Parameters.AddWithValue("@Type", typeValue);
                    cmd.Parameters.AddWithValue("@Absorption", ToDbValue(ParseNullableDecimal(txtAbsorption.Text)));
                    cmd.Parameters.AddWithValue("@MaxDiameter", ToDbValue(ParseNullableDecimal(txtMaxDiameter.Text)));
                    cmd.Parameters.AddWithValue("@Class", txtClass.Text.Trim());
                    cmd.Parameters.AddWithValue("@WaterContent", ToDbValue(ParseNullableDecimal(txtWaterContent.Text)));
                    cmd.Parameters.AddWithValue("@Ice", chkIce.Checked);
                    cmd.Parameters.AddWithValue("@PercentOnCement", ToDbValue(ParseNullableDecimal(txtPercentOnCement.Text)));
                    cmd.Parameters.AddWithValue("@InfluenceWC", ToDbValue(ParseNullableDecimal(txtInfluenceWC.Text)));

                    cmd.ExecuteNonQuery();
                }
                else // Update
                {
                    string upd = @"UPDATE Components SET 
Description=@Description, UOM=@UOM, Gravity=@Gravity, AltCode=@AltCode, Color=@Color, Type=@Type, 
Absorption=@Absorption, MaxDiameter=@MaxDiameter, Class=@Class, WaterContent=@WaterContent, Ice=@Ice, 
PercentOnCement=@PercentOnCement, InfluenceWC=@InfluenceWC WHERE Code=@Code";

                    using var cmd = new MySqlCommand(upd, conn);
                    cmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@UOM", txtUOM.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gravity", ToDbValue(ParseNullableDecimal(txtGravity.Text)));
                    cmd.Parameters.AddWithValue("@AltCode", txtAltCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Color", ColorTranslator.ToHtml(pnlColorPreview.BackColor));
                    cmd.Parameters.AddWithValue("@Type", typeValue);
                    cmd.Parameters.AddWithValue("@Absorption", ToDbValue(ParseNullableDecimal(txtAbsorption.Text)));
                    cmd.Parameters.AddWithValue("@MaxDiameter", ToDbValue(ParseNullableDecimal(txtMaxDiameter.Text)));
                    cmd.Parameters.AddWithValue("@Class", txtClass.Text.Trim());
                    cmd.Parameters.AddWithValue("@WaterContent", ToDbValue(ParseNullableDecimal(txtWaterContent.Text)));
                    cmd.Parameters.AddWithValue("@Ice", chkIce.Checked);
                    cmd.Parameters.AddWithValue("@PercentOnCement", ToDbValue(ParseNullableDecimal(txtPercentOnCement.Text)));
                    cmd.Parameters.AddWithValue("@InfluenceWC", ToDbValue(ParseNullableDecimal(txtInfluenceWC.Text)));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Component saved successfully!");
                LoadComponentsGrid();
                _editCode = null;
                txtCode.Enabled = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving component: " + ex.Message);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string ColorHex = "#FFFFFF";
        private void btnColor_Click(object? sender, EventArgs e)
        {
            using var cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pnlColorPreview.BackColor = cd.Color;
                ColorHex = ColorTranslator.ToHtml(cd.Color);
            }
        }

        // Map ComboBox text to MySQL ENUM
        private string GetDbComponentType(string comboText) => comboText switch
        {
            "Color" => "Colour",
            "Aggregates Mix" => "AggMix",
            _ => comboText
        };

        // Map ENUM to ComboBox text
        private string GetComboComponentType(string dbEnum) => dbEnum switch
        {
            "Colour" => "Color",
            "AggMix" => "Aggregates Mix",
            _ => dbEnum
        };
    }
}
