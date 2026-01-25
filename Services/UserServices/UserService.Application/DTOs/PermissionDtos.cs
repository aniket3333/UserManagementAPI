using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.DTOs
{
    public class PermissionCreateDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class PermissionUpdateDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool  IsActive { get; set; }
    }

    public class PermissionResponseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

}
