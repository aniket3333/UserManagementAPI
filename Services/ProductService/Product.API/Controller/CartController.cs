using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Product.Application.Interfaces;
using Product.Application.DTOs;

namespace CartService.API.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // 🔹 Get logged-in user id from JWT
        private int GetUserId()
        {
            return 10;
        }

        // ✅ Get Cart
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = GetUserId();
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            return Ok(cart);
        }

        // ✅ Add To Cart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCart dto)
        {
            try{
                var userId = GetUserId();

                await _cartRepository.AddToCartAsync(
                    userId,
                    dto.ProductId,
                    dto.ProductName,
                    dto.Price,
                    dto.Quantity
                );

                return Ok(new { message = "Item added to cart" });
            }catch(Exception ex){
                var userId = GetUserId();

                await _cartRepository.AddToCartAsync(
                    userId,
                    dto.ProductId,
                    dto.ProductName,
                    dto.Price,
                    dto.Quantity
                );

                return Ok(new { message = "Item added to cart" });
            }
        }

        // ✅ Update Quantity
        [HttpPut]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartDto dto)
        {
            var userId = GetUserId();

            await _cartRepository.UpdateQuantityAsync(
                userId,
                dto.ProductId,
                dto.Quantity
            );

            return Ok(new { message = "Cart updated" });
        }

        // ✅ Remove Item
        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            var userId = GetUserId();

            await _cartRepository.RemoveItemAsync(userId, productId);

            return Ok(new { message = "Item removed from cart" });
        }

        // ✅ Clear Cart
        [HttpDelete]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetUserId();

            await _cartRepository.ClearCartAsync(userId);

            return Ok(new { message = "Cart cleared" });
        }
    }
}
