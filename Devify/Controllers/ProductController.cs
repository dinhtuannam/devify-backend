using Devify.Application;
using Devify.Entity;
using Devify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productService;
        public ProductController(IProductRepository productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "getAllProduct")]
        public IActionResult GetAllProduct()
        {
            var model = _productService.GetAllProducts();
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "OK",
                Data = model
            });
        }
    }
}
