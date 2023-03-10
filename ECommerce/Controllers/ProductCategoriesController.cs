using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Repository;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProCategoriesService _proCategoriesService;
        public ProductCategoriesController(IProCategoriesService proCategoriesService)
        {
            _proCategoriesService = proCategoriesService;
        }
        [HttpPost("ProductCategories"), Authorize]
        public async Task<ProductCategories> AddPro(ProductCategories pCategories)
        {

            ProductCategories c1 = await _proCategoriesService.AddPro(pCategories);
            return (c1);
        }

        [HttpGet("ProductCategories"), Authorize]
        public async Task<ProductCategories>Add(int id)
        {
            ProductCategories product=await _proCategoriesService.GetProduct(id);
            return (product);                                                                                   
        }
    }
}
