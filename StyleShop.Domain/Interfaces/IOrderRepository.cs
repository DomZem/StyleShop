using StyleShop.Domain.Entities;

namespace StyleShop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

    }
}
