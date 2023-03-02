using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Contract
{
    public interface IOrder
    {
        Task<Order> Add(Order order);
        Task<Order> Get(int id);
    }
}
