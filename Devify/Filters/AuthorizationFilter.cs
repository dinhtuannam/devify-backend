using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Devify.Application.Interfaces;
using Devify.Models;

namespace Devify.Filters
{
    public class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly List<string> _roles = new List<string>();
        public RoleAttribute(params string[] roles)
        {
            _roles = new List<string>(roles);
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string user = context.HttpContext.Items["code"] as string ?? "";
                if (string.IsNullOrEmpty(user))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                string role = context.HttpContext.Items["role"] as string ?? "";
                if (string.IsNullOrEmpty(role))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                if (!_roles.Contains(role))
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }

    public class UserAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string user = context.HttpContext.Items["code"] as string ?? "";
                if (string.IsNullOrEmpty(user))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }


}

