using Microsoft.AspNetCore.Mvc;
using StyleShop.Infrastructure.Persistence;

namespace StyleShop.MVC.Controllers
{
    [Route("api/productCategories")]
    [ApiController]
    public class ProductCategoryApiController : ControllerBase
    {
        private readonly StyleShopDbContext _context;

        public ProductCategoryApiController(StyleShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.ProductCategories.ToList());
        }
    }
}
