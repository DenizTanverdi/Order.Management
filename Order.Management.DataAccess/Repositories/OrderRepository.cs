using Microsoft.EntityFrameworkCore;
using Order.Management.Core.Concrete;
using Order.Management.Core.Concrete.Base;
using Order.Management.Core.DTOs;
using Order.Management.Core.Repositories;
using Order.Management.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrdersRepository
    {
        public OrderRepository(OrderManagementDbContext context) : base(context)
        {
        }

        public  Orders AddOrderAsync(Orders order)
        {
            order.CreationDate = DateTime.Now;
            order.IsActive = Active.Active;
            var _order = _context.Orders.Add(order).Entity;
            _context.SaveChanges();
            return _order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orders = _context.Orders.FirstOrDefault(i => i.Id == id);
              _context.Orders.Remove(orders);
        }

        public async Task<List<Orders>> GetOrderAsync(int id)
        {
            return await _context.Orders.Where(i => i.Id == id).Include(i => i.Customer).Include(i => i.OrderProducts).ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersAsync(int customerId)
        {
            return await  _context.Orders.Where(i => i.CustomerId == customerId).Include(i => i.Customer).Include(i => i.OrderProducts).ToListAsync();
            
        }

        public Orders UpdateOrderAsync(Orders order)
        {
            order.CreationDate = DateTime.Now;
            order.IsActive = Active.Active;
            var _order = _context.Orders.Update(order).Entity;
            _context.SaveChanges();
            return _order;
        }
    }
}
