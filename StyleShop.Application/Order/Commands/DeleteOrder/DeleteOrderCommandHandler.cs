using AutoMapper;
using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        private readonly IUserContext _userContext;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUserContext userContext)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userContext = userContext; 
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if (!currentUser.IsInRole("admin"))
            {
                return Unit.Value;
            }

            var order = _mapper.Map<Domain.Entities.Order>(request);

            _orderRepository.Delete(order);

            await _orderRepository.Commit();

            return Unit.Value;
        }
    }
}
