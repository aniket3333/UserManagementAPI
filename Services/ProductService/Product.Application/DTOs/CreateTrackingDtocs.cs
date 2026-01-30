using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTOs
{
    public class CreateTrackingDtocs
    {
        public int OrderId { get; set; }
        public string Description { get; set; } = "Order Placed";
    }
}
