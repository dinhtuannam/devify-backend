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
            var service = context.RequestServices.GetService<IUnitOfWork>();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                TokenDecodedInfo info = service!.token.DecodeToken(token);
                if (!string.IsNullOrEmpty(info.code))
                {
                    context.Items["code"] = info.code;
                    context.Items["username"] = info.username;
                    context.Items["role"] = info.role;
                    context.Items["token"] = token;
                }
            }
            await _next(context);
        }
    }
}
