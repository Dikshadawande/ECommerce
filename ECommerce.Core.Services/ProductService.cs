using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProduct _product;
        public ProductService(IProduct product)
        {
           _product= product;
        }
        public async Task<Product> AddProduct(Product product)
        {


            //   p1.ProductCId = productRequestModel.CategoryId;
   
            return (await _product.Add(product));
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            var p = await _product.Get();
            return p;
        }




        //get
        public  async Task<Product> GetProduct(int id)
        {
            var Product=await _product.Get(id);
            return Product;
        }

       



    }
}
