using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface ICartRepository
    {

        // Get cart by user
        Task<Cart?> GetCartByUserIdAsync(int userId);

        // Add or update item in cart
        Task AddToCartAsync(
            int userId,
            int productId,
            string productName,
            decimal price,
            int quantity
        );

        // Remove single item
        Task RemoveItemAsync(int userId, int productId);

        // Clear entire cart
        Task ClearCartAsync(int userId);

        // Update quantity
        Task UpdateQuantityAsync(int userId, int productId, int quantity);
    }
}
