using Devify.Application.Interfaces;
using Devify.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Devify.Filters
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;
        private readonly bool _authorize;
        public CacheAttribute(int timeToLiveSeconds = 1000, bool authorize = false)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
            _authorize = authorize;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheConfiguration = context.HttpContext.RequestServices.GetRequiredService<RedisConfiguration>();
            if (!cacheConfiguration.Enable)
            {
                await next();
                return;
            }
            context.HttpContext.Request.EnableBuffering();
            using (StreamReader stream = new StreamReader(context.HttpContext.Request.Body))
            {
                string body = await stream.ReadToEndAsync();

            }

            var cacheKey = generateCacheKeyFromRequest(context.HttpContext.Request,context,_authorize);
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var cacheResponse = await cacheService.cache.GetCacheResponseAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var excutedContext = await next();
            if (excutedContext.Result is JsonResult result && result.StatusCode == 200)
            {
                await cacheService.cache.SetCacheResponseAsync(cacheKey, result.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private static string generateCacheKeyFromRequest(HttpRequest request,ActionExecutingContext context, bool authorize)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach(var (key,value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            if (authorize)
            {
                string user = context.HttpContext.Items["code"] as string ?? "";
                string role = context.HttpContext.Items["role"] as string ?? "";
                keyBuilder.Append($"|user-{user}");
                keyBuilder.Append($"|role-{role}");
            }
            return keyBuilder.ToString();
        }
    }
}


