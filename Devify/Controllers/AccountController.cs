using Devify.Application.Interfaces;
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


        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            return Ok();
        }
    }
}
