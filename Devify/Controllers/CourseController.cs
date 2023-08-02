using Devify.Application.DTO;
using Devify.Application.Features.Course.Commands;
using Devify.Application.Features.Course.Queries;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Devify.Filters;
using Devify.Entity;

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

        [HttpGet("slug/{slug}", Name = "get-course-by-slug")]
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

        
        [HttpGet]
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


        [HttpGet("{slug}/learning", Name = "get-learning-course")]
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


        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateCourseCommand { request = model });
                return result.Success ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(Course model)
        {
            return Ok();
        }
    }
}
