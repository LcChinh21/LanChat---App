namespace BasicChat
{
    partial class FormChat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.Label lblSelectedUser;
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
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblOnlineUsers = new System.Windows.Forms.Label();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.lblChatMode = new System.Windows.Forms.Label();
            this.rdGroupChat = new System.Windows.Forms.RadioButton();
            this.rdPrivateChat = new System.Windows.Forms.RadioButton();
            this.pnlChatMode = new System.Windows.Forms.Panel();
            this.pnlUsers.SuspendLayout();
            this.pnlChatMode.SuspendLayout();
            this.SuspendLayout();

            // lblCurrentUser
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentUser.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(100, 19);
            this.lblCurrentUser.Text = "Dang nhap: ";

            // pnlChatMode
            this.pnlChatMode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlChatMode.Controls.Add(this.rdGroupChat);
            this.pnlChatMode.Controls.Add(this.rdPrivateChat);
            this.pnlChatMode.Controls.Add(this.lblChatMode);
            this.pnlChatMode.Location = new System.Drawing.Point(10, 35);
            this.pnlChatMode.Name = "pnlChatMode";
            this.pnlChatMode.Size = new System.Drawing.Size(420, 35);

            // rdGroupChat
            this.rdGroupChat.AutoSize = true;
            this.rdGroupChat.Location = new System.Drawing.Point(10, 8);
            this.rdGroupChat.Name = "rdGroupChat";
            this.rdGroupChat.Size = new System.Drawing.Size(85, 19);
            this.rdGroupChat.Text = "Chat Nhom";
            this.rdGroupChat.Checked = true;
            this.rdGroupChat.CheckedChanged += new System.EventHandler(this.rdGroupChat_CheckedChanged);

            // rdPrivateChat
            this.rdPrivateChat.AutoSize = true;
            this.rdPrivateChat.Location = new System.Drawing.Point(120, 8);
            this.rdPrivateChat.Name = "rdPrivateChat";
            this.rdPrivateChat.Size = new System.Drawing.Size(85, 19);
            this.rdPrivateChat.Text = "Chat Rieng";
            this.rdPrivateChat.CheckedChanged += new System.EventHandler(this.rdPrivateChat_CheckedChanged);

            // lblChatMode
            this.lblChatMode.AutoSize = true;
            this.lblChatMode.Location = new System.Drawing.Point(250, 10);
            this.lblChatMode.Name = "lblChatMode";
            this.lblChatMode.Size = new System.Drawing.Size(120, 15);
            this.lblChatMode.Text = "Che do: Chat Nhom";
            this.lblChatMode.ForeColor = System.Drawing.Color.Green;

            // rtbChat
            this.rtbChat.BackColor = System.Drawing.Color.White;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbChat.Location = new System.Drawing.Point(10, 75);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(420, 280);

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(10, 365);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(330, 25);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);

            // btnSend
            this.btnSend.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(350, 363);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 30);
            this.btnSend.Text = "Gui";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // pnlUsers
            this.pnlUsers.BackColor = System.Drawing.Color.LightGray;
            this.pnlUsers.Controls.Add(this.lblOnlineUsers);
            this.pnlUsers.Controls.Add(this.lstUsers);
            this.pnlUsers.Controls.Add(this.lblSelectedUser);
            this.pnlUsers.Location = new System.Drawing.Point(440, 35);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(150, 360);
            this.pnlUsers.Visible = false;

            // lblOnlineUsers
            this.lblOnlineUsers.AutoSize = true;
            this.lblOnlineUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOnlineUsers.Location = new System.Drawing.Point(10, 10);
            this.lblOnlineUsers.Name = "lblOnlineUsers";
            this.lblOnlineUsers.Size = new System.Drawing.Size(100, 15);
            this.lblOnlineUsers.Text = "Nguoi dung online:";

            // lstUsers
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(10, 30);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(130, 280);
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);

            // lblSelectedUser
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSelectedUser.Location = new System.Drawing.Point(10, 320);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(80, 15);
            this.lblSelectedUser.Text = "";

            // FormChat
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 410);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.pnlChatMode);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.pnlUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.pnlChatMode.ResumeLayout(false);
            this.pnlChatMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
