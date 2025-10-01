using MySql.Data.MySqlClient;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Text.Json.Nodes;

namespace UserFlowAppWinForms
{
    public partial class Form1 : Form
    {
        // Remember to replace 'your_mysql_password' with your actual MySQL root password.
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=userflowdb;User=root;Password=your_mysql_password;";
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiKey = "";
        private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-preview-05-20:generateContent";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initial form setup on load
            ShowPanel(panelMainMenu);
        }

        private void ShowPanel(Panel panelToShow)
        {
            // Hide all panels
            panelMainMenu.Visible = false;
            panelCustomerLogin.Visible = false;
            panelAuthorLogin.Visible = false;
            panelAuthorMenu.Visible = false;
            panelAddCustomer.Visible = false;
            panelDeleteCustomer.Visible = false;
            panelEditCustomer.Visible = false;

            // Show the requested panel
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

        // --- Back Buttons ---
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelMainMenu);
        }

        private void btnBackToAuthorMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAuthorMenu);
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
                            await LogCustomerLogin(username);
                            lblCustomerMessage.Text = await GetGeminiGreeting(username);
                            lblCustomerMessage.ForeColor = System.Drawing.Color.Green;
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

        private async System.Threading.Tasks.Task LogCustomerLogin(string username)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO CustomerLogs (username) VALUES (@username)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging customer login: {ex.Message}");
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

        private async void btnAnalyzeLogs_Click(object sender, EventArgs e)
        {
            lblAnalysis.Text = "Analyzing logs...";
            try
            {
                var logData = await GetCustomerLogs();
                string prompt = "Analyze the following customer login data and provide a brief, insightful summary. Mention any notable trends or statistics, like the total number of logins or the most active user.\n\nData:\n" + logData + "\n\nSummary:";
                lblAnalysis.Text = await CallGeminiApi(prompt);
            }
            catch (Exception ex)
            {
                lblAnalysis.Text = "Failed to analyze logs.";
            }
        }

        private async System.Threading.Tasks.Task<string> GetCustomerLogs()
        {
            // Simplified log retrieval for demonstration
            string logs = "No logs available.";
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT username, login_time FROM CustomerLogs ORDER BY login_time DESC LIMIT 10;";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            logs = "";
                            while (reader.Read())
                            {
                                logs += $"User: {reader.GetString(0)}, Time: {reader.GetDateTime(1)}\n";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logs = "Error retrieving logs.";
            }
            return logs;
        }

        // --- Add, Delete, Edit Customer ---
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
                if (ex.Number == 1062) // Duplicate entry error code
                {
                    lblAddMessage.Text = "Username already exists.";
                }
                else
                {
                    lblAddMessage.Text = "Database error: " + ex.Message; // Added specific error message for debugging
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
                lblDeleteMessage.Text = "Database error: " + ex.Message; // Added specific error message for debugging
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
                    string query = "UPDATE users SET password = @newPassword WHERE username = @username AND role = 'customer'";
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
                lblEditMessage.Text = "Database error: " + ex.Message; // Added specific error message for debugging
                lblEditMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // --- Gemini API Integration ---
        private async System.Threading.Tasks.Task<string> GetGeminiGreeting(string username)
        {
            string prompt = $"Generate a short, friendly greeting for a user named {username}. No more than 15 words.";
            return await CallGeminiApi(prompt);
        }

        private async System.Threading.Tasks.Task<string> CallGeminiApi(string prompt)
        {
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{ApiUrl}?key={ApiKey}", jsonContent);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var node = JsonNode.Parse(jsonResponse);
                if (node?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"] is JsonNode textNode)
                {
                    return textNode.ToString();
                }
            }
            catch (Exception ex)
            {
                // This is where you would handle API errors
                // For a Windows Forms app, you can show a message box or write to a log
                System.Windows.Forms.MessageBox.Show($"Gemini API call failed: {ex.Message}");
            }
            return "Failed to generate content.";
        }

        private void panelMainMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
