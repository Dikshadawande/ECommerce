using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repository
{
    public class OrderRepo : IOrder
    {
        private readonly ECommerceContext _eCommerceContext;
        public OrderRepo(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public async Task<Order> Add(Order order)
        {
            _eCommerceContext.Orders.Add(order);
            await _eCommerceContext.SaveChangesAsync();
            return order;
        }

        //get
        public  async Task<Order> Get(int id)
        {
            var o2= _eCommerceContext.Orders.FirstOrDefault(x => x.OrderId  == id);
            await _eCommerceContext.SaveChangesAsync();
            return o2;
        }
    }
}
