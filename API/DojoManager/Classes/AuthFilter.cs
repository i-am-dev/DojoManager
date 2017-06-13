using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using DojoManager.Models;
using System.Collections.Generic;
using DojoManager.Classes;

namespace DojoManager.AuthFilter
{
    //public class HasPermission : ActionFilterAttribute
    //{
    //    private readonly ILogger _logger;
    //    public string Permission { get; set; }

    //    public HasPermission(ILoggerFactory loggerFactory)
    //    {
    //        _logger = loggerFactory.CreateLogger("ValidatePermission");
    //    }



    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {

    //        _logger.LogDebug("validating PayloadType");
    //        var jwtBearer = context.HttpContext.Request.Headers["Authorization"].ToString().TrimEnd('}').Substring(7);
    //        List<PermissionFunction> permissions = new List<PermissionFunction>();
    //        UserEngine un = new UserEngine();
    //        permissions = un.GetListOfAllowedPermissionsForJWT(jwtBearer);

    //        //context.HttpContext.Response.StatusCode = 403;
    //        //context.Result = new ContentResult()
    //        //{
    //        //    Content = "Request not allowed"
    //        //};
    //        //return;


    //        base.OnActionExecuting(context);
    //    }
    //}

    public class HasPermission : TypeFilterAttribute
    {
        public HasPermission(params string[] ids) : base(typeof(HasPermissionImpl))
        {
            Arguments = new object[] { ids };
        }

        private class HasPermissionImpl : IActionFilter
        {
            private readonly string[] _ids;
            private readonly ILogger _logger;

            public HasPermissionImpl(ILoggerFactory loggerFactory, string[] ids)
            {
                _ids = ids;
                _logger = loggerFactory.CreateLogger<HasPermission>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                // NOW YOU CAN ACCESS _ids
                //foreach (var id in _ids)
                //{
                //}

                string permission = _ids[0];

                _logger.LogDebug("validating PayloadType");
                var jwtBearer = context.HttpContext.Request.Headers["Authorization"].ToString().TrimEnd('}').Substring(7);
                List<PermissionFunction> permissions = new List<PermissionFunction>();
                UserEngine un = new UserEngine();
                permissions = un.GetListOfAllowedPermissionsForJWT(jwtBearer);
                Boolean isAllowed = false;

                for(var i = 0; i < permissions.Count; i++)
                {
                    if (permissions[i].Name == permission)
                    {
                        isAllowed = true;
                        i = permissions.Count;
                    }
                }

                if (!isAllowed)
                {
                    context.HttpContext.Response.StatusCode = 403;
                    context.Result = new ContentResult()
                    {
                        Content = "Request not allowed"
                    };
                    return;
                }
                
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
        }
    }
}

