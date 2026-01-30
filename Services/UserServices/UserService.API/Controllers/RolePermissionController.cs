using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using UserService.Application.DTOs;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.API.Controllers
{
    [Route("api/role-permissions")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
  
        private readonly UserDbContext _context;

        public RolePermissionController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AssignPermissions(
            RolePermissionDto dto)
        {
            // 1️⃣ Remove existing permissions for role
            var existing = _context.RolePermissions
                .Where(x => x.RoleId == dto.RoleId);

            _context.RolePermissions.RemoveRange(existing);

            // 2️⃣ Add new permissions
            foreach (var permissionId in dto.PermissionIds)
            {
                _context.RolePermissions.Add(new RolePermission
                {
                    RoleId = dto.RoleId,
                    PermissionId = permissionId
                });
            }

            // 3️⃣ Save
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Permissions assigned successfully"
            });
        }

        // GET: api/role-permissions/{roleId}
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetPermissionsByRole(int roleId)
        {
            var permissionIds = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            return Ok(permissionIds); // Returns a list of assigned permission IDs
        }
    }

}
