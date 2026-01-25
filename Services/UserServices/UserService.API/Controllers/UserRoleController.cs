using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserRoleController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllRoleAsync();

            var result = users.Select(u => new UserRole
            {
                Id = u.Id,
                Role = u.Role,
                IsActive = u.IsActive
            });

            return Ok(result);
        }
        [HttpGet("dropdown")]
        public async Task<IActionResult> GetRoles()
        {
            var users = await _repository.GetRoleDropdownAsync();

            var result = users.Select(u => new UserRole
            {
                Id = u.Id,
                Role = u.Role,
            });

            return Ok(result);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var user = await _repository.GetRoleByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(new UserRole
            {
                Id = user.Id,
                Role = user.Role,
                IsActive = user.IsActive
            });
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create(URoleRreDto dto)
        {
            var user = new UserRole
            {
                Role = dto.Role,
                IsActive = true
            };

            await _repository.AddRoleAsync(user);
            await _repository.SaveAsync();

            return Ok(user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,URoleUpdateRreDto dto)
        {
            var user = await _repository.GetRoleByIdAsync(id);
            if (user == null) return NotFound();

            user.Role = dto.Role;
            user.IsActive = dto.IsActive;

            await _repository.UpdateRoleAsync(user);
            await _repository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.GetRoleByIdAsync(id);
            if (user == null) return NotFound();

            await _repository.DeleteRoleAsync(user);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}

