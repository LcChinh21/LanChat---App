using System;
using System.Data.SqlClient;

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
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=LanChatDB;Integrated Security=True;Connect Timeout=5";
            _masterConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Connect Timeout=5";
        }

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
            int idx = connectionString.IndexOf("Initial Catalog=");
            if (idx >= 0)
            {
                _masterConnectionString = connectionString.Substring(0, idx) + "Initial Catalog=master;" + 
                    connectionString.Substring(connectionString.IndexOf(";", idx) + 1);
            }
            else
            {
                _masterConnectionString = connectionString;
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
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
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = (int)cmd.ExecuteScalar();
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
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (var checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            _lastError = "Ten dang nhap da ton tai";
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                    using (var insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? DBNull.Value : email);

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
                using (var masterConn = new SqlConnection(_masterConnectionString))
                {
                    masterConn.Open();

                    string checkDbQuery = "SELECT database_id FROM sys.databases WHERE Name = 'LanChatDB'";
                    using (var checkCmd = new SqlCommand(checkDbQuery, masterConn))
                    {
                        var result = checkCmd.ExecuteScalar();
                        if (result == null)
                        {
                            string createDbQuery = "CREATE DATABASE LanChatDB";
                            using (var createCmd = new SqlCommand(createDbQuery, masterConn))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                        CREATE TABLE Users (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Username NVARCHAR(50) NOT NULL UNIQUE,
                            Password NVARCHAR(255) NOT NULL,
                            Email NVARCHAR(100) NULL
                        )";

                    using (var cmd = new SqlCommand(createTableQuery, conn))
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
