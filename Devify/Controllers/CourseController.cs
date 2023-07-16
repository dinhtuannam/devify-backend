using AutoMapper;
using Devify.Application.Features.Course.Queries;
using Devify.Application.Interfaces;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;
        public CourseController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("get-course-by-slug", Name = "getDetailCourse")]
        //[Cache(120)]
        public async Task<IActionResult> getDetailBySlug(string slug)
        {
            var courseResult = await _mediator.Send(new GetDetailCourseBySlug { Slug = slug });           
            if (courseResult == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "invalid"
                });
            }
            //var model = _mapper.Map<Detail_Course>(result);
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get course success",
                Data = courseResult
            });
        }

        //[Cache(120)]
        [HttpGet("get-all-course", Name = "getAllCourse")]
        public IActionResult getAllCourse()
        {
            var courseResult = _mediator.Send(new GetAllCourse());
            if (courseResult == null)
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "Something wrong, please try again later !",
                });
            //var model = result.Select(course => _mapper.Map<All_Course_List>(course));
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get all course success",
                Data = courseResult
            });
        }
    }
}
