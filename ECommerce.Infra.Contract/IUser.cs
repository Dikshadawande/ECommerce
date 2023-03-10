using ECommerce.Core.Domain.RequestModel;

using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Contract
{
    public  interface IUser
    {
        

        Task<User> AddUser(User user);
      
        
        Task<User> UserLogin(string email);
        
    }
}
