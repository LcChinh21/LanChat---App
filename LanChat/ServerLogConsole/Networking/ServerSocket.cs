using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogConsole.Networking
{
    public class ClientInfo
    {
        public TcpClient TcpClient { get; set; }
        public NetworkStream Stream { get; set; }
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
    }

    public class ServerSocket
    {
        private TcpListener _listener;
        private int _port;
        private bool _isRunning;
        private Dictionary<string, ClientInfo> _clients;
        private Action<string, Color> _logAction;
        private DatabaseHelper _dbHelper;

        public ServerSocket(int port, Action<string, Color> logAction)
        {
            _port = port;
            _logAction = logAction;
            _clients = new Dictionary<string, ClientInfo>();
            _dbHelper = new DatabaseHelper();
        }

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            _isRunning = true;

            Task.Run(() => AcceptClients());
        }

        public void Stop()
        {
            _isRunning = false;
            _listener?.Stop();

            lock (_clients)
            {
                foreach (var client in _clients.Values)
                {
                    try
                    {
                        client.TcpClient?.Close();
                    }
                    catch { }
                }
                _clients.Clear();
            }
        }

        private async Task AcceptClients()
        {
            while (_isRunning)
            {
                try
                {
                    var tcpClient = await _listener.AcceptTcpClientAsync();
                    _logAction($"Ket noi moi tu: {tcpClient.Client.RemoteEndPoint}", Color.Cyan);

                    var clientInfo = new ClientInfo
                    {
                        TcpClient = tcpClient,
                        Stream = tcpClient.GetStream(),
                        IsAuthenticated = false
                    };

                    Task.Run(() => HandleClient(clientInfo));
                }
                catch (Exception ex)
                {
                    if (_isRunning)
                    {
                        _logAction($"Loi accept: {ex.Message}", Color.Red);
                    }
                }
            }
        }

        private async Task HandleClient(ClientInfo clientInfo)
        {
            byte[] buffer = new byte[4096];
            StringBuilder messageBuffer = new StringBuilder();

            try
            {
                while (_isRunning && clientInfo.TcpClient.Connected)
                {
                    int bytesRead = await clientInfo.Stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    messageBuffer.Append(data);

                    string fullData = messageBuffer.ToString();
                    string[] messages = fullData.Split(new string[] { "<END>" }, StringSplitOptions.RemoveEmptyEntries);

                    messageBuffer.Clear();
                    if (!fullData.EndsWith("<END>") && messages.Length > 0)
                    {
                        messageBuffer.Append(messages[messages.Length - 1]);
                        messages = messages.Take(messages.Length - 1).ToArray();
                    }

                    foreach (string msgStr in messages)
                    {
                        var message = ChatMessage.FromProtocolString(msgStr.Trim());
                        if (message != null)
                        {
                            ProcessMessage(clientInfo, message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logAction($"Loi xu ly client: {ex.Message}", Color.Red);
            }
            finally
            {
                DisconnectClient(clientInfo);
            }
        }

        private void ProcessMessage(ClientInfo clientInfo, ChatMessage message)
        {
            switch (message.Type)
            {
                case MessageType.LOGIN_REQUEST:
                    HandleLogin(clientInfo, message);
                    break;

                case MessageType.REGISTER_REQUEST:
                    HandleRegister(clientInfo, message);
                    break;

                case MessageType.GROUP_MESSAGE:
                    HandleGroupMessage(clientInfo, message);
                    break;

                case MessageType.PRIVATE_MESSAGE:
                    HandlePrivateMessage(clientInfo, message);
                    break;
            }
        }

        private void HandleLogin(ClientInfo clientInfo, ChatMessage message)
        {
            string username = message.Sender;
            string password = message.Content;

            _logAction($"Yeu cau dang nhap: {username}", Color.Yellow);

            bool success = _dbHelper.ValidateLogin(username, password);
            var response = new ChatMessage
            {
                Type = MessageType.LOGIN_RESPONSE,
                Success = success,
                Content = success ? "Dang nhap thanh cong" : "Sai ten dang nhap hoac mat khau"
            };

            SendToClient(clientInfo, response);

            if (success)
            {
                clientInfo.Username = username;
                clientInfo.IsAuthenticated = true;

                lock (_clients)
                {
                    if (_clients.ContainsKey(username))
                    {
                        _clients[username].TcpClient?.Close();
                        _clients.Remove(username);
                    }
                    _clients[username] = clientInfo;
                }

                _logAction($"[OK] {username} da dang nhap thanh cong", Color.Green);

                var joinMsg = new ChatMessage
                {
                    Type = MessageType.USER_JOINED,
                    Sender = username
                };
                BroadcastExcept(joinMsg, username);

                BroadcastUserList();
            }
            else
            {
                _logAction($"[FAIL] {username} dang nhap that bai", Color.Red);
            }
        }

        private void HandleRegister(ClientInfo clientInfo, ChatMessage message)
        {
            string username = message.Sender;
            string password = message.Content;
            string email = message.Receiver;

            _logAction($"Yeu cau dang ky: {username} (Email: {email})", Color.Yellow);

            bool success = _dbHelper.RegisterUser(username, password, email);
            var response = new ChatMessage
            {
                Type = MessageType.REGISTER_RESPONSE,
                Success = success,
                Content = success ? "Dang ky thanh cong" : "Ten dang nhap da ton tai"
            };

            SendToClient(clientInfo, response);

            if (success)
            {
                _logAction($"[OK] Dang ky thanh cong: {username}", Color.Green);
            }
            else
            {
                _logAction($"[FAIL] Dang ky that bai: {username} - {_dbHelper.LastError}", Color.Red);
            }
        }

        private void HandleGroupMessage(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            _logAction($"[Nhom] {message.Sender}: {message.Content}", Color.White);

            BroadcastExcept(message, clientInfo.Username);
        }

        private void HandlePrivateMessage(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            string receiver = message.Receiver;
            _logAction($"[Rieng] {message.Sender} -> {receiver}: {message.Content}", Color.Magenta);

            lock (_clients)
            {
                if (_clients.TryGetValue(receiver, out ClientInfo targetClient))
                {
                    SendToClient(targetClient, message);
                }
                else
                {
                    var errorMsg = new ChatMessage
                    {
                        Type = MessageType.PRIVATE_MESSAGE,
                        Sender = "He thong",
                        Content = $"Nguoi dung {receiver} khong online"
                    };
                    SendToClient(clientInfo, errorMsg);
                }
            }
        }

        private void BroadcastUserList()
        {
            string[] userList;
            lock (_clients)
            {
                userList = _clients.Keys.ToArray();
            }

            var message = new ChatMessage
            {
                Type = MessageType.USER_LIST,
                UserList = userList
            };

            Broadcast(message);
        }

        private void Broadcast(ChatMessage message)
        {
            lock (_clients)
            {
                foreach (var client in _clients.Values)
                {
                    if (client.IsAuthenticated)
                    {
                        SendToClient(client, message);
                    }
                }
            }
        }

        private void BroadcastExcept(ChatMessage message, string exceptUsername)
        {
            lock (_clients)
            {
                foreach (var kvp in _clients)
                {
                    if (kvp.Key != exceptUsername && kvp.Value.IsAuthenticated)
                    {
                        SendToClient(kvp.Value, message);
                    }
                }
            }
        }

        private void SendToClient(ClientInfo client, ChatMessage message)
        {
            try
            {
                string data = message.ToProtocolString() + "<END>";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                client.Stream.Write(bytes, 0, bytes.Length);
                client.Stream.Flush();
            }
            catch (Exception ex)
            {
                _logAction($"Loi gui tin nhan: {ex.Message}", Color.Red);
            }
        }

        private void DisconnectClient(ClientInfo clientInfo)
        {
            try
            {
                clientInfo.TcpClient?.Close();
            }
            catch { }

            if (!string.IsNullOrEmpty(clientInfo.Username))
            {
                lock (_clients)
                {
                    if (_clients.ContainsKey(clientInfo.Username))
                    {
                        _clients.Remove(clientInfo.Username);
                    }
                }

                _logAction($"{clientInfo.Username} da ngat ket noi", Color.Orange);

                var leftMsg = new ChatMessage
                {
                    Type = MessageType.USER_LEFT,
                    Sender = clientInfo.Username
                };
                Broadcast(leftMsg);

                BroadcastUserList();
            }
        }
    }
}
