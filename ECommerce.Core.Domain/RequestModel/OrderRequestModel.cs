using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.RequestModel
{
    public class OrderRequestModel
    {
        //public int OrderId { get; set; }
        //public Guid Invoice_Num { get; set; } = Guid.NewGuid();  //own filling value

        //public long? TotalAmount { get; set; }
        public int UserId { get; set; }

        public int[]  ProductId { get; set; }
    }
}
