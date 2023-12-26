using AutoMapper;
using MediatR;
using StyleShop.Domain.Entities;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Queries.GetAllOrderStatuses
{
    public class GetAllOrderStatusesQueryHandler : IRequestHandler<GetAllOrderStatusesQuery, IEnumerable<OrderStatus>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderStatusesQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderStatus>> Handle(GetAllOrderStatusesQuery request, CancellationToken cancellationToken)
        {
            var orderStatuses = await _orderRepository.GetOrderStatuses();
            var dtos = _mapper.Map<IEnumerable<OrderStatus>>(orderStatuses);

            return dtos;
        }
    }
}
