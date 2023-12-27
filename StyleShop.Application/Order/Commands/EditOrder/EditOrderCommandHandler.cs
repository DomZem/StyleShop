using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.EditOrder
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand>    
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IUserContext _userContext;

        public EditOrderCommandHandler(IOrderRepository orderRepository, IUserContext userContext)
        {
            _orderRepository = orderRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if (!currentUser.IsInRole("admin"))
            {
                return Unit.Value;
            }

            var order = await _orderRepository.GetById(request.Id);

            order.OrderStatusId = request.OrderStatusId;

            await _orderRepository.Commit();

            return Unit.Value;
        }
    }
}
