using AutoMapper;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LanguageController(IMediator mediator, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Cache(3600)]
        public IActionResult GetALlLanguage()
        {
            var model = _unitOfWork.LanguageRepository.GetAll().ToList();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLanguage(CreateLanguageModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateLanguageCommand { newLanguage = _mapper.Map<SqlLanguage>(model) });
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLanguage(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new DeleteLanguageCommand { DeleteID = id });
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateLanguageCommand { updateLanguage = _mapper.Map<SqlLanguage>(model) });
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
