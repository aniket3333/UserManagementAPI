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

        public async Task UpdateAsync(Categor category){
              _context.Categories.Update(category);
             await _context.SaveChangesAsync();
        }

public async Task<IEnumerable<Categor>> GetDropdownAsync(){
return await _context.Categories.Where(x => x.IsActive).ToListAsync();
        }

public async Task DeleteAsync(Categor category){
            _context.Categories.Remove(category);
await _context.SaveChangesAsync();
        }
    }
}
