using AutoMapper;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Filters;
using Devify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseRepository courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [HttpGet("get-detail-course", Name = "getDetailCourse")]
        [Cache(120)]
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
            var model = _mapper.Map<Detail_Course>(result);
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get course success",
                Data = model
            });
        }

        [Cache(120)]
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
            var model = result.Select(course => _mapper.Map<All_Course_List>(course));
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = "Get all course success",
                Data = model
            });
        }
    }
}
