using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
       : base(options) { }

        public DbSet<Produc> Products => Set<Produc>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produc>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Description).HasMaxLength(2000);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.DiscountPrice).HasColumnType("decimal(18,2)");
                entity.Property(p => p.SKU).IsRequired().HasMaxLength(100);

                entity.HasIndex(p => p.SKU).IsUnique();
                entity.HasIndex(p => p.CategoryId);
            });
        }

    }
}
