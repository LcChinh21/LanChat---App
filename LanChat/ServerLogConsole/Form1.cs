using System;
using System.Drawing;
using System.Windows.Forms;
using ServerLogConsole.Networking;

namespace ServerLogConsole
{
    public partial class Form1 : Form
    {
        private ServerSocket _server;
        private bool _isRunning = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "LanChat Server";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                StopServer();
            }
            else
            {
                StartServer();
            }
        }

        private void StartServer()
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                
                var dbHelper = new DatabaseHelper();
                var (dbSuccess, dbMessage) = dbHelper.EnsureDatabase();
                
                if (dbSuccess)
                {
                    LogMessage(dbMessage, Color.Cyan);
                }
                else
                {
                    LogMessage(dbMessage, Color.Red);
                    LogMessage("Server van chay nhung dang nhap/dang ky se that bai!", Color.Orange);
                }
                
                _server = new ServerSocket(port, LogMessage);
                _server.Start();

                _isRunning = true;
                btnStart.Text = "Dung Server";
                btnStart.BackColor = Color.Red;
                txtPort.Enabled = false;

                LogMessage($"Server dang chay tren cong {port}...", Color.Green);
            }
            catch (Exception ex)
            {
                LogMessage($"Loi khoi dong server: {ex.Message}", Color.Red);
            }
        }

        private void StopServer()
        {
            try
            {
                _server?.Stop();
                _isRunning = false;
                btnStart.Text = "Chay Server";
                btnStart.BackColor = Color.LimeGreen;
                txtPort.Enabled = true;

                LogMessage("Server da dung.", Color.Orange);
            }
            catch (Exception ex)
            {
                LogMessage($"Loi dung server: {ex.Message}", Color.Red);
            }
        }

        public void LogMessage(string message, Color color)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action<string, Color>(LogMessage), message, color);
                return;
            }

            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            rtbLog.ScrollToCaret();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server?.Stop();
        }
    }
}
