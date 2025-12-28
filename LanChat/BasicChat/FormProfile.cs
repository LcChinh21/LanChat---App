using BasicChat.Networking;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BasicChat
{
    public partial class FormProfile : Form
    {
        private ClientSocket _client;
        private string _username;
        private string _base64ImageString = "";

        // Truyền ảnh về Form chính sau khi cập nhật thành công
        public Image NewAvatar { get; private set; }

        public FormProfile(ClientSocket client, string username)
        {
            InitializeComponent();

            _client = client;
            _username = username;

            lblUsername.Text = "@" + _username;

            RegisterEvents();

            _client.OnMessageReceived += HandleServerResponse;
        }

        private void RegisterEvents()
        {
            btnClose.Click += (s, e) => this.Close();

            pbAvatar.Click += ChooseImage_Click;

            btnSave.Click += BtnSave_Click;
        }

        private void ChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Title = "Chọn ảnh đại diện"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image originalImg = Image.FromFile(ofd.FileName);

                    Bitmap resizedImg = new Bitmap(originalImg, new Size(150, 150));

                    pbAvatar.Image = resizedImg;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        resizedImg.Save(ms, ImageFormat.Jpeg); // Nén dạng Jpeg cho nhej
                        byte[] imageBytes = ms.ToArray();
                        _base64ImageString = Convert.ToBase64String(imageBytes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc ảnh: " + ex.Message);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_base64ImageString))
            {
                MessageBox.Show("Bạn chưa chọn ảnh mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSave.Enabled = false;
            btnSave.Text = "Đang xử lý...";

            _client.Send(new ChatMessage
            {
                Type = MessageType.UPDATE_PROFILE_REQUEST,
                Sender = _username,
                Content = _base64ImageString
            });
        }

        private void HandleServerResponse(ChatMessage msg)
        {
            if (msg.Type == MessageType.UPDATE_PROFILE_RESPONSE)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btnSave.Enabled = true;
                    btnSave.Text = "LƯU THAY ĐỔI";

                    if (msg.Success)
                    {
                        MessageBox.Show("Cập nhật Avatar thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Lưu ảnh hiện tại vào biến NewAvatar để FormChat lấy dùng
                        NewAvatar = pbAvatar.Image;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cập nhật: " + msg.Content, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _client.OnMessageReceived -= HandleServerResponse;
            base.OnFormClosing(e);
        }
    }
}