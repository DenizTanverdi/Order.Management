using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.DTOs
{
    public class OrderProductDto:BaseDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        
    }
}
