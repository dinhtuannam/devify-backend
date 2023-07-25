using AutoMapper;
using Devify.Application.Features.Account.Queries;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Devify.Filters.AuthorizationFilter;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-current-user", Name = "getCurrentUser")]
        [AuthorizeId]
        public async Task<IActionResult> getUserInformation(string id)
        {
            var account = await _mediator.Send(new GetUserInformationById { Id = id });
            if(account != null)
            {
                return Ok(new API_Response_VM
                {
                    Success = true,
                    Message = "Get account information successfully",
                    Data = account
                });
            }
            return NotFound(new API_Response_VM
            {
                Success = false,
                Message = "Not found account"
            });
        }
    }
}
