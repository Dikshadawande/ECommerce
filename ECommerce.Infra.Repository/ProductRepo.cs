using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repository
{
    public  class ProductRepo :IProduct
    {
        private readonly ECommerceContext _eCommerceContext;
        public ProductRepo(ECommerceContext eCommerceContext)
        {
            _eCommerceContext= eCommerceContext;
        }

        public async Task<Product> Add(Product product)
        {
          //  var pc = _eCommerceContext.ProductCategories.FirstOrDefault(x => x.Id== product.ProductCId);
            //product.productCategories = pc;
            _eCommerceContext.Products.Add(product);
            await _eCommerceContext.SaveChangesAsync();

            return product;


        }

        public async  Task<Product> Get(int id )
        {

            var product= _eCommerceContext.Products.FirstOrDefault(x => x.ProductId == id);
            await _eCommerceContext.SaveChangesAsync();
            return product;
        }


        public async Task<IList<Product>> Get()
        {
            var Product =  _eCommerceContext.Products.ToList();
         
            return Product;
        }
    }
}
