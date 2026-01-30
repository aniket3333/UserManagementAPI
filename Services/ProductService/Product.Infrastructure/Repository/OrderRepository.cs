using Product.Application.Interfaces;
using Product.Domain.Entities.OrderService.Domain.Entities;
using Product.Domain.Entities;
using Product.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    
    {
         private readonly ProductDbContext _context;

        public OrderRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(int userId, List<OrderItem> items)
        {
            var total = items.Sum(x => x.Price * x.Quantity);

            var order = new Order
            {
                UserId = userId,
                TotalAmount = total,
                Items = items
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return;

            order.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
