using Order.Management.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Repositories
{
    public interface IApplicationUserRepository: IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetApplicationUserAsync(string userName, string password);
    }
}
