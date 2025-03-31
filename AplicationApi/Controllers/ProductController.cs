using Microsoft.AspNetCore.Mvc;
using AplicationApi.Models;
using AplicationApi.Services;

namespace AplicationApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() => Ok(_productService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newProduct = _productService.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _productService.Update(id, product);
            return success ? NoContent() : NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _productService.GetById(id);
            if (existing == null) return NotFound();

            _productService.Delete(id);
            return NoContent();
        }
    }
}
