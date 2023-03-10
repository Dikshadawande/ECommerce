using ECommerce.Controllers;
using ECommerce.Core.Contract;
using ECommerce.Core.Services;
using ECommerceContextt.Infra.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class ProductCategoriesTesting
    {
        private readonly ProductCategoriesController categoriesController;
        private readonly Mock<IProCategoriesService> _productServiceMock = new Mock<IProCategoriesService>();

        public ProductCategoriesTesting()
        {
            categoriesController = new ProductCategoriesController(_productServiceMock.Object);
        }

        [Fact]

        public void Get()
        {
            var product = new ProductCategories()
            {
                Id = 1,
                Name = "Laptop",

            };
            _productServiceMock.Setup(x => x.GetProduct(1)).ReturnsAsync(product);
            var pro = categoriesController.Add(1).Result;
            Assert.NotNull(pro);
            Assert.True(pro.Id == 1);

        }

        [Fact]
        public void Post()
        {
            var product = new ProductCategories()
            {
                Id = 1,
                Name = "Laptop",
            };
            _productServiceMock.Setup(x =>x.AddPro(product)).ReturnsAsync(product);
            var pro= categoriesController.AddPro(product).Result;
           // Assert.NotNull(pro);
          Assert.Equal(pro,product);

        }

    }
}