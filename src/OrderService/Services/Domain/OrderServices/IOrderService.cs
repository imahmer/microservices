using OrderService.Models.Common;
using OrderService.Models.Domain.Order;

namespace OrderService.Services.Domain.OrderServices
{
    public interface IOrderService
    {
        Response GetById(long orderId);
        Task<Response> Create(Order order);
        Task<Response> Update(Order order);
        Task<Response> Delete(Order order);
        Task<OrderListFilter> GetOrderList(OrderListFilter orderListFilter);
    }
}
