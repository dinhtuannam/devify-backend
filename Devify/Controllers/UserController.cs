using Devify.Application.DTO;
using Devify.Application.Features.User.Commands;
using Devify.Application.Features.User.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-users")]
        [Cache(3600)]
        public async Task<IActionResult> GetAllUsers()
        {
            ApiResponse api = await _mediator.Send(new GetListUserQuery());
            return Ok(api);
        }

        [HttpGet]
        [Route("{code}/get-user")]
        [Cache(3600)]
        public async Task<IActionResult> GetUser(string code)
        {
            ApiResponse api = await _mediator.Send(new GetUserQuery(code));
            return Ok(api);
        }

        [HttpGet]
        [Route("{name}/get-user-by-name")]
        [Cache(3600)]
        public async Task<IActionResult> GetUserByName(string name)
        {
            ApiResponse api = await _mediator.Send(new GetUserByNameQuery(name));
            return Ok(api);
        }

        [HttpPost]
        [Route("create-new-user")]
        public async Task<IActionResult> AddNewUser(CreateUserModel model)
        {
            ApiResponse res = await _mediator.Send(new CreateUserCommand("","",model.username, model.password, model.displayName,model.email,model.role));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            ApiResponse res = await _mediator.Send(new SignInCommand(model.username,model.password));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("edit-user")]
        public async Task<IActionResult> UpdateUser(UpdateUserModel model)
        {
            ApiResponse res = await _mediator.Send(new UpdateUserCommand(
                "",
                "",
                model.code, 
                model.username, 
                model.password,
                model.displayName,
                model.email,
                model.image,
                model.social,
                model.about,
                model.role
            ));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteUser(string code)
        {
            ApiResponse res = await _mediator.Send(new DeleteUserCommand(code));
            if (!res.result)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        
    }
}
