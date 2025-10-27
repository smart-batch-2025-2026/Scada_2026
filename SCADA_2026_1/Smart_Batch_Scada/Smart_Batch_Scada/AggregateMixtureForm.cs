using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class AggregateMixtureForm : Form
    {
        private readonly string connString = "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";
        private readonly int? _mixtureId = null;

        public AggregateMixtureForm(int? mixtureId = null)
        {
            InitializeComponent();
            _mixtureId = mixtureId;

            dgvSelected.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSelected.AllowUserToAddRows = false;
            dgvSelected.EditMode = DataGridViewEditMode.EditOnEnter;

            LoadAggregatesDropdown();
            if (_mixtureId.HasValue)
                LoadMixture(_mixtureId.Value);
        }

        private void LoadAggregatesDropdown()
        {
            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();
                string sql = "SELECT Id, Code, Description FROM Components WHERE Type='Aggregate' ORDER BY Code";
                using var cmd = new MySqlCommand(sql, conn);
                using var rdr = cmd.ExecuteReader();

                cmbAggregates.Items.Clear();
                while (rdr.Read())
                {
                    cmbAggregates.Items.Add(new ComboBoxItem
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Display = $"{rdr["Code"]} - {rdr["Description"]}"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading aggregates: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbAggregates.SelectedItem == null)
            {
                MessageBox.Show("Select an aggregate first.");
                return;
            }

            if (!decimal.TryParse(txtPercentage.Text, out decimal pct) || pct <= 0 || pct > 100)
            {
                MessageBox.Show("Enter a valid percentage (1–100).");
                return;
            }

            var selectedItem = (ComboBoxItem)cmbAggregates.SelectedItem;
            foreach (DataGridViewRow r in dgvSelected.Rows)
            {
                if (Convert.ToInt32(r.Cells["SelId"].Value) == selectedItem.Id)
                {
                    MessageBox.Show("This aggregate is already in the mixture.");
                    return;
                }
            }

            dgvSelected.Rows.Add(selectedItem.Id, selectedItem.Display.Split('-')[0].Trim(),
                selectedItem.Display.Split('-')[1].Trim(), pct);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSelected.SelectedRows.Count == 0) return;
            foreach (DataGridViewRow r in dgvSelected.SelectedRows)
                if (!r.IsNewRow)
                    dgvSelected.Rows.Remove(r);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Mixture name required.");
                return;
            }

            decimal total = 0m;
            foreach (DataGridViewRow r in dgvSelected.Rows)
            {
                if (r.IsNewRow) continue;
                total += Convert.ToDecimal(r.Cells["Percentage"].Value);
            }

            if (total <= 0m)
            {
                MessageBox.Show("Add at least one aggregate.");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();
                int mixtureId;

                if (_mixtureId.HasValue)
                {
                    var upd = new MySqlCommand("UPDATE aggregate_mixtures SET mixture_name=@n, description=@d WHERE mixture_id=@id", conn);
                    upd.Parameters.AddWithValue("@n", name);
                    upd.Parameters.AddWithValue("@d", desc);
                    upd.Parameters.AddWithValue("@id", _mixtureId.Value);
                    upd.ExecuteNonQuery();
                    mixtureId = _mixtureId.Value;

                    var del = new MySqlCommand("DELETE FROM mixture_components WHERE mixture_id=@id", conn);
                    del.Parameters.AddWithValue("@id", mixtureId);
                    del.ExecuteNonQuery();
                }
                else
                {
                    var ins = new MySqlCommand("INSERT INTO aggregate_mixtures (mixture_name, description, created_at) VALUES (@n,@d,NOW())", conn);
                    ins.Parameters.AddWithValue("@n", name);
                    ins.Parameters.AddWithValue("@d", desc);
                    ins.ExecuteNonQuery();
                    mixtureId = (int)ins.LastInsertedId;
                }

                var insComp = new MySqlCommand("INSERT INTO mixture_components (mixture_id, component_id, percentage) VALUES (@m,@c,@p)", conn);
                insComp.Parameters.Add("@m", MySqlDbType.Int32);
                insComp.Parameters.Add("@c", MySqlDbType.Int32);
                insComp.Parameters.Add("@p", MySqlDbType.Decimal);

                foreach (DataGridViewRow r in dgvSelected.Rows)
                {
                    insComp.Parameters["@m"].Value = mixtureId;
                    insComp.Parameters["@c"].Value = Convert.ToInt32(r.Cells["SelId"].Value);
                    insComp.Parameters["@p"].Value = Convert.ToDecimal(r.Cells["Percentage"].Value);
                    insComp.ExecuteNonQuery();
                }

                MessageBox.Show("Mixture saved successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving mixture: " + ex.Message);
            }
        }

        private void LoadMixture(int mixtureId)
        {
            try
            {
                dgvSelected.Rows.Clear();
                using var conn = new MySqlConnection(connString);
                conn.Open();

                var hdr = new MySqlCommand("SELECT mixture_name, description FROM aggregate_mixtures WHERE mixture_id=@id", conn);
                hdr.Parameters.AddWithValue("@id", mixtureId);
                using var rdr = hdr.ExecuteReader();
                if (rdr.Read())
                {
                    txtName.Text = rdr["mixture_name"].ToString();
                    txtDescription.Text = rdr["description"].ToString();
                }
                rdr.Close();

                var cmd = new MySqlCommand(@"SELECT mc.component_id, c.Code, c.Description, mc.percentage
                    FROM mixture_components mc
                    JOIN Components c ON mc.component_id=c.Id
                    WHERE mc.mixture_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", mixtureId);

                using var rdr2 = cmd.ExecuteReader();
                while (rdr2.Read())
                {
                    dgvSelected.Rows.Add(
                        rdr2["component_id"],
                        rdr2["Code"],
                        rdr2["Description"],
                        rdr2["percentage"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading mixture: " + ex.Message);
            }
        }


        private class ComboBoxItem
        {
            public int Id { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }


        private void btnCancel_Click(object sender, EventArgs e)
         {
           this.Close(); // closes the AggregateMixtureForm window
         }
    }  

}
