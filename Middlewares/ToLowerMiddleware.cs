using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares.Middlewares
{
    public class ToLowerMiddleware
    {
        private readonly RequestDelegate _next;
        public ToLowerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items["value"] != null)
                {
                    var value = context.Items["value"].ToString();
                    context.Items["value"] = value.ToLower(); 
                } 

                await _next(context);
        }
    }
}