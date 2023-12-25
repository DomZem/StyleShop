using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StyleShop.Infrastructure.Persistence;

namespace StyleShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StyleShopDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("StyleShop")));
        }
    }
}
