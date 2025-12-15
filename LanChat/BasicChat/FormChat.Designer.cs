namespace BasicChat
{
    partial class FormChat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.Label lblChatMode;
        private System.Windows.Forms.Panel pnlChatMode;


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
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblOnlineUsers = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblChatMode = new System.Windows.Forms.Label();
            this.pnlChatMode = new System.Windows.Forms.Panel();
            this.Name1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Label();
            this.lblGroupChats = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.flowGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.HideUsersLists = new System.Windows.Forms.PictureBox();
            this.ShowUsersLists = new System.Windows.Forms.PictureBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.FlowUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGroupMembers = new System.Windows.Forms.Label();
            this.lstMember = new System.Windows.Forms.ListView();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlChatMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideUsersLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowUsersLists)).BeginInit();
            this.FlowUsers.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.ForeColor = System.Drawing.Color.White;
            this.rtbChat.Location = new System.Drawing.Point(4, 84);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(4);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(496, 488);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(7, 580);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(377, 27);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // lblOnlineUsers
            // 
            this.lblOnlineUsers.AutoSize = true;
            this.lblOnlineUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOnlineUsers.ForeColor = System.Drawing.Color.Silver;
            this.lblOnlineUsers.Location = new System.Drawing.Point(4, 8);
            this.lblOnlineUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlineUsers.Name = "lblOnlineUsers";
            this.lblOnlineUsers.Size = new System.Drawing.Size(143, 20);
            this.lblOnlineUsers.TabIndex = 0;
            this.lblOnlineUsers.Text = "Nguoi dung online:";
            this.lblOnlineUsers.Click += new System.EventHandler(this.lblOnlineUsers_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(4, 4);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(286, 256);
            this.lstUsers.TabIndex = 1;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblCurrentUser.Location = new System.Drawing.Point(109, 5);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(108, 23);
            this.lblCurrentUser.TabIndex = 0;
            this.lblCurrentUser.Text = "Dang nhap: ";
            // 
            // lblChatMode
            // 
            this.lblChatMode.AutoSize = true;
            this.lblChatMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatMode.ForeColor = System.Drawing.Color.Green;
            this.lblChatMode.Location = new System.Drawing.Point(190, 35);
            this.lblChatMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChatMode.Name = "lblChatMode";
            this.lblChatMode.Size = new System.Drawing.Size(139, 16);
            this.lblChatMode.TabIndex = 2;
            this.lblChatMode.Text = "Che do: Chat Nhom";
            // 
            // pnlChatMode
            // 
            this.pnlChatMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlChatMode.Controls.Add(this.Name1);
            this.pnlChatMode.Controls.Add(this.lblChatMode);
            this.pnlChatMode.Controls.Add(this.lblCurrentUser);
            this.pnlChatMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChatMode.Location = new System.Drawing.Point(0, 0);
            this.pnlChatMode.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChatMode.Name = "pnlChatMode";
            this.pnlChatMode.Size = new System.Drawing.Size(503, 76);
            this.pnlChatMode.TabIndex = 1;
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name1.Location = new System.Drawing.Point(3, 6);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(0, 29);
            this.Name1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-2, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.splitContainer1.Panel2.Controls.Add(this.HideUsersLists);
            this.splitContainer1.Panel2.Controls.Add(this.ShowUsersLists);
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Controls.Add(this.lblOnlineUsers);
            this.splitContainer1.Panel2.Controls.Add(this.FlowUsers);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 632);
            this.splitContainer1.SplitterDistance = 760;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.lblGroupChats);
            this.splitContainer2.Panel1.Controls.Add(this.splitter1);
            this.splitContainer2.Panel1.Controls.Add(this.flowGroups);
            this.splitContainer2.Panel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.splitContainer2.Panel2.Controls.Add(this.pnlChatMode);
            this.splitContainer2.Panel2.Controls.Add(this.pnlChat);
            this.splitContainer2.Size = new System.Drawing.Size(760, 632);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(212, 2);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(28, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "+";
            this.button1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblGroupChats
            // 
            this.lblGroupChats.AutoSize = true;
            this.lblGroupChats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupChats.ForeColor = System.Drawing.Color.Silver;
            this.lblGroupChats.Location = new System.Drawing.Point(10, 11);
            this.lblGroupChats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupChats.Name = "lblGroupChats";
            this.lblGroupChats.Size = new System.Drawing.Size(100, 20);
            this.lblGroupChats.TabIndex = 1;
            this.lblGroupChats.Text = "Group Chats:";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 632);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // flowGroups
            // 
            this.flowGroups.AutoScroll = true;
            this.flowGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowGroups.Location = new System.Drawing.Point(10, 45);
            this.flowGroups.Name = "flowGroups";
            this.flowGroups.Size = new System.Drawing.Size(230, 560);
            this.flowGroups.TabIndex = 3;
            this.flowGroups.WrapContents = false;
            // 
            // HideUsersLists
            // 
            this.HideUsersLists.ErrorImage = null;
            this.HideUsersLists.Location = new System.Drawing.Point(270, 7);
            this.HideUsersLists.Name = "HideUsersLists";
            this.HideUsersLists.Size = new System.Drawing.Size(26, 23);
            this.HideUsersLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HideUsersLists.TabIndex = 5;
            this.HideUsersLists.TabStop = false;
            this.HideUsersLists.Click += new System.EventHandler(this.HideUsersLists_Click);
            // 
            // ShowUsersLists
            // 
            this.ShowUsersLists.Location = new System.Drawing.Point(270, 6);
            this.ShowUsersLists.Name = "ShowUsersLists";
            this.ShowUsersLists.Size = new System.Drawing.Size(26, 23);
            this.ShowUsersLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowUsersLists.TabIndex = 6;
            this.ShowUsersLists.TabStop = false;
            this.ShowUsersLists.Visible = false;
            this.ShowUsersLists.Click += new System.EventHandler(this.ShowUsersLists_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 632);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // FlowUsers
            // 
            this.FlowUsers.Controls.Add(this.lstUsers);
            this.FlowUsers.Controls.Add(this.lblGroupMembers);
            this.FlowUsers.Controls.Add(this.lstMember);
            this.FlowUsers.Location = new System.Drawing.Point(9, 35);
            this.FlowUsers.Name = "FlowUsers";
            this.FlowUsers.Size = new System.Drawing.Size(291, 588);
            this.FlowUsers.TabIndex = 7;
            // 
            // lblGroupMembers
            // 
            this.lblGroupMembers.AutoSize = true;
            this.lblGroupMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupMembers.ForeColor = System.Drawing.Color.Silver;
            this.lblGroupMembers.Location = new System.Drawing.Point(4, 264);
            this.lblGroupMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupMembers.Name = "lblGroupMembers";
            this.lblGroupMembers.Size = new System.Drawing.Size(77, 20);
            this.lblGroupMembers.TabIndex = 7;
            this.lblGroupMembers.Text = "GROUPS: ";
            // 
            // lstMember
            // 
            this.lstMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstMember.HideSelection = false;
            this.lstMember.Location = new System.Drawing.Point(3, 287);
            this.lstMember.Name = "lstMember";
            this.lstMember.Size = new System.Drawing.Size(288, 301);
            this.lstMember.TabIndex = 2;
            this.lstMember.UseCompatibleStateImageBehavior = false;
            this.lstMember.SelectedIndexChanged += new System.EventHandler(this.lstMember_SelectedIndexChanged);
            // 
            // pnlChat
            // 
            this.pnlChat.Controls.Add(this.btnSend);
            this.pnlChat.Controls.Add(this.rtbChat);
            this.pnlChat.Controls.Add(this.txtMessage);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChat.Location = new System.Drawing.Point(0, 0);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(503, 632);
            this.pnlChat.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSend.Location = new System.Drawing.Point(391, 579);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1066, 636);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.pnlChatMode.ResumeLayout(false);
            this.pnlChatMode.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HideUsersLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowUsersLists)).EndInit();
            this.FlowUsers.ResumeLayout(false);
            this.FlowUsers.PerformLayout();
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label lblGroupChats;
        private System.Windows.Forms.FlowLayoutPanel flowGroups;
        private System.Windows.Forms.Label button1;
        private System.Windows.Forms.Label Name1;
        private System.Windows.Forms.PictureBox ShowUsersLists;
        private System.Windows.Forms.PictureBox HideUsersLists;
        private System.Windows.Forms.FlowLayoutPanel FlowUsers;
        private System.Windows.Forms.ListView lstMember;
        private System.Windows.Forms.Label lblGroupMembers;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Button btnSend;
    }
}
