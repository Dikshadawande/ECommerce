using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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

        [HttpPost("Product"),Authorize]
        public async Task<Product>Add(Product product)
        {
            Product p1= await _product.AddProduct(product);
            return (p1);
        }


        [HttpGet("Product"), Authorize] //id
        [EnableQuery]
        public async Task<Product>Get(int id)
        {
           Product p2= await _product.GetProduct(id);
            return (p2);
        }


        [HttpGet("Products"), Authorize]
        [EnableQuery]
        public async Task<ActionResult> GetPro()
        {
            var Product = await _product.GetAllProducts();
            return Ok(Product);
        }

    }
}
