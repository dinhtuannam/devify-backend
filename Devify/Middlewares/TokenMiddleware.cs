using Devify.Application.DTO;
using Devify.Application.Interfaces;

namespace Devify.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var unitOfWork = context.RequestServices.GetService<IUnitOfWork>();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(token != null)
            {
                TokenInfoDecoded info = unitOfWork.TokenRepository.DecodedToken(token);
                if(info.Id != null)
                {
                    context.Items["userId"] = info.Id;
                    context.Items["token"] = info.Token;
                    context.Items["roleId"] = info.RoleId;
                }
            }
            await _next(context);
        }
    }
}
