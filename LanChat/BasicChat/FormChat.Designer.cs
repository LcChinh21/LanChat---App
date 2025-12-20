using System.Drawing;
using System.Windows.Forms;

namespace BasicChat
{
    partial class FormChat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Label lblCurrentUser;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.Name1 = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblGroupChats = new System.Windows.Forms.Label();
            this.flowGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.FlowUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblGroupMembers = new System.Windows.Forms.Label();
            this.lstMember = new System.Windows.Forms.ListView();
            this.lblOnlineUsers = new System.Windows.Forms.Label();
            this.HideUsersLists = new System.Windows.Forms.PictureBox();
            this.ShowUsersLists = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSend = new System.Windows.Forms.PictureBox();
            this.pnlChatMode = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlGroups = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnSendFile = new System.Windows.Forms.PictureBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlUsers.SuspendLayout();
            this.FlowUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideUsersLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowUsersLists)).BeginInit();
            this.pnlChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            this.pnlChatMode.SuspendLayout();
            this.pnlGroups.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendFile)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.ForeColor = System.Drawing.Color.White;
            this.rtbChat.Location = new System.Drawing.Point(264, 86);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(693, 626);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            this.rtbChat.TextChanged += new System.EventHandler(this.rtbChat_TextChanged);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(122)))), ((int)(((byte)(135)))));
            this.lblCurrentUser.Location = new System.Drawing.Point(17, 10);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(126, 28);
            this.lblCurrentUser.TabIndex = 0;
            this.lblCurrentUser.Text = "Dang nhap: ";
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.Name1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name1.Location = new System.Drawing.Point(16, 31);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(0, 32);
            this.Name1.TabIndex = 3;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(191)))), ((int)(((byte)(229)))));
            this.lblAdd.Location = new System.Drawing.Point(228, 1);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAdd.Size = new System.Drawing.Size(26, 26);
            this.lblAdd.TabIndex = 4;
            this.lblAdd.Text = "+";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblGroupChats
            // 
            this.lblGroupChats.AutoSize = true;
            this.lblGroupChats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupChats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(178)))));
            this.lblGroupChats.Location = new System.Drawing.Point(4, 4);
            this.lblGroupChats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupChats.Name = "lblGroupChats";
            this.lblGroupChats.Size = new System.Drawing.Size(122, 25);
            this.lblGroupChats.TabIndex = 1;
            this.lblGroupChats.Text = "Group Chats:";
            // 
            // flowGroups
            // 
            this.flowGroups.AutoScroll = true;
            this.flowGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.flowGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowGroups.Location = new System.Drawing.Point(0, 0);
            this.flowGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowGroups.Name = "flowGroups";
            this.flowGroups.Size = new System.Drawing.Size(256, 794);
            this.flowGroups.TabIndex = 3;
            this.flowGroups.WrapContents = false;
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.pnlUsers.Controls.Add(this.FlowUsers);
            this.pnlUsers.Controls.Add(this.lblOnlineUsers);
            this.pnlUsers.Controls.Add(this.HideUsersLists);
            this.pnlUsers.Controls.Add(this.ShowUsersLists);
            this.pnlUsers.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUsers.Location = new System.Drawing.Point(962, 50);
            this.pnlUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(237, 794);
            this.pnlUsers.TabIndex = 6;
            this.pnlUsers.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUsers_Paint);
            // 
            // FlowUsers
            // 
            this.FlowUsers.Controls.Add(this.lstUsers);
            this.FlowUsers.Controls.Add(this.lblGroupMembers);
            this.FlowUsers.Controls.Add(this.lstMember);
            this.FlowUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowUsers.Location = new System.Drawing.Point(0, 56);
            this.FlowUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FlowUsers.Name = "FlowUsers";
            this.FlowUsers.Size = new System.Drawing.Size(237, 738);
            this.FlowUsers.TabIndex = 7;
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 20;
            this.lstUsers.Location = new System.Drawing.Point(4, 5);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(230, 280);
            this.lstUsers.TabIndex = 1;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // lblGroupMembers
            // 
            this.lblGroupMembers.AutoSize = true;
            this.lblGroupMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(178)))));
            this.lblGroupMembers.Location = new System.Drawing.Point(4, 290);
            this.lblGroupMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupMembers.Name = "lblGroupMembers";
            this.lblGroupMembers.Size = new System.Drawing.Size(95, 25);
            this.lblGroupMembers.TabIndex = 7;
            this.lblGroupMembers.Text = "GROUPS: ";
            // 
            // lstMember
            // 
            this.lstMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.lstMember.HideSelection = false;
            this.lstMember.Location = new System.Drawing.Point(3, 319);
            this.lstMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstMember.Name = "lstMember";
            this.lstMember.Size = new System.Drawing.Size(230, 414);
            this.lstMember.TabIndex = 2;
            this.lstMember.UseCompatibleStateImageBehavior = false;
            // 
            // lblOnlineUsers
            // 
            this.lblOnlineUsers.AutoSize = true;
            this.lblOnlineUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOnlineUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(178)))));
            this.lblOnlineUsers.Location = new System.Drawing.Point(9, 4);
            this.lblOnlineUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlineUsers.Name = "lblOnlineUsers";
            this.lblOnlineUsers.Size = new System.Drawing.Size(177, 25);
            this.lblOnlineUsers.TabIndex = 0;
            this.lblOnlineUsers.Text = "Người dùng online:";
            this.lblOnlineUsers.Click += new System.EventHandler(this.lblOnlineUsers_Click);
            // 
            // HideUsersLists
            // 
            this.HideUsersLists.ErrorImage = null;
            this.HideUsersLists.Image = global::BasicChat.Properties.Resources.upscrollarrow_83865__1_;
            this.HideUsersLists.Location = new System.Drawing.Point(198, 10);
            this.HideUsersLists.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HideUsersLists.Name = "HideUsersLists";
            this.HideUsersLists.Size = new System.Drawing.Size(29, 29);
            this.HideUsersLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HideUsersLists.TabIndex = 5;
            this.HideUsersLists.TabStop = false;
            this.HideUsersLists.Click += new System.EventHandler(this.HideUsersLists_Click);
            // 
            // ShowUsersLists
            // 
            this.ShowUsersLists.Image = global::BasicChat.Properties.Resources.scrollarrowtodown_83796;
            this.ShowUsersLists.Location = new System.Drawing.Point(199, 10);
            this.ShowUsersLists.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowUsersLists.Name = "ShowUsersLists";
            this.ShowUsersLists.Size = new System.Drawing.Size(29, 29);
            this.ShowUsersLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowUsersLists.TabIndex = 6;
            this.ShowUsersLists.TabStop = false;
            this.ShowUsersLists.Visible = false;
            this.ShowUsersLists.Click += new System.EventHandler(this.ShowUsersLists_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(243)))));
            this.btnExit.Location = new System.Drawing.Point(1136, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(122)))), ((int)(((byte)(135)))));
            this.lblAppName.Location = new System.Drawing.Point(4, 5);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(129, 32);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "LanChat";
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.pnlChat.Controls.Add(this.btnSendFile);
            this.pnlChat.Controls.Add(this.txtMessage);
            this.pnlChat.Controls.Add(this.btnSend);
            this.pnlChat.Controls.Add(this.rtbChat);
            this.pnlChat.Controls.Add(this.pnlChatMode);
            this.pnlChat.Controls.Add(this.pnlGroups);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChat.Location = new System.Drawing.Point(0, 50);
            this.pnlChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(962, 794);
            this.pnlChat.TabIndex = 10;
            // 
            // txtMessage
            // 
            this.txtMessage.AutoRoundedCorners = true;
            this.txtMessage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.DefaultText = "";
            this.txtMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.txtMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.Location = new System.Drawing.Point(234, 578);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "";
            this.txtMessage.SelectedText = "";
            this.txtMessage.Size = new System.Drawing.Size(568, 38);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(819, 582);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(26, 30);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSend.TabIndex = 5;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.AutoRoundedCorners = true;
            this.txtMessage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.DefaultText = "";
            this.txtMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.txtMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.Location = new System.Drawing.Point(263, 722);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "";
            this.txtMessage.SelectedText = "";
            this.txtMessage.Size = new System.Drawing.Size(606, 48);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(921, 728);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(36, 38);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSend.TabIndex = 5;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlChatMode
            // 
            this.pnlChatMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.pnlChatMode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.pnlChatMode.BorderRadius = 20;
            this.pnlChatMode.BorderThickness = 5;
            this.pnlChatMode.Controls.Add(this.lblCurrentUser);
            this.pnlChatMode.Controls.Add(this.Name1);
            this.pnlChatMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChatMode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.pnlChatMode.Location = new System.Drawing.Point(256, 0);
            this.pnlChatMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChatMode.Name = "pnlChatMode";
            this.pnlChatMode.Size = new System.Drawing.Size(706, 78);
            this.pnlChatMode.TabIndex = 6;
            // 
            // pnlGroups
            // 
            this.pnlGroups.Controls.Add(this.lblAdd);
            this.pnlGroups.Controls.Add(this.lblGroupChats);
            this.pnlGroups.Controls.Add(this.flowGroups);
            this.pnlGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGroups.Location = new System.Drawing.Point(0, 0);
            this.pnlGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(256, 794);
            this.pnlGroups.TabIndex = 7;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.pnlMenu.Controls.Add(this.btnMinimize);
            this.pnlMenu.Controls.Add(this.btnResize);
            this.pnlMenu.Controls.Add(this.btnExit);
            this.pnlMenu.Controls.Add(this.lblAppName);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1199, 50);
            this.pnlMenu.TabIndex = 8;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSendFile.Image")));
            this.btnSendFile.Location = new System.Drawing.Point(875, 728);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(36, 38);
            this.btnSendFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSendFile.TabIndex = 9;
            this.btnSendFile.TabStop = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(243)))));
            this.btnResize.Location = new System.Drawing.Point(1067, 0);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(63, 50);
            this.btnResize.TabIndex = 3;
            this.btnResize.Text = "☐";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnMinimize
            // guna2AnimateWindow1
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(243)))));
            this.btnMinimize.Location = new System.Drawing.Point(998, -3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(63, 54);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.guna2AnimateWindow1.Interval = 200;
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlMenu;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1199, 844);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlUsers);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.FlowUsers.ResumeLayout(false);
            this.FlowUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideUsersLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowUsersLists)).EndInit();
            this.pnlChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            this.pnlChatMode.ResumeLayout(false);
            this.pnlChatMode.PerformLayout();
            this.pnlGroups.ResumeLayout(false);
            this.pnlGroups.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendFile)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label lblGroupChats;
        private System.Windows.Forms.FlowLayoutPanel flowGroups;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label Name1;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.FlowLayoutPanel FlowUsers;
        private System.Windows.Forms.ListView lstMember;
        private System.Windows.Forms.Label lblGroupMembers;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.PictureBox ShowUsersLists;
        private System.Windows.Forms.PictureBox HideUsersLists;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnExit;
        private Guna.UI2.WinForms.Guna2Panel pnlChatMode;
        private Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Panel pnlGroups;
        private PictureBox btnSend;
        private Guna.UI2.WinForms.Guna2TextBox txtMessage;
        private PictureBox btnSendFile;
        private Button btnMinimize;
        private Button btnResize;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}
