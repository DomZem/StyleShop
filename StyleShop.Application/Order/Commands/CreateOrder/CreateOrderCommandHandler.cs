﻿using AutoMapper;
using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        private readonly IUserContext _userContext;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository ,IMapper mapper, IUserContext userContext)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;   
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderedProduct = await _productRepository.GetById(request.ProductId);
            orderedProduct.Quantity -= 1;

            await _productRepository.Commit();

            var order = _mapper.Map<Domain.Entities.Order>(request);
               
            order.OrderStatusId = 1;
            order.UserId = _userContext.GetCurrentUser().Id;

            await _orderRepository.Create(order);

            return Unit.Value;
        }
    }
}
