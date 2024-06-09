using OrderService.Models.Common;

namespace OrderService.Models.Domain.Order
{
    [DBTable(Name = "Orders")]
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
