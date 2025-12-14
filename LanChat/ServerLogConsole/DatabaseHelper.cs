using System;
using MySql.Data.MySqlClient;

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
                using (var masterConn = new MySqlConnection(_masterConnectionString))
                {
                    masterConn.Open();

                    string checkDbQuery =
                        "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LanChatDB'";

                    using (var checkCmd = new MySqlCommand(checkDbQuery, masterConn))
                    {
                        var result = checkCmd.ExecuteScalar();
                        if (result == null)
                        {
                            string createDbQuery = "CREATE DATABASE LanChatDB";
                            using (var createCmd = new MySqlCommand(createDbQuery, masterConn))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

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
    }
}
