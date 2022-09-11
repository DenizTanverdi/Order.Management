using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Management.API.Controllers.Base;
using Order.Management.Core.Concrete;
using Order.Management.Core.Concrete.Base;
using Order.Management.Core.DTOs;
using Order.Management.Core.Services;

namespace Order.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : CustomBaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, IMapper mapper, ILogger<OrderController> logger)
        {
           
            _orderService = orderService;
            _mapper=mapper;
            _logger = logger;
        }
        [HttpGet("{customerId}/orders")] // api/order/2
        public async Task<IActionResult> All(int customerId)
        {
            
            return CreatActionResult(await _orderService.GetOrdersAsync(customerId));
          
        }
        [HttpGet("{id}")] // api/order/5
        public async Task<IActionResult> GetById(int id)
        {
            return CreatActionResult(await _orderService.GetOrderAsync(id));

        }
        [HttpPost("{customerId}")] // api/order/2
        public async Task<IActionResult> Save(OrderDto orderDto, int customerId)
        {
            orderDto.Customer=new CustomerDto();
            orderDto.Customer.Id = customerId;
            var order =await _orderService.AddOrderAsync(_mapper.Map<Orders>(orderDto));
            if (order.StatusCode!=201)
            {
                return CreatActionResult(CustomResponseDto<OrderDto>.Fail(404,order.Errors));
            }
            else
            {
                return CreatActionResult(order);
            }
           

        }
        [HttpPut("{customerId}")] // api/order
        public async Task<IActionResult> Update(OrderDto orderDto, int customerId)
        {
            orderDto.Customer = new CustomerDto();
            orderDto.Customer.Id = customerId;
            var order = await _orderService.UpdateOrderAsync(_mapper.Map<Orders>(orderDto));
            if (order.StatusCode != 201)
            {
                return CreatActionResult(CustomResponseDto<OrderDto>.Fail(404, order.Errors));
            }
            else
            {
                return CreatActionResult(order);
            }
            
        }
        [HttpDelete("{id}")] // api/order/5
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return CreatActionResult(CustomResponseDto<NoContentDto>.Success(204));
            
            

        }
    }
}
