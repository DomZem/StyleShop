using AutoMapper;
using StyleShop.Application.Product;
using StyleShop.Application.Product.Commands.EditProduct;

namespace StyleShop.Application.Mappings
{
    public class StyleShopMappingProfile : Profile
    {
        public StyleShopMappingProfile()
        {
            CreateMap<ProductDto, Domain.Entities.Product>().ReverseMap();

            CreateMap<ProductDto, EditProductCommand>();
        }
    }
}
