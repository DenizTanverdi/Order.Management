using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
