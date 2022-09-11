using Order.Management.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.DTOs
{
    public class OrderDto:BaseDto
    {
        public ICollection<OrderProductDto> OrderProducts { get; set; }
        public CustomerDto Customer { get; set; }
        public string OrderAddress { get; set; }
    }
}
