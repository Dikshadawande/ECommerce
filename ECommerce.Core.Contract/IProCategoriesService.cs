using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Contract
{
    public interface IProCategoriesService
    {
        Task<ProductCategories>AddPro(ProductCategories category);
        Task<ProductCategories>GetProduct(int id);  
        
    }
}
