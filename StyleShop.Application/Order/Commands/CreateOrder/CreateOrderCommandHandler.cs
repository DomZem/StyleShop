using AutoMapper;
using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;   
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domain.Entities.Order>(request);
            order.OrderStatusId = 1;
            await _orderRepository.Create(order);

            return Unit.Value;
        }
    }
}
