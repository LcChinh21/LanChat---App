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

        public HashSet<string> OnlineUsers { get; private set; } = new HashSet<string>();
        public Action OnUserListChanged { get; set; }
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


        private void StartReceiveLoop()
        {
            Task.Run(async () =>
            {
                var buffer = new byte[4096];
                var byteBuffer = new List<byte>();
                byte[] endMarker = Encoding.UTF8.GetBytes("<END>");

                try
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        if (_stream == null) break;

                        int len = await _stream.ReadAsync(buffer, 0, buffer.Length, _cts.Token);
                        if (len <= 0) break;

                        for (int i = 0; i < len; i++)
                        {
                            byteBuffer.Add(buffer[i]);
                        }

                        while (true)
                        {
                            int endIndex = FindBytes(byteBuffer, endMarker);

                            if (endIndex != -1)
                            {
                                byte[] msgBytes = byteBuffer.Take(endIndex).ToArray();
                                string msgStr = Encoding.UTF8.GetString(msgBytes);

                                byteBuffer.RemoveRange(0, endIndex + endMarker.Length);

                                var msg = ChatMessage.FromProtocolString(msgStr);
                                if (msg != null)
                                {
                                    switch (msg.Type)
                                    {
                                        case MessageType.USER_LIST:
                                            var users = msg.Content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                            OnlineUsers.Clear();
                                            foreach (var u in users) OnlineUsers.Add(u);
                                            OnUserListChanged?.Invoke();
                                            break;

                                        case MessageType.USER_JOINED:
                                            if (!OnlineUsers.Contains(msg.Content))
                                            {
                                                OnlineUsers.Add(msg.Content);
                                                OnUserListChanged?.Invoke();
                                            }
                                            break;

                                        case MessageType.USER_LEFT:
                                            if (OnlineUsers.Contains(msg.Content))
                                            {
                                                OnlineUsers.Remove(msg.Content);
                                                OnUserListChanged?.Invoke();
                                            }
                                            break;
                                    }
                                    OnMessageReceived?.Invoke(msg);
                                }
                            }
                            else
                            {
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
