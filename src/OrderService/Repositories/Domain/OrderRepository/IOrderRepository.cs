using OrderService.Models.Domain.Order;
using OrderService.Repositories.Base;

namespace OrderService.Repositories.Domain.OrderRepository
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
        Task<OrderListFilter> GetOrderList(OrderListFilter orderListFilter);
    }
}
