using Order.Management.Core.Concrete;
using Order.Management.Core.Concrete.Base;
using Order.Management.Core.Repositories;
using Order.Management.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(OrderManagementDbContext context) : base(context)
        {
        }
        public OrderProduct AddOrder(OrderProduct orderProduct)
        {
            orderProduct.CreationDate = DateTime.Now;
            orderProduct.IsActive = Active.Active;
            return _context.OrderProducts.Add(orderProduct).Entity;
        }

        public List<OrderProduct> GetOrderProducts(int orderId)
        {
            return _context.OrderProducts.Where(i=>i.OrderId==orderId).ToList();
        }
    }
}
