using AutoMapper;
using StyleShop.Application.Product;
using StyleShop.Domain.Entities;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Create(ProductDto productDto)
        {
            var product = _mapper.Map<Domain.Entities.Product>(productDto);
            await _productRepository.Create(product);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _productRepository.GetProductCategories();
        }
    }
}
