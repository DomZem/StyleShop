using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StyleShop.Application.Order.Queries.GetAllOrders;

namespace StyleShop.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return View(orders);    
        }
    }
}
