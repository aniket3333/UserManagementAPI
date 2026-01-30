using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class OrderTracking
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int UserId { get; set; }

        public string Status { get; set; } = "Order Placed";
        public string Description { get; set; } = "Order has been placed";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

