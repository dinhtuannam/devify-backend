using Devify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Devify.Application.Interfaces;
using Devify.Application.DTO.RequestDTO;
using Devify.Entity;
using Devify.Application.Features.Course.Commands;
using Devify.Application.Features.Auth.Commands;
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

        [HttpPost("login", Name = "authlogin")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new LoginCommand { username = model.Name, password = model.Password });
                return result.Success ? Ok(result) : BadRequest(result);
            }
            return BadRequest("Vui lòng điền đầy đủ tên đăng nhập và mật khẩu");
        }

        [HttpGet("logout", Name = "authlogout")] 
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        [HttpPost("register", Name = "register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork.AuthRepository.Register(model);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("renew-token", Name = "renewToken")]
        public async Task<IActionResult> RenewToken(RefreshToken_Request model)
        {
            try
            {
                var result = await _unitOfWork.TokenRepository.RenewToken(model.refreshToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
