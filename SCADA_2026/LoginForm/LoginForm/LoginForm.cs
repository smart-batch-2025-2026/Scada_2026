namespace LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Allow resizing + maximize/minimize
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Start centered on screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // If you want it to open full screen from the start:
            // this.WindowState = FormWindowState.Maximized;

            // Or, if you prefer it to open as a normal window:
            this.WindowState = FormWindowState.Normal;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
