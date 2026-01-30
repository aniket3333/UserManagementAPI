using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.DTOs
{
    public class RolePermissionDto
    {
     
            public int RoleId { get; set; }
            public List<int> PermissionIds { get; set; }
        

    }
}
