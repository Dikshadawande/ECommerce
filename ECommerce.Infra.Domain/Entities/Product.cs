using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ECommerceContextt.Infra.Domain.Entities
{
    public  class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [JsonIgnore]
        public ProductCategories? productCategories { get; set; }
        [JsonIgnore]
        public Order? order { get; set; }

        [JsonIgnore]
        public Images? Image { get; set; } 
       


    }
}
