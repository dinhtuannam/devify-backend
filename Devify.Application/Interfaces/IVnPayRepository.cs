using Devify.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Devify.Application.Interfaces
{
    public interface IVnPayService
    {
        Task<string> CreatePaymentUrl(string user, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
