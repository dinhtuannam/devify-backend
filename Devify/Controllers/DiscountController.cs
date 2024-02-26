using Devify.Application.DTO;
using Devify.Application.Features.Discount.Commands;
using Devify.Application.Features.Discount.Queries;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Features.Language.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-discount")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllDiscount()
        {
            ApiResponse api = await _mediator.Send(new GetAllDiscountQuery());
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{code}/get-discount")]
        [Cache(3600)]
        public async Task<IActionResult> GetDiscount(string code)
        {
            ApiResponse api = await _mediator.Send(new GetDiscountQuery(code));
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("create-new-discount")]
        public async Task<IActionResult> AddNewDiscount(CreateDiscount model)
        {
            ApiResponse res = await _mediator.Send(new CreateLanguageCommand(model.code, model.name, model.des));
            return Program.my_api.response(res);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteDiscount(string code)
        {
            ApiResponse res = await _mediator.Send(new DeleteDiscountCommand(code));
            return Program.my_api.response(res);
        }

        [HttpPut]
        [Route("edit-discount")]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscount model)
        {
            ApiResponse res = await _mediator.Send(new UpdateLanguageCommand(model.code, model.name, model.des));
            return Program.my_api.response(res);
        }
    }
}
