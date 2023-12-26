using AutoMapper;
using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Queries.GetAllOrders
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return dtos;
        }
    }
}
