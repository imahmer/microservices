using OrderService.Models.Common;

namespace OrderService.Models.Domain.Order
{
    public class OrderListFilter: Pagination<int>
    {
        public IEnumerable<OrderGridFilterListItem> OrderGridFilterList { get; set; } = default!;
    }
}
