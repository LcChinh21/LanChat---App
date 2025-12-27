using BasicChat.Networking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        private Dictionary<string, List<string>> _groups = new Dictionary<string, List<string>>();

        public ServerSocket(int port, Action<string, Color> logAction)
        {
            _port = port;
            _logAction = logAction;
            _clients = new Dictionary<string, ClientInfo>();
            _dbHelper = new DatabaseHelper();

            // Ensure DB tables exist
            _dbHelper.EnsureDatabase();
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
            List<byte> byteBuffer = new List<byte>(); // Dùng List để xử lý nối chuỗi byte an toàn hơn
            byte[] endMarker = Encoding.UTF8.GetBytes("<END>");

            try
            {
                while (_isRunning && clientInfo.TcpClient.Connected)
                {
                    // Giữ nguyên await ReadAsync để không chặn luồng chính
                    int bytesRead = await clientInfo.Stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client ngắt kết nối

                    // Thêm dữ liệu vào buffer tạm
                    for (int i = 0; i < bytesRead; i++) byteBuffer.Add(buffer[i]);

                    // Xử lý tách tin nhắn (cơ chế <END>)
                    while (true)
                    {
                        int endIndex = FindBytes(byteBuffer, endMarker);
                        if (endIndex != -1)
                        {
                            byte[] msgBytes = byteBuffer.Take(endIndex).ToArray();
                            string msgStr = Encoding.UTF8.GetString(msgBytes);

                            // Xóa message cũ khỏi buffer
                            byteBuffer.RemoveRange(0, endIndex + endMarker.Length);

                            var message = ChatMessage.FromProtocolString(msgStr);
                            if (message != null)
                            {
                                // Xử lý logic tin nhắn
                                ProcessMessage(clientInfo, message);
                            }
                        }
                        else
                        {
                            break; // Chưa đủ tin nhắn, đợi đọc tiếp
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logAction($"Lỗi kết nối client: {ex.Message}", Color.Red);
            }
            finally
            {
                // --- QUAN TRỌNG: Luôn chạy vào đây khi client thoát ---
                DisconnectClient(clientInfo);
            }
        }

        // Hàm phụ trợ tìm kiếm byte (để tách tin nhắn)
        private int FindBytes(List<byte> src, byte[] find)
        {
            if (src.Count < find.Length) return -1;
            for (int i = 0; i <= src.Count - find.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < find.Length; j++)
                {
                    if (src[i + j] != find[j]) { match = false; break; }
                }
                if (match) return i;
            }
            return -1;
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

                case MessageType.PRIVATE_MESSAGE:
                    HandlePrivateMessage(clientInfo, message);
                    break;

                case MessageType.GROUP_MESSAGE:
                    HandleGroupMessage(clientInfo, message);
                    break;

                case MessageType.GROUP_JOIN:
                    HandleGroupJoin(clientInfo, message);
                    break;

                case MessageType.GROUP_LEAVE:
                    HandleGroupLeave(clientInfo, message);
                    break;

                case MessageType.CREATE_GROUP_REQUEST:
                    HandleCreateGroup(clientInfo, message);
                    break;

                case MessageType.LOAD_GROUP_REQUEST:
                    HandleLoadGroup(clientInfo);
                    break;

                case MessageType.FILE_SEND:
                    HandleFile(clientInfo, message);
                    break;
                case MessageType.ADD_MEMBER_REQUEST:
                case MessageType.GROUP_INVITE_REQUEST:
                    HandleGroupInvite(clientInfo, message);
                    break;
                case MessageType.SEARCH_USER_REQUEST:
                    HandleSearchUser(clientInfo, message);
                    break;
                case MessageType.HISTORY_REQUEST:
                    HandleHistoryRequest(clientInfo, message);
                    break;
                case MessageType.UPDATE_PROFILE_REQUEST:
                    HandleUpdateProfile(clientInfo, message);
                    break;
                case MessageType.GET_AVATAR_REQUEST:
                    HandleGetAvatar(clientInfo, message);
                    break;
            }
        }

        private void HandleGetAvatar(ClientInfo clientInfo, ChatMessage message)
        {
            string targetUser = string.IsNullOrEmpty(message.Content) ? message.Sender : message.Content;

            string avatarBase64 = _dbHelper.GetUserAvatar(targetUser);

            SendToClient(clientInfo, new ChatMessage
            {
                Type = MessageType.GET_AVATAR_RESPONSE,
                Sender = targetUser,

                Content = avatarBase64,
                Success = !string.IsNullOrEmpty(avatarBase64)
            });
        }

        private void HandleUpdateProfile(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            bool isUpdated = _dbHelper.UpdateUserAvatar(message.Sender, message.Content);

            var response = new ChatMessage
            {
                Type = MessageType.UPDATE_PROFILE_RESPONSE,
                Success = isUpdated,
                Content = isUpdated ? "Cập nhật Avatar thành công!" : ("Lỗi: " + _dbHelper.LastError)
            };

            SendToClient(clientInfo, response);

            if (isUpdated)
            {
                _logAction($"User {message.Sender} updated profile avatar.", Color.Magenta);
            }
        }

        private void HandleGetAllUsers(ClientInfo client)
        {
            if (!client.IsAuthenticated) return;
            var users = _dbHelper.GetAllUsers();
            SendToClient(client, new ChatMessage
            {
                Type = MessageType.GET_ALL_USERS_RESPONSE,
                UserList = users.ToArray()
            });
        }

        private void HandleSearchUser(ClientInfo client, ChatMessage message)
        {
            if (!client.IsAuthenticated) return;
            var users = _dbHelper.SearchUsers(message.Content);
            SendToClient(client, new ChatMessage
            {
                Type = MessageType.SEARCH_USER_RESPONSE,
                UserList = users.ToArray()
            });
        }

        private void HandleHistoryRequest(ClientInfo client, ChatMessage message)
        {
            if (!client.IsAuthenticated) return;

            string target = message.Receiver;
            string mode = message.Content;

            List<ChatMessage> history = null;
            if (mode == "GROUP")
            {
                history = _dbHelper.GetGroupHistory(target);
            }
            else
            {
                history = _dbHelper.GetPrivateHistory(client.Username, target);
            }

            if (history != null && history.Count > 0)
            {
                var response = new ChatMessage
                {
                    Type = MessageType.HISTORY_RESPONSE,
                    Receiver = target,
                    Content = mode,
                    HistoryList = history
                };
                SendToClient(client, response);
                _logAction($"Gui history {mode} cho {client.Username} (target: {target}, count: {history.Count})", Color.Cyan);
            }
        }

        private void HandleLoadGroup(ClientInfo client)
        {
            var allGroups = _dbHelper.GetAllGroupsWithMembers();

            var userGroups = new Dictionary<string, List<string>>();

            foreach (var g in allGroups)
            {
                if (g.Value.Contains(client.Username))
                    userGroups[g.Key] = g.Value;
            }

            SendToClient(client, new ChatMessage
            {
                Type = MessageType.LOAD_GROUP_RESPONSE,
                GroupList = userGroups
            });
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
            // ... (Đoạn code kiểm tra password OK) ...

            // Thêm client vào danh sách quản lý
            lock (_clients)
            {
                _clients[username] = clientInfo;
            }

            clientInfo.Username = username;
            clientInfo.IsAuthenticated = true;
            string allOnlineUsers = string.Join(",", _clients.Keys);
            SendToClient(clientInfo, new ChatMessage
            {
                Type = MessageType.USER_LIST,
                Content = allOnlineUsers
            });
            Broadcast(new ChatMessage
            {
                Type = MessageType.USER_JOINED,
                Content = username
            }); 

            _logAction($"User {username} logged in.", Color.Green);
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
        private void HandleGroupInvite(ClientInfo clientInfo, ChatMessage message)
        {
            if (clientInfo.IsAuthenticated == false)
                return;
            string inviter = message.Sender;
            string invitee = message.Receiver;
            string groupName = message.Content;
            if (!_groups.ContainsKey(groupName))
            {
                var groups = _dbHelper.GetAllGroupsWithMembers();
                if (groups.ContainsKey(groupName))
                {
                    lock (_groups) _groups[groupName] = groups[groupName];
                }
                else
                {
                    SendToClient(clientInfo, new ChatMessage { Type = MessageType.GROUP_INVITE_RESPONSE, Success = false, Content = "Nhom khong ton tai" });
                    return;
                }
            }

            // Add vao DB
            _dbHelper.AddGroupMember(groupName, invitee);

            // Update
            lock (_groups)
            {
                if (!_groups[groupName].Contains(invitee))
                    _groups[groupName].Add(invitee);
            }

            lock (_clients)
            {
                if (_clients.TryGetValue(invitee, out ClientInfo targetClient))
                {
                    ChatMessage inviteMsg = new ChatMessage
                    {
                        Type = MessageType.GROUP_INVITE_REQUEST,
                        Sender = inviter,
                        Receiver = invitee,
                        Content = groupName
                    };
                    SendToClient(targetClient, inviteMsg);

                    var allGroups = _dbHelper.GetAllGroupsWithMembers();
                    var userGroups = new Dictionary<string, List<string>>();
                    foreach (var g in allGroups)
                    {
                        if (g.Value.Contains(invitee))
                            userGroups[g.Key] = g.Value;
                    }

                    SendToClient(targetClient, new ChatMessage
                    {
                        Type = MessageType.LOAD_GROUP_RESPONSE,
                        GroupList = userGroups
                    });

                    var addMemberMsg = new ChatMessage
                    {
                        Type = MessageType.ADD_MEMBER_RESPONSE,
                        Content = groupName,
                        Receiver = invitee
                    };
                    SendToGroup(groupName, addMemberMsg, invitee);
                }
                else
                {
                    SendToClient(clientInfo, new ChatMessage { Type = MessageType.GROUP_INVITE_RESPONSE, Success = true, Content = $"Da them {invitee} vao nhom (Offline)" });
                    return;
                }
            }
            _logAction($"[{groupName}] {inviter} added {invitee} to group", Color.Cyan);
        }


        private void HandleGroupMessage(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated)
                return;

            string groupName = message.Receiver;
            if (string.IsNullOrEmpty(groupName))
                return;

            _dbHelper.SaveMessage(message.Sender, groupName, message.Content, true);

            List<string> members;

            lock (_groups)
            {
                if (!_groups.TryGetValue(groupName, out members))
                {
                    var allGroups = _dbHelper.GetAllGroupsWithMembers();
                    if (!allGroups.TryGetValue(groupName, out members))
                        return;

                    _groups[groupName] = new List<string>(members);
                }
            }

            _logAction(
                $"[Nhom:{groupName}] {message.Sender}: {message.Content}",
                Color.White
            );

            foreach (var username in members)
            {
                if (username == clientInfo.Username)
                    continue;

                if (_clients.TryGetValue(username, out var client))
                {
                    SendToClient(client, new ChatMessage
                    {
                        Type = MessageType.GROUP_MESSAGE,
                        Sender = message.Sender,
                        Receiver = groupName, 
                        Content = message.Content
                    });
                }
            }
        }


        private void HandlePrivateMessage(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;
            string receiver = message.Receiver;
            _logAction($"[Rieng] {message.Sender} -> {receiver}: {message.Content}", Color.Magenta);

            _dbHelper.SaveMessage(message.Sender, message.Receiver, message.Content, false);

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


        private void Broadcast(ChatMessage msg)
        {
            List<ClientInfo> activeClients;

            lock (_clients)
            {
                activeClients = _clients.Values.ToList();
            }

            foreach (var client in activeClients)
            {
                if (client.IsAuthenticated)
                {
                    try
                    {
                        SendToClient(client, msg);
                    }
                    catch
                    {
                        // Nếu lỗi gửi thì bỏ qua
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
        private void SendToGroup(string groupName, ChatMessage msg)
        {
            lock (_groups)
            {
                if (!_groups.TryGetValue(groupName, out var members))
                    return;

                foreach (var username in members)
                {
                    if (_clients.TryGetValue(username, out var client))
                    {
                        SendToClient(client, msg);
                    }
                }
            }
        }

        private void DisconnectClient(ClientInfo client)
        {
            if (client == null) return;

            try { client.Stream?.Close(); } catch { }
            try { client.TcpClient?.Close(); } catch { }

            if (string.IsNullOrEmpty(client.Username)) return;

            lock (_clients)
            {
                if (_clients.ContainsKey(client.Username))
                {
                    _clients.Remove(client.Username);

                    Broadcast(new ChatMessage
                    {
                        Type = MessageType.USER_LEFT,
                        Content = client.Username
                    });

                    _logAction?.Invoke($"User {client.Username} đã ngắt kết nối.", Color.Orange);
                }
            }
        }
        private void HandleCreateGroup(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            string groupName = message.Content?.Trim();

            if (string.IsNullOrEmpty(groupName))
            {
                SendToClient(clientInfo, new ChatMessage { Type = MessageType.CREATE_GROUP_RESPONSE, Success = false, Content = "Ten nhom khong hop le" });
                return;
            }

            lock (_groups)
            {
                if (_groups.ContainsKey(groupName))
                {
                    SendToClient(clientInfo, new ChatMessage { Type = MessageType.CREATE_GROUP_RESPONSE, Success = false, Content = "Nhom da ton tai" });
                    return;
                }
                _groups[groupName] = new List<string> { clientInfo.Username };
            }

            try
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(_dbHelper.GetConnectionString()))
                {
                    conn.Open();
                    var cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO ChatGroups (GroupName, CreatedBy) VALUES (@name, @by)", conn);
                    cmd.Parameters.AddWithValue("@name", groupName);
                    cmd.Parameters.AddWithValue("@by", clientInfo.Username);
                    cmd.ExecuteNonQuery();

                    var joinCmd = new MySql.Data.MySqlClient.MySqlCommand(@"INSERT INTO GroupMembers (GroupId, UserName) VALUES (LAST_INSERT_ID(), @user)", conn);
                    joinCmd.Parameters.AddWithValue("@user", clientInfo.Username);
                    joinCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SendToClient(clientInfo, new ChatMessage { Type = MessageType.CREATE_GROUP_RESPONSE, Success = false, Content = "Loi DB: " + ex.Message });
                return;
            }

            SendToClient(clientInfo, new ChatMessage { Type = MessageType.CREATE_GROUP_RESPONSE, Success = true, Content = groupName });
        }

        private void HandleGroupJoin(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            string groupName = message.Receiver;
            if (string.IsNullOrEmpty(groupName)) return;

            _dbHelper.AddGroupMember(groupName, clientInfo.Username);

            lock (_groups)
            {
                if (!_groups.ContainsKey(groupName))
                    _groups[groupName] = new List<string>();

                if (!_groups[groupName].Contains(clientInfo.Username))
                    _groups[groupName].Add(clientInfo.Username);
            }

            _logAction($"{clientInfo.Username} joined group {groupName}", Color.LightGreen);
        }

        private void HandleGroupLeave(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            string groupName = message.Receiver;
            if (string.IsNullOrEmpty(groupName)) return;

            lock (_groups)
            {
                if (_groups.TryGetValue(groupName, out var members))
                {
                    members.Remove(clientInfo.Username);
                    if (members.Count == 0) _groups.Remove(groupName);
                }
            }
            var leaveAck = new ChatMessage { Type = MessageType.GROUP_LEAVE, Success = true, Receiver = groupName };
            SendToClient(clientInfo, leaveAck);

            var leaveNotify = new ChatMessage { Type = MessageType.GROUP_REMOVE_MEMBER, Sender = clientInfo.Username, Receiver = groupName };
            SendToGroup(groupName, leaveNotify);

            _logAction($"{clientInfo.Username} left group {groupName}", Color.Orange);
        }

        private void HandleFile(ClientInfo clientInfo, ChatMessage message)
        {
            if (!clientInfo.IsAuthenticated) return;

            bool isGroup = false;
            lock (_groups)
            {
                if (_groups.ContainsKey(message.Receiver)) isGroup = true;
            }

            if (isGroup)
            {
                _logAction($"[File Group: {message.Receiver}] {message.Sender} gui file.", Color.Cyan);
                SendToGroup(message.Receiver, message, clientInfo.Username);
            }
            else
            {
                _logAction($"[File Private] {message.Sender} -> {message.Receiver}", Color.Cyan);
                lock (_clients)
                {
                    if (_clients.TryGetValue(message.Receiver, out ClientInfo targetClient))
                    {
                        SendToClient(targetClient, message);
                    }
                }
            }
        }

        private void SendToGroup(string groupName, ChatMessage msg, string excludeUser)
        {
            lock (_groups)
            {
                if (!_groups.TryGetValue(groupName, out var members))
                    return;

                foreach (var username in members)
                {
                    if (username != excludeUser && _clients.TryGetValue(username, out var client))
                    {
                        SendToClient(client, msg);
                    }
                }
            }
        }
    }
}