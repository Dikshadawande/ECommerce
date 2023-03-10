using AutoMapper;
using ECommerce.Core.Domain.RequestModel;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class atoMappper : Profile
    {
        public atoMappper()
        {
            CreateMap<UserRequestModel, User>().ReverseMap();
        }
    }


}
