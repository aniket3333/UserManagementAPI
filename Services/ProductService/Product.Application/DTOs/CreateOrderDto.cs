using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTOs
{
    namespace OrderService.Application.DTOs
    {
        public class CreateOrderDto
        {
            public List<OrderItemDto> Items { get; set; } = new();
        }
    }

}
