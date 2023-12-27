using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StyleShop.Domain.Entities;

namespace StyleShop.Infrastructure.Persistence
{
    public class StyleShopDbContext : IdentityDbContext
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

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(pc => pc.Name)
                .IsUnique();

            modelBuilder.Entity<OrderStatus>()
                .HasIndex(os => os.Name)
                .IsUnique();

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(os => os.Orders)
                .WithOne(o => o.OrderStatus)
                .HasForeignKey(p => p.OrderStatusId);

            #region === Seed ===

            // Tester
            string TESTER_USER_ID = Guid.NewGuid().ToString();

            var testerUser = new IdentityUser
            {
                Id = TESTER_USER_ID,
                Email = "tester@gmail.com",
                EmailConfirmed = true,
                UserName = "tester",
                NormalizedUserName = "TESTER"
            };

            PasswordHasher<IdentityUser> testerPh = new PasswordHasher<IdentityUser>();
            testerUser.PasswordHash = testerPh.HashPassword(testerUser, "zaq1@WSX");

            testerUser.NormalizedUserName = testerUser.Email.ToUpper();
            testerUser.NormalizedEmail = testerUser.Email.ToUpper();
            testerUser.LockoutEnabled = true;
            testerUser.LockoutEnd = null;

            // Admin
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            // Hash admin password
            PasswordHasher<IdentityUser> adminPh = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = adminPh.HashPassword(admin, "zaq1@WSX");

            admin.NormalizedUserName = admin.Email.ToUpper();
            admin.NormalizedEmail = admin.Email.ToUpper();
            admin.LockoutEnabled = true;
            admin.LockoutEnd = null;

            // Save users
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(testerUser);

            // Add role to admin
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<ProductCategory>()
                .HasData
                (
                    new ProductCategory() { Id = 1, Name = "Electronics" },
                    new ProductCategory() { Id = 2, Name = "Fashion" },
                    new ProductCategory() { Id = 3, Name = "Entertainment" }
                );

            modelBuilder.Entity<Product>()
                .HasData
                (
                    new Product() { Id = 1, Name = "Iphone 13", Description = "The iPhone 13, introduced in 2021, is part of Apple's flagship smartphone series.", Price = 3100, Quantity = 100, ProductCategoryId = 1 },
                    new Product() { Id = 2, Name = "Nike sports sweatshirt", Description = "Elevate your athletic wardrobe with the Nike Dri-FIT Performance Crewneck Sweatshirt, a perfect blend of style and functionality.", Price = 119.99M, Quantity = 100, ProductCategoryId = 2 },
                    new Product() { Id = 3, Name = "Game of Thrones - A Clash of Kingdoms", Description = "Dive into the epic realm of Westeros with 'A Clash of Kingdoms,' the latest installment in the gripping 'Game of Thrones' series by George R.R. Martin.", Price = 49.99M, Quantity = 100, ProductCategoryId = 3 }
                );

            modelBuilder.Entity<OrderStatus>()
                .HasData
                (
                    new OrderStatus() { Id = 1, Name = "Pending" },
                    new OrderStatus() { Id = 2, Name = "Processing" },
                    new OrderStatus() { Id = 3, Name = "Shipped" },
                    new OrderStatus() { Id = 4, Name = "Delivered" }
                );

            modelBuilder.Entity<Order>()
                .HasData
                (
                    new Order() { Id = 1, ProductQuantity = 1, OrderStatusId = 1, ProductId = 1, UserId = TESTER_USER_ID },
                    new Order() { Id = 2, ProductQuantity = 2, OrderStatusId = 2, ProductId = 2, UserId = TESTER_USER_ID },
                    new Order() { Id = 3, ProductQuantity = 3, OrderStatusId = 4, ProductId = 3, UserId = TESTER_USER_ID }
                );

            modelBuilder.Entity<Order>()
                .OwnsOne(o => o.OrderAddress)
                .HasData(
                    new { OrderId = 1, Street = "789 Pine Lane", City = "Another City", PostalCode = "54321", Country = "UK" },
                    new { OrderId = 2, Street = "123 Main Street", City = "Anytown", PostalCode = "12345", Country = "USA" },
                    new { OrderId = 3, Street = "456 Oak Avenue", City = "Sometown", PostalCode = "67890", Country = "Canada" }
                );
            #endregion
        }
    }
}
