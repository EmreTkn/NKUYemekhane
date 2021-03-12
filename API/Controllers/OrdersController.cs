using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Order;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderAggregate>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var order = await _orderService.CreateOrderAsync(email, orderDto.BasketId);
            if (order==null)
            {
                return BadRequest(new ApiResponse(400, "Problem creating order"));
            }

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var orders = await _orderService.GetOrdersForUserAsync(email);

            Console.WriteLine("asdasd");

            var data = _mapper.Map<IReadOnlyList<OrderAggregate>, IReadOnlyList<OrderToReturnDto>>(orders);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var order = await _orderService.GetOrderByIdAsync(id, email);
            if (order==null)
            {
                return NotFound(new ApiResponse(404));
            }

            var data = _mapper.Map<OrderAggregate, OrderToReturnDto>(order);

            foreach (var item in data.Menus)
            {
                foreach (var keko in order.Menus)
                {
                    item.SchoolName = keko.MenuOrdered.SchoolName;
                    item.DinnerTime = keko.MenuOrdered.DinnerTime;
                }
            }
            return data;
        }
    }
}
