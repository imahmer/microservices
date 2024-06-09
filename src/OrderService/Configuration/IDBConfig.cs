namespace OrderService.Configuration
{
    public interface IDBConfig
    {
        string ConnectionString { get; }
        string GetDBName();
    }
}
