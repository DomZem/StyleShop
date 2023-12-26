using AutoMapper;
using StyleShop.Application.Product;

namespace StyleShop.Application.Mappings
{
    public class StyleShopMappingProfile : Profile
    {
        public StyleShopMappingProfile()
        {
            CreateMap<ProductDto, Domain.Entities.Product>().ReverseMap();    
        }
    }
}
