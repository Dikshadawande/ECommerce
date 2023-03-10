using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceContextt.Infra.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public Guid Invoice_Num { get; set; } = Guid.NewGuid();  //own filling value
   
        
        public long? TotalAmount { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        
        [JsonIgnore]
        public User Users { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get;set; }
    }
}
