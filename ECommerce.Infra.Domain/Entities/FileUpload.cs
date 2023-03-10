using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Domain.Entities
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
        public int ProductId { get; set; }
        public Task<Images> AddImage(FileUpload image)
        {
            throw new NotImplementedException();
        }
    }
}
