using Microsoft.AspNetCore.Mvc;
using N_tier.BLL.Services;


namespace N_tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _service.GetAllProducts();
            return Ok(products);
        }
    }
}
