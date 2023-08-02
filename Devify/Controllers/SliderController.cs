using Devify.Application.Features.Course.Queries;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Filters;
using Devify.Models;
using Microsoft.AspNetCore.Http;
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
            return Ok(_unitOfWork.SliderRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSlider(Slider model)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlider(Slider model)
        {
            return Ok();
        }
    }
}
