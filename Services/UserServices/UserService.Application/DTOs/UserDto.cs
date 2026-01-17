using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.DTOs
{
    public class UserDto
    {
       public int Id { get; set; }
       public string Name { get; set; } = null!;
       public string Email { get; set; } = null!;
       public bool IsActive { get; set; }

    }
}
