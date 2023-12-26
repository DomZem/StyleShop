using MediatR;

namespace StyleShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderDto, IRequest
    {
    }
}
