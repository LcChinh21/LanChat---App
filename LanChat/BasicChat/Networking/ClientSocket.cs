using System;
using System.Collections.Generic;
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

        private void StartReceiveLoop()
        {
            Task.Run(async () =>
            {
                var buffer = new byte[4096];
                try
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        int len = await _stream.ReadAsync(buffer, 0, buffer.Length, _cts.Token);
                        if (len <= 0) break;

                        string data = Encoding.UTF8.GetString(buffer, 0, len);
                        string[] messages = data.Split(new string[] { "<END>" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string msgStr in messages)
                        {
                            ChatMessage msg = ChatMessage.FromProtocolString(msgStr);
                            if (msg != null)
                            {
                                OnMessageReceived?.Invoke(msg);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!_cts.Token.IsCancellationRequested)
                    {
                        OnDisconnected?.Invoke("Mat ket noi: " + ex.Message);
                    }
                }
            }, _cts.Token);
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
