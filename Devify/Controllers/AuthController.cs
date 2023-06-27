using Devify.Entity;
using Devify.Application.DTO;
using Devify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Devify.Application.Interfaces;
using Azure.Core;

namespace Loship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authService;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController( IAuthRepository authService, SignInManager<IdentityUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
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
                var token = await _authService.GenerateToken(result);
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
        public async Task<IActionResult> RenewToken(Token_VM model)
        {
            try
            {
                var token = new Token
                {
                    AccessToken = model.AccessToken,
                    RefreshToken = model.RefreshToken
                };
                var result = await _authService.RenewToken(token);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
