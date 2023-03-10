using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
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
        [HttpPost,Authorize]
        public async Task<Order>AddOrder([FromQuery]OrderRequestModel orderRequestModel)
        {
            Order o1= await _orderService.AddOrder(orderRequestModel);
            return (o1);
        }

        [HttpGet,Authorize]
        public async Task<Order>Get(int id)
        {
            Order o2= await _orderService.GetOrder(id);
            return (o2);
        }
    }
}
