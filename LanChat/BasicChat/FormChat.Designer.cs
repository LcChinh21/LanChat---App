using System.Drawing;
using System.Windows.Forms;

namespace BasicChat
{
    partial class FormChat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblCurrentUser;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblChatMode = new System.Windows.Forms.Label();
            this.pnlChatMode = new System.Windows.Forms.Panel();
            this.Name1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Label();
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlGroups = new System.Windows.Forms.Panel();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.PictureBox();
            this.pnlChatMode.SuspendLayout();
            this.pnlUsers.SuspendLayout();
            this.FlowUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideUsersLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowUsersLists)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlGroups.SuspendLayout();
            this.pnlChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.ForeColor = System.Drawing.Color.White;
            this.rtbChat.Location = new System.Drawing.Point(319, 142);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(4);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(151, 123);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(0, 532);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(555, 27);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(122)))), ((int)(((byte)(135)))));
            this.lblCurrentUser.Location = new System.Drawing.Point(7, 6);
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
            this.lblChatMode.Location = new System.Drawing.Point(465, 3);
            this.lblChatMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChatMode.Name = "lblChatMode";
            this.lblChatMode.Size = new System.Drawing.Size(139, 16);
            this.lblChatMode.TabIndex = 2;
            this.lblChatMode.Text = "Che do: Chat Nhom";
            // 
            // pnlChatMode
            // 
            this.pnlChatMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.pnlChatMode.Controls.Add(this.lblCurrentUser);
            this.pnlChatMode.Controls.Add(this.Name1);
            this.pnlChatMode.Controls.Add(this.lblChatMode);
            this.pnlChatMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChatMode.Location = new System.Drawing.Point(300, 40);
            this.pnlChatMode.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChatMode.Name = "pnlChatMode";
            this.pnlChatMode.Size = new System.Drawing.Size(555, 76);
            this.pnlChatMode.TabIndex = 1;
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name1.Location = new System.Drawing.Point(6, 44);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(27, 29);
            this.Name1.TabIndex = 3;
            this.Name1.Text = "n";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(191)))), ((int)(((byte)(229)))));
            this.button1.Location = new System.Drawing.Point(272, 0);
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
            this.lblGroupChats.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupChats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupChats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(178)))));
            this.lblGroupChats.Location = new System.Drawing.Point(0, 0);
            this.lblGroupChats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupChats.Name = "lblGroupChats";
            this.lblGroupChats.Size = new System.Drawing.Size(100, 20);
            this.lblGroupChats.TabIndex = 1;
            this.lblGroupChats.Text = "Group Chats:";
            // 
            // flowGroups
            // 
            this.flowGroups.AutoScroll = true;
            this.flowGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.flowGroups.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowGroups.Location = new System.Drawing.Point(0, 23);
            this.flowGroups.Name = "flowGroups";
            this.flowGroups.Size = new System.Drawing.Size(300, 612);
            this.flowGroups.TabIndex = 3;
            this.flowGroups.WrapContents = false;
            this.flowGroups.Paint += new System.Windows.Forms.PaintEventHandler(this.flowGroups_Paint);
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.pnlUsers.Controls.Add(this.FlowUsers);
            this.pnlUsers.Controls.Add(this.lblOnlineUsers);
            this.pnlUsers.Controls.Add(this.HideUsersLists);
            this.pnlUsers.Controls.Add(this.ShowUsersLists);
            this.pnlUsers.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUsers.Location = new System.Drawing.Point(855, 40);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(211, 635);
            this.pnlUsers.TabIndex = 6;
            // 
            // FlowUsers
            // 
            this.FlowUsers.Controls.Add(this.lstUsers);
            this.FlowUsers.Controls.Add(this.lblGroupMembers);
            this.FlowUsers.Controls.Add(this.lstMember);
            this.FlowUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowUsers.Location = new System.Drawing.Point(0, 45);
            this.FlowUsers.Name = "FlowUsers";
            this.FlowUsers.Size = new System.Drawing.Size(211, 590);
            this.FlowUsers.TabIndex = 7;
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(4, 4);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(204, 224);
            this.lstUsers.TabIndex = 1;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // lblGroupMembers
            // 
            this.lblGroupMembers.AutoSize = true;
            this.lblGroupMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(178)))));
            this.lblGroupMembers.Location = new System.Drawing.Point(4, 232);
            this.lblGroupMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupMembers.Name = "lblGroupMembers";
            this.lblGroupMembers.Size = new System.Drawing.Size(77, 20);
            this.lblGroupMembers.TabIndex = 7;
            this.lblGroupMembers.Text = "GROUPS: ";
            // 
            // lstMember
            // 
            this.lstMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(61)))));
            this.lstMember.HideSelection = false;
            this.lstMember.Location = new System.Drawing.Point(3, 255);
            this.lstMember.Name = "lstMember";
            this.lstMember.Size = new System.Drawing.Size(205, 332);
            this.lstMember.TabIndex = 2;
            this.lstMember.UseCompatibleStateImageBehavior = false;
            this.lstMember.SelectedIndexChanged += new System.EventHandler(this.lstMember_SelectedIndexChanged);
            // 
            // lblOnlineUsers
            // 
            this.lblOnlineUsers.AutoSize = true;
            this.lblOnlineUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOnlineUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(178)))));
            this.lblOnlineUsers.Location = new System.Drawing.Point(8, 3);
            this.lblOnlineUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnlineUsers.Name = "lblOnlineUsers";
            this.lblOnlineUsers.Size = new System.Drawing.Size(144, 20);
            this.lblOnlineUsers.TabIndex = 0;
            this.lblOnlineUsers.Text = "Người dùng online:";
            this.lblOnlineUsers.Click += new System.EventHandler(this.lblOnlineUsers_Click);
            // 
            // HideUsersLists
            // 
            this.HideUsersLists.ErrorImage = null;
            this.HideUsersLists.Location = new System.Drawing.Point(177, 8);
            this.HideUsersLists.Name = "HideUsersLists";
            this.HideUsersLists.Size = new System.Drawing.Size(26, 23);
            this.HideUsersLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HideUsersLists.TabIndex = 5;
            this.HideUsersLists.TabStop = false;
            this.HideUsersLists.Click += new System.EventHandler(this.HideUsersLists_Click);
            // 
            // ShowUsersLists
            // 
            this.ShowUsersLists.Location = new System.Drawing.Point(177, 8);
            this.ShowUsersLists.Name = "ShowUsersLists";
            this.ShowUsersLists.Size = new System.Drawing.Size(26, 23);
            this.ShowUsersLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowUsersLists.TabIndex = 6;
            this.ShowUsersLists.TabStop = false;
            this.ShowUsersLists.Visible = false;
            this.ShowUsersLists.Click += new System.EventHandler(this.ShowUsersLists_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.pnlMenu.Controls.Add(this.btnExit);
            this.pnlMenu.Controls.Add(this.lblAppName);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1066, 40);
            this.pnlMenu.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(243)))));
            this.btnExit.Location = new System.Drawing.Point(1010, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 40);
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
            this.lblAppName.Location = new System.Drawing.Point(4, 4);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(108, 29);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "LanChat";
            // 
            // pnlGroups
            // 
            this.pnlGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.pnlGroups.Controls.Add(this.lblGroupChats);
            this.pnlGroups.Controls.Add(this.button1);
            this.pnlGroups.Controls.Add(this.flowGroups);
            this.pnlGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGroups.Location = new System.Drawing.Point(0, 40);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(300, 635);
            this.pnlGroups.TabIndex = 9;
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.pnlChat.Controls.Add(this.btnSend);
            this.pnlChat.Controls.Add(this.txtMessage);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChat.Location = new System.Drawing.Point(300, 116);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(555, 559);
            this.pnlChat.TabIndex = 10;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(586, 534);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(20, 25);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSend.TabIndex = 5;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1066, 675);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlChatMode);
            this.Controls.Add(this.pnlGroups);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.pnlUsers);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.pnlChatMode.ResumeLayout(false);
            this.pnlChatMode.PerformLayout();
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.FlowUsers.ResumeLayout(false);
            this.FlowUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideUsersLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowUsersLists)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlGroups.ResumeLayout(false);
            this.pnlGroups.PerformLayout();
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label lblGroupChats;
        private System.Windows.Forms.FlowLayoutPanel flowGroups;
        private System.Windows.Forms.Label button1;
        private System.Windows.Forms.Label Name1;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.FlowLayoutPanel FlowUsers;
        private System.Windows.Forms.ListView lstMember;
        private System.Windows.Forms.Label lblGroupMembers;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.PictureBox ShowUsersLists;
        private System.Windows.Forms.PictureBox HideUsersLists;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlGroups;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.PictureBox btnSend;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnExit;
    }
}
