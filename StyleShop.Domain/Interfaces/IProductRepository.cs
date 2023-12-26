using StyleShop.Domain.Entities;

namespace StyleShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(int id);  

        Task<IEnumerable<ProductCategory>> GetProductCategories();

        Task Commit();

    }
}
