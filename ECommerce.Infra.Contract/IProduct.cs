using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Contract
{
    public  interface IProduct
    {
        Task<Product> Add(Product product);
        Task<Product> Get(int id);
    }
}
