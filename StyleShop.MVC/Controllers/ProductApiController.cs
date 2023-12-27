using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StyleShop.Infrastructure.Persistence;
using StyleShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StyleShop.MVC.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly StyleShopDbContext _dbContext;

        public ProductApiController(StyleShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Product product)
        {
            if (!User.IsInRole("admin"))
            {
                return StatusCode(401, "Unauthorized");
            }

            var result = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
  
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result = await _dbContext.Products.ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var product =  await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (!User.IsInRole("admin"))
            {
                return StatusCode(401, "Unauthorized");
            }

            var productToUpdate = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToUpdate == null || productToUpdate.Id != product.Id)
            {
                return NotFound();
            }

            var result = _dbContext.Update(productToUpdate);
            await _dbContext.SaveChangesAsync();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsInRole("admin"))
            {
                return StatusCode(401, "Unauthorized");
            }

            var productToRemove = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToRemove == null)
            {
                return NotFound();
            }

            var result = _dbContext.Products.Remove(productToRemove);
            await _dbContext.SaveChangesAsync();

            return Ok(result);
        }
    }
}
