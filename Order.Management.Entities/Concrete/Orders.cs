using Order.Management.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Entities.Concrete
{
    public class Orders : BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
