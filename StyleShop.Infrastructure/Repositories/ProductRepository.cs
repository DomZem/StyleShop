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
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToArrayAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.FirstAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _dbContext.ProductCategories.ToListAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(Product product)
        {
            _dbContext.Products.Remove(product);
        }
    }
}
