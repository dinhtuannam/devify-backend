using Devify.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LanguageController(ILogger<LanguageController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-all-language")]
        public async Task<IActionResult> GetALlLanguage()
        {
            var model = await _unitOfWork.LanguageRepository.GetAllAsync();
            return Ok(model);
        }
    }
}
