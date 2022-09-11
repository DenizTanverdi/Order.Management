using Order.Management.Core.Concrete;
using Order.Management.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Services
{
    public interface IApplicationUserService
    {
        string Authenticate(AuthenticateRequest model);
         ApplicationUser GetById(int id);


    }
}
