using Devify.Application.DTO;
using Devify.Application.Features.Category.Commands;
using Devify.Application.Features.Category.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-categories")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllCategories()
        {
            ApiResponse api = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(api);
        }

        [HttpGet]
        [Route("{code}/get-language")]
        [Cache(3600)]
        public async Task<IActionResult> GetCategory(string code)
        {
            ApiResponse api = await _mediator.Send(new GetCategoryQuery(code));
            return Ok(api);
        }

        [HttpPost]
        [Route("create-new-category")]
        public async Task<IActionResult> AddNewCategory(CreateCategoryModel model)
        {
            ApiResponse res = await _mediator.Send(new CreateCategoryCommand(model.code, model.name, model.des));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteCategory(string code)
        {
            ApiResponse res = await _mediator.Send(new DeleteCategoryCommand(code));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("edit-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryModel model)
        {
            ApiResponse res = await _mediator.Send(new UpdateCategoryCommand(model.code, model.name, model.des));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
