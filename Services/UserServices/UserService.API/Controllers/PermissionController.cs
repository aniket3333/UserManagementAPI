using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _repo;

        public PermissionController(IPermissionRepository repo)
        {
            _repo = repo;
        }

        // 🔹 GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permissions = await _repo.GetAllAsync();

            var result = permissions.Select(p => new PermissionResponseDto
            {
                Id = p.Id,
                Code = p.Code,
                Description = p.Description,
                IsActive = p.IsActive
            });

            return Ok(result);
        }

        // 🔹 GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _repo.GetByIdAsync(id);
            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        // 🔹 CREATE
        [HttpPost]
        public async Task<IActionResult> Create(PermissionCreateDto dto)
        {
            var permission = new Permission
            {
                Code = dto.Code.ToUpper(),
                Description = dto.Description
            };

            await _repo.CreateAsync(permission);
            return Ok(permission);
        }

        // 🔹 UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PermissionUpdateDto dto)
        {
            var permission = await _repo.GetByIdAsync(id);
            if (permission == null)
                return NotFound();

            permission.Code = dto.Code.ToUpper();
            permission.Description = dto.Description;
            permission.IsActive = dto.IsActive;

            await _repo.UpdateAsync(permission);
            return Ok(permission);
        }

        // 🔹 DELETE (Soft)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _repo.GetByIdAsync(id);
            if (permission == null)
                return NotFound();

            await _repo.DeleteAsync(permission);
            return Ok("Permission removed");
        }
    }

}
