using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class OrderServices: IOrderService
    {
        private readonly IOrder _order;

        public OrderServices(IOrder order)
        {
            _order = order;
        }

        public async Task<Order> AddOrder(OrderRequestModel orderRequestModel)
        {
        

            return (await _order.Add(orderRequestModel));

        }

        //get
        public async Task<Order> GetOrder(int id)
        {
            var o2= await _order.Get(id);
            return o2;
        }


    }
}
