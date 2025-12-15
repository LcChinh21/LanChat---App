using BasicChat.Networking;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BasicChat
{
    public partial class DangKy : Form
    {
        private ClientSocket _client;

        private string _serverIp;
        private int _serverPort = 9000;

        public DangKy()
        {
            InitializeComponent();
            _client = new ClientSocket(); //tạo client socket
            _client.OnMessageReceived = HandleServerResponse; //gán hàm xử lý tin nhắn từ server
            _client.OnError = (err) => MessageBox.Show(err, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            _serverIp = txtSeverIP.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(_serverIp))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IPAddress.TryParse(txtSeverIP.Text, out IPAddress ipAddr) || ipAddr.AddressFamily != AddressFamily.InterNetwork)
            {
                MessageBox.Show("Địa chỉ IP không hợp lệ!", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRegister.Enabled = false;

            if (!_client.IsConnected)
            {   //client kết nối tới sever qua _severIp và _serverPort
                bool connected = await _client.ConnectAsync(_serverIp, _serverPort);
                if (!connected)
                {
                    MessageBox.Show("Khong the ket noi den server.");
                    btnRegister.Enabled = true;
                    return;
                }
            }
            //khai báo 1 tin nhắn đăng ký và gửi lên server
            var regMsg = new ChatMessage
            {
                Type = MessageType.REGISTER_REQUEST, //loại message đăng ký tài khoản
                Sender = user,
                Content = pass,
                Receiver = email
            };
            _client.Send(regMsg); //gửi gói tin nhắn này lên server
        }

        private void HandleServerResponse(ChatMessage msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ChatMessage>(HandleServerResponse), msg);
                return;
            }

            if (msg.Type == MessageType.REGISTER_RESPONSE)
            {
                btnRegister.Enabled = true;
                _client.Disconnect();

                if (msg.Success)
                {
                    MessageBox.Show("Dang ky thanh cong! Hay dang nhap.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dang ky that bai. Ten dang nhap da ton tai.");
                }
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            _client.Disconnect();
            this.Close();
        }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Disconnect();
        }
    }
}
