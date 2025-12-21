using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicChat.Networking
{
    public class ClientSocket
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;
        private readonly object _streamLock = new object();

        public Action<ChatMessage> OnMessageReceived { get; set; }
        public Action<string> OnDisconnected { get; set; }
        public Action<string> OnError { get; set; }
        public bool IsConnected => _client != null && _client.Connected;
        public List<string> OnlineUsers { get; set; }
        public async Task<bool> ConnectAsync(string ip, int port)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ip, port);
                _stream = _client.GetStream();
                _cts = new CancellationTokenSource();
                StartReceiveLoop();
                return true;
            }
            catch (Exception ex)
            {
                OnError?.Invoke("Khong the ket noi: " + ex.Message);
                return false;
            }
        }

        private StringBuilder _receiveBuffer = new StringBuilder();

        // Thay thế hàm StartReceiveLoop cũ bằng hàm này
        private void StartReceiveLoop()
        {
            Task.Run(async () =>
            {
                var buffer = new byte[4096];
                var byteBuffer = new List<byte>(); // Dùng List<byte> thay vì StringBuilder

                // Chuỗi đánh dấu kết thúc tin nhắn
                byte[] endMarker = Encoding.UTF8.GetBytes("<END>");

                try
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        if (_stream == null) break;

                        int len = await _stream.ReadAsync(buffer, 0, buffer.Length, _cts.Token);
                        if (len <= 0) break;

                        // Thêm dữ liệu mới nhận vào buffer tạm
                        for (int i = 0; i < len; i++)
                        {
                            byteBuffer.Add(buffer[i]);
                        }

                        // Xử lý tách tin nhắn dựa trên <END>
                        while (true)
                        {
                            int endIndex = FindBytes(byteBuffer, endMarker);

                            if (endIndex != -1)
                            {
                                // Tìm thấy <END>, trích xuất tin nhắn
                                // Lấy từ đầu đến trước <END>
                                byte[] msgBytes = byteBuffer.Take(endIndex).ToArray();
                                string msgStr = Encoding.UTF8.GetString(msgBytes);

                                // Xóa tin nhắn đã xử lý và marker <END> khỏi buffer
                                byteBuffer.RemoveRange(0, endIndex + endMarker.Length);

                                // Xử lý tin nhắn
                                var msg = ChatMessage.FromProtocolString(msgStr);
                                if (msg != null)
                                {
                                    OnMessageReceived?.Invoke(msg);
                                }
                            }
                            else
                            {
                                // Chưa nhận đủ tin nhắn (chưa có <END>), đợi nhận tiếp
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!_cts.Token.IsCancellationRequested)
                        OnDisconnected?.Invoke("Mất kết nối: " + ex.Message);
                }
            }, _cts.Token);
        }

        // Hàm hỗ trợ tìm chuỗi byte
        private int FindBytes(List<byte> src, byte[] find)
        {
            if (src.Count < find.Length) return -1;

            for (int i = 0; i <= src.Count - find.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < find.Length; j++)
                {
                    if (src[i + j] != find[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return i;
            }
            return -1;
        }

        public void Send(ChatMessage message)
        {
            lock (_streamLock)
            {
                if (_stream == null || !_stream.CanWrite) return;

                string data = message.ToProtocolString() + "<END>";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                _stream.Write(bytes, 0, bytes.Length);
            }
        }

        public void Disconnect()
        {
            _cts?.Cancel();
            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }
        }
    }
}
