using MediatR;
using StyleShop.Domain.Entities;

namespace StyleShop.Application.Product.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategory>>
    {
    }
}
