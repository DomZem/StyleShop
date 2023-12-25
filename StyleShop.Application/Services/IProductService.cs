using StyleShop.Application.Product;

namespace StyleShop.Application.Services
{
    public interface IProductService
    {
        Task Create(ProductDto product);
    }
}
