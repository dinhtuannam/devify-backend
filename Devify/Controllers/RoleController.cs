using Devify.Application.DTO;
using Devify.Application.Features.Role.Commands;
using Devify.Application.Features.Role.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-roles")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllRoles()
        {
            ApiResponse api = await _mediator.Send(new GetListRoleQuery());
            return Ok(api);
        }

        [HttpGet]
        [Route("{code}/get-role")]
        [Cache(3600)]
        public async Task<IActionResult> GetRole(string code)
        {
            ApiResponse api = await _mediator.Send(new GetRoleQuery(code));
            return Ok(api);
        }

        [HttpPost]
        [Route("create-new-role")]
        public async Task<IActionResult> AddNewRole(CreateRoleModel model)
        {
            ApiResponse res = await _mediator.Send(new CreateRoleCommand(model.code, model.name, model.des));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteRole(string code)
        {
            ApiResponse res = await _mediator.Send(new DeleteRoleCommand(code));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("edit-role")]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel model)
        {
            ApiResponse res = await _mediator.Send(new UpdateRoleCommand(model.code, model.name, model.des));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
