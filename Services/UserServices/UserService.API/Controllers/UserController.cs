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
                IsActive = u.IsActive
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
                IsActive = user.IsActive
            });
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                IsActive = true
            };

            await _repository.AddAsync(user);
            await _repository.SaveAsync();

            return Ok(user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserCreateDto dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.Name = dto.Name;
            user.Email = dto.Email;

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
