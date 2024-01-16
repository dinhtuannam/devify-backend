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
        [Route("get-all-user")]
        [Cache(3600)]
        public async Task<IActionResult> getAllUsers()
        {
            ApiResponse api = await _mediator.Send(new GetListUserQuery());
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{code}/get-user")]
        [Cache(3600)]
        public async Task<IActionResult> getUser(string code)
        {
            ApiResponse api = await _mediator.Send(new GetUserQuery(code));
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{name}/get-user-by-name")]
        [Cache(3600)]
        public async Task<IActionResult> getUserByName(string name)
        {
            ApiResponse api = await _mediator.Send(new GetUserByNameQuery(name));
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("create-new-user")]
        public async Task<IActionResult> createNewUser(CreateUserModel model)
        {
            ApiResponse api = await _mediator.Send(new CreateUserCommand("","",model.username, model.password, model.displayName,model.email,model.role));
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> signIn(SignInModel model)
        {
            ApiResponse api = await _mediator.Send(new SignInCommand(model.username,model.password));
            return Program.my_api.response(api);
        }

        [HttpPut]
        [Route("edit-user")]
        public async Task<IActionResult> updateUser(UpdateUserModel model)
        {
            ApiResponse api = await _mediator.Send(new UpdateUserCommand(
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
            return Program.my_api.response(api);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> deleteUser(string code)
        {
            ApiResponse api = await _mediator.Send(new DeleteUserCommand(code));
            return Program.my_api.response(api);
        }

        
    }
}
