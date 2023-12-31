﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StyleShop.Domain.Interfaces;
using StyleShop.Infrastructure.Persistence;
using StyleShop.Infrastructure.Repositories;

namespace StyleShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StyleShopDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("StyleShop")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()   
                .AddEntityFrameworkStores<StyleShopDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();    
        }
    }
}
