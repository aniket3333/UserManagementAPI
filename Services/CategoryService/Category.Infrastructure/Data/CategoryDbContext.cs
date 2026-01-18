using Category.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Category.Infrastructure.Data
{
    public class CategoryDbContext: DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options)
                : base(options) { }

        public DbSet<Categor> Categories => Set<Categor>();
    }
}
