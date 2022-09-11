using AutoMapper;
using Order.Management.Core.Concrete;
using Order.Management.Core.Repositories;
using Order.Management.Core.Services;
using Order.Management.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Service.Services
{
    public class OrderProductService : Service<OrderProduct>, IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderProductService(IGenericRepository<OrderProduct> repository, IUnitOfWork unitOfWork, IOrderProductRepository orderProductRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;

            _orderProductRepository = orderProductRepository;
        }
    
    }
}
