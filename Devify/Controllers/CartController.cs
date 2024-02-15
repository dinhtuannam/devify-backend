using Devify.Application.DTO;
using Devify.Application.Features.Cart.Commands;
using Devify.Application.Features.Cart.Queries;
using Devify.Application.Features.Category.Queries;
using Devify.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-cart")]
        public async Task<IActionResult> getCart(string user)
        {
            ApiResponse res = await _mediator.Send(new GetUserCartQuery(user));
            return Program.my_api.response(res);
        }

        [HttpPost]
        [Route("add-item/{course}")]
        public async Task<IActionResult> addItem(string user,string course)
        {
            ApiResponse res = await _mediator.Send(new AddItemCommand(user,course));
            return Program.my_api.response(res);
        }

        [HttpDelete]
        [Route("remove-item/{course}")]
        public async Task<IActionResult> removeItem(string user, string course)
        {
            ApiResponse res = await _mediator.Send(new RemoveItemCommand(user, course));
            return Program.my_api.response(res);
        }

        [HttpPost]
        [Route("apply-discount/{discount}")]
        public async Task<IActionResult> applyDiscount(string user, string discount)
        {
            ApiResponse res = await _mediator.Send(new ApplyDiscountCommand(user,discount));
            return Program.my_api.response(res);
        }

        [HttpDelete]
        [Route("remove-discount/{discount}")]
        public async Task<IActionResult> removeDiscount(string user,string discount)
        {
            ApiResponse res = await _mediator.Send(new RemoveDiscountCommand(user, discount));
            return Program.my_api.response(res);
        }

        [HttpDelete]
        [Route("clear-cart")]
        public async Task<IActionResult> clearCart(string user)
        {
            ApiResponse res = await _mediator.Send(new ClearCartCommand(user));
            return Program.my_api.response(res);
        }
    }
}
