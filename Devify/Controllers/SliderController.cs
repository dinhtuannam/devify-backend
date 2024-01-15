using Devify.Application.Interfaces;
using Devify.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/slider")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SliderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Cache(120)]
        public async Task<IActionResult> getAllSlider()
        {
            return Ok("_unitOfWork.SliderRepository.GetAll()");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            return Ok();
        }

    }
}
