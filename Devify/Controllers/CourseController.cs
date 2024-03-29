﻿using Devify.Application.DTO;
using Devify.Application.Features.Course.Commands;
using Devify.Application.Features.Course.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Devify.Filters;
using Devify.Models;

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

        [HttpGet]
        [Route("get-all-course")]
        [Cache(120)]
        public async Task<IActionResult> getAllCourse([FromQuery] CourseSearchParam req)
        {
            ApiResponse result = await _mediator.Send(new GetAllCourseQuery(req.query, req.pageSize,req.page,req.cat,req.lang,req.lvl));
            return Program.my_api.response(result);
        }

        [HttpGet]
        [Route("{code}/get-view-info-course")]
        [Cache(120,true)]
        public async Task<IActionResult> getViewInfoCourse(string code)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(new GetCourseQuery(code,false,user,role));
            return Program.my_api.response(result);
        }

        [HttpGet]
        [Route("{code}/get-course")]
        [Role("admin","manager","creator")]
        [Cache(120,true)]
        public async Task<IActionResult> getCourse(string code)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(new GetCourseQuery(code,true,user,role));
            return Program.my_api.response(result);
        }


        [HttpGet]
        [Route("{code}/get-learning-info")]
        [User]
        [Cache(120,true)]
        public async Task<IActionResult> getLearningInfo(string code)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(new GetLearningInfoQuery(code, user, role));
            return Program.my_api.response(result);
        }

        [HttpPost]
        [Role("admin","creator")]
        [Route("create-new-course")]
        public async Task<IActionResult> CreateCourse(CreateCourseModel req)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            ApiResponse result = await _mediator.Send(new CreateCourseCommand(
                user,
                req.title,
                req.des,
                req.price,
                req.salePrice,
                req.issale,
                req.category,
                req.languages,
                req.levels
            ));
            return Program.my_api.response(result);
        }

        [HttpPost]
        [Route("{code}/upload-image")]
        public async Task<IActionResult> uploadImageCourse(string code,IFormFile file)
        {
            ApiResponse result = await _mediator.Send(new UploadCourseImageCommand(code, file));
            return Program.my_api.response(result);
        }

        [HttpPost]
        [Route("lesson/{code}/upload-image")]
        public async Task<IActionResult> uploadImageLesson(string code, IFormFile file)
        {
            ApiResponse result = await _mediator.Send(new UploadLessonImageCommand(code, file));
            return Program.my_api.response(result);
        }

        [HttpPost]
        [Route("lesson/{code}/upload-video")]
        public async Task<IActionResult> uploadVideoLesson(string code, IFormFile file)
        {
            ApiResponse result = await _mediator.Send(new UploadLessonVideoCommand(code, file));
            return Program.my_api.response(result);
        }

        [HttpDelete]
        [Role("admin", "creator")]
        [Route("{code}")]
        public async Task<IActionResult> DeleteCourse(string code)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(new DeleteCourseCommand(code,user,role));
            return Program.my_api.response(result);
        }

        [HttpPut]
        [Role("admin", "creator")]
        [Route("edit-course")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseModel req)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new UpdateCourseCommand(user,role,req.code,req.title,req.des,req.price, req.salePrice,req.issale, req.category,req.languages,req.levels));
            return Program.my_api.response(result);
        }

        [HttpPost]
        [Role("admin", "creator")]
        [Route("{code}/add-chapter")]
        public async Task<IActionResult> AddChapter([FromRoute] string code,LearningCreateUpdateModel req)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new CreateChapterCommand(user, role, code, req.name, req.des, req.step));
            return Program.my_api.response(result);
        }

        [HttpPost]
        [Role("admin", "creator")]
        [Route("chapter/{code}/add-lesson")]
        public async Task<IActionResult> AddLesson([FromRoute] string code,LearningCreateUpdateModel req)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new CreateLessonCommand(user, role, code, req.name, req.des, req.step));
            return Program.my_api.response(result);
        }

        [HttpPut]
        [Role("admin", "creator")]
        [Route("chapter/{code}/update-chapter")]
        public async Task<IActionResult> UpdateChapter([FromRoute] string code,LearningCreateUpdateModel req)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new UpdateChapterCommand(user, role, code, req.name, req.des, req.step));
            return Program.my_api.response(result);
        }

        [HttpPut]
        [Role("admin", "creator")]
        [Route("chapter/lesson/{code}/update-lesson")]
        public async Task<IActionResult> UpdateLesson([FromRoute] string code,LearningCreateUpdateModel req)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new UpdateLessonCommand(user, role, code, req.name, req.des, req.step));
            return Program.my_api.response(result);
        }

        [HttpDelete]
        [Role("admin", "creator")]
        [Route("chapter/{code}/delete-chapter")]
        public async Task<IActionResult> DeleteChapter([FromRoute] string code)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new DeleteChapterCommand(user, role, code));
            return Program.my_api.response(result);
        }

        [HttpDelete]
        [Role("admin", "creator")]
        [Route("chapter/lesson/{code}/delete-lesson")]
        public async Task<IActionResult> DeleteLesson([FromRoute] string code)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse result = await _mediator.Send(
                new DeleteLessonCommand(user, role, code));
            return Program.my_api.response(result);
        }

    }
}
