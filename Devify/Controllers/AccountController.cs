using Devify.Application.DTO.ResponseDTO;
using Devify.Application.Features.Account.Queries;
using Devify.Application.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("{id}", Name = "getDetailAccount")]
        //[AuthorizeId]
        public async Task<IActionResult> getDetailAccount(string id)
        {
            return Ok(await _unitOfWork.AccountRepository.getUserById(id));
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
