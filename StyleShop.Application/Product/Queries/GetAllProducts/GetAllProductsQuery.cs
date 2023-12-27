using MediatR;

namespace StyleShop.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
    }
}
