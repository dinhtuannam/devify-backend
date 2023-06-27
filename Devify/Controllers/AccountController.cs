using AutoMapper;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Devify.Filters.AuthorizationFilter;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository,IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet("get-user-information", Name = "getUserInformation")]
        [AuthorizeId]
        public async Task<IActionResult> getUserInformation(string id)
        {
            var account = _accountRepository.getAccountInformation(id);
            if(account.Result != null)
            {
                var model = _mapper.Map<Account_Information_VM>(account.Result);
                return Ok(new API_Response_VM
                {
                    Success = true,
                    Message = "Get account information successfully",
                    Data = model
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
