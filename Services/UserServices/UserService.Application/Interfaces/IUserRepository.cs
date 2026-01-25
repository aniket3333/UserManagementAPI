using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task SaveAsync();

        //public string GenerateToken(User user, string roleName, bool rememberMe);
        public string GenerateToken(
            User user,
            string roleName,
            List<string> permissions,
            bool rememberMe);



        Task<List<UserRole>> GetAllRoleAsync();
        Task<List<UserRole>> GetRoleDropdownAsync();
        
                Task<UserRole?> GetRoleByIdAsync(int id);
        Task AddRoleAsync(UserRole user);
        Task UpdateRoleAsync(UserRole user);
        Task DeleteRoleAsync(UserRole user);
       


    }
}
