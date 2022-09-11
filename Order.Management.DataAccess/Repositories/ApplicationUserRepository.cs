using Microsoft.EntityFrameworkCore;
using Order.Management.Core.Concrete;
using Order.Management.Core.Repositories;
using Order.Management.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(OrderManagementDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetApplicationUserAsync(string userName, string password)
        {
            return  await _context.ApplicationUsers.FirstOrDefaultAsync(i => i.Username == userName && i.Password == password);
          
        }
    }
}
