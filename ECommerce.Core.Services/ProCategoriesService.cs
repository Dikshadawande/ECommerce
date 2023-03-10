using ECommerce.Core.Contract;
using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class ProCategoriesService : IProCategoriesService
    {
        private readonly IProductCategories _proCategoriesService;
        public ProCategoriesService(IProductCategories proCategoriesService)
        {
            _proCategoriesService = proCategoriesService;
        }

        public async Task<ProductCategories> AddPro(ProductCategories productCategories)
        {
            ProductCategories c1 = new ProductCategories();
            c1.Id = productCategories.Id;
            c1.Name= productCategories.Name;
            return (await  _proCategoriesService.Add(c1));


        }

        public async Task<ProductCategories> GetProduct(int id)
        {
            var Catogory = await _proCategoriesService.Get(id);
            return Catogory;
        }
    }
}
