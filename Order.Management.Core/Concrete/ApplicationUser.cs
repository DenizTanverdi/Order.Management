using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Management.Core.Concrete
{
    public class ApplicationUser:BaseModel
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}
