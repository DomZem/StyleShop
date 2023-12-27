using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleShop.Application.Product.Commands.CreateProduct;
using StyleShop.Application.Product.Commands.DeleteProduct;
using StyleShop.Application.Product.Commands.EditProduct;
using StyleShop.Application.Product.Queries.GetAllProductCategories;
using StyleShop.Application.Product.Queries.GetAllProducts;
using StyleShop.Application.Product.Queries.GetProductDetailsById;

namespace StyleShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;   
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            var categories = await _mediator.Send(new GetAllProductCategoriesQuery());
            ViewBag.Categories = categories.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateProductCommand command)
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
            var dto = await _mediator.Send(new GetProductDetailsByIdQuery(id));
            return View(dto);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetProductDetailsByIdQuery(id));
            EditProductCommand model = _mapper.Map<EditProductCommand>(dto);

            var categories = await _mediator.Send(new GetAllProductCategoriesQuery());
            ViewBag.Categories = categories.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, EditProductCommand command)
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
            var dto = await _mediator.Send(new GetProductDetailsByIdQuery(id));
            DeleteProductCommand model = _mapper.Map<DeleteProductCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id, DeleteProductCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
