using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Produc
    {
        public int Id { get; set; }

        // Basic Info
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Pricing
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }

        // Inventory
        public int StockQuantity { get; set; }
        public bool IsInStock => StockQuantity > 0;

        // Category
        public int CategoryId { get; set; }

        // Tracking & Status
        public string SKU { get; set; } = string.Empty; // Unique product code
        public bool IsActive { get; set; } = true;

        // Media
        public string ImageUrl { get; set; } = string.Empty;

        // Auditing (VERY IMPORTANT for orders & payments)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

}
