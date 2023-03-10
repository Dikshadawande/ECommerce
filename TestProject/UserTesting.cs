using ECommerce.Controllers;
using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Domain.Entities;
using ECommerceContextt.Infra.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserTesting
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> userservicesMock = new Mock<IUserService>();

        public UserTesting()
        {
            _userController = new UserController(userservicesMock.Object);
        }

        [Fact]
        public void GetUser()
        {
            var user = new User1()
            {
                //Id = 1,
                //Name = "string",
                Email = "string",
                //   Address = "string",
                //  Role = "string",
                Password = "password",
                //PhoneNumber=

            };
            string s1 = "hello";
            userservicesMock.Setup(x => x.Login(user)).ReturnsAsync(s1);
            var u = _userController.login(user).Result;
            Assert.Equal(s1, u);
            Assert.NotNull(u);

        }
        [Fact]
        public void PostUser()
        {

            var user = new User()
            {
                //Id = 1,
                //Name = "string",
                Email = "string",
             
            };

            var user1 = new UserRequestModel()
            {
                Id = 1,
                Name = "string",
                Email = "string",

                Role = "string",
            };
            userservicesMock.Setup(x => x.Add(user1)).ReturnsAsync(user);
            var z= _userController.AddUser(user1).Result;

            Assert.Equal(user,z);
           

        }


    }
}
