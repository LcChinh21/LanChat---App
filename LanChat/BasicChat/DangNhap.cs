using System;
using System.Windows.Forms;
using BasicChat.Networking;

namespace BasicChat
{
    public partial class DangNhap : Form
    {
        private ClientSocket _client;
        private string _serverIp = "192.168.56.1";
        private int _serverPort = 9000;

        public DangNhap()
        {
            InitializeComponent();
            _client = new ClientSocket();
            _client.OnMessageReceived = HandleServerResponse;
            _client.OnError = (err) => MessageBox.Show(err, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtName.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui long nhap ten dang nhap va mat khau.");
                return;
            }

            btnLogin.Enabled = false;

            if (!_client.IsConnected)
            {
                bool connected = await _client.ConnectAsync(_serverIp, _serverPort);
                if (!connected)
                {
                    MessageBox.Show("Khong the ket noi den server. Hay chac chan server dang chay.");
                    btnLogin.Enabled = true;
                    return;
                }
            }

            var loginMsg = new ChatMessage
            {
                Type = MessageType.LOGIN_REQUEST,
                Sender = user,
                Content = pass
            };
            _client.Send(loginMsg);
        }

        private void HandleServerResponse(ChatMessage msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ChatMessage>(HandleServerResponse), msg);
                return;
            }

            if (msg.Type == MessageType.LOGIN_RESPONSE)
            {
                btnLogin.Enabled = true;

                if (msg.Success)
                {
                    MessageBox.Show("Dang nhap thanh cong!");
                    FormChat chatForm = new FormChat(txtName.Text.Trim(), _client);
                    chatForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai ten dang nhap hoac mat khau.");
                    _client.Disconnect(); //Khi ??ng nh?p th?t b?i thì ?óng k?t n?i
                }
            }
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.FormClosed += (s, args) => this.Show();
            dangKy.Show();
            this.Hide();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            _client.Disconnect();
            Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Disconnect();
        }
        //Enter de dang nhap
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
