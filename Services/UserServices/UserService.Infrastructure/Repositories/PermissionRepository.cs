using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories
{

    public class PermissionRepository : IPermissionRepository
    {
        private readonly UserDbContext _context;

        public PermissionRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            //return await _context.Permissions
            //    .Where(p => p.IsActive)
            //    .OrderBy(p => p.Code)
            //    .ToListAsync();

            return await _context.Permissions
                            .OrderBy(p => p.Code)
                            .ToListAsync();
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }

        public async Task CreateAsync(Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Permission permission)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Permission permission)
        {
            permission.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }

}
