using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceContextt.Infra.Domain.Entities
{
    public class Images
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }

      //  [ForeignKey("ProductId")]
    //    public Product Products { get; set; }
    }
}
