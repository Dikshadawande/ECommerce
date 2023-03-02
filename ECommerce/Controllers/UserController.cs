using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("Register")]
        public async Task<User> AddUser(UserRequestModel userRequestModel)
        {
            User u1 = await _user.Add(userRequestModel);
            return (u1);
        }
        [HttpGet("Login")]

        public async Task<string>login([FromQuery]UserRequestModel userRequestModel)
        {
            return await _user.Login(userRequestModel);
        }
    }
}
