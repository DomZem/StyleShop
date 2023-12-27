using AutoMapper;
using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Queries.GetOrderDetailsById
{
    public class GetOrderDetailsByIdQueryHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderDto?>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        private readonly IUserContext _userContext;

        public GetOrderDetailsByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper, IUserContext userContext)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<OrderDto?> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            var order = await _orderRepository.GetById(request.Id);
            
            if(order.User.Id != currentUser.Id && !currentUser.IsInRole("admin")) 
            {
                return null;
            }

            var dto = _mapper.Map<OrderDto>(order); 

            return dto;
        }
    }
}
