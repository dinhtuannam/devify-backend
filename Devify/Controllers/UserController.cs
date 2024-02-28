using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Features.Course.Queries;
using Devify.Application.Features.User.Commands;
using Devify.Application.Features.User.Queries;
using Devify.Filters;
using Devify.Models;
using Firebase.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/user")]
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
        [Cache(120)]
        public async Task<IActionResult> getAllUsers()
        {
            ApiResponse api = await _mediator.Send(new GetListUserQuery());
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("get-profile")]
        [User]
        [Cache(120,true)]
        public async Task<IActionResult> getProfile()
        {
            string user = HttpContext.Items["code"] as string ?? "";
            ApiResponse api = await _mediator.Send(new GetProfileQuery(user));
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("get-inventory")]
        [User]
        [Cache(360,true)]
        public async Task<IActionResult> getInventory()
        {
            string user = HttpContext.Items["code"] as string ?? "";
            ApiResponse api = await _mediator.Send(new GetUserInventory(user));
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{code}/get-user")]
        [Cache(120,true)]
        public async Task<IActionResult> getUser(string code)
        {
            ApiResponse api = await _mediator.Send(new GetUserQuery(code));
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Route("{code}/get-creator-courses")]
        [Cache(120)]
        public async Task<IActionResult> getCreatorCourses(string code,int page = 1,int size = 8,string title = "")
        {
            ApiResponse api = await _mediator.Send(new GetCreatorCourseQuery(code,page,size,title));
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
            UserSignInInfo data = (UserSignInInfo)api.data;
            if(!string.IsNullOrEmpty(data.token.AccessToken))
            {
                Response.Cookies.Append(ConfigKey.AT_COOKIES, data.token.AccessToken, new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true, 
                    SameSite = SameSiteMode.None, 
                    Expires = ConfigKey.getATExpiredTime()
                });

                Response.Cookies.Append(ConfigKey.RT_COOKIES, data.token.RefreshToken, new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = ConfigKey.getRTExpiredTime()
                });

                Response.Cookies.Append("devify_isLogin", "true", new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = ConfigKey.getRTExpiredTime()
                });
            }
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("{token}/renew-token")]
        public async Task<IActionResult> renewToken(string token)
        {
            ApiResponse api = await _mediator.Send(new RenewTokenCommand(token));
            TokenDTO data = (TokenDTO)api.data;
            Response.Cookies.Append(ConfigKey.AT_COOKIES, data.AccessToken, new CookieOptions
            {
                HttpOnly = false,
                Secure = true, 
                SameSite = SameSiteMode.None, 
                Expires = ConfigKey.getATExpiredTime()
            });
            Response.Cookies.Append(ConfigKey.RT_COOKIES, data.RefreshToken, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = ConfigKey.getRTExpiredTime()
            });
            Response.Cookies.Append("devify_isLogin", "true", new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = ConfigKey.getRTExpiredTime()
            });
            return Program.my_api.response(api);
        }

        [HttpPut]
        [User]
        [Route("edit-user")]
        public async Task<IActionResult> updateUser(UpdateUserModel model)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse api = await _mediator.Send(new UpdateUserCommand(
                user,
                role,
                model.code, 
                model.username, 
                model.displayName,
                model.email,
                model.social,
                model.about,
                model.role
            ));
            return Program.my_api.response(api);
        }

        [HttpPut]
        [User]
        [Route("edit-password")]
        public async Task<IActionResult> updatePassword(UpdatePasswordModel model)
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string role = HttpContext.Items["role"] as string ?? "";
            ApiResponse api = await _mediator.Send(new UpdatePasswordCommand(
                user,
                role,
                model.code,
                model.curPassword,
                model.newPassword
            ));
            return Program.my_api.response(api);
        }

        [HttpDelete]
        [Role("admin")]
        [Route("{code}")]
        public async Task<IActionResult> deleteUser(string code)
        {
            ApiResponse api = await _mediator.Send(new DeleteUserCommand(code));
            return Program.my_api.response(api);
        }

    }
}
