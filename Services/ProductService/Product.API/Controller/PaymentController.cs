using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using Product.Infrastructure.Repository;
using System.Security.Claims;

namespace Product.API.Controller
{
    [ApiController]
    [Route("api/payment")]

    public class PaymentController : ControllerBase
    {
   
        private readonly IPaymentRespositorycs _paymentRepository;

        public PaymentController(IPaymentRespositorycs paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        private int GetUserId()
        {
            return 2;
        }

        // ✅ Initiate Payment
        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                UserId = GetUserId(),
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                Status = "Success" // simulate success
            };

            var result = await _paymentRepository.CreateAsync(payment);

            // 🔥 Later: publish event → OrderService (PaymentSuccess)

            return Ok(new PaymentResponseDto
            {
                TransactionId = result.TransactionId,
                Status = result.Status
            });
        }

        // ✅ Get Payment by Order
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            var payment = await _paymentRepository.GetByOrderIdAsync(orderId);
            if (payment == null) return NotFound();

            return Ok(payment);
        }
    }
}
