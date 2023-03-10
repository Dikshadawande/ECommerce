using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repository
{
    public class ImageRepo : IImage
    {
        private readonly ECommerceContext _eCommerceContext;
        public ImageRepo(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

      

        public Images Add(Images image)
        {
            _eCommerceContext.Imagess.Add(image);
             _eCommerceContext.SaveChanges();
            return image;
        }
    }
}
