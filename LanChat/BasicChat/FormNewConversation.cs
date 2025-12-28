using BasicChat.Networking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BasicChat
{
    public partial class FormNewConversation : Form
    {
        private ClientSocket _client;
        private Action<ChatMessage> _originalHandler; // Lưu lại handler cũ của FormChat
        private List<string> _allUsers = new List<string>();

        // Property để trả kết quả về cho FormChat
        public string SelectedUser { get; private set; } = null;

        public FormNewConversation(ClientSocket client)
        {
            InitializeComponent();
            _client = client;

            // Đăng ký các sự kiện
            RegisterEvents();

            // Cấu hình mạng để nhận danh sách user
            SetupNetworkHandler();

            // Gửi lệnh xin danh sách user ngay khi mở form
            RequestUserList();
        }

        private void RegisterEvents()
        {
            // Đóng form
            lblClose.Click += (s, e) => this.Close();

            // Tìm kiếm
            txtSearch.TextChanged += TxtSearch_TextChanged;

            // Chọn user trong list
            lstUsers.SelectedIndexChanged += LstUsers_SelectedIndexChanged;
        }

        private void SetupNetworkHandler()
        {
            // 1. Lưu lại handler xử lý tin nhắn hiện tại của FormChat (để không làm mất tính năng chat)
            _originalHandler = _client.OnMessageReceived;

            // 2. Gán handler tạm thời cho Form này
            _client.OnMessageReceived = (msg) =>
            {
                // Vẫn gọi handler cũ để nếu có tin nhắn chat đến thì FormChat vẫn nhận được
                _originalHandler?.Invoke(msg);

                // Xử lý riêng tin nhắn trả về danh sách user
                if (msg.Type == MessageType.GET_ALL_USERS_RESPONSE)
                {
                    this.Invoke(new Action(() =>
                    {
                        // Parse chuỗi danh sách (Ví dụ: "UserA,UserB,UserC")
                        if (!string.IsNullOrEmpty(msg.Content))
                        {
                            _allUsers = msg.Content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            RenderList(_allUsers); // Hiển thị lên ListView
                        }
                    }));
                }
            };
        }

        private void RequestUserList()
        {
            _client.Send(new ChatMessage
            {
                Type = MessageType.GET_ALL_USERS_REQUEST,
                Sender = "ME" // Sender không quan trọng ở request này
            });
        }

        // Hàm vẽ danh sách lên giao diện
        private void RenderList(List<string> users)
        {
            lstUsers.Items.Clear();
            foreach (var user in users)
            {
                var item = new ListViewItem(user);
                // Bạn có thể set ImageIndex ở đây nếu có ImageList icon avatar
                lstUsers.Items.Add(item);
            }
        }

        // Xử lý tìm kiếm
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            // Lọc danh sách gốc
            var filtered = _allUsers.Where(u => u.ToLower().Contains(keyword)).ToList();
            RenderList(filtered);
        }

        // Xử lý khi chọn một người dùng
        private void LstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                // Lấy tên người được chọn
                SelectedUser = lstUsers.SelectedItems[0].Text;

                // Đặt kết quả là OK để FormChat biết
                this.DialogResult = DialogResult.OK;

                // Đóng form
                this.Close();
            }
        }

        // Khi đóng form, phải trả lại quyền điều khiển cho FormChat
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_originalHandler != null)
            {
                _client.OnMessageReceived = _originalHandler;
            }
            base.OnFormClosing(e);
        }
    }
}