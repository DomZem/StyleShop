using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StyleShop.Application.ApplicationUser;
using StyleShop.Application.Mappings;
using StyleShop.Application.Product.Commands.CreateProduct;

namespace StyleShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateProductCommand));

            services.AddAutoMapper(typeof(StyleShopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
        }
    }
}
