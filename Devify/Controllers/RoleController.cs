using Devify.Application.DTO;
using Devify.Application.Features.Role.Commands;
using Devify.Application.Features.Role.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-role")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllRoles()
        {
            ApiResponse api = await _mediator.Send(new GetListRoleQuery());
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{code}/get-role")]
        [Cache(3600)]
        public async Task<IActionResult> GetRole(string code)
        {
            ApiResponse api = await _mediator.Send(new GetRoleQuery(code));
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("create-new-role")]
        public async Task<IActionResult> AddNewRole(CreateRoleModel model)
        {
            ApiResponse api = await _mediator.Send(new CreateRoleCommand(model.code, model.name, model.des));
            return Program.my_api.response(api);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteRole(string code)
        {
            ApiResponse api = await _mediator.Send(new DeleteRoleCommand(code));
            return Program.my_api.response(api);
        }

        [HttpPut]
        [Route("edit-role")]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel model)
        {
            ApiResponse api = await _mediator.Send(new UpdateRoleCommand(model.code, model.name, model.des));
            return Program.my_api.response(api);
        }
    }
}
