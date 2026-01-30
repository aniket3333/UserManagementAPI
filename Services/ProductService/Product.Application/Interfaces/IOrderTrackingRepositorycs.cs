using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface IOrderTrackingRepositorycs
    {
        Task AddAsync(OrderTracking tracking);
        Task<IEnumerable<OrderTracking>> GetByOrderIdAsync(int orderId);
        Task UpdateStatusAsync(int orderId, string status, string description);
    }
}
