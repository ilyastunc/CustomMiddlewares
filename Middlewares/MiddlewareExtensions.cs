using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CustomMiddlewares.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNumberChecker(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NumberCheckerMiddleware>();
        }

        public static IApplicationBuilder UseToLower(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ToLowerMiddleware>();
        }

        public static IApplicationBuilder UseCheckUserIsAuthenticated(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CheckUserIsAuthenticated>();
        }
    }
}