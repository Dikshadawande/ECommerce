using ECommerce.Controllers;
using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerceContextt.Infra.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class OrderTesting
    {
        private readonly OrderController orderController;
        private readonly Mock<IOrderService> orderServiceMock =new Mock<IOrderService>();
        public OrderTesting()
        {
            orderController= new OrderController(orderServiceMock.Object);
        }

        [Fact]

        public void GetOrder()
        {
            var order = new Order()
            {
                OrderId = 1,
                Invoice_Num = new Guid("9D1A3AF0-EC7F-4234-BCC5-6F6C90763AD0"),
                TotalAmount= 15000,
                UserId= 1,

            };

            var order1 = new Order()
            {
                OrderId = 2,
                Invoice_Num = new Guid("F724198B-64EA-48AD-999A-A7A8BBBAB8F5"),
                TotalAmount = 90000,
                UserId = 3,

            };

            orderServiceMock.Setup(x => x.GetOrder(1)).ReturnsAsync(order);
            orderServiceMock.Setup(x =>x.GetOrder(2)).ReturnsAsync(order1);
            var o = orderController.Get(1).Result;
            var O = orderController.Get(2).Result;
            //Assert.NotNull(o);
            Assert.True(order.OrderId== 1);
            
        }
        [Fact]  
        public void PostOrder()
        {

            var Order = new Order()
            {
                OrderId = 1,
                Invoice_Num = new Guid("9D1A3AF0-EC7F-4234-BCC5-6F6C90763AD0"),
                TotalAmount = 15000,
                UserId = 1,

            };

            var order1 = new OrderRequestModel()
            {
                UserId = 1,

            };
            orderServiceMock.Setup(x => x.AddOrder(order1)).ReturnsAsync(Order);
            var o2= orderController.AddOrder(order1).Result;
            Assert.Equal(o2,Order);
           
        }

         
       
    }
}
