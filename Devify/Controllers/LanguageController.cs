using Devify.Application.DTO;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Features.Language.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-languages")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllLanguage()
        {
            ApiResponse api = await _mediator.Send(new GetAllLanguageQuery());
            return Ok(api);
        }

        [HttpGet]
        [Route("{code}/get-language")]
        [Cache(3600)]
        public async Task<IActionResult> GetLanguage(string code)
        {
            ApiResponse api = await _mediator.Send(new GetLanguageQuery(code));
            return Ok(api);
        }

        [HttpPost]
        [Route("create-new-language")]
        public async Task<IActionResult> AddNewLanguage(CreateLanguageModel model)
        {
            ApiResponse res = await _mediator.Send(new CreateLanguageCommand(model.code, model.name, model.des));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteLanguage(string code)
        {
            ApiResponse res = await _mediator.Send(new DeleteLanguageCommand(code));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("edit-language")]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageModel model)
        {
            ApiResponse res = await _mediator.Send(new UpdateLanguageCommand(model.code, model.name, model.des));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
