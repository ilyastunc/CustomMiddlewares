using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares.Middlewares
{
    public class NumberCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public NumberCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/products")
                {
                    var value = context.Request.Query["category"].ToString();

                    if (int.TryParse(value, out int intValue))
                    {
                        await context.Response.WriteAsync($"category sayısal bir ifade : {intValue}");
                    }
                    else
                    {
                        context.Items["value"] = value;
                        await _next(context);
                    }
                } 
                else
                    await _next(context);
        }
    }
}