﻿using Devify.Application;
using Devify.Entity;
using Devify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountRepository _accountService;
        private readonly IAuthRepository _authService;

        public AuthController(IAccountRepository accountService, IAuthRepository authService)
        {
            _accountService = accountService;
            _authService = authService;
        }

        [HttpPost("login", Name = "authlogin")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _authService.Login(model.Name, model.Password);
                if (result == null)
                {
                    return Ok(new API_Response_VM
                    {
                        Success = false,
                        Message = "invalid"
                    });
                }
                var token = await _authService.GenerateToken(result);
                return Ok(new API_Response_VM
                {
                    Success = true,
                    Message = "authenticated success",
                    Data = token
                });
            }
            return BadRequest("You re not authenticated");
        }

        [HttpPost("renewToken", Name = "renewToken")]
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
