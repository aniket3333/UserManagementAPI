using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Code { get; set; }  
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
