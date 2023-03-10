using ECommerce.Core.Domain.RequestModel;
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
        Task<Order> Add(OrderRequestModel order);
        Task<Order> Get(int id);
    }
}
