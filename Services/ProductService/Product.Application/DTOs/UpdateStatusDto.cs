using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTOs
{
    public class UpdateStatusDto
    {
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
