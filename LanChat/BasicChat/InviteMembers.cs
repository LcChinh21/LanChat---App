using BasicChat.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicChat
{
    public partial class InviteMembers : Form
    {
        private ClientSocket _client;
        private ChatMessage message;
        public InviteMembers(ClientSocket client, ChatMessage msg)
        {
            InitializeComponent();
            _client = client;
            message = msg;
            foreach (var user in _client.OnlineUsers)
            {
                lstOnlineUsers.Items.Add(user);
            }
        }

        private void lstOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstOnlineUsers.SelectedItems.Count > 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(lstOnlineUsers.SelectedItems.Count > 0)
            {
                foreach(var user in lstOnlineUsers.SelectedItems)
                {
                    string selectedUser = user.ToString();
                    var inviteMsg = new ChatMessage
                    {
                        Type = MessageType.GROUP_INVITE_REQUEST,
                        Sender = message.Sender,
                        Receiver = message.Receiver,
                        Content = message.Content
                    };
                    _client.Send(inviteMsg);
                }
                MessageBox.Show("Da gui loi moi tham gia nhom den cac thanh vien duoc chon.");
                Close();
            }
        }
    }
}
