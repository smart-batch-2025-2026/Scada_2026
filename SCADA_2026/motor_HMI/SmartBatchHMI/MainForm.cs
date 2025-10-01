using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharp7;

namespace SmartBatchHMI
{
    public partial class MainForm : Form
    {
        private S7Client _client;
        private System.Threading.Timer _pollTimer;
        private bool _lastMotorState = false;
        private volatile bool _isConnected = false;

        // CONFIG
        private const string PlcIp = "192.168.1.61"; // set your PLC IP
        private const int PlcRack = 0;
        private const int PlcSlot = 1;
        private const int PollMs = 500;

        public MainForm()
        {
            InitializeComponent();

            // create LED images programmatically if not using resources
            picGreen.Image = MakeLed(Color.LimeGreen, picGreen.Width);
            picRed.Image = MakeLed(Color.Red, picRed.Width);

            // start connect + polling in background
            Task.Run(() => ConnectAndStartPolling());
        }

        private void ConnectAndStartPolling()
        {
            _client = new S7Client();

            int res = _client.ConnectTo(PlcIp, PlcRack, PlcSlot);
            if (res == 0)
            {
                _isConnected = true;

                // start timer (runs on ThreadPool)
                _pollTimer = new System.Threading.Timer(PollPlc, null, 0, PollMs);
            }
            else
            {
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("PLC Connection Error: " + _client.ErrorText(res),
                                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnToggleMotor.Enabled = false;
                }));
            }
        }

        private void PollPlc(object state)
        {
            if (!_isConnected) return;

            try
            {
                byte[] buffer = new byte[1];
                int r = _client.DBRead(1, 0, 1, buffer); // DB1, offset 0, 1 byte
                if (r == 0)
                {
                    bool motorOn = (buffer[0] & 0x01) != 0;
                    if (motorOn != _lastMotorState)
                    {
                        _lastMotorState = motorOn;
                        BeginInvoke(new Action(() => UpdateMotorUI(motorOn)));
                    }
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("PLC Read Error: " + _client.ErrorText(r),
                                        "Read Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnToggleMotor.Enabled = false;
                    }));
                }
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Exception: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnToggleMotor.Enabled = false;
                }));
            }
        }

        private void UpdateMotorUI(bool motorOn)
        {
            lblStatus.Text = motorOn ? "Motor is ON" : "Motor is OFF";
            picGreen.Visible = motorOn;
            picRed.Visible = !motorOn;
            btnToggleMotor.Enabled = true;
        }

        private void btnToggleMotor_Click(object sender, EventArgs e)
        {
            if (!_isConnected) return;

            btnToggleMotor.Enabled = false;

            Task.Run(() =>
            {
                try
                {
                    byte[] write = new byte[1];
                    bool newState = !_lastMotorState;
                    write[0] = newState ? (byte)0x01 : (byte)0x00;

                    int w = _client.DBWrite(1, 0, 1, write);
                    if (w == 0)
                    {
                        _lastMotorState = newState;
                        BeginInvoke(new Action(() => UpdateMotorUI(newState)));
                    }
                    else
                    {
                        BeginInvoke(new Action(() =>
                        {
                            MessageBox.Show("Write error: " + _client.ErrorText(w),
                                            "Write Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnToggleMotor.Enabled = true;
                        }));
                    }
                }
                catch (Exception ex)
                {
                    BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Exception on write: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnToggleMotor.Enabled = false;
                    }));
                }
            });
        }

        private Bitmap MakeLed(Color color, int size = 48)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (var brush = new SolidBrush(Color.FromArgb(64, color)))
                    g.FillEllipse(brush, 0, 0, size, size);
                using (var brush = new SolidBrush(color))
                    g.FillEllipse(brush, 4, 4, size - 8, size - 8);
                using (var brush = new SolidBrush(Color.FromArgb(180, Color.White)))
                    g.FillEllipse(brush, 6, 6, (size - 8) / 4, (size - 8) / 4);
            }
            return bmp;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                _pollTimer?.Dispose();
                if (_client != null && _client.Connected)
                    _client.Disconnect();
                _client = null;
            }
            catch { }
        }

        private void picGreen_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
