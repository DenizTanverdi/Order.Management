using Order.Management.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Core.Repositories
{
    public interface IOrderProductRepository:IGenericRepository<OrderProduct>
    {
        OrderProduct AddOrder(OrderProduct orderProduct);
        List<OrderProduct> GetOrderProducts(int orderId);
    }
}
