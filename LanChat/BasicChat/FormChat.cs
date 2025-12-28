using BasicChat.Networking;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private readonly string[] _imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

        private bool _isShowingGroups = true;
        private Guna2Panel _pnlEmoji;
        private readonly string[] _emojiList = {
            "😀", "😁", "😂", "🤣", "😃", "😄", "😅", "😆", "😉", "😊",
            "😋", "😎", "😍", "😘", "🥰", "😗", "😙", "😚", "☺", "🙂",
            "🤗", "🤩", "🤔", "🤨", "😐", "😑", "😶", "🙄", "😏", "😣",
            "😥", "😮", "😯", "😪", "😫", "😴", "😌", "😛", "😜", "😝",
            "🤤", "😒", "😓", "😔", "😕", "🙃", "👍", "👎", "👌", "❤",
            "💔", "🌹", "🎉", "🎂", "🎁", "🔥"
        };

        private NotifyIcon _notifyIcon;

        public FormChat(string username, ClientSocket client)
        {
            InitializeComponent();

            InitializeEmojiPanel(); 
            btnEmoji.Click += (s, e) => ToggleEmojiPanel(); 

            guna2DragControl1.TargetControl = pnlHeader;
            Guna.UI2.WinForms.Guna2DragControl dragSidebar = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            dragSidebar.TargetControl = pnlSidebar;
            dragSidebar.TransparentWhileDrag = true;

            txtSearchGroup.TextChanged += txtSearchGroup_TextChanged;

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
            _client.OnUserListChanged = () =>
            {
                this.Invoke(new Action(() =>
                {
                    if (!_isShowingGroups)
                    {
                        RenderOnlineUserList();
                    }
                    if (!_isShowingGroups)
                    {
                        RenderOnlineUserList();
                    }
                }));

            };
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
                Content = _currentUser 
            });

            btnInvite.Click += BtnInvite_Click;

            pnlRightInfo.Controls.Add(btnInvite);


            this.Load += FormChat_Load;

            flowMessages.Click += (s, e) => _pnlEmoji.Visible = false;
            pnlChatArea.Click += (s, e) => _pnlEmoji.Visible = false;
            pnlHeader.Click += (s, e) => _pnlEmoji.Visible = false;
            lblHeaderTitle.Click += (s, e) => _pnlEmoji.Visible = false;
            txtMessage.Click += (s, e) => _pnlEmoji.Visible = false;

            flowMessages.AllowDrop = true;
            pnlChatArea.AllowDrop = true; 

            DragEventHandler dragEnter = (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy; 
                else
                    e.Effect = DragDropEffects.None;
            };

            flowMessages.DragEnter += dragEnter;
            pnlChatArea.DragEnter += dragEnter;

            DragEventHandler dragDrop = (s, e) =>
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Duyệt qua từng file và gửi
                foreach (string file in files)
                {
                    // GỌI HÀM CHUNG (Y hệt nút bấm)
                    SendFilePath(file);
                }
            };

            flowMessages.DragDrop += dragDrop;
            pnlChatArea.DragDrop += dragDrop;


            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = SystemIcons.Application; 
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "LanChat is running";

            _notifyIcon.BalloonTipClicked += (s, e) =>
            {
                this.WindowState = FormWindowState.Normal;
                this.Focus();
            };
        }

        private void BtnInvite_Click(object sender, EventArgs e)
        {
            if (!_isGroupChat || string.IsNullOrEmpty(_currentGroup))
            {
                MessageBox.Show("Chức năng này chỉ dùng trong Chat Nhóm.");
                return;
            }

            List<string> currentMembers = new List<string>();
            if (_groupMembers.ContainsKey(_currentGroup))
            {
                currentMembers = _groupMembers[_currentGroup];
            }

            ChatMessage dummyMsg = new ChatMessage
            {
                Sender = _currentUser,
                Content = _currentGroup,
                Type = MessageType.GROUP_INVITE_REQUEST
            };

            InviteMembers inviteForm = new InviteMembers(_client, dummyMsg, currentMembers);

            inviteForm.StartPosition = FormStartPosition.Manual;
            inviteForm.Location = new Point(
                this.Location.X + (this.Width - inviteForm.Width) / 2,
                this.Location.Y + (this.Height - inviteForm.Height) / 2
            );

            inviteForm.ShowDialog();
        }

        // Trong FormChat.cs

        private void SendFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)) return;

            string target = _isGroupChat ? _currentGroup : _selectedUser;
            if (string.IsNullOrEmpty(target)) return;

            try
            {
                // 1. Đọc dữ liệu file
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);

                // Kiểm tra dung lượng (Ví dụ > 10MB thì thôi)
                if (fileBytes.Length > 10 * 1024 * 1024)
                {
                    MessageBox.Show("File quá lớn (>10MB).");
                    return;
                }

                string base64 = Convert.ToBase64String(fileBytes);
                string contentToSend = $"{fileName}|{base64}";

                // 2. Gửi lên Server
                _client.Send(new ChatMessage
                {
                    Type = MessageType.FILE_SEND,
                    Sender = _currentUser,
                    Receiver = target,
                    Content = contentToSend,
                    Timestamp = DateTime.Now
                });

                // [THAY ĐỔI Ở ĐÂY]: Phân loại hiển thị
                if (IsImageFile(fileName))
                {
                    // Convert byte[] sang Image để hiển thị
                    using (MemoryStream ms = new MemoryStream(fileBytes))
                    {
                        // Dùng new Bitmap(ms) để tránh lỗi GDI+ khi đóng stream
                        AddImageBubble("Me", new Bitmap(ms), true, DateTime.Now);
                    }
                }
                else
                {
                    // File thường
                    AddFileBubble("Me", fileName, fileBytes, true, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi file: " + ex.Message);
            }
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
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Kiểm tra xem có ảnh mới không
                if (frm.NewAvatar != null)
                {
                    pbAppIcon.Image = frm.NewAvatar;
                    foreach (Control pnl in flowMembers.Controls)
                    {
                        foreach (Control child in pnl.Controls)
                        {
                            if (child is Guna2CirclePictureBox pb &&
                                pb.Tag != null &&
                                pb.Tag.ToString() == _currentUser)
                            {
                                pb.Image = frm.NewAvatar;
                            }
                        }
                    }
                }
            }

            shadow.Close();
        }

        private bool IsImageFile(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            return _imageExtensions.Contains(ext);
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

        private void AddImageBubble(string sender, Image image, bool isMe, DateTime time)
        {
            if (InvokeRequired) { Invoke(new Action(() => AddImageBubble(sender, image, isMe, time))); return; }

            var pnlContainer = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                Margin = new Padding(0, 0, 0, 10),
                MaximumSize = new Size(flowMessages.Width - 30, 0),
                BackColor = Color.Transparent
            };

            if (!isMe)
            {
                var lblSender = new Label
                {
                    Text = sender,
                    ForeColor = Color.Silver,
                    Font = new Font("Segoe UI", 8, FontStyle.Regular),
                    AutoSize = true,
                    Margin = new Padding(5, 0, 0, 2)
                };
                pnlContainer.Controls.Add(lblSender);
            }

            var pbImage = new Guna2PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderRadius = 10,
                Cursor = Cursors.Hand,
                Size = new Size(200, 200),
                FillColor = Color.Transparent
            };

            pbImage.Click += (s, e) =>
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Image|*.jpg;*.png" };
                if (sfd.ShowDialog() == DialogResult.OK)
                    image.Save(sfd.FileName);
            };

            pnlContainer.Controls.Add(pbImage);

            var lblTime = new Label
            {
                Text = time.ToString("HH:mm"),
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 7),
                AutoSize = true,
                Margin = new Padding(isMe ? 170 : 5, 2, 0, 0)
            };
            pnlContainer.Controls.Add(lblTime);

            if (isMe)
            {
                pnlContainer.FlowDirection = FlowDirection.RightToLeft;
                flowMessages.Controls.Add(pnlContainer);
                pnlContainer.Margin = new Padding(flowMessages.Width - pnlContainer.Width - 25, 0, 0, 10);
            }
            else
            {
                flowMessages.Controls.Add(pnlContainer);
            }

            flowMessages.ScrollControlIntoView(pnlContainer);
        }

        private void AddFileBubble(string sender, string fileName, byte[] fileData, bool isMe, DateTime time)
        {
            if (InvokeRequired) { Invoke(new Action(() => AddFileBubble(sender, fileName, fileData, isMe, time))); return; }

            var pnlContainer = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 10)
            };

            if (!isMe)
            {
                var lblSender = new Label { Text = sender, ForeColor = Color.Silver, Font = new Font("Segoe UI", 8), AutoSize = true };
                pnlContainer.Controls.Add(lblSender);
            }

            var btnFile = new Guna2Button
            {
                Text = "📄 " + fileName,
                AutoRoundedCorners = true,
                FillColor = isMe ? _colorSelected1 : Color.FromArgb(40, 40, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Size = new Size(200, 45),
                Cursor = Cursors.Hand
            };

            btnFile.Click += (s, e) =>
            {
                SaveFileDialog sfd = new SaveFileDialog { FileName = fileName };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, fileData);
                    MessageBox.Show("Saved: " + sfd.FileName);
                }
            };

            pnlContainer.Controls.Add(btnFile);

            if (isMe)
            {
                pnlContainer.FlowDirection = FlowDirection.RightToLeft;
                flowMessages.Controls.Add(pnlContainer);
                pnlContainer.Margin = new Padding(flowMessages.Width - pnlContainer.Width - 25, 0, 0, 10);
            }
            else
            {
                flowMessages.Controls.Add(pnlContainer);
            }

            flowMessages.ScrollControlIntoView(pnlContainer);
        }

        private void ProcessReceivedFile(ChatMessage msg)
        {
            try
            {
                string decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(msg.Content));
                string[] parts = decoded.Split('|');
                if (parts.Length < 2) return;

                string fileName = parts[0];
                string base64Data = parts[1];
                byte[] fileBytes = Convert.FromBase64String(base64Data);

                if (IsImageFile(fileName))
                {
                    using (var ms = new MemoryStream(fileBytes))
                    {
                        Image img = Image.FromStream(ms);
                        AddImageBubble(msg.Sender, new Bitmap(img), false, DateTime.Now);
                    }
                }
                else
                {
                    AddFileBubble(msg.Sender, fileName, fileBytes, false, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error process file: " + ex.Message);
            }
        }

        private void UpdateRightPanelMembers()
        {
            flowMembers.Controls.Clear();
            lblGroupNameRight.Text = _currentGroup;

            if (_groupMembers.ContainsKey(_currentGroup))
            {
                var members = _groupMembers[_currentGroup];
                lblMemberCount.Text = $"{members.Count} Members";

                var sortedMembers = members
                    .OrderByDescending(u => _client.OnlineUsers.Contains(u)) // Online lên đầu
                    .ThenBy(u => u) // A-Z
                    .ToList();

                foreach (var member in sortedMembers)
                {
                    bool isOnline = (member == _currentUser) || _client.OnlineUsers.Contains(member);
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
            switch (msg.Type)
            {
                case MessageType.GROUP_MESSAGE:
                    string grp = msg.Receiver;
                    string content = msg.Content;

                    if (content.Contains("|"))
                    {
                        var p = content.Split('|');
                        grp = p[0];
                        content = p.Length > 1 ? p[1] : "";
                    }

                    AddMessageToStorage(grp, msg.Sender, content, msg.Sender == _currentUser);

                    if (_currentGroup == grp)
                        AddMessageBubble(msg.Sender, content, msg.Sender == _currentUser, DateTime.Now);

                    NotifyIfHidden(msg.Sender, content);
                    break;

                case MessageType.PRIVATE_MESSAGE:

                    string target = (msg.Sender == _currentUser) ? msg.Receiver : msg.Sender;
                    AddMessageToStorage(target, msg.Sender, msg.Content, msg.Sender == _currentUser);

                    // Nếu đang chat với người này thì hiện luôn
                    if (!_isGroupChat && _selectedUser == target)
                        AddMessageBubble(msg.Sender, msg.Content, msg.Sender == _currentUser, DateTime.Now);

                    NotifyIfHidden(msg.Sender, msg.Content);
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
                    {
                        string htarget = msg.Receiver;
                        bool isCorrectWindow = (_isGroupChat && htarget == _currentGroup) ||
                                               (!_isGroupChat && htarget == _selectedUser);

                        if (isCorrectWindow)
                        {
                            this.Invoke(new Action(() =>
                            {
                                flowMessages.Controls.Clear();

                                if (msg.HistoryList != null)
                                {
                                    foreach (var histMsg in msg.HistoryList)
                                    {
                                        string realContent = histMsg.Content;
                                        try
                                        {
                                            realContent = Encoding.UTF8.GetString(Convert.FromBase64String(histMsg.Content));
                                        }
                                        catch
                                        {
                                            realContent = histMsg.Content;
                                        }

                                        bool isMe = (histMsg.Sender == _currentUser);
                                        bool isFileProcessed = false;
                                        if (realContent.Contains("|"))
                                        {
                                            string[] parts = realContent.Split(new char[] { '|' }, 2);
                                            if (parts.Length == 2 && parts[0].Contains("."))
                                            {
                                                try
                                                {
                                                    string fileName = parts[0];
                                                    byte[] fileData = Convert.FromBase64String(parts[1]);

                                                    if (IsImageFile(fileName))
                                                    {
                                                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(fileData))
                                                        {
                                                            Bitmap bmp = new Bitmap(Image.FromStream(ms));
                                                            AddImageBubble(histMsg.Sender, bmp, isMe, histMsg.Timestamp);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        AddFileBubble(histMsg.Sender, fileName, fileData, isMe, histMsg.Timestamp);
                                                    }
                                                    isFileProcessed = true;
                                                }
                                                catch
                                                {
                                                    isFileProcessed = false;
                                                }
                                            }
                                        }

                                        if (!isFileProcessed)
                                        {
                                            AddMessageBubble(histMsg.Sender, realContent, isMe, histMsg.Timestamp);
                                        }
                                    }

                                    if (flowMessages.Controls.Count > 0)
                                    {
                                        try
                                        {
                                            flowMessages.ScrollControlIntoView(flowMessages.Controls[flowMessages.Controls.Count - 1]);
                                        }
                                        catch { }
                                    }
                                }
                            }));
                        }
                        break;
                    }
                case MessageType.ADD_MEMBER_RESPONSE:
                    if (_currentGroup == msg.Content)
                    {
                        if (!_groupMembers.ContainsKey(msg.Content)) _groupMembers[msg.Content] = new List<string>();
                        if (!_groupMembers[msg.Content].Contains(msg.Receiver)) _groupMembers[msg.Content].Add(msg.Receiver);

                        this.Invoke(new Action(() => UpdateRightPanelMembers()));
                    }
                    break;
                case MessageType.FILE_SEND:
                    ProcessReceivedFile(msg);
                    break;
                case MessageType.GET_AVATAR_RESPONSE:
                    {
                        string targetUser = msg.Sender; // Tên user chủ sở hữu ảnh
                        string base64Image = msg.Content; // Dữ liệu ảnh
                        bool hasImage = msg.Success;

                        if (!hasImage || string.IsNullOrEmpty(base64Image)) break;

                        this.Invoke(new Action(() =>
                        {
                            // Chuyển đổi ảnh một lần để dùng chung
                            Image newAvatar = null;
                            try
                            {
                                byte[] imgBytes = Convert.FromBase64String(base64Image);
                                using (MemoryStream ms = new MemoryStream(imgBytes))
                                {
                                    newAvatar = new Bitmap(Image.FromStream(ms)); // Clone ra bitmap mới để tránh lỗi stream closed
                                }
                            }
                            catch { return; } // Ảnh lỗi thì bỏ qua

                            // 1. Cập nhật Sidebar (Danh sách User/Group)
                            foreach (Control c in flowGroups.Controls)
                            {
                                // Kiểm tra Tag của nút xem có đúng user không
                                if (c is Guna2Button btn && btn.Tag != null && btn.Tag.ToString() == targetUser)
                                {
                                    btn.Image = newAvatar;
                                }
                                // Nếu là Group panel (trong trường hợp bạn hiện avatar user trong list group)
                                else if (c is Guna2GradientPanel pnl && pnl.Tag != null && pnl.Tag.ToString() == targetUser)
                                {
                                    foreach (Control child in pnl.Controls)
                                    {
                                        if (child is Guna2CirclePictureBox pb) pb.Image = newAvatar;
                                    }
                                }
                            }

                            // 2. Cập nhật Right Panel (Danh sách thành viên bên phải)
                            foreach (Control pnl in flowMembers.Controls)
                            {
                                foreach (Control child in pnl.Controls)
                                {
                                    // Tìm PictureBox có Tag trùng tên User
                                    if (child is Guna2CirclePictureBox pb &&
                                        pb.Tag != null &&
                                        pb.Tag.ToString() == targetUser)
                                    {
                                        pb.Image = newAvatar;
                                    }
                                }
                            }

                            // 3. Cập nhật icon chính mình (Góc trên trái) nếu là mình đổi
                            if (targetUser == _currentUser)
                            {
                                pbAppIcon.Image = newAvatar;
                            }

                            // 4. (Tùy chọn) Cập nhật icon trong khung chat hiện tại (nếu đang chat với người đó)
                            if (!_isGroupChat && _selectedUser == targetUser)
                            {
                                pbGroupIconRight.Image = newAvatar; // Icon to bên phải
                            }
                        }));
                        break;
                    }
                case MessageType.UPDATE_PROFILE_RESPONSE:
                    if (msg.Success)
                    {
                        _client.Send(new ChatMessage
                        {
                            Type = MessageType.GET_AVATAR_REQUEST,
                            Sender = _currentUser,
                            Content = msg.Sender
                        });
                    }
                    break;
                case MessageType.GET_RECENT_USERS_RESPONSE:
                    {
                        // 1. Lấy chuỗi danh sách user (Ví dụ: "UserA,UserB,UserC")
                        string hcontent = msg.Content;

                        // 2. Tách chuỗi thành mảng các tên (Array String)
                        // Nếu chuỗi rỗng thì tạo mảng rỗng để tránh lỗi
                        string[] users = string.IsNullOrEmpty(hcontent)
                                         ? new string[0]
                                         : hcontent.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        // 3. Gọi hàm vẽ giao diện (Hàm này sẽ tự xử lý Invoke/Thread safe bên trong)
                        RenderUserChatList(users);

                        break;
                    }
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


            pbGroupIconRight.SizeMode = PictureBoxSizeMode.StretchImage;
            flowMembers.Controls.Clear();

            if (isGroup && _groupMembers.ContainsKey(name))
            {
                lblMemberCount.Visible = true;
                pbGroupIconRight.Image = AvatarGenerator.Generate(name);
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
            if (string.IsNullOrEmpty(_selectedUser)) return;

            // Invisible
            lblGroupNameRight.Text = _selectedUser;
            pbGroupIconRight.Image = AvatarGenerator.Generate(_selectedUser);
            lblMemberCount.Visible = false; // Ẩn số lượng thành viên đi

            // --- HIỂN THỊ PROFILE USER ---

            // 1. Tạo Panel chứa Avatar to
            Guna2Panel pnlProfile = new Guna2Panel();
            pnlProfile.Size = new Size(flowMembers.Width - 10, 160);
            pnlProfile.Margin = new Padding(0, 0, 0, 10);

            // Avatar to (80x80)
            Guna2CirclePictureBox pbBig = new Guna2CirclePictureBox();
            pbBig.Size = new Size(80, 80);
            pbBig.Location = new Point((pnlProfile.Width - 80) / 2, 10); // Căn giữa
            pbBig.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBig.Image = AvatarGenerator.Generate(_selectedUser, 80, 80); // Dùng lại Generator

            // Tên User to
            Label lblBigName = new Label();
            lblBigName.Text = _selectedUser;
            lblBigName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBigName.ForeColor = Color.White;
            lblBigName.AutoSize = false;
            lblBigName.Size = new Size(pnlProfile.Width, 30);
            lblBigName.TextAlign = ContentAlignment.MiddleCenter;
            lblBigName.Location = new Point(0, 100);

            // Trạng thái Online/Offline dưới tên
            Label lblStatus = new Label();
            bool isUserOnline = _client.OnlineUsers.Contains(_selectedUser);
            lblStatus.Text = isUserOnline ? "● Online" : "○ Offline";
            lblStatus.ForeColor = isUserOnline ? Color.LimeGreen : Color.Gray;
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblStatus.AutoSize = false;
            lblStatus.Size = new Size(pnlProfile.Width, 20);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Location = new Point(0, 130);

            pnlProfile.Controls.Add(pbBig);
            pnlProfile.Controls.Add(lblBigName);
            pnlProfile.Controls.Add(lblStatus);
            flowMembers.Controls.Add(pnlProfile);

            // Gửi request lấy Avatar thật (nếu có) để update lại sau
            _client.Send(new ChatMessage
            {
                Type = MessageType.GET_AVATAR_REQUEST,
                Sender = _currentUser,
                Content = _selectedUser
            });

        }
        private void AddMessageBubble(string sender, string message, bool isMe, DateTime time)
        {
            Guna2Panel pnlMsg = new Guna2Panel();
            pnlMsg.AutoSize = true;
            pnlMsg.MaximumSize = new Size(flowMessages.Width - 30, 0);
            pnlMsg.Padding = new Padding(5);
            pnlMsg.Margin = new Padding(0, 0, 0, 10);
            pnlMsg.FillColor = Color.Transparent;

            if (!isMe)
            {
                Guna2CirclePictureBox pbAvatar = new Guna2CirclePictureBox();
                pbAvatar.Size = new Size(35, 35);
                pbAvatar.Image = AvatarGenerator.Generate(sender);
                pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAvatar.Location = new Point(0, 0);
                pnlMsg.Controls.Add(pbAvatar);
            }

            Guna2Button btnBubble = new Guna2Button(); 
            btnBubble.Text = message;
            btnBubble.Font = new Font("Segoe UI", 10);
            btnBubble.ForeColor = Color.White;
            btnBubble.TextAlign = HorizontalAlignment.Left;
            btnBubble.AutoRoundedCorners = true;
            btnBubble.BorderRadius = 10;

            btnBubble.FillColor = isMe ? _colorSelected2 : _colorUnselected;

            Size textSize = TextRenderer.MeasureText(message, btnBubble.Font, new Size(flowMessages.Width - 100, 0), TextFormatFlags.WordBreak);
            btnBubble.Size = new Size(textSize.Width + 30, textSize.Height + 20);

            if (isMe)
            {
                btnBubble.Location = new Point(pnlMsg.MaximumSize.Width - btnBubble.Width, 0);
            }
            else
            {
                btnBubble.Location = new Point(45, 10); 

                Label lblSenderName = new Label();
                lblSenderName.Text = sender;
                lblSenderName.ForeColor = Color.Gray;
                lblSenderName.Font = new Font("Segoe UI", 8);
                lblSenderName.Location = new Point(50, -2);
                lblSenderName.AutoSize = true;
                pnlMsg.Controls.Add(lblSenderName);
            }

            pnlMsg.Controls.Add(btnBubble);
            flowMessages.Controls.Add(pnlMsg);
            flowMessages.ScrollControlIntoView(pnlMsg);
        }
        //fix lỗi bong bóng chat khi resize form
        private void AdjustChatBubbles()
        {
            flowMessages.SuspendLayout();
            int newContainerWidth = flowMessages.ClientSize.Width - 25;

            foreach (Control control in flowMessages.Controls)
            {
                if (control is Panel pnlContainer)
                {
                    pnlContainer.Width = newContainerWidth;

                    foreach (Control child in pnlContainer.Controls)
                    {
                        if (child is Guna.UI2.WinForms.Guna2Panel pnlBubble && pnlBubble.Tag is bool isMe)
                        {
                            pnlBubble.MaximumSize = new Size((int)(newContainerWidth * 0.7), 0);

                            if (isMe)
                            {
                                pnlBubble.Location = new Point(pnlContainer.Width - pnlBubble.Width, 0);
                            }
                            else
                            {
                                int currentY = pnlBubble.Location.Y;
                                pnlBubble.Location = new Point(0, currentY);
                            }
                        }
                    }
                }
            }

            flowMessages.ResumeLayout();
            flowMessages.PerformLayout();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustChatBubbles();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string content = txtMessage.Text.Trim();
            _pnlEmoji.Visible = false; // Tắt bảng icon khi gửi
            string txt = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(txt)) return;

            ChatMessage msg = new ChatMessage
            {
                Sender = _currentUser,
                Content = content,
                Type = _isGroupChat ? MessageType.GROUP_MESSAGE : MessageType.PRIVATE_MESSAGE,
                Receiver = _isGroupChat ? _currentGroup : _selectedUser
            };
            _client.Send(msg);

            AddMessageBubble(_currentUser, content, true, DateTime.Now);

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

            if (_isShowingGroups)
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
            else
            {
                FormNewConversation frm = new FormNewConversation(_client);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string selectedUser = frm.SelectedUser;
                    if (!string.IsNullOrEmpty(selectedUser))
                    {
                        AddUserToSidebar(selectedUser);

                        OpenPrivateChat(selectedUser);
                    }
                }
            }
        }

        private void AddUserToSidebar(string username)
        {
            // Kiểm tra xem user đã có trong list chưa (dựa vào Tag)
            foreach (Control c in flowGroups.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == username) return;
            }

            // 1. Tạo Panel chứa (Thay cho Guna2Button cũ)
            Guna2GradientPanel pnl = new Guna2GradientPanel();
            pnl.Size = new Size(flowGroups.Width - 10, 60);
            pnl.BorderRadius = 15; // Bo góc panel
            pnl.FillColor = Color.Transparent;
            pnl.FillColor2 = Color.Transparent;
            pnl.Cursor = Cursors.Hand;
            pnl.Margin = new Padding(5, 5, 5, 0);
            pnl.Tag = username; // Cực kỳ quan trọng: Để hàm HandleMessage tìm được và update AVT sau này

            // 2. Tạo Avatar hình tròn (Guna2CirclePictureBox)
            Guna2CirclePictureBox pb = new Guna2CirclePictureBox();
            pb.Size = new Size(40, 40);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = AvatarGenerator.Generate(username); // Tạo ảnh mặc định
            pb.BackColor = Color.Transparent;
            pb.UseTransparentBackground = true;

            // 3. Tạo Tên User
            Label lbl = new Label();
            lbl.Text = "    " + username; // Thêm khoảng trắng cho đẹp
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point(60, 18); // Căn chỉnh vị trí bên cạnh Avatar
            lbl.BackColor = Color.Transparent;

            // 4. Sự kiện Click (Xử lý giống nút bấm cũ)
            EventHandler clickEvent = (s, e) =>
            {
                // Reset màu các item khác (cả Button và Panel để an toàn)
                foreach (Control c in flowGroups.Controls)
                {
                    if (c is Guna2Button b) b.FillColor = Color.Transparent;
                    if (c is Guna2GradientPanel p)
                    {
                        p.FillColor = Color.Transparent;
                        p.FillColor2 = Color.Transparent;
                    }
                }

                // Đổi màu item đang chọn
                pnl.FillColor = _colorSelected1;
                // pnl.FillColor2 = _colorSelected2; // Nếu muốn hiệu ứng gradient thì bỏ comment dòng này

                OpenPrivateChat(username);
                UpdateRightSideBar(username, false);
            };

            // Gán sự kiện click cho tất cả thành phần để bấm vào đâu cũng ăn
            pnl.Click += clickEvent;
            pb.Click += clickEvent;
            lbl.Click += clickEvent;

            // 5. Thêm các control con vào Panel
            pnl.Controls.Add(pb);
            pnl.Controls.Add(lbl);

            // 6. Thêm Panel vào danh sách
            flowGroups.Controls.Add(pnl);

            // Kích hoạt click ngay lập tức (giống logic cũ)
            // Lưu ý: Cần gọi sự kiện click một cách thủ công hoặc gọi hàm xử lý
            // Ở đây ta gọi trực tiếp logic xử lý để tránh lỗi Event tham số
            foreach (Control c in flowGroups.Controls)
            {
                if (c is Guna2GradientPanel p) { p.FillColor = Color.Transparent; p.FillColor2 = Color.Transparent; }
                if (c is Guna2Button b) b.FillColor = Color.Transparent;
            }
            pnl.FillColor = _colorSelected1;
            OpenPrivateChat(username);
            UpdateRightSideBar(username, false);
        }

        private void ResetSidebarColor()
        {
            foreach (Control c in flowGroups.Controls)
            {
                if (c is Guna2Button btn) btn.FillColor = Color.Transparent;
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

        // Hàm riêng để xử lý gửi file từ đường dẫn (dùng chung cho cả button gửi file và Kéo thả)
        private void SendFileByPath(string filePath)
        {
            try
            {
                // Kiểm tra dung lượng (10MB)
                long length = new FileInfo(filePath).Length;
                if (length > 10 * 1024 * 1024)
                {
                    MessageBox.Show("File quá lớn (>10MB). Vui lòng chọn file nhỏ hơn.");
                    return;
                }

                // Đọc file và chuyển sang Base64
                byte[] b = File.ReadAllBytes(filePath);
                string b64 = Convert.ToBase64String(b);
                string payload = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{Path.GetFileName(filePath)}|{b64}"));

                // Gửi lệnh lên Server
                _client.Send(new ChatMessage
                {
                    Type = MessageType.FILE_SEND,
                    Sender = _currentUser,
                    Receiver = _isGroupChat ? _currentGroup : _selectedUser,
                    Content = payload
                });

                // Hiển thị bong bóng chat 
                AddMessageBubble(_currentUser, $"Sent file: {Path.GetFileName(filePath)}", true, DateTime.Now);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi file: " + ex.Message);
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] fileBytes = File.ReadAllBytes(ofd.FileName);
                    string base64Data = Convert.ToBase64String(fileBytes);
                    string fileName = Path.GetFileName(ofd.FileName);
                    string payload = fileName + "|" + base64Data;

                    string contentToSend = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));

                    _client.Send(new ChatMessage
                    {
                        Type = MessageType.FILE_SEND,
                        Sender = _currentUser,
                        Receiver = _isGroupChat ? _currentGroup : _selectedUser,
                        Content = contentToSend
                    });

                    if (IsImageFile(fileName))
                    {
                        using (var ms = new MemoryStream(fileBytes))
                        {
                            AddImageBubble(_currentUser, new Bitmap(Image.FromStream(ms)), true, DateTime.Now);
                        }
                    }
                    else
                    {
                        AddFileBubble(_currentUser, fileName, fileBytes, true, DateTime.Now);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void NotifyIfHidden(string sender, string message)
        {
            if (sender != _currentUser && (this.WindowState == FormWindowState.Minimized || !this.Focused))
            {
                try
                {
                    System.Media.SystemSounds.Exclamation.Play();

                    _notifyIcon.ShowBalloonTip(3000, $"New message from {sender}", message, ToolTipIcon.Info);
                }
                catch
                {
                }
            }
        }
        private void pbGroupIconRight_Click(object sender, EventArgs e)
        {

        }

        private void btnTabGroup_Click(object sender, EventArgs e)
        {
            SwitchTab(true);
        }

        private void btnTabUser_Click(object sender, EventArgs e)
        {
            SwitchTab(false);

        }


        private void SwitchTab(bool isGroup)
        {
            _isShowingGroups = isGroup;

            if (isGroup)
            {
                btnTabGroup.FillColor = _colorSelected2; 
                btnTabUser.FillColor = Color.Transparent;

                txtSearchGroup.PlaceholderText = "Tìm nhóm...";
            }
            else
            {
                btnTabUser.FillColor = _colorSelected2; 
                btnTabGroup.FillColor = Color.Transparent;

                txtSearchGroup.PlaceholderText = "Tìm người dùng...";
            }

            flowGroups.Controls.Clear();

            if (isGroup)
            {
                RenderGroupList();
            }
            else
            {
                _client.Send(new ChatMessage
                {
                    Type = MessageType.GET_RECENT_USERS_REQUEST,
                    Sender = _currentUser
                });
            }
        }

        private void RenderGroupList()
        {
            flowGroups.Controls.Clear();
            _client.Send(new ChatMessage
            {
                Type = MessageType.LOAD_GROUP_REQUEST,
                Sender = _currentUser
            });
        }

        private void RenderOnlineUserList()
        {
            flowGroups.Controls.Clear();

            if (_client.OnlineUsers == null) return;

            foreach (var user in _client.OnlineUsers)
            {
                if (user == _currentUser) continue;

                Guna2Button btnUser = new Guna2Button();
                btnUser.Size = new Size(flowGroups.Width - 10, 50);
                btnUser.BorderRadius = 10;

                bool isSelected = (!_isGroupChat && _selectedUser == user);
                btnUser.FillColor = isSelected ? _colorSelected1 : Color.Transparent;

                btnUser.ForeColor = Color.White;
                btnUser.TextAlign = HorizontalAlignment.Left;
                btnUser.Text = "   " + user; 
                btnUser.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnUser.Margin = new Padding(5);
                btnUser.Cursor = Cursors.Hand;

                btnUser.Click += (s, e) =>
                {
                    OpenPrivateChat(user);

                    foreach (Control c in flowGroups.Controls)
                        if (c is Guna2Button b) b.FillColor = Color.Transparent;
                    btnUser.FillColor = _colorSelected1;
                };

                flowGroups.Controls.Add(btnUser);
            }
        }


        private void RenderUserChatList(string[] users)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => RenderUserChatList(users)));
                return;
            }

            // Chỉ vẽ nếu đang ở Tab User
            if (_isShowingGroups) return;

            flowGroups.Controls.Clear();

            if (users == null) return;

            foreach (string user in users)
            {
                if (user == _currentUser) continue;

                // Gọi hàm thêm nút mới
                AddUserToSidebar(user);
            }
        }


        private void AddUserButton(string username)
        {
            Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();

            btn.Size = new Size(245, 55); 
            btn.FillColor = Color.Transparent;
            btn.ForeColor = Color.White;      
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.TextAlign = HorizontalAlignment.Left;
            btn.Image = null; 
            btn.Text = "  " + username;
            btn.BorderRadius = 10;
            btn.Margin = new Padding(5, 5, 0, 5);
            btn.Cursor = Cursors.Hand;

            btn.HoverState.FillColor = Color.FromArgb(40, 44, 52);

            btn.Click += (sender, e) =>
            {
                foreach (Control c in flowGroups.Controls)
                {
                    if (c is Guna.UI2.WinForms.Guna2Button b)
                        b.FillColor = Color.Transparent;
                }

                btn.FillColor = _colorSelected1;

                OpenPrivateChat(username);
            };

            flowGroups.Controls.Add(btn);
        }


        private void OpenPrivateChat(string targetUser)
        {
            _isGroupChat = false;
            _selectedUser = targetUser;
            _currentGroup = null;

            lblHeaderTitle.Text = targetUser;
            lblMemberCount.Text = "Private Chat";


            flowMessages.Controls.Clear();

            _client.Send(new ChatMessage
            {
                Type = MessageType.HISTORY_REQUEST,
                Sender = _currentUser,     
                Receiver = targetUser,     
                Content = "PRIVATE"  
            });
        }

        private void btnInvite_Click_1(object sender, EventArgs e)
        {

        }


        // Cho phép resize form từ các cạnh và góc
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;

            // Resize handles (các cạnh và góc)
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            base.WndProc(ref m);

            // Nếu là tin nhắn kiểm tra vị trí chuột
            if (m.Msg == WM_NCHITTEST)
            {
                int resizeBorder = 10; // Độ rộng vùng biên để bắt sự kiện resize (pixel)

                Point pos = this.PointToClient(new Point(m.LParam.ToInt32()));

                if (pos.X <= resizeBorder && pos.Y <= resizeBorder)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (pos.X >= this.ClientSize.Width - resizeBorder && pos.Y <= resizeBorder)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (pos.X <= resizeBorder && pos.Y >= this.ClientSize.Height - resizeBorder)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (pos.X >= this.ClientSize.Width - resizeBorder && pos.Y >= this.ClientSize.Height - resizeBorder)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (pos.X <= resizeBorder)
                    m.Result = (IntPtr)HTLEFT;
                else if (pos.X >= this.ClientSize.Width - resizeBorder)
                    m.Result = (IntPtr)HTRIGHT;
                else if (pos.Y <= resizeBorder)
                    m.Result = (IntPtr)HTTOP;
                else if (pos.Y >= this.ClientSize.Height - resizeBorder)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void txtSearchGroup_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchGroup.Text.Trim().ToLower();
            flowGroups.SuspendLayout();

            foreach (Control control in flowGroups.Controls)
            {               
                if (control is Guna2GradientPanel pnl && pnl.Tag != null)
                {
                    string groupName = pnl.Tag.ToString().ToLower();

                    if (string.IsNullOrEmpty(keyword) || groupName.Contains(keyword))
                    {
                        pnl.Visible = true;
                    }
                    else
                    {
                        pnl.Visible = false;
                    }
                }
            }

            flowGroups.ResumeLayout();
        }

        private void InitializeEmojiPanel()
        {
            _pnlEmoji = new Guna2Panel();
            _pnlEmoji.Size = new Size(250, 200); 
            _pnlEmoji.FillColor = Color.FromArgb(35, 45, 65); 
            _pnlEmoji.BorderRadius = 10;
            _pnlEmoji.Visible = false; 
            _pnlEmoji.ShadowDecoration.Enabled = true; 

            FlowLayoutPanel flowEmoji = new FlowLayoutPanel();
            flowEmoji.Dock = DockStyle.Fill;
            flowEmoji.Padding = new Padding(10);
            flowEmoji.AutoScroll = true; 
            flowEmoji.BackColor = Color.Transparent;

            foreach (string icon in _emojiList)
            {
                Label lblIcon = new Label();
                lblIcon.Text = icon;
                lblIcon.Font = new Font("Segoe UI Emoji", 14F); 
                lblIcon.ForeColor = Color.White;
                lblIcon.AutoSize = false;
                lblIcon.Size = new Size(35, 35);
                lblIcon.TextAlign = ContentAlignment.MiddleCenter;
                lblIcon.Cursor = Cursors.Hand;

                lblIcon.MouseEnter += (s, e) => { lblIcon.BackColor = Color.FromArgb(50, 60, 80); };
                lblIcon.MouseLeave += (s, e) => { lblIcon.BackColor = Color.Transparent; };

                lblIcon.Click += (s, e) =>
                {
                    txtMessage.Text += icon; 
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                    txtMessage.Focus();
                };

                flowEmoji.Controls.Add(lblIcon);
            }

            _pnlEmoji.Controls.Add(flowEmoji);
            this.Controls.Add(_pnlEmoji); 
            _pnlEmoji.BringToFront(); 
        }
        private void ToggleEmojiPanel()
        {
            if (_pnlEmoji.Visible)
            {
                _pnlEmoji.Visible = false;
            }
            else
            {
                Point btnLoc = btnEmoji.PointToScreen(Point.Empty);
                Point formLoc = this.PointToScreen(Point.Empty);

                int x = btnLoc.X - formLoc.X;
                int y = (btnLoc.Y - formLoc.Y) - _pnlEmoji.Height - 10;

                _pnlEmoji.Location = new Point(x, y);
                _pnlEmoji.Visible = true;
                _pnlEmoji.BringToFront();
            }
        }
    }
}