using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.RequestModel
{
    public class UserRequestModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Role { get; set; }
        public string password { get; set; }
    }
}
