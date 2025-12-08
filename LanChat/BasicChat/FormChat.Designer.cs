namespace BasicChat
{
    partial class FormChat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.Label lblChatMode;
        private System.Windows.Forms.RadioButton rdGroupChat;
        private System.Windows.Forms.RadioButton rdPrivateChat;
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
            this.btnSend = new System.Windows.Forms.Button();
            this.lblOnlineUsers = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblChatMode = new System.Windows.Forms.Label();
            this.rdGroupChat = new System.Windows.Forms.RadioButton();
            this.rdPrivateChat = new System.Windows.Forms.RadioButton();
            this.pnlChatMode = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lblGroupChats = new System.Windows.Forms.Label();
            this.pnlChatMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.ForeColor = System.Drawing.Color.White;
            this.rtbChat.Location = new System.Drawing.Point(4, 86);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(496, 463);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(8, 573);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(377, 27);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(393, 567);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 37);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Gui";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
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
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(8, 32);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(290, 592);
            this.lstUsers.TabIndex = 1;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblCurrentUser.Location = new System.Drawing.Point(4, 8);
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
            this.lblChatMode.Location = new System.Drawing.Point(333, 12);
            this.lblChatMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChatMode.Name = "lblChatMode";
            this.lblChatMode.Size = new System.Drawing.Size(139, 16);
            this.lblChatMode.TabIndex = 2;
            this.lblChatMode.Text = "Che do: Chat Nhom";
            // 
            // rdGroupChat
            // 
            this.rdGroupChat.AutoSize = true;
            this.rdGroupChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rdGroupChat.Checked = true;
            this.rdGroupChat.ForeColor = System.Drawing.Color.White;
            this.rdGroupChat.Location = new System.Drawing.Point(13, 10);
            this.rdGroupChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdGroupChat.Name = "rdGroupChat";
            this.rdGroupChat.Size = new System.Drawing.Size(94, 20);
            this.rdGroupChat.TabIndex = 0;
            this.rdGroupChat.TabStop = true;
            this.rdGroupChat.Text = "Chat Nhom";
            this.rdGroupChat.UseVisualStyleBackColor = false;
            this.rdGroupChat.CheckedChanged += new System.EventHandler(this.rdGroupChat_CheckedChanged);
            // 
            // rdPrivateChat
            // 
            this.rdPrivateChat.AutoSize = true;
            this.rdPrivateChat.ForeColor = System.Drawing.Color.White;
            this.rdPrivateChat.Location = new System.Drawing.Point(160, 10);
            this.rdPrivateChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdPrivateChat.Name = "rdPrivateChat";
            this.rdPrivateChat.Size = new System.Drawing.Size(94, 20);
            this.rdPrivateChat.TabIndex = 1;
            this.rdPrivateChat.Text = "Chat Rieng";
            this.rdPrivateChat.CheckedChanged += new System.EventHandler(this.rdPrivateChat_CheckedChanged);
            // 
            // pnlChatMode
            // 
            this.pnlChatMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlChatMode.Controls.Add(this.rdGroupChat);
            this.pnlChatMode.Controls.Add(this.rdPrivateChat);
            this.pnlChatMode.Controls.Add(this.lblChatMode);
            this.pnlChatMode.Location = new System.Drawing.Point(8, 35);
            this.pnlChatMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlChatMode.Name = "pnlChatMode";
            this.pnlChatMode.Size = new System.Drawing.Size(492, 43);
            this.pnlChatMode.TabIndex = 1;
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
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Controls.Add(this.lblOnlineUsers);
            this.splitContainer1.Panel2.Controls.Add(this.lstUsers);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 632);
            this.splitContainer1.SplitterDistance = 760;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.splitContainer2.Panel1.Controls.Add(this.lblGroupChats);
            this.splitContainer2.Panel1.Controls.Add(this.splitter1);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.splitContainer2.Panel2.Controls.Add(this.txtMessage);
            this.splitContainer2.Panel2.Controls.Add(this.pnlChatMode);
            this.splitContainer2.Panel2.Controls.Add(this.rtbChat);
            this.splitContainer2.Panel2.Controls.Add(this.btnSend);
            this.splitContainer2.Panel2.Controls.Add(this.lblCurrentUser);
            this.splitContainer2.Size = new System.Drawing.Size(760, 632);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 632);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 632);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
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
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1066, 636);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label lblGroupChats;
    }
}
