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
        private IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-course-by-slug", Name = "getDetailCourse")]
        [Cache(120)]
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
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get course success",
                Data = courseResult
            });
        }

        
        [HttpGet("get-all-course", Name = "getAllCourse")]
        [Cache(120)]
        public async Task<IActionResult> getAllCourse()
        {
            var courseResult = await _mediator.Send(new GetAllCourse());
            if (courseResult == null)
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "Something wrong, please try again later !",
                });
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get all course success",
                Data = courseResult
            });
        }
    }
}
