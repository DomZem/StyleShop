using AutoMapper;
using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Queries.GetOrderDetailsById
{
    public class GetOrderDetailsByIdQueryHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public GetOrderDetailsByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(request.Id);

            var dto = _mapper.Map<OrderDto>(order); 

            return dto;
        }
    }
}
