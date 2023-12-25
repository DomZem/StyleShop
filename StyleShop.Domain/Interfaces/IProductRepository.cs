using StyleShop.Domain.Entities;

namespace StyleShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product);
    }
}
