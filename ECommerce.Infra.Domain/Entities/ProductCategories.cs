using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceContextt.Infra.Domain.Entities
{
    public  class ProductCategories
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
       public ICollection<Product>? Products { get; set; }
    }
}
