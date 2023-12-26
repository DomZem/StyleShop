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

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.ToArrayAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _dbContext.Orders.FirstAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<OrderStatus>> GetOrderStatuses()
        {
            return await _dbContext.OrderStatuses.ToListAsync();
        }
    }
}
