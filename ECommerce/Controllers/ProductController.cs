using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            _product= product;
        }

        [HttpPost("Product")]
        public async Task<Product>Add(Product product)
        {
            Product p1= await _product.AddProduct(product);
            return (p1);
        }


        [HttpGet]
        public async Task<Product>Get(int id)
        {
           Product p2= await _product.GetProduct(id);
            return (p2);
        }
        
    }
}
