using System.Data.SqlClient;

namespace OrderService.Repositories.Database
{
    public interface IDataConnection
    {
        SqlConnection? Connect(string dbName, string connectionString);
        void Disconnect();
    }
}
