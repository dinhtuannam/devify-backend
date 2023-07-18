using Devify.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-all-category")]
        public async Task<IActionResult> GetALlCategory()
        {
            var model = await _unitOfWork.CategoryRepository.GetAll();
            return Ok(model);
        }

        [HttpGet("get-category-by-name")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var model = await _unitOfWork.CategoryRepository.SearchAsAsync(name);
            return Ok(model);
        }
    }
}
