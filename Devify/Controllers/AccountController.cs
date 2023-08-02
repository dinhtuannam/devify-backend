using Devify.Application.DTO.ResponseDTO;
using Devify.Application.Features.Account.Queries;
using Devify.Entity;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/current", Name = "getCurrentUser")]
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
                Message = "Not found account",
                ErrCode = "404"
        });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAccount(Slider model)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(Slider model)
        {
            return Ok();
        }
    }
}
