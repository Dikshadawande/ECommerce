using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Contract
{
    public interface IImage
    {
        public Images Add(Images image);
    }
}
