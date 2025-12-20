using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BasicChat.Networking;
using System.Linq;
using System.Configuration;
using System.IO; 

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
        private Dictionary<string, List<string>> _groupMembers
            = new Dictionary<string, List<string>>();
        private bool _isExpanded = false; 
        private Size _oldSize;            
        private Point _oldLocation;    

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
            this.Load += FormChat_Load;
        }

        public void FormChat_Load(object sender, EventArgs e)
        {
            // Load nhóm từ server khi form được tải
            ChatMessage loadGroupsMsg = new ChatMessage
            {
                Type = MessageType.LOAD_GROUP_REQUEST,
                Sender = _currentUser
            };
            _client.Send(loadGroupsMsg);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (_isExpanded == false)
            {
                _oldSize = this.Size;
                _oldLocation = this.Location;

                int newWidth = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
                int newHeight = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);

                this.Size = new Size(newWidth, newHeight);

                this.CenterToScreen();

                _isExpanded = true;
                btnResize.Text = "❐"; 
            }
            else
            {
                this.Size = _oldSize;
                this.Location = _oldLocation;

                _isExpanded = false;
                btnResize.Text = "☐"; 
            }
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
                    _client.OnlineUsers = new List<string>();
                    _client.OnlineUsers.AddRange(msg.UserList);
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
                        _groupMembers[msg.Content] = new List<string> { _currentUser };
                        CreateGroupButton(msg.Content);
                    }
                    else
                    {
                        MessageBox.Show("Nhóm đã tồn tại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case MessageType.LOAD_GROUP_RESPONSE:
                    LoadGroups(msg.GroupList);
                    break;
                case MessageType.GROUP_LEAVE:
                    if (_groupMembers.ContainsKey(msg.Receiver))
                    {
                        _groupMembers[msg.Receiver].Remove(_currentUser);
                        if (_groupMembers[msg.Receiver].Count == 0)
                            _groupMembers.Remove(msg.Receiver);
                    }
                    if (_currentGroup == msg.Receiver)
                    {
                        _currentGroup = null;
                        rtbChat.Clear();
                        lstMember.Items.Clear();
                        Name1.Text = "";
                    }
                    RemoveGroupButton(msg.Receiver);
                    _isGroupChat = false;
                    UpdateChatMode();
                    break;          
                case MessageType.FILE_SEND:
                    string[] parts = msg.Content.Split(new char[] { '|' }, 2);

                    if (parts.Length == 2)
                    {
                        string fileName = parts[0];
                        string fileBase64 = parts[1];

                        AppendChat($"[FILE] {msg.Sender} đã gửi một file: {fileName}", Color.Magenta);

                        DialogResult result = MessageBox.Show(
                            $"{msg.Sender} vừa gửi file '{fileName}'. Bạn có muốn tải về không?",
                            "Nhận File",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            SaveFileToDisk(fileName, fileBase64);
                        }
                    }
                    break;
            }
        }

        private void LoadGroups(Dictionary<string, List<string>> groups)
        {
            flowGroups.Controls.Clear();
            foreach (var g in groups)
            {
                if (g.Value.Contains(_currentUser))
                {
                    _groupMembers[g.Key] = g.Value;
                    CreateGroupButton(g.Key);
                }
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
                    MessageBox.Show("Vui lòng chọn nhóm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AppendGroupChat(_currentGroup,$"Bạn: {message}",Color.White);
                chatMsg = new ChatMessage
                {
                    Type = MessageType.GROUP_MESSAGE,
                    Sender = _currentUser,
                    Receiver = _currentGroup,   // BẮT BUỘC
                    Content = message
                };
            }
            else
            {
                if (string.IsNullOrEmpty(_selectedUser))
                {
                    MessageBox.Show("Vui lòng chọn người để nhắn trong danh sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Name1.Text = _selectedUser;
            }
        }

        private void UpdateChatMode()
        {
            if (_isGroupChat)
            {
                lstMember.Visible = true;
                lblGroupMembers.Visible = true;
            }
            else 
            {
                lstMember.Visible = false;
                lblGroupMembers.Visible = false;
            }
            //thêm cập nhật hiển thị member trong nhóm
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
                Width = 180,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(36, 45, 59),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Tag = groupName
            };

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Thêm thành viên", null, (s, e) =>
            {
                ChatMessage addMsg = new ChatMessage
                {
                    Sender = _currentUser,
                    Content = groupName
                };
                InviteMembers frm = new InviteMembers(_client, addMsg, _groupMembers[groupName]);
                frm.ShowDialog(this);
            });
            menu.Items.Add("Rời nhóm", null, (s, e) =>
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn rời nhóm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes) 
                {
                    ChatMessage leaveMsg = new ChatMessage
                    {
                        Type = MessageType.GROUP_LEAVE,
                        Sender = _currentUser,
                        Receiver = groupName
                    };
                    _client.Send(leaveMsg);
                }
            });

            groupBtn.Paint += (s, e) =>
            {
                string dots = "⋮";
                SizeF size = e.Graphics.MeasureString(dots, groupBtn.Font);
                float x = groupBtn.Width - size.Width - 10; // cách mép phải 10px
                float y = (groupBtn.Height - size.Height) / 2;
                e.Graphics.DrawString(dots, groupBtn.Font, Brushes.White, x, y);
            };

            groupBtn.MouseClick += (s, e) =>
            {
                // Nếu click vào 30px cuối bên phải -> hiện menu
                if (e.X >= groupBtn.Width - 30)
                {
                    menu.Show(groupBtn, new System.Drawing.Point(e.X, e.Y));
                }
                else
                {
                    // Click vào phần còn lại -> chọn nhóm
                    GroupButton_Click(groupBtn, EventArgs.Empty);
                }
            };

            groupBtn.FlatAppearance.BorderSize = 0;
            groupBtn.Click += GroupButton_Click;

            flowGroups.Controls.Add(groupBtn);
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            if(_isGroupChat == false)
            {
                _isGroupChat = true;
                UpdateChatMode();
            }
            foreach (Control c in flowGroups.Controls)
                if (c is Button b)
                    b.BackColor = Color.FromArgb(39, 39, 58);

            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(0, 120, 215);

            _currentGroup = btn.Tag.ToString();


            Name1.Text = _currentGroup;
            RenderCurrentGroup();
            lstMember.BeginUpdate();
            lstMember.Items.Clear();
            foreach (var member in _groupMembers[_currentGroup])
            {
                lstMember.Items.Add(member);
            }

            lstMember.EndUpdate();
        }

        private void RemoveGroupButton(string groupName)
        {
            if (flowGroups.InvokeRequired)
            {
                flowGroups.Invoke(new Action(() => RemoveGroupButton(groupName)));
                return;
            }

            Button btnToRemove = null;
            foreach (Control c in flowGroups.Controls)
            {
                if (c is Button btn && btn.Text == groupName)
                {
                    btnToRemove = btn;
                    break;
                }
            }
            if (btnToRemove != null)
            {
                flowGroups.Controls.Remove(btnToRemove);
                btnToRemove.Dispose();
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

        private void lblAdd_Click(object sender, EventArgs e)
        {
            var tempMsg = new ChatMessage
            {
                Sender = _currentUser
            };

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


        private void HideUsersLists_Click(object sender, EventArgs e)
        {
            if (ShowUsersLists.Visible)
                return;
            lstUsers.Visible = false;
            ShowUsersLists.Visible = true;
            HideUsersLists.Visible = false;
        }

        private void ShowUsersLists_Click(object sender, EventArgs e)
        {
            if (HideUsersLists.Visible)
                return;
            lstUsers.Visible = true;
            ShowUsersLists.Visible = false;
            HideUsersLists.Visible = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn file để gửi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = Path.GetFileName(filePath);
                long fileSize = new FileInfo(filePath).Length;

                // Giới hạn 10MB (10 * 1024 * 1024 bytes)
                if (fileSize > 10 * 1024 * 1024)
                {
                    MessageBox.Show("File quá lớn! Vui lòng gửi file dưới 10MB.", "Cảnh báo");
                    return;
                }

                try
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string fileData = Convert.ToBase64String(fileBytes);
                    string contentToSend = $"{fileName}|{fileData}";

                    ChatMessage msg = new ChatMessage
                    {
                        Type = MessageType.FILE_SEND,
                        Sender = _currentUser,
                        Receiver = _isGroupChat ? _currentGroup : _selectedUser,
                        Content = contentToSend
                    };

                    if (string.IsNullOrEmpty(msg.Receiver))
                    {
                        MessageBox.Show("Vui lòng chọn người nhận hoặc nhóm trước khi gửi!");
                        return;
                    }

                    _client.Send(msg);

                    // Hiển thị lên chat 
                    AppendChat($"[Bạn đã gửi file]: {fileName}", Color.Blue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
                }
            }
        }

        private void SaveFileToDisk(string defaultFileName, string base64Data)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = defaultFileName;
            sfd.Filter = "All Files|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Chuyển ngược chuỗi Base64 thành mảng byte
                    byte[] fileBytes = Convert.FromBase64String(base64Data);

                    // Ghi mảng byte xuống đường dẫn người dùng chọn
                    File.WriteAllBytes(sfd.FileName, fileBytes);

                    MessageBox.Show("Lưu file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở thư mục chứa file                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
