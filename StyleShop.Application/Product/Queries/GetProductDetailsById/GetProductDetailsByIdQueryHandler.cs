using AutoMapper;
using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Queries.GetProductDetailsById
{
    public class GetProductDetailsByIdQueryHandler : IRequestHandler<GetProductDetailsByIdQuery, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public GetProductDetailsByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            return product;
        }
    }
}
