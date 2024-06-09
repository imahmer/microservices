using System.Data.SqlClient;
using System.Data;

namespace OrderService.Repositories.Database
{
    public class DataConnectionProvider : IDataConnection
    {
        private SqlConnection connection { get; set; } = default!;

        public SqlConnection? Connect(string dbName, string connectionString)
        {
            if (connection?.State == ConnectionState.Open) return connection;
            var connString = Transform(dbName, connectionString);
            if (string.IsNullOrEmpty(connString)) return connection;
            connection = new SqlConnection(connString);
            connection.Open();
            return connection;
        }

        public void Disconnect()
        {
            if (connection == null) return;
            if (connection.State == ConnectionState.Open)
            {
                connection?.Close();
            }
            connection?.Dispose();
        }

        private string Transform(string dbName, string connectionString)
        {
            return connectionString.Replace("DB_Placeholder", dbName);
        }
    }
}
