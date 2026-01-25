using Category.Application.DTOs;
using Category.Application.Interfaces;
using Category.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Category.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var category = new Categor
            {
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true
            };

            var result = await _repo.AddAsync(category);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto category) {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return NotFound();
            result.Id = id; result.Name = category.Name; result.Description = category.Description; result.IsActive = category.IsActive;
            await _repo.UpdateAsync(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repo.GetAllAsync());

        [HttpGet("dropdown")]
        public async Task<IActionResult> CategoryDropdown(){
           var result = await _repo.GetDropdownAsync();
            var categgories = result.Select(u => new Categor{
Id = u.Id,
Name = u.Name,
            });
return Ok(categgories);

        }

        [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id){
            var result =await  _repo.GetByIdAsync(id);
                        if (result == null) return NotFound();
            var cate = new UpdateCategoryDto
            {
                 Id = id,
                 Name = result.Name,
Description = result.Description,
IsActive = result.IsActive,


            };
            return Ok(cate);
                    }


[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id){
            var result = await _repo.GetByIdAsync(id);
if( result == null) return NotFound();
           await  _repo.DeleteAsync(result);
return NoContent();
        }

    }

}
