using Microsoft.EntityFrameworkCore;
using Order.Management.Core.Repositories;
using Order.Management.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OrderManagementDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(OrderManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
           return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public  void Update(T entity)
        {
              _dbSet.Update(entity);
        }
    }
}
