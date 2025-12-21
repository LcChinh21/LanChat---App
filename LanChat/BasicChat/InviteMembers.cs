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
        private Action<ChatMessage> _originalHandler;

        public InviteMembers(ClientSocket client, ChatMessage msg, List<string> groupmembers)
        {
            InitializeComponent();
            lstOnlineUsers.View = View.List;
            _client = client;
            message = msg;
            this.groupmembers = groupmembers;

            // Chain handler for search response
            _originalHandler = _client.OnMessageReceived;
            _client.OnMessageReceived = (m) =>
            {
                _originalHandler?.Invoke(m);
                if (m.Type == MessageType.SEARCH_USER_RESPONSE)
                {
                    this.Invoke(new Action(() =>
                    {
                        lstOnlineUsers.BeginUpdate();
                        lstOnlineUsers.Items.Clear();
                        if (m.UserList != null)
                        {
                            foreach (var u in m.UserList)
                            {
                                if (!this.groupmembers.Contains(u))
                                    lstOnlineUsers.Items.Add(u);
                            }
                        }
                        lstOnlineUsers.EndUpdate();
                    }));
                }
            };

            foreach (var user in _client.OnlineUsers)
            {
                if (!groupmembers.Contains(user))
                    lstOnlineUsers.Items.Add(user);
            }
            lstOnlineUsers.Width = 475;

            btnAdd.Visible = false;
        }

        private void lstOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOnlineUsers.SelectedItems.Count > 0)
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
                Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                lstOnlineUsers.BeginUpdate();
                lstOnlineUsers.Items.Clear();
                foreach (var user in _client.OnlineUsers)
                {
                    if (!groupmembers.Contains(user))
                        lstOnlineUsers.Items.Add(user);
                }
                lstOnlineUsers.EndUpdate();
            }
            else
            {
                _client.Send(new ChatMessage { Type = MessageType.SEARCH_USER_REQUEST, Content = keyword });
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore original handler
            if (_originalHandler != null)
                _client.OnMessageReceived = _originalHandler;
            base.OnFormClosing(e);
        }
    }
}
