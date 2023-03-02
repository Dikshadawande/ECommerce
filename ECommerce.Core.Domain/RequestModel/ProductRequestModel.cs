﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.RequestModel
{
    public class ProductRequestModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int  CategoryId { get; set; }
        public long? Price { get; set; }
    }
}
