using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Management.Core.Concrete;
using Order.Management.Core.Concrete.Base;
using Order.Management.Core.DTOs;
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
    public class OrderService : Service<Orders>, IOrderService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IGenericRepository<Orders> repository, IUnitOfWork unitOfWork, IMapper mapper, IOrdersRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IOrderProductRepository orderProductRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderProductRepository= orderProductRepository;
            _unitOfWork= unitOfWork;
        }

        public async Task<CustomResponseDto<List<OrderDto>>> GetOrdersAsync(int customerId)
        {
           var orders= await _orderRepository.GetOrdersAsync(customerId);
            foreach (var order in orders)
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    orderProduct.Product=_productRepository.GetByIdAsync(orderProduct.ProductId).Result;
                }
            }
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return  CustomResponseDto<List<OrderDto>>.Success(200, ordersDto);
        }
        public async Task<CustomResponseDto<List<OrderDto>>> GetOrderAsync(int id)
        {
            var orders = await _orderRepository.GetOrderAsync(id);
            foreach (var order in orders)
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    orderProduct.Product = _productRepository.GetByIdAsync(orderProduct.ProductId).Result;
                }
            }
            var orderDto = _mapper.Map<List<OrderDto>>(orders);
            return CustomResponseDto<List<OrderDto>>.Success(200, orderDto);
        }

        public async Task<CustomResponseDto<OrderDto>> AddOrderAsync(Orders order)
        {
            var customer = await _customerRepository.GetByIdAsync(order.CustomerId);
            
            if (customer==null)
            {
                
                return CustomResponseDto<OrderDto>.Fail(404, "Customer not found !");
            }
            else
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    var product = await _productRepository.GetByIdAsync(orderProduct.ProductId);
                    if (product==null)
                    {
                        return CustomResponseDto<OrderDto>.Fail(404, $"Product not found ! ProductId : {orderProduct.ProductId}");
                    }
                }
                var orderProducts = new List<OrderProduct>();
                foreach (var item in order.OrderProducts)
                {

                    var orderProduct = new OrderProduct();
                    orderProduct.ProductId = item.ProductId;
                     orderProduct.CreationDate = DateTime.Now;
                    orderProduct.Quantity = item.Quantity;
                    orderProduct.IsActive = Active.Active;
                    orderProducts.Add(orderProduct);
                }
                var model = new Orders
                {
                    Customer =await _customerRepository.GetByIdAsync(order.CustomerId),
                    OrderAddress = order.OrderAddress,
                    OrderProducts = orderProducts
                    
                };
                var orderModel = _orderRepository.AddOrderAsync(model);
                
                
                var orderDto = _mapper.Map<OrderDto>(orderModel);
                return  CustomResponseDto<OrderDto>.Success(201, orderDto);
            }
            
        }

        public async Task<CustomResponseDto<OrderDto>> UpdateOrderAsync(Orders order)
        {
            var customer = await _customerRepository.GetByIdAsync(order.CustomerId);

            if (customer == null)
            {

                return CustomResponseDto<OrderDto>.Fail(404, "Customer not found !");
            }
            else
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    var product = await _productRepository.GetByIdAsync(orderProduct.ProductId);
                    if (product == null)
                    {
                        return CustomResponseDto<OrderDto>.Fail(404, $"Product not found ! ProductId : {orderProduct.ProductId}");
                    }
                }
                
                var orderProducts = _orderProductRepository.GetOrderProducts(order.Id);
                foreach (var item in order.OrderProducts)
                {

                    var orderProduct = orderProducts.FirstOrDefault(i=>i.Id== item.Id);
                    if (orderProduct != null)
                    {
                        orderProduct.ProductId = item.ProductId;
                         orderProduct.Quantity = item.Quantity;
                        _orderProductRepository.Update(orderProduct);
                        _unitOfWork.Commit();
                    }
                    else
                    {
                        orderProduct=new OrderProduct();
                        orderProduct.ProductId = item.ProductId;
                        orderProduct.CreationDate = DateTime.Now;
                        orderProduct.Quantity = item.Quantity;
                        orderProduct.IsActive = Active.Active;
                        orderProduct.OrderId = order.Id;
                        await _orderProductRepository.AddAsync(orderProduct);
                        _unitOfWork.Commit();
                    }


                }
                foreach (var item in orderProducts)
                {
                    var isValue = order.OrderProducts.FirstOrDefault(i=>i.Id==item.Id);
                    if (isValue==null)
                    {
                        _orderProductRepository.Delete(item);
                        _unitOfWork.Commit();
                    }
                }
               
                var model = new Orders
                {
                    Customer = await _customerRepository.GetByIdAsync(order.CustomerId),
                    Id = order.Id,
                    OrderAddress = order.OrderAddress,
                 };
                var orderModel = _orderRepository.UpdateOrderAsync(model);


                var orderDto = _mapper.Map<OrderDto>(orderModel);
                return CustomResponseDto<OrderDto>.Success(201, orderDto);
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orderProducts = _orderProductRepository.GetOrderProducts(id);
            foreach (var item in orderProducts)
            {
                    _orderProductRepository.Delete(item);
                    _unitOfWork.Commit();
            }
           await _orderRepository.DeleteOrderAsync(id);
        }
    }
}
