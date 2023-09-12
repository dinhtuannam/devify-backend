using Devify.Application.DTO;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Devify.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vpnPayService;
        private readonly IConfiguration _configuration;
        public PaymentController(IVnPayService vpnPayService, IConfiguration configuration)
        {
            _vpnPayService = vpnPayService;
            _configuration = configuration;
        }

        [HttpPost("vnpay")]
        public IActionResult Payment(OrderCheckoutDTO model)
        {
            var url = _vpnPayService.CreatePaymentUrl(model, HttpContext);
            return Ok(url);
        }

        [HttpGet("callback")]
        public IActionResult PaymentCallback()
        {
            var response = _vpnPayService.PaymentExecute(Request.Query);
            var frontendUrl = _configuration.GetValue<string>("FrontendUrl");
            if(response.VnPayResponseCode == "00")
            return Redirect($"{frontendUrl}/cart/success");
            else
                return Redirect($"{frontendUrl}/bad-request");
        }
    }
}
