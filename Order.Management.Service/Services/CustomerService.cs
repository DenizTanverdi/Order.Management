using AutoMapper;
using Order.Management.Core.Concrete;
using Order.Management.Core.Repositories;
using Order.Management.Core.Services;
using Order.Management.Core.UnitOfWork;
using Order.Management.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            
            _customerRepository = customerRepository;
        }
    }
}
