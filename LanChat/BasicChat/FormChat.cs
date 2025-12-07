using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BasicChat.Networking;

namespace BasicChat
{
    public partial class FormChat : Form
    {
        private ClientSocket _client;
        private string _currentUser;
        private string _selectedUser = null;
        private bool _isGroupChat = true;

        public FormChat(string username, ClientSocket client)
        {
            InitializeComponent();
            _currentUser = username;
            _client = client;

            this.Text = "LanChat - Xin chao: " + _currentUser;
            lblCurrentUser.Text = "Dang nhap: " + _currentUser;

            _client.OnMessageReceived = HandleMessage;
            _client.OnDisconnected = (msg) =>
            {
                AppendChat("[He thong] " + msg, Color.Red);
            };

            rdGroupChat.Checked = true;
            UpdateChatMode();
        }

        private void HandleMessage(ChatMessage msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ChatMessage>(HandleMessage), msg);
                return;
            }

            switch (msg.Type)
            {
                case MessageType.GROUP_MESSAGE:
                    string groupText = $"[Nhom] {msg.Sender}: {msg.Content}";
                    AppendChat(groupText, Color.Black);
                    break;

                case MessageType.PRIVATE_MESSAGE:
                    string privateText = $"[Rieng tu {msg.Sender}]: {msg.Content}";
                    AppendChat(privateText, Color.Purple);
                    break;

                case MessageType.USER_LIST:
                    UpdateUserList(msg.UserList);
                    break;

                case MessageType.USER_JOINED:
                    AppendChat($"[He thong] {msg.Sender} da tham gia.", Color.Green);
                    break;

                case MessageType.USER_LEFT:
                    AppendChat($"[He thong] {msg.Sender} da roi.", Color.Orange);
                    break;
            }
        }

        private void UpdateUserList(string[] users)
        {
            lstUsers.Items.Clear();
            if (users != null)
            {
                foreach (string user in users)
                {
                    if (!string.IsNullOrEmpty(user) && user != _currentUser)
                    {
                        lstUsers.Items.Add(user);
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            ChatMessage chatMsg;

            if (_isGroupChat)
            {
                chatMsg = new ChatMessage
                {
                    Type = MessageType.GROUP_MESSAGE,
                    Sender = _currentUser,
                    Content = message
                };
                AppendChat($"[Nhom] Ban: {message}", Color.Blue);
            }
            else
            {
                if (string.IsNullOrEmpty(_selectedUser))
                {
                    MessageBox.Show("Vui long chon nguoi nhan tu danh sach.");
                    return;
                }

                chatMsg = new ChatMessage
                {
                    Type = MessageType.PRIVATE_MESSAGE,
                    Sender = _currentUser,
                    Receiver = _selectedUser,
                    Content = message
                };
                AppendChat($"[Gui rieng cho {_selectedUser}]: {message}", Color.Purple);
            }

            _client.Send(chatMsg);
            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void AppendChat(string text, Color color)
        {
            if (rtbChat.InvokeRequired)
            {
                rtbChat.Invoke(new Action<string, Color>(AppendChat), text, color);
                return;
            }

            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionColor = color;
            rtbChat.AppendText($"[{DateTime.Now:HH:mm}] {text}\n");
            rtbChat.ScrollToCaret();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                _selectedUser = lstUsers.SelectedItem.ToString();
                lblSelectedUser.Text = "Chat voi: " + _selectedUser;
            }
        }

        private void rdGroupChat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChatMode();
        }

        private void rdPrivateChat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChatMode();
        }

        private void UpdateChatMode()
        {
            _isGroupChat = rdGroupChat.Checked;
            pnlUsers.Visible = !_isGroupChat;

            if (_isGroupChat)
            {
                lblChatMode.Text = "Che do: Chat Nhom";
                _selectedUser = null;
                lblSelectedUser.Text = "";
            }
            else
            {
                lblChatMode.Text = "Che do: Chat Rieng";
            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSend_Click(sender, e);
                e.Handled = true;
            }
        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Disconnect();
            Application.Exit();
        }
    }
}
