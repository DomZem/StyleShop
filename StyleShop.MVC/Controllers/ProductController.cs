using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            await _productService.Create(product);
            return RedirectToAction("Index", "Home");
        }
    }
}
