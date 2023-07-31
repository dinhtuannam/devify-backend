using Devify.Application.DTO;
using Devify.Application.Features.Course.Commands;
using Devify.Application.Features.Course.Queries;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Devify.Filters;

namespace Devify.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-course-by-slug", Name = "get-course-by-slug")]
        [Cache(120)]
        public async Task<IActionResult> getDetailBySlug(string slug)
        {
            var courseResult = await _mediator.Send(new GetDetailCourseBySlug { Slug = slug });
            
            if (courseResult == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = $"Cannot not find course with slug = {slug}",
                    ErrCode = "404"
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
        [Cache(120)]
        public async Task<IActionResult> getAllCourse()
        {
            var courseResult = await _mediator.Send(new GetAllCourse());
            if (courseResult == null)
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "Something wrong, please try again later !",
                    ErrCode = "404"
                });
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get all course success",
                Data = courseResult
            });
        }


        [HttpGet("get-learning-course", Name = "get-learning-course")]
        [Cache(120)]
        public async Task<IActionResult> getLearningCourse(string slug)
        {
            var courseResult = await _mediator.Send(new GetLearningCourse { Slug = slug });

            if (courseResult == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = $"Cannot not find learning course with slug = {slug}",
                    ErrCode = "404"
                });
            }
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get course success",
                Data = courseResult
                
            });
        }

        [HttpGet("{slug}/lesson/{lessonId}", Name = "get-learning-lesson")]
        [CourseOwner]
        [Cache(120)]
        public async Task<IActionResult> getLearningLesson(string slug,Guid lessonId)
        {
            var courseResult = await _mediator.Send(new GetLearningLesson { slugRequest = slug, lessonIdRequest = lessonId });
            if (courseResult == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = $"Cannot not find learning lesson with id = {lessonId}",
                    ErrCode = "404"
                });
            }
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get leaning lesson success",
                Data = courseResult

            });
        }


        [HttpPost("create-new-course", Name = "create-new-course")]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateCourseCommand { request = model });
                return result.Success ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }

    }
}
