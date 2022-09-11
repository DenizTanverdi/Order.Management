using Order.Management.Core.Concrete;
using Order.Management.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Repositories
{
    public interface IOrdersRepository: IGenericRepository<Orders>
    {
        Task<List<Orders>> GetOrdersAsync(int customerId);
        Task<List<Orders>> GetOrderAsync(int id);
        Orders AddOrderAsync(Orders order);
        Orders UpdateOrderAsync(Orders order);
        Task DeleteOrderAsync(int id);


    }
}
