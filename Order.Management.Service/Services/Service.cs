using Microsoft.EntityFrameworkCore;
using Order.Management.Core.Repositories;
using Order.Management.Core.Services;
using Order.Management.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork=unitOfWork;
        }   
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async void Delete(T entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetAll(expression).ToListAsync();
        }
        
        public async Task<T> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public async void Update(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
