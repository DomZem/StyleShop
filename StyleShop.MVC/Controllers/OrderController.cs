using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleShop.Application.Order.Commands.CreateOrder;
using StyleShop.Application.Order.Queries.GetAllOrders;
using StyleShop.Application.Order.Queries.GetOrderDetailsById;
using StyleShop.Application.Product.Queries.GetAllProducts;

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

        public async Task<IActionResult> Create()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            ViewBag.Products = products.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = $"{o.Name} - {o.Price}$, {o.Quantity} Left" });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _mediator.Send(new GetOrderDetailsByIdQuery(id));
            return View(dto);
        }
    }
}
