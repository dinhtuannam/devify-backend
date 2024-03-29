﻿using Devify.Application.DTO;
using Devify.Application.Features.Level.Commands;
using Devify.Application.Features.Level.Queries;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/level")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private IMediator _mediator;
        public LevelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Cache(3600)]
        [Route("get-all-level")]
        public async Task<IActionResult> GetAllLevel()
        {
            ApiResponse api = await _mediator.Send(new GetAllLevelQuery());
            return Program.my_api.response(api);
        }

        [HttpGet]
        [Cache(3600)]
        [Route("{code}/get-level")]
        public async Task<IActionResult> GetLevel(string code)
        {
            ApiResponse api = await _mediator.Send(new GetLevelQuery(code));
            return Program.my_api.response(api);
        }

        [HttpPost]
        [Route("create-new-level")]
        public async Task<IActionResult> CreateLevel(CreateLevelModel model)
        {
            ApiResponse api = await _mediator.Send(new CreateLevelCommand(model.code,model.name,model.des));
            return Program.my_api.response(api);
        }

        [HttpPut]
        [Route("edit-level")]
        public async Task<IActionResult> UpdateLevel(UpdateLevelModel model)
        {
            ApiResponse api = await _mediator.Send(new UpdateLevelCommand(model.code, model.name, model.des));
            return Program.my_api.response(api);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteLevel(string code)
        {
            ApiResponse api = await _mediator.Send(new DeleteLevelCommand(code));
            return Program.my_api.response(api);
        }
    }
}
