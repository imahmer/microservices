using OrderService.Models.Common;
using OrderService.Models.Domain.Order;
using OrderService.Repositories.Domain.OrderRepository;

namespace OrderService.Services.Domain.OrderServices
{
    public class OrderService : BaseAPIResponse, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Response GetById(long id)
        {
            try
            {
                return SuccessResponse(_orderRepository.GetByColumns(new { Id = id, Status = 1 }));
            }
            catch (Exception ex)
            {
                return FaultResponse(resultText: "Unable to create category");
            }
        }

        public async Task<Response> Create(Order order)
        {
            try
            {
                //if (_orderRepository.IsExists(new { Name = order.Name, Status = (int)Status.NotDeleted }, category.Id))
                //    return FaultResponse(resultText: "Order Already exists");

                //long response = await _orderRepository.InsertAsync(category);
                //category.Id = response;
                //if (category.RootId == 0)
                //{
                //    category.Code = response.ToString().LeadingZero(1);
                //}
                //else
                //{
                //    long count = _orderRepository.GetCountByColumns(new { RootId = category.RootId });
                //    category.Code = count.ToString().LeadingZero(category.RootId.ToString(), '-', 1);
                //}
                var result = await _orderRepository.UpdateAsync(order);
                return SuccessResponse(id: order.Id, resultText: "Order successfully added");
            }
            catch (Exception ex)
            {
                return FaultResponse(resultText: "Unable to create order");
            }
        }

        public async Task<Response> Update(Order order)
        {
            try
            {
                var result = await _orderRepository.UpdateAsync(order);
                if (result)
                {
                    return SuccessResponse(id: order.Id, resultText: "Order successfully updated");
                }
                return FaultResponse(resultText: "Unable to update order");
            }
            catch (Exception ex)
            {
                return FaultResponse(resultText: "Unable to update order");
            }
        }

        public async Task<Response> Delete(Order order)
        {
            try
            {
                var result = await _orderRepository.DeleteModifiedAsync(order);
                if (result)
                {
                    return SuccessResponse(id: order.Id, resultText: "Order successfully deleted");
                }
                return FaultResponse(resultText: "Unable to delete order");
            }
            catch (Exception ex)
            {
                return FaultResponse(resultText: "Unable to delete order");
            }
        }

        public async Task<OrderListFilter> GetOrderList(OrderListFilter orderListFilter)
        {
            try
            {
                return await _orderRepository.GetOrderList(orderListFilter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
