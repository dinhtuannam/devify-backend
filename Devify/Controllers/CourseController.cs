using AutoMapper;
using Devify.Application.Features.Course.Queries;
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

        [HttpGet("get-course-by-slug", Name = "get-course-by-slug")]
        //[Cache(120)]
        public async Task<IActionResult> getDetailBySlug(string slug)
        {
            var courseResult = await _mediator.Send(new GetDetailCourseBySlug { Slug = slug });
            
            if (courseResult == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = $"Cannot not find course with slug = {slug}"
                });
            }
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get course success",
                Data = courseResult
            });
        }

        
        [HttpGet("get-all-course", Name = "get-all-course")]
        //[Cache(120)]
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

        [HttpPost("create-new-course", Name = "create-new-course")]
        public async Task<IActionResult> Upload([FromForm] Create_Course p)
        {
            if (p.Image.Length > 0)
            {
                
                var fileName = DateTime.UtcNow.ToString("yymmssfff") + p.Image.FileName;
                //await UploadToFirebase(p.Image.OpenReadStream(),fileName);
            }

            return Ok(p.Image.FileName);
        }

        
    }
}
