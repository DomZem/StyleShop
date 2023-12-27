using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.EditOrder
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand>    
    {
        private readonly IOrderRepository _orderRepository;

        public EditOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            // Check if user has role admin
            var order = await _orderRepository.GetById(request.Id);

            order.OrderStatusId = request.OrderStatusId;

            await _orderRepository.Commit();

            return Unit.Value;
        }
    }
}
