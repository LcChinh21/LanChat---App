using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BasicChat.Networking;
using System.Linq;

namespace BasicChat
{
    public partial class FormChat : Form
    {
        private ClientSocket _client;
        private string _currentUser;
        private string _selectedUser = null;
        private bool _isGroupChat = true;
        private List<Button> _groupButtons = new List<Button>();
        private string _currentGroup = null;


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
            lstUsers.Items.Clear(); //xóa hết danh sách user hiện có
            if (users != null)
            {
                foreach (string user in users)
                {
                    if (!string.IsNullOrEmpty(user) && user != _currentUser)
                    {
                        lstUsers.Items.Add(user); //cập nhật lại danh sách user
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

        private void AppendChat(string text, Color color) //hiện chat trên rtb
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
                //lblSelectedUser.Text = "Chat voi: " + _selectedUser;
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
            //pnlUsers.Visible = !_isGroupChat;

            if (_isGroupChat)
            {
                lblChatMode.Text = "Che do: Chat Nhom";
                _selectedUser = null;
                //lblSelectedUser.Text = "";
            }
            else
            {
                lblChatMode.Text = "Che do: Chat Rieng";
            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e) //enter tự động gửi
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSend_Click(sender, e);
                e.Handled = true;
            }
        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e) //đóng form thì ngắt kết nối
        {
            _client.Disconnect();
            Application.Exit();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SendCreateGroupRequest(string groupName)
        {
            var msg = new ChatMessage
            {
                Type = MessageType.CREATE_GROUP_REQUEST,
                Content = groupName
            };

            _client.Send(msg);
        }
        private string ShowInputDialog(string title, string prompt)
        {
            Form form = new Form();
            Label lbl = new Label();
            TextBox txt = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = title;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ClientSize = new Size(300, 130);
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            lbl.Text = prompt;
            lbl.SetBounds(10, 10, 280, 20);

            txt.SetBounds(10, 35, 270, 25);

            btnOk.Text = "OK";
            btnOk.SetBounds(60, 70, 75, 30);
            btnOk.DialogResult = DialogResult.OK;

            btnCancel.Text = "Huy";
            btnCancel.SetBounds(150, 70, 75, 30);
            btnCancel.DialogResult = DialogResult.Cancel;

            form.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? txt.Text : null;
        }

        private void CreateGroupButton(string groupName)
        {
            // Không tạo trùng
            if (_groupButtons.Any(b => b.Text == groupName))
                return;

            Button btn = new Button();
            btn.Text = groupName;
            btn.Width = splitContainer2.Panel1.Width - 10;
            btn.Height = 35;
            btn.Left = 5;
            btn.Top = 40 + _groupButtons.Count * 40;

            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(64, 64, 90);
            btn.FlatAppearance.BorderSize = 0;

            btn.Click += (s, e) =>
            {
                _currentGroup = groupName;
                rdGroupChat.Checked = true;
                lblChatMode.Text = $"Che do: Chat Nhom ({groupName})";
            };

            splitContainer2.Panel1.Controls.Add(btn);
            _groupButtons.Add(btn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupName = ShowInputDialog("Tao Group", "Nhap ten group:");

            if (string.IsNullOrWhiteSpace(groupName))
                return;

            CreateGroupButton(groupName);
            SendCreateGroupRequest(groupName);
        }
    }
}
