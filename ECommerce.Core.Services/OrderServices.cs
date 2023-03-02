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
            Order o1 = new Order();
            //o1.OrderId = orderRequestModel.OrderId;
            //o1.Invoice_Num = orderRequestModel.Invoice_Num;
            o1.TotalAmount = orderRequestModel.TotalAmount;
            o1.UserId = orderRequestModel.UserId;
            o1.ProductId = orderRequestModel.ProductId;

            return (await _order.Add(o1));

        }

        //get
        public async Task<Order> GetOrder(int id)
        {
            var o2= await _order.Get(id);
            return o2;
        }


    }
}
