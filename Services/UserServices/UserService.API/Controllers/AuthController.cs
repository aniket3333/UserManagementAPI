using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly UserDbContext _context;

        public AuthController(
            IUserRepository userRepo, UserDbContext context)
        {
            _userRepo = userRepo;
_context = context;
        }

       
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            var role = await _context.Roles.FindAsync(user.RoleId);

            var permissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == role.Id)
                .Select(rp => rp.Permission.Code)
                .ToListAsync();

            var token = _userRepo.GenerateToken(
                user,
                role.Role,
                permissions,
                dto.RememberMe
            );

            return Ok(new { token });
        }



    }

}
