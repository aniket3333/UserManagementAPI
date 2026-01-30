using Product.Domain.Entities.OrderService.Domain.Entities;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(int userId, List<OrderItem> items);
        Task<Order?> GetByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);
        Task UpdateStatusAsync(int orderId, string status);
    }
}
