using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.DTOs
{
    public class CustomerDto:BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        
        List<OrderDto>  OrderDtos { get; set; }
    }
}
