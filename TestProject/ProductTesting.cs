using ECommerce.Controllers;
using ECommerce.Core.Contract;
using ECommerceContextt.Infra.Domain.Entities;
using Moq;

namespace TestProject
{
    public class ProductTesting
    {
        private readonly ProductController productController;
        private readonly Mock<IProductService> _productServiceMock = new Mock<IProductService>();
        public ProductTesting()
        {
            productController = new ProductController(_productServiceMock.Object);
        }


        [Fact]
        public void GetProduct()
        {
            var product = new Product()
            {
                ProductId = 1,
                Name = "h.P",
                Description = "string",
                Price = 15000,
                CategoryId = 1,

            };
            var p2 = new Product()
            {
                ProductId = 2,
                Name = "Laptop",
                Description = "string",
                Price = 2000,
                CategoryId = 2,
            };

            _productServiceMock.Setup(x => x.GetProduct(1)).ReturnsAsync(product);
            var pro = productController.Get(1).Result;
            var p = productController.Get(2).Result;
            //   Assert.Equal(p, p2);
            // Assert.NotNull(pro);
            Assert.Equal(pro, product);

        }

        [Fact]
        public void Post()
        {
            var product = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "string",
                Description = "string",
                Price = 1200,

            };
            _productServiceMock.Setup(x => x.AddProduct(product));
            var p = productController.Get(1).Result;
            Assert.Equal(p, product);
            Assert.True(product.ProductId == 1);
            Assert.True(product.Name == "string");
            Assert.False(product.Description != "string");
        }

        [Fact]
        public void Get()
        {
            var product = new Product()
            {
                ProductId = 1,
                Name = "h.P",
                Description = "string",
                Price = 15000,
                CategoryId = 1,
            };
            _productServiceMock.Setup(X => X.GetProduct(1)).ReturnsAsync(product);
            var pro = productController.Get(1).Result;
            Assert.Equal(pro, product);
            Assert.False(product.ProductId != 1);
        }
    }





}
