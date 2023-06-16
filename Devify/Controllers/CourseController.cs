using Devify.Application;
using Devify.Entity;
using Devify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseService;
        public CourseController(ICourseRepository courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("get-detail-course", Name = "getDetailCourse")]
        public IActionResult getDetailByName(string name)
        {
            var result = _courseService.GetCourseByName(name);
            if (result == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "invalid"
                });
            }
            
      
            var model = new Detail_Course
            {
                CourseId = result.CourseId,
                Title = result.Title,
                Purchased = result.Purchased,
                Price = result.Price,
                Description = result.Description,
                Image = result.Image,
                Link = result.Link,
                Creator = new Detail_Course_Creator
                {
                    CreatorId = result.CreatorId,
                    Name = result.Creator.Name,
                    Link = result.Creator.Link,
                    Image = result.Creator.Image
                },
                Languages = new Detail_Course_LanguageList
                {
                    LanguageItems = result.CourseLanguages.Select(cl => new Detail_Course_LanguageItem
                    {
                        LanguageId = cl.Language.LanguageId,
                        Name = cl.Language.Name
                    })
                },
                Chapters = result.Chapters.Select(ch => new Detail_Course_ChapterList
                {
                    ChapterId = ch.ChapterId,
                    Name = ch.Name,
                    Description = ch.Description,
                    Lessons = ch.Lessons.Select(ls => new Detail_Course_LessonList
                    {
                        LessonId = ls.LessonId,
                        Name = ls.Name
                    })
                }),
            };
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get course success",
                Data = model
            });
        }

        [HttpGet("get-all-course", Name = "getAllCourse")]
        public IActionResult getAllCourse()
        {
            return Ok(new API_Response
            {
                Success = true,
                Message = "Get all course success",
                Data = _courseService.GetAllCourse()
            });
        }
    }
}
