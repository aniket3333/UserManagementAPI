using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    namespace OrderService.Domain.Entities
    {
        public class OrderItem
        {
            public int Id { get; set; }

            public int OrderId { get; set; } // internal only
            public int ProductId { get; set; }

            public string ProductName { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }

}
