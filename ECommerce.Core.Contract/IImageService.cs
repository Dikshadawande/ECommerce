    using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Domain.Entities;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Contract
{
    public interface IImageService
    {
       
       // Task<string> Addimage([FromForm] FileUpload image);
        string Addimage([FromForm] FileUpload image);
        
    }
}
