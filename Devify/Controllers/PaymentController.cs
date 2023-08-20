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

        public PaymentController(IVnPayService vpnPayService)
        {
            _vpnPayService = vpnPayService;
        }

        [HttpPost]
        public IActionResult Payment( PaymentInformationModel model)
        {
            var url = _vpnPayService.CreatePaymentUrl(model, HttpContext);
            return Ok(url);
        }

        [HttpGet("callback")]
        public IActionResult PaymentCallback()
        {
            var response = _vpnPayService.PaymentExecute(Request.Query);
            return Ok(response);
        }
    }
}
