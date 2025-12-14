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
        private string _currentGroup = null;
        private List<string> _groupButtons = new List<string>();
        private Dictionary<string, List<(string text, Color color)>> _groupMessages
            = new Dictionary<string, List<(string, Color)>>();



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
                    AppendGroupChat(
                        msg.Receiver,
                        $"{msg.Sender}: {msg.Content}",
                        Color.Black
                    );
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
                case MessageType.CREATE_GROUP_RESPONSE:
                    if (msg.Success)
                    {
                        CreateGroupButton(msg.Content);
                    }
                    else
                    {
                        MessageBox.Show("Group da ton tai!");
                    }
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
                if (string.IsNullOrEmpty(_currentGroup))
                {
                    MessageBox.Show("Vui long chon nhom!");
                    return;
                }

                chatMsg = new ChatMessage
                {
                    Type = MessageType.GROUP_MESSAGE,
                    Sender = _currentUser,
                    Receiver = _currentGroup,   // 🔥 BẮT BUỘC
                    Content = message
                };

                // append theo group
                AppendGroupChat(
                    _currentGroup,
                    $"Ban: {message}",
                    Color.Blue
                );
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

                AppendChat(
                    $"[Gui rieng cho {_selectedUser}]: {message}",
                    Color.Purple
                );
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
            foreach (Control c in flowGroups.Controls)
            {
                if (c is Button btn && btn.Text == groupName)
                    return; // đã tồn tại
            }

            Button groupBtn = new Button
            {
                Text = groupName,
                Width = 210,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(39, 39, 58),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Tag = groupName
            };

            groupBtn.FlatAppearance.BorderSize = 0;
            groupBtn.Click += GroupButton_Click;

            flowGroups.Controls.Add(groupBtn);
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in flowGroups.Controls)
                if (c is Button b)
                    b.BackColor = Color.FromArgb(39, 39, 58);

            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(0, 120, 215);

            _currentGroup = btn.Tag.ToString();

            lblChatMode.Text = $"Dang chat nhom: {_currentGroup}";
            Name1.Text = _currentGroup;
            RenderCurrentGroup();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (FormCreateGroup frm = new FormCreateGroup())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ChatMessage msg = new ChatMessage
                    {
                        Type = MessageType.CREATE_GROUP_REQUEST,
                        Sender = _currentUser,
                        Content = frm.GroupName
                    };

                    _client.Send(msg);
                }
            }
        }
        private void AppendGroupChat(string groupName, string text, Color color)
        {
            if (string.IsNullOrEmpty(groupName))
                return;

            if (!_groupMessages.ContainsKey(groupName))
                _groupMessages[groupName] = new List<(string, Color)>();

            _groupMessages[groupName].Add(($"[{DateTime.Now:HH:mm}] {text}", color));

            if (_currentGroup == groupName)
                RenderCurrentGroup();
        }
        private void RenderCurrentGroup()
        {
            rtbChat.Clear();

            if (string.IsNullOrEmpty(_currentGroup))
                return;

            if (!_groupMessages.ContainsKey(_currentGroup))
                return;

            foreach (var msg in _groupMessages[_currentGroup])
            {
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.SelectionColor = msg.color;
                rtbChat.AppendText(msg.text + Environment.NewLine);
            }

            rtbChat.ScrollToCaret();
        }

        private void lblOnlineUsers_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            using (FormCreateGroup frm = new FormCreateGroup())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ChatMessage msg = new ChatMessage
                    {
                        Type = MessageType.CREATE_GROUP_REQUEST,
                        Sender = _currentUser,
                        Content = frm.GroupName
                    };

                    _client.Send(msg);
                }
            }
        }

    }
}
