using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Concrete
{
    public class Orders : BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public string OrderAddress { get; set; }
    }
}
