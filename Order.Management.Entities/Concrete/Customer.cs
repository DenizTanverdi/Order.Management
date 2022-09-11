using Order.Management.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Entities.Concrete
{
    public class Customer:BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }


    }
}
