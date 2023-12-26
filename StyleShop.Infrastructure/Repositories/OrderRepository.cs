using Microsoft.EntityFrameworkCore;
using StyleShop.Domain.Entities;
using StyleShop.Domain.Interfaces;
using StyleShop.Infrastructure.Persistence;

namespace StyleShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StyleShopDbContext _dbContext;

        public OrderRepository(StyleShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.ToArrayAsync();
        }
    }
}
