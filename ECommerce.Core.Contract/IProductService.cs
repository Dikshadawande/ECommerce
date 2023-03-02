using ECommerce.Core.Domain.RequestModel;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Contract
{
    public  interface IProductService
    {
      
        Task<Product> AddProduct(Product product);
        Task<Product> GetProduct(int id);
       
    }
}
