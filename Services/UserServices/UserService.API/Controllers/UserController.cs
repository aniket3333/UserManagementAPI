using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllAsync();

            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                RoleId = u.RoleId,
                Role = u.Role,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt
            });

            return Ok(result);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                RoleId = user.RoleId,
                Role = user.Role,
                IsActive = user.IsActive
            });
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var role = await _repository.GetRoleByIdAsync(dto.RoleId);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash,
                RoleId = dto.RoleId,
                Role = role.Role,
                IsActive = true
            };

            await _repository.AddAsync(user);
            await _repository.SaveAsync();
            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email,
                user.RoleId,
                user.IsActive,
                user.CreatedAt
            });
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserCreateDto dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();
            var role = await _repository.GetRoleByIdAsync(dto.RoleId);
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.RoleId = dto.RoleId;
            user.Role = role.Role;

            await _repository.UpdateAsync(user);
            await _repository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            await _repository.DeleteAsync(user);
            await _repository.SaveAsync();

            return NoContent();
        }


    }
}
