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
            var creator = new Detail_Course_Creator
            {
                CreatorId = result.CreatorId,
                Name = result.Creator.Name,
                Link = result.Creator.Link,
                Image = result.Creator.Image
            };
            var categoryList = result.CourseCategories.Select(c => new Detail_Course_CategoryList
            {
                CategoryName = c.Category.CategoryName,
                CategoryId = c.Category.CategoryId,
            });
            var chapterList = result.Chapters.Select(ch => new Detail_Course_ChapterList
            {
                ChapterId = ch.ChapterId,
                Name = ch.Name,
                Description = ch.Description,
                Lessons = ch.Lessons.Select(ls => new Detail_Course_LessonList
                {
                    LessonId = ls.LessonId,
                    Name = ls.Name
                })
            });
            var languagesList = result.CourseLanguages.Select(l => new Detail_Course_LanguageList
            {
                LanguageId = l.Language.LanguageId,
                Name = l.Language.Name,
            });
            var model = new Detail_Course
            {
                CourseId = result.CourseId,
                Title = result.Title,
                Purchased = result.Purchased,
                Price = result.Price,
                Description = result.Description,
                Image = result.Image,
                Link = result.Link,
                Creator = creator,
                Languages = languagesList,
                Categories = categoryList,
                Chapters = chapterList
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
            var result = _courseService.GetAllCourse();
            if (result == null)
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "Something wrong, please try again later !",
                });
            var model = new All_Course_List
            {
                courseItems = result.Select(c => new All_Course_Item
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Purchased = c.Purchased,
                    Price = c.Price,
                    Link = c.Link,
                    Image = c.Image,
                    Creator = new Detail_Course_Creator
                    {
                        CreatorId = c.CreatorId,
                        Name = c.Creator.Name,
                        Link = c.Creator.Link,
                        Image = c.Creator.Image
                    },
                    Languages = c.CourseLanguages.Select(cl => new Detail_Course_LanguageList
                    {
                        LanguageId = cl.Language.LanguageId,
                        Name = cl.Language.Name
                    }),
                    Categories = c.CourseCategories.Select(cl => new Detail_Course_CategoryList
                    {
                        CategoryId = cl.Category.CategoryId,
                        CategoryName = cl.Category.CategoryName
                    })
                })
            };             
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get all course success",
                Data = model
            });
        }
    }
}
