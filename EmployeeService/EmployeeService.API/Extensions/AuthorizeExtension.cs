
using EmployeeService.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeeService.API.Extensions
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var item =  context.HttpContext.Items["user_id"];
            if (item == null)
            {
                // not logged in
                context.Result = new UnauthorizedResult();
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var item = context.HttpContext.Items["role_name"];
            if (item == null || item.ToString() != SystemRoles.Admin.ToString())
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

