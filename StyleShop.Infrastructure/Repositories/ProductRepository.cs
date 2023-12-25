using Microsoft.EntityFrameworkCore;
using StyleShop.Domain.Entities;
using StyleShop.Domain.Interfaces;
using StyleShop.Infrastructure.Persistence;

namespace StyleShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StyleShopDbContext _dbContext;

        public ProductRepository(StyleShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Product product)
        {
            _dbContext.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _dbContext.ProductCategories.ToListAsync();
        }
    }
}
