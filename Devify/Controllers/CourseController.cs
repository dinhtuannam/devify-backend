using Devify.Application.DTO;
using Devify.Application.Features.Course.Commands;
using Devify.Application.Features.Course.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Devify.Filters;
using Devify.Entity;
using Devify.Application.Interfaces;

namespace Devify.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        private IUnitOfWork _unitOfWork;
        public CourseController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("home", Name = "home")]
        [Cache(120)]
        public async Task<IActionResult> getHomeCourses()
        {
            return Ok();
        }

        [HttpGet("slug/{slug}", Name = "get-course-by-slug")]
        [Cache(120)]
        public async Task<IActionResult> getDetailBySlug(string slug)
        {
            var courseResult = await _mediator.Send(new GetDetailCourseBySlug { Slug = slug });
            
            if (courseResult == null)
            {
                return NotFound(new ApiResponse
                {
                    result = false,
                    message = $"Cannot not find course with slug = {slug}",
                    code = 404
                });
            }
            return Ok(new ApiResponse
            {
                result = true,
                message = "Get course success",
                data = courseResult,
                code = 200
            });
        }

        [HttpGet("search", Name = "search-course")]
        [Cache(120)]
        public async Task<IActionResult> searchCourse([FromQuery] CourseSearchParams model)
        {
            var result = await _unitOfWork.course.SearchCourse(model);
            return Ok(new ApiResponse
            {
                result = true,
                message = "searching course sucessfully",
                data = result,
                code = 200
            });
        }

        [HttpGet]
        [Cache(120)]
        public async Task<IActionResult> getAllCourse()
        {
            var courseResult = await _mediator.Send(new GetAllCourse());
            if (courseResult == null)
                return NotFound(new ApiResponse
                {
                    result = false,
                    message = "Something wrong, please try again later !",
                    code = 404
                });
            return Ok(new ApiResponse
            {
                result = true,
                message = "Get all course success",
                data = courseResult
            });
        }


        [HttpGet("{slug}/learning", Name = "get-learning-course")]
        [Cache(120)]
        public async Task<IActionResult> getLearningCourse(string slug)
        {
            var courseResult = await _mediator.Send(new GetLearningCourse { Slug = slug });

            if (courseResult == null)
            {
                return NotFound(new ApiResponse
                {
                    result = false,
                    message = $"Cannot not find learning course with slug = {slug}",
                    code = 404
                });
            }
            return Ok(new ApiResponse
            {
                result = true,
                message = "Get course success",
                data = courseResult
                
            });
        }

        [HttpGet("{slug}/lesson/{lessonId}", Name = "get-learning-lesson")]
        [Cache(120)]
        public async Task<IActionResult> getLearningLesson(string slug,Guid lessonId)
        {
            var courseResult = await _mediator.Send(new GetLearningLesson { slugRequest = slug, lessonIdRequest = lessonId });
            if (courseResult == null)
            {
                return NotFound(new ApiResponse
                {
                    result = false,
                    message = $"Cannot not find learning lesson with id = {lessonId}",
                    code = 404
                });
            }
            return Ok(new ApiResponse
            {
                result = true,
                message = "Get leaning lesson success",
                data = courseResult

            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateCourseCommand { request = model });
                return result.result ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(SqlCourse model)
        {
            return Ok();
        }

        [HttpPost("{courseId}/chapter")]
        public async Task<IActionResult> CreateCourseChapter([FromForm] CreateCourseChapterRequest model, Guid courseId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateCourseChapterCommand { request = model , CourseId = courseId });
                return result.result ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{courseId}/chapter")]
        public async Task<IActionResult> UpdateCourseChapter([FromForm] UpdateCourseChapterRequest model, Guid courseId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateCourseChapterCommand {  UpdateCourseChapterRequest = model, CourseId = courseId });
                return result.result ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("{courseId}/chapter/{chapterId}/lesson")]
        public async Task<IActionResult> CreateCourseLesson([FromForm] CreateCourseRequest model, string courseId , string chapterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateCourseCommand { request = model });
                return result.result ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{courseId}/chapter/{chapterId}/lesson")]
        public async Task<IActionResult> UpdateCourseLesson([FromForm] CreateCourseRequest model, string courseId, string chapterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateCourseCommand { request = model });
                return result.result ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
        }
    }
}
