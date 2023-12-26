using MediatR;

namespace StyleShop.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : OrderDto, IRequest
    {
    }
}
