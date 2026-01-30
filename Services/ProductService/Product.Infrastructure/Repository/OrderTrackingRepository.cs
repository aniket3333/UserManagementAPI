using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class OrderTrackingRepository: IOrderTrackingRepositorycs
    { 
        private readonly ProductDbContext _context;

        public OrderTrackingRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderTracking tracking)
        {
            _context.OrderTrackings.Add(tracking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderTracking>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderTrackings
                .Where(x => x.OrderId == orderId)
                .OrderBy(x => x.UpdatedAt)
                .ToListAsync();
        }

        public async Task UpdateStatusAsync(int orderId, string status, string description)
        {
            var tracking = new OrderTracking
            {
                OrderId = orderId,
                Status = status,
                Description = description,
                UpdatedAt = DateTime.UtcNow
            };

            _context.OrderTrackings.Add(tracking);
            await _context.SaveChangesAsync();
        }
    }
}
