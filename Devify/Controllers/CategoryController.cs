using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Filters;
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

        [HttpGet]
        [Cache(3600)]
        public async Task<IActionResult> GetALlCategory()
        {
            var model = await _unitOfWork.CategoryRepository.GetAllAsync();
            return Ok(model);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var model = await _unitOfWork.CategoryRepository.SearchAsAsync(name);
            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewCategory(Category model)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category model)
        {
            return Ok();
        }
    }
}
