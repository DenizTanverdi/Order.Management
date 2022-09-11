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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OrderManagementDbContext context) : base(context)
        {
        }
    }
}
