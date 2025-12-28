using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BasicChat.Networking;
using Guna.UI2.WinForms;

namespace BasicChat
{
    public partial class FormChat : Form
    {
        private ClientSocket _client;
        private string _currentUser;
        private string _selectedUser = null;
        private bool _isGroupChat = true;
        private string _currentGroup = null;

        private Dictionary<string, List<(string sender, string text, bool isMe, DateTime time)>> _groupMessages
            = new Dictionary<string, List<(string, string, bool, DateTime)>>();

        private Dictionary<string, List<string>> _groupMembers = new Dictionary<string, List<string>>();

        private Color _colorSelected1 = Color.FromArgb(250, 48, 90);
        private Color _colorSelected2 = Color.FromArgb(128, 36, 206);
        private Color _colorUnselected = Color.FromArgb(23, 28, 41);
        private Color _colorText = Color.White;

        public FormChat(string username, ClientSocket client)
        {
            InitializeComponent();
            _currentUser = username;
            _client = client;

            _client.OnUserListChanged = () =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (_isGroupChat && !string.IsNullOrEmpty(_currentGroup))
                    {
                        UpdateRightPanelMembers();
                    }
                });
            };

            lblHeaderTitle.Text = $"Welcome, {_currentUser}";

            _client.OnMessageReceived = HandleMessage;
            _client.OnDisconnected = (msg) => Invoke((MethodInvoker)(() => MessageBox.Show(msg)));

            pbAppIcon.Cursor = Cursors.Hand;
            pbAppIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAppIcon.Image = AvatarGenerator.Generate(_currentUser);
            pbAppIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAppIcon.Click += PbMyAvatar_Click;

            _client.Send(new ChatMessage
            {
                Type = MessageType.GET_AVATAR_REQUEST,
                Sender = _currentUser,
                Content = _currentUser // Lấy ảnh của chính mình
            });

            this.Load += FormChat_Load;
        }

        private void PbMyAvatar_Click(object sender, EventArgs e)
        {
            Form shadow = new Form()
            {
                BackColor = Color.Black,
                Opacity = 0.5,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.Manual,
                Location = this.Location,
                Size = this.Size
            };
            shadow.Show();
            FormProfile frm = new FormProfile(_client, _currentUser);
            frm.ShowDialog();

            shadow.Close();
        }

        private Image Base64ToImage(string base64String, string fallbackText)
        {
            try
            {
                if (!string.IsNullOrEmpty(base64String))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return new Bitmap(ms); 
                    }
                }
            }
            catch
            {
                // Lỗi thì bỏ qua, xuống dưới tạo ảnh mặc định
            }

            return AvatarGenerator.Generate(fallbackText);
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            _client.Send(new ChatMessage
            {
                Type = MessageType.LOAD_GROUP_REQUEST,
                Sender = _currentUser
            });

            _client.Send(new ChatMessage { Type = MessageType.GET_ALL_USERS_REQUEST });
        }

        // Logic sắp xếp và làm mới danh sách
        private void UpdateRightPanelMembers()
        {
            flowMembers.Controls.Clear();
            lblGroupNameRight.Text = _currentGroup;

            // Kiểm tra xem nhóm hiện tại có danh sách thành viên chưa
            if (_groupMembers.ContainsKey(_currentGroup))
            {
                var members = _groupMembers[_currentGroup];
                lblMemberCount.Text = $"{members.Count} Members";

                // Ai Online đưa lên đầu, Offline xuống dưới
                var sortedMembers = members.OrderByDescending(u => _client.OnlineUsers.Contains(u)).ToList();

                foreach (var member in sortedMembers)
                {
                    bool isOnline = _client.OnlineUsers.Contains(member);
                    AddMemberToPanel(member, isOnline);
                }
            }
        }

        private void RenderMemberInRightPanel(string memberName)
        {
            Guna2Panel pnlItem = new Guna2Panel { Size = new Size(180, 40), Dock = DockStyle.Top };

            Guna2CirclePictureBox pbMemberAvatar = new Guna2CirclePictureBox
            {
                Size = new Size(30, 30),
                Location = new Point(5, 5),
                SizeMode = PictureBoxSizeMode.StretchImage, 
                FillColor = Color.Gray, 
                Tag = memberName
            };

            Label lblName = new Label
            {
                Text = memberName,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(45, 12),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            pnlItem.Controls.Add(pbMemberAvatar);
            pnlItem.Controls.Add(lblName);

            flowMembers.Controls.Add(pnlItem);

            _client.Send(new ChatMessage
            {
                Type = MessageType.GET_AVATAR_REQUEST,
                Sender = _currentUser,
                Content = memberName   
            });
        }

        private void AddMemberToPanel(string username, bool isOnline)
        {
            Guna2Panel pnlItem = new Guna2Panel();
            pnlItem.Size = new Size(flowMembers.Width - 10, 45);
            pnlItem.BorderRadius = 5;
            pnlItem.BackColor = Color.Transparent;

            Guna2CirclePictureBox pbAvatar = new Guna2CirclePictureBox();
            pbAvatar.Size = new Size(30, 30);
            pbAvatar.Location = new Point(5, 7);
            pbAvatar.FillColor = _colorSelected2;
            pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            pbAvatar.Tag = username;

            pnlItem.Controls.Add(pbAvatar);

            Label lblName = new Label();
            lblName.Text = username;
            lblName.ForeColor = Color.White;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblName.AutoSize = true;
            lblName.Location = new Point(45, 12);
            pnlItem.Controls.Add(lblName);

            Guna2Shapes shapeStatus = new Guna2Shapes();
            shapeStatus.Size = new Size(12, 12);
            shapeStatus.PolygonSkip = 1;
            shapeStatus.Rotate = 0F;
            shapeStatus.Shape = Guna.UI2.WinForms.Enums.ShapeType.Ellipse;
            shapeStatus.BorderColor = Color.Transparent;
            shapeStatus.BorderThickness = 0;
            shapeStatus.FillColor = isOnline ? Color.LimeGreen : Color.Gray;
            shapeStatus.Location = new Point(pnlItem.Width - 25, 16);
            pnlItem.Controls.Add(shapeStatus);

            flowMembers.Controls.Add(pnlItem);

            if (username == _currentUser)
            {
                if (pbAppIcon.Image != null)
                    pbAvatar.Image = pbAppIcon.Image;
                else
                    pbAvatar.Image = AvatarGenerator.Generate(username); // Tạo tạm
            }
            else
            {
                pbAvatar.Image = AvatarGenerator.Generate(username);

                _client.Send(new ChatMessage
                {
                    Type = MessageType.GET_AVATAR_REQUEST,
                    Sender = _currentUser,
                    Content = username
                });
            }
        }

        private void HandleMessage(ChatMessage msg)
        {
            if (InvokeRequired) { Invoke(new Action<ChatMessage>(HandleMessage), msg); return; }
            if (msg.Type == MessageType.UPDATE_PROFILE_RESPONSE) return;
            switch (msg.Type)
            {
                case MessageType.GROUP_MESSAGE:
                    string grp = msg.Receiver;
                    string content = msg.Content;
                    if (content.Contains("|")) { var p = content.Split('|'); grp = p[0]; content = p.Length > 1 ? p[1] : ""; }

                    AddMessageToStorage(grp, msg.Sender, content, msg.Sender == _currentUser);
                    if (_currentGroup == grp)
                        AddMessageBubble(msg.Sender, content, msg.Sender == _currentUser, DateTime.Now);
                    break;

                case MessageType.PRIVATE_MESSAGE:
                    string target = (msg.Sender == _currentUser) ? msg.Receiver : msg.Sender;
                    AddMessageToStorage(target, msg.Sender, msg.Content, msg.Sender == _currentUser);

                    // Nếu đang chat với người này thì hiện luôn
                    if (!_isGroupChat && _selectedUser == target)
                        AddMessageBubble(msg.Sender, msg.Content, msg.Sender == _currentUser, DateTime.Now);
                    break;

                case MessageType.LOAD_GROUP_RESPONSE:
                    LoadGroups(msg.GroupList);
                    break;

                case MessageType.CREATE_GROUP_RESPONSE:
                    if (msg.Success)
                    {
                        _groupMembers[msg.Content] = new List<string> { _currentUser };
                        AddGroupItemUI(msg.Content, "New group created", DateTime.Now);
                    }
                    else MessageBox.Show("Group already exists!");
                    break;

                case MessageType.HISTORY_RESPONSE:
                    string hTarget = msg.Receiver; 
                    if (msg.HistoryList != null)
                    {
                        if ((_isGroupChat && _currentGroup == hTarget) || (!_isGroupChat && _selectedUser == hTarget))
                            flowMessages.Controls.Clear();

                        foreach (var m in msg.HistoryList)
                        {
                            bool isMe = m.Sender == _currentUser;
                            AddMessageBubble(m.Sender, m.Content, isMe, m.Timestamp);
                        }
                    }
                    break;
                case MessageType.ADD_MEMBER_RESPONSE:
                    if (_currentGroup == msg.Content)
                    {
                        if (!_groupMembers.ContainsKey(msg.Content)) _groupMembers[msg.Content] = new List<string>();
                        if (!_groupMembers[msg.Content].Contains(msg.Receiver)) _groupMembers[msg.Content].Add(msg.Receiver);
                        UpdateRightSideBar(_currentGroup, true);
                    }
                    break;
                case MessageType.GET_ALL_USERS_RESPONSE:
                    
                    break;
                case MessageType.FILE_SEND:
                    ProcessReceivedFile(msg);
                    break;
                case MessageType.GET_AVATAR_RESPONSE:
                    string ownerName = msg.Sender;
                    string base64Data = msg.Content;

                    if (string.IsNullOrEmpty(base64Data)) return;

                    this.Invoke((MethodInvoker)delegate
                    {
                        Image img = Base64ToImage(base64Data, ownerName);
                        if (img == null) return;

                        if (ownerName == _currentUser)
                        {
                            pbAppIcon.Image = img;
                        }
                        foreach (Control pnl in flowMembers.Controls)
                        {
                            foreach (Control child in pnl.Controls)
                            {
                                if (child is Guna2CirclePictureBox pb &&
                                    pb.Tag != null &&
                                    pb.Tag.ToString() == ownerName)
                                {
                                    pb.Image = img; 
                                    return;
                                }
                            }
                        }
                    });
                    break;
            }
        }

        private void AddMessageToStorage(string target, string sender, string content, bool isMe)
        {
            if (!_groupMessages.ContainsKey(target))
                _groupMessages[target] = new List<(string, string, bool, DateTime)>();
            _groupMessages[target].Add((sender, content, isMe, DateTime.Now));
        }

        private void LoadGroups(Dictionary<string, List<string>> groups)
        {
            flowGroups.Controls.Clear();
            _groupMembers = groups;
            foreach (var g in groups)
            {
                AddGroupItemUI(g.Key, "Click to chat", DateTime.Now);
            }
        }

        private void AddGroupItemUI(string name, string lastMsg, DateTime time)
        {
            Guna2GradientPanel pnl = new Guna2GradientPanel();
            pnl.Size = new Size(190, 60);
            pnl.BorderRadius = 15;
            pnl.FillColor = _colorUnselected;
            pnl.FillColor2 = _colorUnselected;
            pnl.Cursor = Cursors.Hand;
            pnl.Margin = new Padding(10, 5, 0, 5);
            pnl.Tag = name;

            Guna2CirclePictureBox pb = new Guna2CirclePictureBox();
            pb.Size = new Size(35, 35);
            pb.Location = new Point(10, 12);
            pb.FillColor = Color.FromArgb(100, 88, 255);
            pb.Image = AvatarGenerator.Generate(name);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;

            Label lblName = new Label();
            lblName.Text = name;
            lblName.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(50, 10);
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;

            Label lblMsg = new Label();
            lblMsg.Text = lastMsg;
            lblMsg.Font = new Font("Segoe UI", 7);
            lblMsg.ForeColor = Color.Silver;
            lblMsg.Location = new Point(50, 30);
            lblMsg.AutoSize = true;
            lblMsg.BackColor = Color.Transparent;

            EventHandler clickEvent = (s, e) =>
            {
                SelectGroup(name, pnl);    

                UpdateRightPanelMembers();
            };
            pnl.Click += clickEvent;
            lblName.Click += clickEvent;
            lblMsg.Click += clickEvent;
            pb.Click += clickEvent;

            pnl.Controls.Add(lblName);
            pnl.Controls.Add(lblMsg);
            pnl.Controls.Add(pb);

            flowGroups.Controls.Add(pnl);
        }

        private void SelectGroup(string groupName, Guna2GradientPanel selectedPnl)
        {
            foreach (Control c in flowGroups.Controls)
            {
                if (c is Guna2GradientPanel p)
                {
                    p.FillColor = _colorUnselected;
                    p.FillColor2 = _colorUnselected;
                }
            }
            selectedPnl.FillColor = _colorSelected1;
            selectedPnl.FillColor2 = _colorSelected2;

            _currentGroup = groupName;
            _isGroupChat = true;
            _selectedUser = null;
            lblHeaderTitle.Text = $"# {groupName}";

            UpdateRightSideBar(groupName, true);

            _client.Send(new ChatMessage
            {
                Type = MessageType.HISTORY_REQUEST,
                Sender = _currentUser,
                Receiver = groupName,
                Content = "GROUP"
            });

            flowMessages.Controls.Clear();
        }

        private void UpdateRightSideBar(string name, bool isGroup)
        {
            lblGroupNameRight.Text = name;
            pbGroupIconRight.Image = AvatarGenerator.Generate(name);
            pbGroupIconRight.SizeMode = PictureBoxSizeMode.StretchImage;
            flowMembers.Controls.Clear();

            if (isGroup && _groupMembers.ContainsKey(name))
            {
                List<string> members = _groupMembers[name];
                lblMemberCount.Text = $"Members ({members.Count})";

                foreach (var mem in members)
                {
                    // Tạo UI cho từng member
                    Panel p = new Panel();
                    p.Size = new Size(140, 40);

                    Guna2CirclePictureBox pb = new Guna2CirclePictureBox();
                    pb.Size = new Size(30, 30);
                    pb.FillColor = Color.Teal;
                    pb.Location = new Point(0, 5);

                    Label l = new Label();
                    l.Text = mem;
                    l.ForeColor = Color.White;
                    l.Location = new Point(35, 12);
                    l.AutoSize = true;

                    p.Controls.Add(pb);
                    p.Controls.Add(l);
                    flowMembers.Controls.Add(p);
                }
            }
            else
            {
                lblMemberCount.Text = "Private Chat";
            }
        }
        private void AddMessageBubble(string sender, string text, bool isMe, DateTime time)
        {
            Panel pnlContainer = new Panel();
            pnlContainer.Width = flowMessages.ClientSize.Width - 25;
            pnlContainer.Height = 0; 
            pnlContainer.Padding = new Padding(0, 5, 0, 5);
            pnlContainer.Margin = new Padding(0);
            pnlContainer.BackColor = Color.Transparent;

            Guna2Panel pnlBubble = new Guna2Panel();
            pnlBubble.BorderRadius = 12;
            pnlBubble.FillColor = isMe ? _colorSelected2 : Color.FromArgb(40, 42, 55);
            pnlBubble.AutoSize = true;
            pnlBubble.Padding = new Padding(12, 10, 12, 10);
            pnlBubble.MaximumSize = new Size((int)(pnlContainer.Width * 0.7), 0); // Tối đa 70% chiều rộng

            Label lblContent = new Label();
            lblContent.Text = text;
            lblContent.ForeColor = Color.White;
            lblContent.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblContent.AutoSize = true;
            lblContent.MaximumSize = new Size(pnlContainer.Width - 60, 0); // Wrap text xuống dòng

            lblContent.BackColor = pnlBubble.FillColor;

            if (!isMe && _isGroupChat)
            {
                Label lblSender = new Label();
                lblSender.Text = sender;
                lblSender.ForeColor = Color.LightGray;
                lblSender.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                lblSender.AutoSize = true;
                lblSender.BackColor = pnlBubble.FillColor;
                lblSender.Location = new Point(12, 5);
                pnlBubble.Controls.Add(lblSender);

                lblContent.Location = new Point(12, 25);
            }
            else
            {
                lblContent.Location = new Point(12, 10);
            }

            pnlBubble.Controls.Add(lblContent);
            pnlContainer.Controls.Add(pnlBubble);

            if (isMe)
            {
                pnlBubble.Location = new Point(pnlContainer.Width - pnlBubble.Width, 0);
                pnlContainer.Height = pnlBubble.Height + 10;
            }
            else
            {
                pnlBubble.Location = new Point(0, 0);
                pnlContainer.Height = pnlBubble.Height + 10;
            }

            flowMessages.Controls.Add(pnlContainer);

            flowMessages.ScrollControlIntoView(pnlContainer);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string txt = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(txt)) return;

            if (_isGroupChat && !string.IsNullOrEmpty(_currentGroup))
            {
                _client.Send(new ChatMessage
                {
                    Type = MessageType.GROUP_MESSAGE,
                    Sender = _currentUser,
                    Receiver = _currentGroup,
                    Content = txt
                });
                AddMessageBubble(_currentUser, txt, true, DateTime.Now);
            }
            txtMessage.Clear();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSend_Click(null, null);
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            using (FormCreateGroup frm = new FormCreateGroup())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _client.Send(new ChatMessage
                    {
                        Type = MessageType.CREATE_GROUP_REQUEST,
                        Sender = _currentUser,
                        Content = frm.GroupName
                    });
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Disconnect();
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] b = File.ReadAllBytes(ofd.FileName);
                    if (b.Length > 10 * 1024 * 1024) { MessageBox.Show("File > 10MB"); return; }
                    string b64 = Convert.ToBase64String(b);
                    string payload = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{Path.GetFileName(ofd.FileName)}|{b64}"));

                    _client.Send(new ChatMessage
                    {
                        Type = MessageType.FILE_SEND,
                        Sender = _currentUser,
                        Receiver = _isGroupChat ? _currentGroup : _selectedUser,
                        Content = payload
                    });
                    AddMessageBubble(_currentUser, $"Sent file: {Path.GetFileName(ofd.FileName)}", true, DateTime.Now);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void ProcessReceivedFile(ChatMessage msg)
        {
            try
            {
                string decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(msg.Content));
                string[] parts = decoded.Split('|');
                string fileName = parts[0];
                string fileData = parts[1];

                AddMessageBubble(msg.Sender, $"Sent file: {fileName}", false, DateTime.Now);

                if (MessageBox.Show($"Download {fileName}?", "File Received", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = fileName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllBytes(sfd.FileName, Convert.FromBase64String(fileData));
                }
            }
            catch { }
        }

        private void pbGroupIconRight_Click(object sender, EventArgs e)
        {

        }
    }
}