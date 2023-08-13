using Devify.Application.Interfaces;
using Devify.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Devify.Filters
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;
        public CacheAttribute(int timeToLiveSeconds = 1000)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
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

            var cacheKey = generateCacheKeyFromRequest(context.HttpContext.Request);
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var cacheResponse = await cacheService.CacheRepository.GetCacheResponseAsync(cacheKey);

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
            if(excutedContext.Result is OkObjectResult okObjectResult)
            {
                await cacheService.CacheRepository.SetCacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private static string generateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach(var (key,value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
