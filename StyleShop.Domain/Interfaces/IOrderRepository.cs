using StyleShop.Domain.Entities;

namespace StyleShop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task Create(Order order);

        Task<IEnumerable<Order>> GetAll();

        Task<Order> GetById(int id);

        void Delete(Order order);

        Task<IEnumerable<OrderStatus>> GetOrderStatuses();

        Task Commit();
    }
}
