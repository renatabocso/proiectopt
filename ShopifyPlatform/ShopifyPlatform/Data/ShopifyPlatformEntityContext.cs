using Microsoft.EntityFrameworkCore;

namespace ShopifyPlatform.Data
{
    public class ShopifyPlatformEntityContext : DbContext
    {
        public ShopifyPlatformEntityContext(DbContextOptions<ShopifyPlatformEntityContext> options)
            : base(options)
        {
        }

        public DbSet<ShopifyPlatform.Models.Customer> Customer { get; set; } = default!;

        public DbSet<ShopifyPlatform.Models.Order> Order { get; set; }

        public DbSet<ShopifyPlatform.Models.Product> Product { get; set; }
    }
}
