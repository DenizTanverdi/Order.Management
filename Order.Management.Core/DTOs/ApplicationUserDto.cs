using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.DTOs
{
    public class ApplicationUserDto : BaseDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
