using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Devify.Application.Interfaces;
using Devify.Models;

namespace Devify.Filters
{
    public class AuthorizationFilter
    {
        public class AuthorizeIdAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString();
                var id = context.HttpContext.Request.Query["id"].ToString();
                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(id))
                {
                    context.Result = new UnauthorizedObjectResult(new API_Response_VM
                    {
                        Success = false,
                        Message = "Vui lòng đăng nhập",
                        Data = "/login"
                    });
                    return;
                }
                var tokenValue = token.Split(" ")[1];
                var authService = context.HttpContext.RequestServices.GetService<IAuthRepository>();

                // ===================== Kiểm tra tính hợp lệ của token
                var IsTokenValid = authService.ValidateToken(tokenValue);
                if(!IsTokenValid)
                {
                    context.Result = new UnauthorizedObjectResult(new API_Response_VM
                    {
                        Success = false,
                        Message = "Quyền truy cập không hợp lệ",
                    });
                    return;
                }

                // ===================== Kiểm tra token có = request Id
                var IsTokenIdEqualRequestId = authService.IsTokenIdEqualRequestId(tokenValue, id);
                if (!IsTokenIdEqualRequestId)
                {
                    context.Result = new UnauthorizedObjectResult(new API_Response_VM
                    {
                        Success = false,
                        Message = "Bạn không có quyền truy cập dịch vụ này",
                    });
                    return;
                }
            }
        }
    }
}
