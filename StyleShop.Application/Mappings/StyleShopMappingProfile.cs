using AutoMapper;
using StyleShop.Application.ApplicationUser;
using StyleShop.Application.Order;
using StyleShop.Application.Order.Commands.DeleteOrder;
using StyleShop.Application.Product;
using StyleShop.Application.Product.Commands.DeleteProduct;
using StyleShop.Application.Product.Commands.EditProduct;
using StyleShop.Domain.Entities;

namespace StyleShop.Application.Mappings
{
    public class StyleShopMappingProfile : Profile
    {
        public StyleShopMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<OrderDto, Domain.Entities.Order>()
                .ForMember(e => e.OrderAddress, opt => opt.MapFrom(src => new OrderAddress()
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Country = src.Country,
                }));

            CreateMap<Domain.Entities.Order, OrderDto>()
                .ForMember(dto => dto.IsVisible, opt => opt.MapFrom(src => user != null && (src.UserId == user.Id || user.IsInRole("admin"))))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.OrderAddress.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.OrderAddress.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.OrderAddress.PostalCode))
                .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.OrderAddress.Country));

            CreateMap<OrderDto, DeleteOrderCommand>();

            CreateMap<ProductDto, Domain.Entities.Product>().ReverseMap();

            CreateMap<ProductDto, EditProductCommand>();

            CreateMap<ProductDto, DeleteProductCommand>();
        }
    }
}
