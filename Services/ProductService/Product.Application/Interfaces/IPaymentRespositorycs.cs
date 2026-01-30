using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface IPaymentRespositorycs
    {
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> GetByOrderIdAsync(int orderId);
        Task UpdateStatusAsync(string transactionId, string status);
    }
}
