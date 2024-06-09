namespace OrderService.Configuration
{
    public class DBConfig : IDBConfig
    {
        private readonly IConfiguration _config;
        public DBConfig(IConfiguration config)
        {
            _config = config;
        }
        public string ConnectionString => GetConfig("ConnectionStrings:DefaultConnection")?.Value;

        public string GetDBName()
        {
            return "Procurement";
        }
        public IConfigurationSection GetConfig(string key) => _config.GetSection(key);
    }
}
