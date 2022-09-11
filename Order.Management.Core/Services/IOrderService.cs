using Order.Management.Core.Concrete;
using Order.Management.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Services
{
    public interface IOrderService:IService<Orders>
    {
        Task<CustomResponseDto<List<OrderDto>>> GetOrdersAsync(int customerId);
        Task<CustomResponseDto<List<OrderDto>>> GetOrderAsync(int id);
        Task<CustomResponseDto<OrderDto>> AddOrderAsync(Orders order);
        Task<CustomResponseDto<OrderDto>> UpdateOrderAsync(Orders order);
        Task DeleteOrderAsync(int id);
    }
}
