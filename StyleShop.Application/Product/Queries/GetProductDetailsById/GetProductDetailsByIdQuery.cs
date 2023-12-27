using MediatR;

namespace StyleShop.Application.Product.Queries.GetProductDetailsById
{
    public class GetProductDetailsByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }

        public GetProductDetailsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
