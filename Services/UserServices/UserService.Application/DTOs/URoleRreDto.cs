using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.DTOs
{
    public class URoleRreDto
    {
        public string Role { get; set; }
    }

    public class URoleUpdateRreDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }

    public class URoleRespDto{
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;    
    }
}
