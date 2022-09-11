using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Entities.Concrete.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime? DateOfDeletion { get; set; }
        public DateTime CreationDate { get; set; }
        public Active IsActive { get; set; }
    }
    public enum Active
    {
        Active = 1,
        NotActive = 0
    }
}
