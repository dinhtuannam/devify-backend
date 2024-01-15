using Microsoft.AspNetCore.Mvc;
using Devify.Application.Interfaces;
using MediatR;

namespace Loship.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public AuthController( IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        /*[HttpPost("login", Name = "authlogin")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new LoginCommand { username = model.Name, password = model.Password });
                return result.result ? Ok(result) : BadRequest(result);
            }
            return BadRequest("Vui lòng điền đầy đủ tên đăng nhập và mật khẩu");
        }

        [HttpGet("logout", Name = "authlogout")] 
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        [HttpPost("register", Name = "register")]
        public async Task<IActionResult> Register(string username, string password, string email, string phone)
        {
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork.auth.Register(username,password,email,phone);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("renew-token", Name = "renewToken")]
        public async Task<IActionResult> RenewToken(RefreshToken_Request model)
        {
            try
            {
                var result = await _unitOfWork.token.RenewToken(model.refreshToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }*/
    }
}
