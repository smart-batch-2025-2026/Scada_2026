using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Smart_Batch_Scada
{
    public partial class MainMenu : Form
    {
        private readonly string _customerUsername;
        private MySqlConnection conn;  // <-- Add connection here


        public MainMenu(string username)
        {
            InitializeComponent();
            _customerUsername = username;
            lblUser.Text = "User: " + _customerUsername;
            button2.Click += new System.EventHandler(this.button2_Click);

            // Initialize the MySQL connection
            string connString = "server=localhost;user id=root;password=Mohammed10.;database=hary_data_0;";
            conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            ShowPanel(panelProduction);
        }

        private void ShowPanel(Panel panelToShow)
        {
            // Hide all panels first
            panelProduction.Visible = false;
            panelFiles.Visible = false;
            panelSystem.Visible = false;

            // Reset z-order and docking
            panelProduction.Dock = DockStyle.None;
            panelFiles.Dock = DockStyle.None;
            panelSystem.Dock = DockStyle.None;

            this.Cursor = Cursors.WaitCursor;

            // Bring selected panel to front and dock it properly
            panelToShow.Visible = true;
            panelToShow.Dock = DockStyle.Fill;
            panelToShow.BringToFront();

            // Reset cursor when done
            this.Cursor = Cursors.Default;
        }

        // --- Navigator Buttons ---
        private void btnProduction_Click(object sender, EventArgs e)
        {
            ShowPanel(panelProduction);
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            ShowPanel(panelFiles);
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            ShowPanel(panelSystem);
        }

        // --- Logout Button ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close the current form and show the main login form
            Userappflow loginForm = new Userappflow();
            loginForm.Show();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm();
            productsForm.ShowDialog();   // modal (blocks until closed)
                                         // or use productsForm.Show(); for non-modal
        }
        private void panelProduction_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panelFiles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void formula_button(object sender, EventArgs e)
        {
            FormulasForm formulasForm = new FormulasForm();
            formulasForm.ShowDialog();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Open the Plant Mimic form when button5 is clicked
            Plant_Mimic plantMimicForm = new Plant_Mimic();
            plantMimicForm.Show();
            // Optionally, hide or close MainMenu if you want:
            // this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Open Components window
            ComponentsForm compForm = new ComponentsForm();
            compForm.ShowDialog();   // modal
                                     // or compForm.Show();   // non-modal
        }

       

    }
}
