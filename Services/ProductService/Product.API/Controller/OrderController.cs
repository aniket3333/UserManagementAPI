using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs.OrderService.Application.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities.OrderService.Domain.Entities;
using System.Security.Claims;

namespace Product.API.Controller
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
   
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        private int GetUserId()
        {
            return 2;
        }

        // ✅ Create Order (from Cart)
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            var userId = GetUserId();

            var items = dto.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();

            var order = await _orderRepository.CreateOrderAsync(userId, items);

            return Ok(order);
        }

        // ✅ Get User Orders
        [HttpGet]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = GetUserId();
            var orders = await _orderRepository.GetByUserIdAsync(userId);
            return Ok(orders);
        }

        // ✅ Get Order By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return NotFound();

            return Ok(order);
        }

        // ✅ Update Status (Admin / Payment / Shipping)
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateOrderStatusDto dto)
        {
            await _orderRepository.UpdateStatusAsync(id, dto.Status);
            return Ok(new { message = "Order status updated" });
        }
    }
}

