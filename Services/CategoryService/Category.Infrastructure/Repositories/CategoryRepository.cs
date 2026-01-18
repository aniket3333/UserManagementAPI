using Category.Application.Interfaces;
using Category.Domain.Entities;
using Category.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
  
         private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<Categor> AddAsync(Categor category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Categor?> GetByIdAsync(int id)
            => await _context.Categories.FindAsync(id);

        public async Task<IEnumerable<Categor>> GetAllAsync()
            => await _context.Categories.ToListAsync();

    }
}
