using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Active IsActive { get; set; }
    }
}
