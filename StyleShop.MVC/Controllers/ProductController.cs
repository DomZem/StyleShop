using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleShop.Application.Product;
using StyleShop.Application.Services;

namespace StyleShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _productService.GetProductCategories();
            ViewBag.Categories = categories.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            await _productService.Create(product);
            return RedirectToAction("Index", "Home");
        }
    }
}
