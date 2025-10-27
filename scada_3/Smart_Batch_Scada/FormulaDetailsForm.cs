using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class FormulaDetailsForm : Form
    {
        // If you pass a connection, we’ll reuse it. Otherwise we’ll create/dispose our own.
        private readonly MySqlConnection _externalConn;
        private readonly string _connString =
            "server=localhost;user id=root;password=Mohammed10.;database=hary_data_0;";

        // null => new formula, otherwise edit

        // tracks whether we're cloning an existing formula
        private readonly bool _copyMode = false;

        // when copying: the source formula we load from
        private readonly int? _sourceFormulaId = null;


        private  int? _formulaId;

        public FormulaDetailsForm(MySqlConnection connection = null, int? id = null, bool copyMode = false)
        {
            InitializeComponent();


            _externalConn = connection;
            _copyMode = copyMode;

            _connString = connection?.ConnectionString
                  ?? "server=localhost;Port=3306;user id=root;password=Mohammed10.;database=hary_data_0;";

            if (copyMode)
            {
                // we're copying FROM this id, but will SAVE AS a new row
                _sourceFormulaId = id;
                _formulaId = null;           // ensures Save will do INSERT, not UPDATE
            }
            else
            {
                // normal edit/open of an existing formula (or new if id == null)
                _formulaId = id;
            }
        }


        // ---------- form lifecycle ----------
        private void FormulaDetailsForm_Load(object sender, EventArgs e)
        {
            // if we're copying, load the source formula’s values to the UI
            int? idToLoad = _copyMode ? _sourceFormulaId : _formulaId;

            if (idToLoad.HasValue)
            {
                LoadFormulaHeader(idToLoad.Value);
                LoadFormulaComponents(idToLoad.Value);

                if (_copyMode)
                {
                    // reset identity-ish info for a new formula
                    txtCode.Text = txtCode.Text + "_copy";
                    // IMPORTANT: clear any per-row hidden IDs so rows INSERT for the new formula.
                    // Only do this if the hidden ID column exists
                    if (dgvComponents.Columns["FormulaComponentId"] != null)
                    {
                        foreach (DataGridViewRow r in dgvComponents.Rows)
                        {
                            if (!r.IsNewRow)                 // skip the template new row
                                r.Cells["FormulaComponentId"].Value = null;
                        }
                    }
                }
            }

            // optional: set window caption so user knows this is a copy
            if (_copyMode)
                this.Text = "Formula Details (Copy)";
        }






        // ---------- load data ----------
        private void LoadFormulaHeader(int id)
        {
            using var conn = EnsureOpen();
            using var cmd = new MySqlCommand(
                @"SELECT code, description, rck_strength, slump, exposure_class, water_cement_ratio
                  FROM formulas
                  WHERE id=@id;", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                txtCode.Text = r["code"]?.ToString();
                txtDescription.Text = r["description"]?.ToString();
                txtStrength.Text = r["rck_strength"]?.ToString();
                txtSlump.Text = r["slump"]?.ToString();
                txtExposure.Text = r["exposure_class"]?.ToString();

                if (decimal.TryParse(Convert.ToString(r["water_cement_ratio"], CultureInfo.InvariantCulture),
                                     NumberStyles.Any, CultureInfo.InvariantCulture, out var wc))
                {
                    numWC.Value = wc;
                }
            }
        }

        private void LoadFormulaComponents(int formulaId)
        {
            dgvComponents.Rows.Clear();

            using var conn = EnsureOpen();
            using var cmd = new MySqlCommand(
                @"SELECT fc.id AS fc_id, fc.component_id, c.code, c.description,
                         IFNULL(fc.percent_on_cement, 0) AS pct
                  FROM formula_components fc
                  JOIN components c ON c.id = fc.component_id
                  WHERE fc.formula_id = @fid
                  ORDER BY fc.id;", conn);
            cmd.Parameters.AddWithValue("@fid", formulaId);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                dgvComponents.Rows.Add(
                    r["fc_id"],             // hidden
                    r["component_id"],      // hidden
                    r["code"],
                    r["description"],
                    r["pct"]
                );
            }
        }

        // ---------- add / delete component ----------
        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            using var dlg = new FormulaComponentSelectForm(_externalConn);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            // The selector places an anonymous object in Tag: { ComponentId, Code, Description }
            dynamic sel = dlg.Tag;
            int compId = (int)sel.ComponentId;
            string code = (string)sel.Code;
            string desc = (string)sel.Description;

            // Add empty percentage cell; user can edit directly in grid
            dgvComponents.Rows.Add(null /*fc_id*/, compId, code, desc, 0m);
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            if (dgvComponents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a component row to delete.");
                return;
            }

            var row = dgvComponents.SelectedRows[0];
            var fcidObj = row.Cells["FormulaComponentId"].Value;

            // Remove from DB only if it already exists there
            if (fcidObj != null && int.TryParse(fcidObj.ToString(), out int fcid) && fcid > 0)
            {
                using var conn = EnsureOpen();
                using var cmd = new MySqlCommand(
                    "DELETE FROM formula_components WHERE id=@id;", conn);
                cmd.Parameters.AddWithValue("@id", fcid);
                cmd.ExecuteNonQuery();
            }

            // Always remove from the grid
            dgvComponents.Rows.Remove(row);
        }

        // ---------- save ----------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = EnsureOpen();

                // Optional safety: total % should be ~100
                decimal totalPct = 0m;
                foreach (DataGridViewRow row in dgvComponents.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Percentage"].Value == null) continue;

                    if (decimal.TryParse(
                            row.Cells["Percentage"].Value.ToString(),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out decimal p))
                    {
                        totalPct += p;
                    }
                }
                // allow tiny rounding slack (±0.5%)
                if (Math.Abs(totalPct - 100m) > 0.5m)
                {
                    var ans = MessageBox.Show(
                        $"Total percentage is {totalPct:0.##}%. Do you still want to save?",
                        "Total not 100%",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (ans == DialogResult.No) return;
                }

                // 1) Insert or update the formula header
                int currentId;
                if (_formulaId.HasValue)
                {
                    UpdateFormula(conn, _formulaId.Value);
                    currentId = _formulaId.Value;
                }
                else
                {
                    currentId = InsertFormula(conn);
                    _formulaId = currentId;     // keep new id so next saves do UPDATE
                }

                // 2) Upsert components (percent_on_cement)
                foreach (DataGridViewRow row in dgvComponents.Rows)
                {
                    if (row.IsNewRow) continue;

                    var compIdObj = row.Cells["ComponentId"].Value;
                    if (compIdObj == null) continue;

                    int compId = Convert.ToInt32(compIdObj);

                    decimal percentage = 0m;
                    var pctObj = row.Cells["Percentage"].Value;
                    if (pctObj != null)
                        decimal.TryParse(pctObj.ToString(),
                                         NumberStyles.Any,
                                         CultureInfo.InvariantCulture,
                                         out percentage);

                    int fcid = 0;
                    var fcidObj = row.Cells["FormulaComponentId"].Value;
                    if (fcidObj != null) int.TryParse(fcidObj.ToString(), out fcid);

                    if (fcid > 0)
                    {
                        using var cmdU = new MySqlCommand(@"
                    UPDATE formula_components
                    SET percent_on_cement = @pct
                    WHERE id = @id;", conn);
                        cmdU.Parameters.AddWithValue("@pct", percentage);
                        cmdU.Parameters.AddWithValue("@id", fcid);
                        cmdU.ExecuteNonQuery();
                    }
                    else
                    {
                        using var cmdI = new MySqlCommand(@"
                    INSERT INTO formula_components (formula_id, component_id, percent_on_cement)
                    VALUES (@fid, @cid, @pct);", conn);
                        cmdI.Parameters.AddWithValue("@fid", currentId);
                        cmdI.Parameters.AddWithValue("@cid", compId);
                        cmdI.Parameters.AddWithValue("@pct", percentage);
                        cmdI.ExecuteNonQuery();

                        // write back new id so future edits update
                        row.Cells["FormulaComponentId"].Value = (int)cmdI.LastInsertedId;
                    }
                }

                MessageBox.Show("Formula saved.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: reload to ensure UI is perfectly in sync
                LoadFormulaHeader(currentId);
                LoadFormulaComponents(currentId);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Save failed: " + ex.Message, "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvComponents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Simple validation: clamp percentage to [0, 100] and warn if total > 100
            if (dgvComponents.Columns[e.ColumnIndex].Name == "Percentage")
            {
                var cell = dgvComponents.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!decimal.TryParse(Convert.ToString(cell.Value, CultureInfo.InvariantCulture),
                                      NumberStyles.Any, CultureInfo.InvariantCulture, out var pct))
                {
                    pct = 0m;
                }
                if (pct < 0m) pct = 0m;
                if (pct > 100m) pct = 100m;
                cell.Value = pct;

                var total = dgvComponents.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Sum(r =>
                    {
                        if (decimal.TryParse(Convert.ToString(r.Cells["Percentage"].Value, CultureInfo.InvariantCulture),
                                             NumberStyles.Any, CultureInfo.InvariantCulture, out var p)) return p;
                        return 0m;
                    });

                if (total > 100m)
                {
                    MessageBox.Show($"Total percentage = {total:0.##}% (>100%). Please adjust.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        // ---------- SQL helpers ----------
        private MySqlConnection EnsureOpen()
        {
            var conn = new MySqlConnection(_connString);
            conn.Open();
            return conn;  // caller owns it (ok to use `using var`)
        }


        private int InsertFormula(MySqlConnection conn)
        {
            using var cmd = new MySqlCommand(
                @"INSERT INTO formulas
                    (code, description, rck_strength, slump, exposure_class, water_cement_ratio)
                  VALUES
                    (@code, @desc, @rck, @slump, @exp, @wc);", conn);

            cmd.Parameters.AddWithValue("@code", txtCode.Text?.Trim());
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text?.Trim());
            cmd.Parameters.AddWithValue("@rck", txtStrength.Text?.Trim());
            cmd.Parameters.AddWithValue("@slump", txtSlump.Text?.Trim());
            cmd.Parameters.AddWithValue("@exp", txtExposure.Text?.Trim());
            cmd.Parameters.AddWithValue("@wc", numWC.Value);

            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;
        }

        private void UpdateFormula(MySqlConnection conn, int id)
        {
            using var cmd = new MySqlCommand(
                @"UPDATE formulas
                  SET code=@code, description=@desc, rck_strength=@rck,
                      slump=@slump, exposure_class=@exp, water_cement_ratio=@wc
                  WHERE id=@id;", conn);

            cmd.Parameters.AddWithValue("@code", txtCode.Text?.Trim());
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text?.Trim());
            cmd.Parameters.AddWithValue("@rck", txtStrength.Text?.Trim());
            cmd.Parameters.AddWithValue("@slump", txtSlump.Text?.Trim());
            cmd.Parameters.AddWithValue("@exp", txtExposure.Text?.Trim());
            cmd.Parameters.AddWithValue("@wc", numWC.Value);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        private int GetCurrentFormulaId(MySqlConnection conn)
        {
            // fetch by unique code (assumes code unique)
            using var cmd = new MySqlCommand(
                "SELECT id FROM formulas WHERE code=@c LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@c", txtCode.Text?.Trim());
            var o = cmd.ExecuteScalar();
            return o == null ? 0 : Convert.ToInt32(o);
        }

        private static object ParseInt(string s)
        {
            if (int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var i))
                return i;
            return DBNull.Value; // if you prefer 0, return 0 instead
        }
    }
}
