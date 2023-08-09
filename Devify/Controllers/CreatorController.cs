using Devify.Application.Features.Creator.Queries;
using Devify.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Devify.Entity.Enums;
using Devify.Application.DTO.ResponseDTO;
using Devify.Models;

namespace Devify.Controllers
{
    [Route("api/creator")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private IMediator _mediator;
        public CreatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllCreator()
        {
            return Ok();
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new GetCreatorByConditionQuery
            {
                condition = id,
                type = ConditionEnum.ID
            });
            if(result == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "Something wrong, please try again later !",
                    ErrCode = "404"
                });
            }
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = $"get creator with id :{id} successfully",
                Data = result
            });
        }

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var result = await _mediator.Send(new GetCreatorByConditionQuery
            {
                condition = slug,
                type = ConditionEnum.SLUG
            });
            if (result == null)
            {
                return NotFound(new API_Response_VM
                {
                    Success = false,
                    Message = "Something wrong, please try again later !",
                    ErrCode = "404"
                });
            }
            return Ok(new API_Response_VM
            {
                Success = true,
                Message = $"get creator with slug :{slug} successfully",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCreatort(Slider model)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCreator(int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCreator(Slider model)
        {
            return Ok();
        }
    }
}
