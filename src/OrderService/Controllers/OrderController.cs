using Microsoft.AspNetCore.Mvc;
using OrderService.Models.Common;
using OrderService.Models.Domain.Order;
using OrderService.Services.Domain.OrderServices;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [SwaggerResponse(400, "BAD REQUEST", Type = typeof(Response))]
        [SwaggerResponse(401, "UNAUTHORIZED REQUEST", Type = typeof(Response))]
        [SwaggerResponse(200, Description = "", Type = typeof(Response))]
        [HttpPost]
        [Route("getOrderList")]
        public async Task<OrderListFilter> GetOrderList(OrderListFilter orderListFilter)
        {
            return await _orderService.GetOrderList(orderListFilter);
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
