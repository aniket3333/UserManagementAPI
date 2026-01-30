using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System.Security.Claims;

namespace Product.API.Controller
{
    [ApiController]
    [Route("api/order-tracking")]
    public class OrderTrackingController : ControllerBase
   { 
        private readonly IOrderTrackingRepositorycs _repository;

        public OrderTrackingController(IOrderTrackingRepositorycs repository)
        {
            _repository = repository;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }

        // ✅ Create Initial Tracking
        [HttpPost]
        public async Task<IActionResult> Create(CreateTrackingDtocs dto)
        {
            var tracking = new OrderTracking
            {
                OrderId = dto.OrderId,
                UserId = GetUserId(),
                Description = dto.Description
            };

            await _repository.AddAsync(tracking);
            return Ok();
        }

        // ✅ Update Order Status
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateStatus(
            int orderId,
            UpdateStatusDto dto)
        {
            await _repository.UpdateStatusAsync(
                orderId,
                dto.Status,
                dto.Description
            );

            return Ok();
        }

        // ✅ Get Order Timeline
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetTracking(int orderId)
        {
            var result = await _repository.GetByOrderIdAsync(orderId);
            return Ok(result);
        }
    }
}
