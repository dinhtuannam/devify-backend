using Devify.Application.Features.Creator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/creator")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private IMediator _mediator;
        public CreatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllCreator()
        {
            return Ok();
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new GetCreatorByConditionQuery
            {
                condition = id,
                //type = ConditionEnum.ID
            });
            return new JsonResult(result)
            {
                StatusCode = int.Parse(result.ErrCode)
            };
        }

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var result = await _mediator.Send(new GetCreatorByConditionQuery
            {
                condition = slug,
                //type = ConditionEnum.SLUG
            });
            return new JsonResult(result)
            {
                StatusCode = int.Parse(result.ErrCode)
            }; 
        }

        [HttpGet("slug/{slug}/courses")]
        public async Task<IActionResult> GetCreatorCoursesBySlug(string slug)
        {
            var result = await _mediator.Send(new GetCreatorCoursesQuery
            {
                condition = slug,
                //type = ConditionEnum.SLUG
            });
            return new JsonResult(result)
            {
                StatusCode = int.Parse(result.ErrCode)
            };
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCreatorCoursesById(string id)
        {
            var result = await _mediator.Send(new GetCreatorCoursesQuery
            {
                condition = id,
                
            });
            return new JsonResult(result)
            {
                StatusCode = int.Parse(result.ErrCode)
            };
        }

       
    }
}
