using Microsoft.EntityFrameworkCore;
using StyleShop.Domain.Entities;

namespace StyleShop.Infrastructure.Persistence
{
    public class StyleShopDbContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }    

        public DbSet<OrderStatus> OrderStatuses { get; set; }   

        public DbSet<Order> Orders { get; set; }

        public StyleShopDbContext(DbContextOptions<StyleShopDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<OrderStatus>()
                .HasIndex(os => os.Name)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .OwnsOne(o => o.OrderAddress);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(os => os.Orders)
                .WithOne(o => o.OrderStatus)
                .HasForeignKey(p => p.OrderStatusId);
        }
    }
}
