using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using Product.Infrastructure.Repository;

namespace Product.API.Controller
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositories _repo;

        public ProductController(IProductRepositories repo)
        {
            _repo = repo;
        }

        // CREATE PRODUCT
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Produc
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                DiscountPrice = dto.DiscountPrice,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
                SKU = dto.SKU,
                ImageUrl = dto.ImageUrl,
                IsActive = true
            };

            var createdProduct = await _repo.AddAsync(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdProduct.Id },
                createdProduct
            );
        }

        // GET ALL PRODUCTS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET PRODUCT BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET PRODUCTS BY CATEGORY
        [HttpGet("by-category/{categoryId:int}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            return Ok(await _repo.GetByCategoryIdAsync(categoryId));
        }

        // UPDATE PRODUCT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Produc
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                DiscountPrice = dto.DiscountPrice,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
                SKU = dto.SKU,
                ImageUrl = dto.ImageUrl,
                IsActive = dto.IsActive
            };

            var updatedProduct = await _repo.UpdateAsync(product);

            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        // DELETE PRODUCT (SOFT DELETE)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
