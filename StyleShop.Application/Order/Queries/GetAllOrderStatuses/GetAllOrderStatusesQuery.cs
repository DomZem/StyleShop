using MediatR;
using StyleShop.Domain.Entities;

namespace StyleShop.Application.Order.Queries.GetAllOrderStatuses
{
    public class GetAllOrderStatusesQuery : IRequest<IEnumerable<OrderStatus>>
    {
    }
}
