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
        [Route("get-all-language")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllLanguage()
        {
            ApiResponse api = await _mediator.Send(new GetAllLanguageQuery());
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{code}/get-language")]
        [Cache(3600)]
        public async Task<IActionResult> GetLanguage(string code)
        {
            ApiResponse api = await _mediator.Send(new GetLanguageQuery(code));
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("create-new-language")]
        public async Task<IActionResult> AddNewLanguage(CreateLanguageModel model)
        {
            ApiResponse res = await _mediator.Send(new CreateLanguageCommand(model.code, model.name, model.des));
            return Program.my_api.response(res);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteLanguage(string code)
        {
            ApiResponse res = await _mediator.Send(new DeleteLanguageCommand(code));
            return Program.my_api.response(res);
        }

        [HttpPut]
        [Route("edit-language")]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageModel model)
        {
            ApiResponse res = await _mediator.Send(new UpdateLanguageCommand(model.code, model.name, model.des));
            return Program.my_api.response(res);
        }
    }
}
