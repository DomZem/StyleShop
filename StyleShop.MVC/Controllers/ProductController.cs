using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleShop.Application.Product.Commands.CreateProduct;
using StyleShop.Application.Product.Queries.GetAllProductCategories;
using StyleShop.Application.Product.Queries.GetAllProducts;
using StyleShop.Application.Product.Queries.GetProductDetailsById;

namespace StyleShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _mediator.Send(new GetAllProductCategoriesQuery());
            ViewBag.Categories = categories.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });
            return View();
        }

        public async  Task<IActionResult> Details(int id) 
        {
            var dto = await _mediator.Send(new GetProductDetailsByIdQuery(id));
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
