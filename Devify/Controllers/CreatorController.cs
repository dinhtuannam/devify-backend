using Devify.Application.Features.Creator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    }
}
