using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Concrete
{
    public class Product:BaseModel
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
       
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
