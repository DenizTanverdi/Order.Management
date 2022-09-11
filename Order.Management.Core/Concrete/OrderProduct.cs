using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Concrete
{
    public class OrderProduct:BaseModel
    {
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
       
    }
    
}
