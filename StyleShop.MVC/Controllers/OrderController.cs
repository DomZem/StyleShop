using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleShop.Application.Order.Commands.CreateOrder;
using StyleShop.Application.Order.Commands.DeleteOrder;
using StyleShop.Application.Order.Commands.EditOrder;
using StyleShop.Application.Order.Queries.GetAllOrders;
using StyleShop.Application.Order.Queries.GetAllOrderStatuses;
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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return View(orders);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            ViewBag.Products = products.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = $"{o.Name} - {o.Price}$, {o.Quantity} Left" });
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _mediator.Send(new GetOrderDetailsByIdQuery(id));
            return View(dto);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetOrderDetailsByIdQuery(id));
            EditOrderCommand model = _mapper.Map<EditOrderCommand>(dto);

            var orderStatuses = await _mediator.Send(new GetAllOrderStatusesQuery());
            ViewBag.OrderStatuses = orderStatuses.Select(os => new SelectListItem() { Value = os.Id.ToString(), Text = os.Name });

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, EditOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _mediator.Send(new GetOrderDetailsByIdQuery(id));
            DeleteOrderCommand model = _mapper.Map<DeleteOrderCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id, DeleteOrderCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
