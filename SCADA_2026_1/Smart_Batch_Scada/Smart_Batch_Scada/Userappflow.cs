using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada
{
    public partial class Userappflow : Form
    {
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=hary_data_0;User=root;Password=Mohammed10.;";

        public Userappflow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPanel(panelMainMenu);
        }

        private void ShowPanel(Panel panelToShow)
        {
            panelMainMenu.Visible = false;
            panelCustomerLogin.Visible = false;
            panelAuthorLogin.Visible = false;
            panelAuthorMenu.Visible = false;
            panelAddCustomer.Visible = false;
            panelDeleteCustomer.Visible = false;
            panelEditCustomer.Visible = false;

            panelToShow.Visible = true;
        }

        // --- Main Menu Buttons ---
        private void btnCustomerRole_Click(object sender, EventArgs e)
        {
            ShowPanel(panelCustomerLogin);
        }

        private void btnAuthorRole_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAuthorLogin);
        }

        // --- Back Buttons for each panel ---
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelMainMenu);
        }

        private void btnBackToAuthorMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAuthorMenu);
        }

        private void btnBackToCustomerLogin_Click(object sender, EventArgs e)
        {
            ShowPanel(panelCustomerLogin);
        }

        private void btnBackToAddCustomer_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAddCustomer);
        }

        private void btnBackToDeleteCustomer_Click(object sender, EventArgs e)
        {
            ShowPanel(panelDeleteCustomer);
        }

        private void btnBackToEditCustomer_Click(object sender, EventArgs e)
        {
            ShowPanel(panelEditCustomer);
        }

        // --- Customer Login ---
        private async void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            string username = txtCustomerUsername.Text;
            string password = txtCustomerPassword.Text;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT COUNT(1) FROM users WHERE username=@username AND password=@password AND role='customer'";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        long count = (long)await cmd.ExecuteScalarAsync();

                        if (count > 0)
                        {
                            MainMenu mainMenu = new MainMenu(username);
                            mainMenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            lblCustomerMessage.Text = "Invalid username or password.";
                            lblCustomerMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCustomerMessage.Text = "Error connecting to database: " + ex.Message;
                lblCustomerMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // --- Author Login ---
        private void btnAuthorLogin_Click(object sender, EventArgs e)
        {
            string username = txtAuthorUsername.Text;
            string password = txtAuthorPassword.Text;

            if (username == "moh" && password == "1234")
            {
                ShowPanel(panelAuthorMenu);
            }
            else
            {
                lblAuthorMessage.Text = "Invalid author credentials.";
                lblAuthorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // --- Author Menu Actions ---
        private void btnAuthorAdd_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAddCustomer);
            lblAddMessage.Text = "";
            txtAddUsername.Text = "";
            txtAddPassword.Text = "";
        }

        private void btnAuthorDelete_Click(object sender, EventArgs e)
        {
            ShowPanel(panelDeleteCustomer);
            lblDeleteMessage.Text = "";
            txtDeleteUsername.Text = "";
        }

        private void btnAuthorEdit_Click(object sender, EventArgs e)
        {
            ShowPanel(panelEditCustomer);
            lblEditMessage.Text = "";
            txtEditUsername.Text = "";
            txtEditPassword.Text = "";
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string username = txtAddUsername.Text;
            string password = txtAddPassword.Text;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO Users (username, password, role) VALUES (@username, @password, 'customer')";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            lblAddMessage.Text = "Customer added successfully.";
                            lblAddMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblAddMessage.Text = "Failed to add customer.";
                            lblAddMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    lblAddMessage.Text = "Username already exists.";
                }
                else
                {
                    lblAddMessage.Text = "Database error: " + ex.Message;
                }
                lblAddMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string username = txtDeleteUsername.Text;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM Users WHERE username = @username AND role = 'customer'";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            lblDeleteMessage.Text = "Customer deleted successfully.";
                            lblDeleteMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblDeleteMessage.Text = "User not found or is an author.";
                            lblDeleteMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblDeleteMessage.Text = "Database error: " + ex.Message;
                lblDeleteMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private async void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string username = txtEditUsername.Text;
            string newPassword = txtEditPassword.Text;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE Users SET password = @newPassword WHERE username = @username AND role = 'customer'";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            lblEditMessage.Text = "Password updated successfully.";
                            lblEditMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblEditMessage.Text = "User not found or is an author.";
                            lblEditMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblEditMessage.Text = "Database error: " + ex.Message;
                lblEditMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // --- Dummy methods from Designer - can be removed if not used
        private void panelMainMenu_Paint(object sender, PaintEventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
    }
}
