namespace OrderService.Models.Common
{
    public class DBTable : Attribute
    {
        public string Name { get; set; } = default!;
        public string PrimaryKeyColumnCSV { get; set; } = default!;
    }
}
