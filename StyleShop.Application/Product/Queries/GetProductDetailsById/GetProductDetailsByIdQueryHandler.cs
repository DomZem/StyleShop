using AutoMapper;
using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Queries.GetProductDetailsById
{
    public class GetProductDetailsByIdQueryHandler : IRequestHandler<GetProductDetailsByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public GetProductDetailsByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
    }
}
