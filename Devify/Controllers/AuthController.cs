using Devify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Devify.Application.Interfaces;
using Devify.Application.DTO.RequestDTO;
using Devify.Entity;

namespace Loship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authService;
        private readonly ITokenRepository _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthController( IAuthRepository authService, ITokenRepository tokenService, SignInManager<ApplicationUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login", Name = "authlogin")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Login(model.Name, model.Password);
                if (result == null)
                {
                    return Ok(new API_Response_VM
                    {
                        Success = false,
                        Message = "Tên đăng nhập hoặc mật khẩu không đúng"
                    });
                }
                var token = await _tokenService.GenerateToken(result);
                return Ok(new API_Response_VM
                {
                    Success = true,
                    Message = "Đăng nhập thành công",
                    Data = token 
                });
            }
            return BadRequest("Vui lòng điền đầy đủ tên đăng nhập và mật khẩu");
        }

        [HttpGet("logout", Name = "authlogout")]
        public async Task<IActionResult> Logout()
        {
            bool isAuthenticated = _signInManager.IsSignedIn(User);
            return Ok(isAuthenticated);

        }

        [HttpPost("register", Name = "register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Register(model);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("renew-token", Name = "renewToken")]
        public async Task<IActionResult> RenewToken(RefreshToken_Request model)
        {
            try
            {
                var result = await _tokenService.RenewToken(model.refreshToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
