
using BasicChat.Networking;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ServerLogConsole
{
    public class DatabaseHelper
    {
        private string _connectionString;
        private string _masterConnectionString;
        private string _lastError;

        public string LastError => _lastError;

        public DatabaseHelper()
        {
            _connectionString =
                "Server=lanchat-mysql-lanchat.k.aivencloud.com;" +
                "Database=LanChatDB;" +
                "User=avnadmin;" +
                "Password=AVNS_5ytzbDnRb1mZrHTALwZ;" +
                "Port=15478;";

            _masterConnectionString = _connectionString;
        }

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
            _masterConnectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    _lastError = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return false;
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _lastError = $"Loi kiem tra dang nhap: {ex.Message}";
                return false;
            }
        }

        public bool RegisterUser(string username, string password, string email = "")
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        if ((long)checkCmd.ExecuteScalar() > 0)
                        {
                            _lastError = "Ten dang nhap da ton tai";
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                    using (var insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? DBNull.Value : email);
                        return insertCmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _lastError = $"Loi dang ky: {ex.Message}";
                return false;
            }
        }

        public (bool success, string message) EnsureDatabase()
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string createUsers = @"CREATE TABLE IF NOT EXISTS Users (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Username VARCHAR(50) NOT NULL UNIQUE,
                        Password VARCHAR(255) NOT NULL,
                        Email VARCHAR(100) NULL
                    )";
                    using (var cmd = new MySqlCommand(createUsers, conn)) cmd.ExecuteNonQuery();

                    string createMessages = @"CREATE TABLE IF NOT EXISTS Messages (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Sender VARCHAR(50) NOT NULL,
                        Receiver VARCHAR(50) NOT NULL,
                        Content TEXT,
                        IsGroup BIT,
                        CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                    )";
                    using (var cmd = new MySqlCommand(createMessages, conn)) cmd.ExecuteNonQuery();
                }
                return (true, "Ket noi database thanh cong");
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return (false, $"Loi database: {ex.Message}");
            }
        }

        public string GetConnectionString() => _connectionString;

        public Dictionary<string, List<string>> GetAllGroupsWithMembers()
        {
            var result = new Dictionary<string, List<string>>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                    SELECT g.GroupName, gm.UserName
                    FROM ChatGroups g
                    LEFT JOIN GroupMembers gm ON g.GroupId = gm.GroupId
                    ORDER BY g.GroupName", conn);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            string group = rd.GetString("GroupName");
                            string user = rd.IsDBNull("UserName") ? null : rd.GetString("UserName");

                            if (!result.ContainsKey(group))
                                result[group] = new List<string>();

                            if (!string.IsNullOrEmpty(user))
                                result[group].Add(user);
                        }
                    }
                }
            }
            catch { }
            return result;
        }

        public bool UpdateUserAvatar(string username, string base64Avatar)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET Avatar = @avatar WHERE Username = @user";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@avatar", base64Avatar);
                        cmd.Parameters.AddWithValue("@user", username);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return false;
            }
        }

        public string GetUserAvatar(string username)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT Avatar FROM Users WHERE Username = @user";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch { }
            return "";
        }

        public bool AddGroupMember(string groupName, string username)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmdGetId = new MySqlCommand("SELECT GroupId FROM ChatGroups WHERE GroupName=@name", conn);
                    cmdGetId.Parameters.AddWithValue("@name", groupName);
                    object idObj = cmdGetId.ExecuteScalar();
                    if (idObj == null) return false;

                    int groupId = Convert.ToInt32(idObj);

                    var cmdCheck = new MySqlCommand("SELECT COUNT(*) FROM GroupMembers WHERE GroupId=@gid AND UserName=@user", conn);
                    cmdCheck.Parameters.AddWithValue("@gid", groupId);
                    cmdCheck.Parameters.AddWithValue("@user", username);
                    if ((long)cmdCheck.ExecuteScalar() > 0) return true;

                    var cmdInsert = new MySqlCommand("INSERT INTO GroupMembers (GroupId, UserName) VALUES (@gid, @user)", conn);
                    cmdInsert.Parameters.AddWithValue("@gid", groupId);
                    cmdInsert.Parameters.AddWithValue("@user", username);
                    cmdInsert.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return false;
            }
        }

        // Trong DatabaseHelper.cs
        // Trong DatabaseHelper.cs

        public void SaveMessage(string sender, string receiver, string content, bool isGroup)
        {
            // Debug: In ra để xem dữ liệu đầu vào có đúng không
            Console.WriteLine($"[DB START] Save: {sender} -> {receiver} (Group: {isGroup}) | Len: {content?.Length}");

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "";

                    if (isGroup)
                    {
                        // Bảng Messages (Lưu ý tên cột phải khớp với Bước 1)
                        query = "INSERT INTO Messages (Sender, GroupName, Content, SentTime) VALUES (@s, @r, @c, NOW())";
                    }
                    else
                    {
                        // Bảng PrivateMessages
                        query = "INSERT INTO PrivateMessages (Sender, Receiver, Content, SentTime) VALUES (@s, @r, @c, NOW())";
                    }

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", sender);
                        cmd.Parameters.AddWithValue("@r", receiver);
                        cmd.Parameters.AddWithValue("@c", content);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            Console.WriteLine("[DB SUCCESS] Đã lưu thành công!");
                        else
                            Console.WriteLine("[DB WARNING] Lệnh chạy nhưng không lưu dòng nào.");
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                // Lỗi liên quan đến SQL (sai tên bảng, sai cú pháp, packet quá lớn)
                Console.WriteLine($"[SQL ERROR] Mã lỗi: {sqlEx.Number} - {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Lỗi khác (kết nối mạng, v.v.)
                Console.WriteLine($"[SYSTEM ERROR] {ex.Message}");
            }
        }

        // Trong DatabaseHelper.cs

        public List<ChatMessage> GetGroupHistory(string groupName)
        {
            var list = new List<ChatMessage>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    // [QUAN TRỌNG] Đọc từ bảng 'Messages' (nơi bạn đang lưu tin nhóm)
                    // Lấy 50 tin nhắn gần nhất
                    string query = "SELECT Sender, Content, SentTime FROM Messages WHERE GroupName = @g ORDER BY SentTime ASC LIMIT 50";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@g", groupName);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                // Tạo object ChatMessage để trả về
                                var msg = new ChatMessage
                                {
                                    Type = MessageType.GROUP_MESSAGE, // Đánh dấu là tin nhóm
                                    Sender = r.GetString("Sender"),
                                    Receiver = groupName,
                                    Content = r.GetString("Content"), // Lấy nội dung gốc (Text hoặc Base64 file)
                                    Timestamp = r.GetDateTime("SentTime")
                                };
                                list.Add(msg);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetGroupHistory: " + ex.Message);
            }
            return list;
        }

        // Lấy lịch sử tin nhắn riêng giữa user1 và user2
        // Trong DatabaseHelper.cs

        // Trong DatabaseHelper.cs

        public List<string> GetRecentChatUsers(string currentUser)
        {
            var list = new List<string>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    // Câu lệnh SQL "thần thánh":
                    // 1. Lấy người nhận (nếu mình là người gửi)
                    // 2. Lấy người gửi (nếu mình là người nhận)
                    // 3. Dùng UNION để gộp lại và loại bỏ trùng lặp (DISTINCT)
                    string query = @"
                SELECT DISTINCT Receiver AS ContactName FROM PrivateMessages WHERE Sender = @me
                UNION
                SELECT DISTINCT Sender AS ContactName FROM PrivateMessages WHERE Receiver = @me";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@me", currentUser);

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                list.Add(r.GetString("ContactName"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetRecentChatUsers: " + ex.Message);
            }
            return list;
        }
        // Trong DatabaseHelper.cs

        public List<ChatMessage> GetPrivateHistory(string user1, string user2)
        {
            var list = new List<ChatMessage>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    // Lấy tin nhắn 2 chiều: (Tôi gửi cho Bạn) HOẶC (Bạn gửi cho Tôi)
                    // Sắp xếp theo thời gian tăng dần (Cũ nhất -> Mới nhất)
                    string query = @"
                SELECT Sender, Content, SentTime 
                FROM PrivateMessages 
                WHERE (Sender = @u1 AND Receiver = @u2) 
                   OR (Sender = @u2 AND Receiver = @u1)
                ORDER BY SentTime ASC LIMIT 50";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u1", user1);
                        cmd.Parameters.AddWithValue("@u2", user2);

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                list.Add(new ChatMessage
                                {
                                    Type = MessageType.PRIVATE_MESSAGE,
                                    Sender = r.GetString("Sender"),
                                    Receiver = user2, // (Tạm để user2, Client sẽ tự check isMe)
                                    Content = r.GetString("Content"),
                                    Timestamp = r.GetDateTime("SentTime")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetPrivateHistory: " + ex.Message);
            }
            return list;
        }

        // Trong DatabaseHelper.cs

        public List<string> GetAllUsers()
        {
            var list = new List<string>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username FROM Users"; // Lấy hết username
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(r.GetString("Username"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAllUsers: " + ex.Message);
            }
            return list;
        }

        public List<string> SearchUsers(string keyword)
        {
            var list = new List<string>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username FROM Users WHERE Username LIKE @k ORDER BY Username LIMIT 20";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read()) list.Add(r.GetString("Username"));
                        }
                    }
                }
            }
            catch { }
            return list;
        }
        public bool IsGroupExists(string groupName)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    // Kiểm tra trong bảng chứa thành viên nhóm (GroupMembers) hoặc bảng danh sách nhóm (Groups)
                    // Giả sử bạn có bảng GroupMembers (lưu ai thuộc nhóm nào)
                    string query = "SELECT COUNT(*) FROM GroupMembers WHERE GroupName = @g";

                    // HOẶC nếu bạn không có bảng GroupMembers mà chỉ có bảng Messages:
                    // string query = "SELECT COUNT(*) FROM Messages WHERE GroupName = @g"; 

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@g", groupName);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        // Trong DatabaseHelper.cs

        public bool IsUserExisting(string username)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    // Kiểm tra trong bảng Users xem có ai tên như vậy không
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @u";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
    // Trong DatabaseHelper.cs
    

}
