using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using BasicChat.Networking;

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
                "Server=sql12.freesqldatabase.com;" +
                "Database=sql12811813;" +
                "User=sql12811813;" +
                "Password=CcqIIHHKaH;" +
                "Port=3306;";

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

        public void SaveMessage(string sender, string receiver, string content, bool isGroup)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO Messages (Sender, Receiver, Content, IsGroup, CreatedAt) VALUES (@s, @r, @c, @g, @t)", conn);
                    cmd.Parameters.AddWithValue("@s", sender);
                    cmd.Parameters.AddWithValue("@r", receiver);
                    cmd.Parameters.AddWithValue("@c", content);
                    cmd.Parameters.AddWithValue("@g", isGroup ? 1 : 0);
                    cmd.Parameters.AddWithValue("@t", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { _lastError = ex.Message; }
        }

        public List<ChatMessage> GetGroupHistory(string groupName)
        {
            var list = new List<ChatMessage>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT Sender, Content, CreatedAt FROM Messages WHERE Receiver=@r AND IsGroup=1 ORDER BY CreatedAt ASC LIMIT 50", conn);
                    cmd.Parameters.AddWithValue("@r", groupName);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ChatMessage
                            {
                                Sender = r.GetString("Sender"),
                                Content = r.GetString("Content"),
                                Timestamp = r.GetDateTime("CreatedAt"),
                                Type = MessageType.GROUP_MESSAGE
                            });
                        }
                    }
                }
            }
            catch { }
            return list;
        }

        public List<ChatMessage> GetPrivateHistory(string user1, string user2)
        {
            var list = new List<ChatMessage>();
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT Sender, Receiver, Content, CreatedAt FROM Messages WHERE IsGroup=0 AND " +
                        "((Sender=@u1 AND Receiver=@u2) OR (Sender=@u2 AND Receiver=@u1)) " +
                        "ORDER BY CreatedAt ASC LIMIT 50", conn);
                    cmd.Parameters.AddWithValue("@u1", user1);
                    cmd.Parameters.AddWithValue("@u2", user2);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ChatMessage
                            {
                                Sender = r.GetString("Sender"),
                                Receiver = r.GetString("Receiver"),
                                Content = r.GetString("Content"),
                                Timestamp = r.GetDateTime("CreatedAt"),
                                Type = MessageType.PRIVATE_MESSAGE
                            });
                        }
                    }
                }
            }
            catch { }
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
    }
}
