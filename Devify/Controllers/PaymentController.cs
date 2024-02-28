using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Devify.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vpnPayService;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentController(IVnPayService vpnPayService, IConfiguration configuration,IUnitOfWork unitOfWork)
        {
            _vpnPayService = vpnPayService;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("vnpay")]
        [User]
        public async Task<IActionResult> Payment()
        {
            string user = HttpContext.Items["code"] as string ?? "";
            string url = await _vpnPayService.CreatePaymentUrl(user, HttpContext);
            ApiResponse api = new ApiResponse(true,"Thanh toán thành công",url,200);
            if (string.IsNullOrEmpty(url))
            {
                api.result = false;
                api.message = "Thanh toán thất bại";
                api.code = 400;
            }
            return (Program.my_api.response(api));
        }

        [HttpGet("callback")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = _vpnPayService.PaymentExecute(Request.Query);
            var frontendUrl = _configuration.GetValue<string>("FrontendUrl");
            if(response.VnPayResponseCode != "00")
            {
                return Redirect($"{frontendUrl}/cart");
            }
            bool result = await _unitOfWork.order.CheckOut(response.OrderDescription);
            if(result == false)
            {
                return Redirect($"{frontendUrl}/cart");
            }

            await Task.WhenAll(
                _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.inventory),
                _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.cart),
                _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course),
                _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.discount),
                _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.profile)
            );

            return Redirect($"{frontendUrl}/success");

        }
    }
}
