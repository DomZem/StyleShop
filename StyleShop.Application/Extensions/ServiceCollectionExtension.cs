using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using StyleShop.Application.Mappings;
using StyleShop.Application.Product;
using StyleShop.Application.Services;

namespace StyleShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(StyleShopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
        }
    }
}
