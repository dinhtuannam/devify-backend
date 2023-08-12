using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Filters;
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

        [HttpGet]
        [Cache(3600)]
        public async Task<IActionResult> GetALlLanguage()
        {
            var model = await _unitOfWork.LanguageRepository.GetAllAsync();
            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewLanguage(Language model)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguage(Language model)
        {
            return Ok();
        }
    }
}
