using AutoMapper;
using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domain.Entities.Order>(request);

            _orderRepository.Delete(order);

            await _orderRepository.Commit();

            return Unit.Value;
        }
    }
}
