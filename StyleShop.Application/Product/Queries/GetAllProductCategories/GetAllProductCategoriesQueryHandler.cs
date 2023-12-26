using AutoMapper;
using MediatR;
using StyleShop.Domain.Entities;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IEnumerable<ProductCategory>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductCategoriesQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategory>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductCategories();
        }
    }
}
