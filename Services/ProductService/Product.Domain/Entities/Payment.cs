using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
 
        public class Payment
        {
            public int Id { get; set; }

            public int OrderId { get; set; }
            public int UserId { get; set; }

            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; } = "UPI";
            public string Status { get; set; } = "Initiated";

            public string TransactionId { get; set; } = Guid.NewGuid().ToString();

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    

}
