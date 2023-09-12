using Devify.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Devify.Application.Interfaces
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(OrderCheckoutDTO model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
