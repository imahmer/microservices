namespace OrderService.Models.Domain.Order
{
    public class OrderGridFilterListItem
    {
        public string User { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int Quantity { get; set; } = default!;
    }
}
