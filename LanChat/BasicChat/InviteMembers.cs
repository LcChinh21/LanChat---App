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
        private List<string> groupmembers = new List<string>();
        public string GroupName { get; private set; }
        public InviteMembers(ClientSocket client, ChatMessage msg, List<string> groupmembers)
        {
            InitializeComponent();
            _client = client;
            message = msg;
            foreach (var user in _client.OnlineUsers)
            {
                lstOnlineUsers.Items.Add(user);
                lstOnlineUsers.Width = 475;
            }
            for (int i = lstOnlineUsers.Items.Count - 1; i >= 0; i--)
            {
                if (groupmembers.Contains(lstOnlineUsers.Items[i].Text))
                    lstOnlineUsers.Items.RemoveAt(i);
            }
            btnAdd.Visible = false;
            this.groupmembers = groupmembers;
        }

        private void lstOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstOnlineUsers.SelectedItems.Count > 0)
            {
                btnAdd.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstOnlineUsers.SelectedItems.Count <= 0) return;
            else
            {
                foreach (var user in lstOnlineUsers.SelectedItems)
                {
                    string selectedUser = user.ToString();
                    var inviteMsg = new ChatMessage
                    {
                        Type = MessageType.GROUP_INVITE_REQUEST,
                        Sender = message.Sender,
                        Receiver = selectedUser,
                        Content = message.Content
                    };
                    _client.Send(inviteMsg);
                }
                //thêm hàm
                Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstOnlineUsers.BeginUpdate();
            lstOnlineUsers.Items.Clear();
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                foreach (var user in groupmembers)
                {
                    lstOnlineUsers.Items.Add(user);
                }
            }
            else
            {
                keyword = keyword.ToLower();
                foreach (var user in groupmembers)
                {
                    if (user.ToLower().Contains(keyword))
                    {
                        lstOnlineUsers.Items.Add(user);
                    }
                }
            }
            lstOnlineUsers.EndUpdate();
        }
    }
}
