using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Concrete
{
    public class Customer:BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Orders> Order { get; set; }


    }
}
