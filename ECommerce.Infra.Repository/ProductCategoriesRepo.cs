using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repository
{
    public class ProductCategoriesRepo : IProductCategories
    {
        private readonly ECommerceContext _eCommerceContext;
        public ProductCategoriesRepo(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public async Task<ProductCategories> Add(ProductCategories category)
        {
            _eCommerceContext.ProductCategories.Add(category);
            await _eCommerceContext.SaveChangesAsync();
            return category;
        }

        public async Task<ProductCategories> Get(int id)
        {
            var catogory = _eCommerceContext.ProductCategories.FirstOrDefault(x => x.Id == id);
            await _eCommerceContext.SaveChangesAsync();
            return catogory;
        }
    }
}
