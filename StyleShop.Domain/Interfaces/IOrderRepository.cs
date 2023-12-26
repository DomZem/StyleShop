using StyleShop.Domain.Entities;

namespace StyleShop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task Create(Order order);

        Task<IEnumerable<Order>> GetAll();

        Task<IEnumerable<OrderStatus>> GetOrderStatuses();
    }
}
