using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

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

            _masterConnectionString = _connectionString; // giữ cho khỏi lỗi
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
                    string query =
                        "SELECT COUNT(*) FROM Users " +
                        "WHERE Username = @Username AND Password = @Password";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        long count = (long)cmd.ExecuteScalar();
                        _lastError = null;
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

                    string checkQuery =
                        "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        long exists = (long)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            _lastError = "Ten dang nhap da ton tai";
                            return false;
                        }
                    }

                    string insertQuery =
                        "INSERT INTO Users (Username, Password, Email) " +
                        "VALUES (@Username, @Password, @Email)";

                    using (var insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(email) ? DBNull.Value : email);

                        int rows = insertCmd.ExecuteNonQuery();
                        _lastError = null;
                        return rows > 0;
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
                // CHỈ connect thẳng DB hiện có (sql12811813)
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Username VARCHAR(50) NOT NULL UNIQUE,
                    Password VARCHAR(255) NOT NULL,
                    Email VARCHAR(100) NULL
                )";

                    using (var cmd = new MySqlCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                _lastError = null;
                return (true, "Ket noi database thanh cong");
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return (false, $"Loi database: {ex.Message}");
            }

        }
        public string GetConnectionString()
        {
            return _connectionString;
        }
        public Dictionary<string, List<string>> GetAllGroupsWithMembers()
        {
            var result = new Dictionary<string, List<string>>();

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
            return result;
        }

    }
}
