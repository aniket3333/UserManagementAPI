using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities
{
    public class UserRole
    {
public int Id { get; set; }
    public string Role { get; set; }
public bool IsActive { get; set; }
    }
}
