using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        //public async Task<Order> Add(OrderOrderRequestModel order)
        //{
        //    _eCommerceContext.Orders.Add(order);

        //    await _eCommerceContext.SaveChangesAsync();
        //    return order;
        //}

        public async Task<Order> Add(OrderRequestModel order)
        {
            var total = await _eCommerceContext.Products.Where(x => order.ProductId.Contains(x.ProductId)).SumAsync(x => x.Price);
            ICollection<Product> products = new List<Product>();
            
            foreach(var pro in order.ProductId)
            {
              var product  =  _eCommerceContext.Products.FirstOrDefault(x => x.ProductId == pro);
                products.Add(product);
            }
            Order o1 = new Order()
            {
                //OrderId = order.OrderId,
                //Invoice_Num = order.Invoice_Num,
                TotalAmount = total,
                UserId = order.UserId,
                Products = products

            };
            _eCommerceContext.Orders.Add(o1);
            await _eCommerceContext.SaveChangesAsync();
            return o1;
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
