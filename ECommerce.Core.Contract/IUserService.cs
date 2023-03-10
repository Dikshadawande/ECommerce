using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Domain.Entities;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Contract
{
    public interface IUserService
    {
        Task<User> Add(UserRequestModel userRequestModel);
        Task<string> Login(User1 user1);
          
        
    }
}
