using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares.Middlewares
{
    public class CheckUserIsAuthenticated
    {
        private RequestDelegate _next;
        public CheckUserIsAuthenticated(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
             if (context.Request.Path == "/products" && context.Request.Method == "POST" && !context.User.Identity.IsAuthenticated)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Bu işlem işin yetkiniz yok.");
                }
                else
                    await _next(context);
        }
    }
}