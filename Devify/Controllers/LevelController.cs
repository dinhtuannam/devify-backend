using Devify.Application.Interfaces;
using Devify.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/level")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelController(ILogger<LanguageController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLevel()
        {
            var model = await _unitOfWork.LevelRepository.GetAllAsync();
            return Ok(model);
        }
    }
}
