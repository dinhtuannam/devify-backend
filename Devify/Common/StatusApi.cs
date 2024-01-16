using Devify.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Common
{
    public class StatusApi
    {
        public JsonResult response(ApiResponse api)
        {
            return new JsonResult(api)
            {
                StatusCode = int.Parse(api.code.ToString())
            };
        }
    }
}
