using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email); 
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        

        public string GenerateToken(
            User user,
            string roleName,
            List<string> permissions,
            bool rememberMe)
        {
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            if (string.IsNullOrEmpty(secret))
                throw new Exception("JWT_SECRET missing");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = rememberMe
                ? DateTime.UtcNow.AddDays(30)
                : DateTime.UtcNow.AddHours(2);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("name", user.Name),
        new Claim(ClaimTypes.Role, roleName)
    };

            // ✅ ADD permissions as multiple claims
            foreach (var permission in permissions)
            {
                claims.Add(new Claim("permission", permission));
            }

            var token = new JwtSecurityToken(
                issuer: "UserService",
                audience: "UserServiceClient",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        public async Task<List<UserRole>> GetAllRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<List<UserRole>> GetRoleDropdownAsync()
        {
            return await _context.Roles.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<UserRole?> GetRoleByIdAsync(int id)
        {
           return await _context.Roles.FindAsync(id);
        }

        public async Task AddRoleAsync(UserRole role)
        {
            await _context.Roles.AddAsync(role);
        }

        public async Task UpdateRoleAsync(UserRole role)
        {
             _context.Roles.Update(role);
        }

        public async Task DeleteRoleAsync(UserRole role)
        {
            _context.Roles.Remove(role);
        }

    }
}
