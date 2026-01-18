using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using Product.Infrastructure.Repository;

namespace Product.API.Controller
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositories _repo;

        public ProductController(IProductRepositories repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = new Produc
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                IsActive = true
            };

            return Ok(await _repo.AddAsync(product));
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
            => Ok(await _repo.GetByCategoryIdAsync(categoryId));
    }

}
