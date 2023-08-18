using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMiddlewares.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CustomMiddlewares
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseNumberChecker(); //girilen query string'in değerinin sayısal olup olmadığını kontrol eden middleware
            app.UseToLower(); //girilen query string değerini küçük harfe çeviren middleware

            app.UseCheckUserIsAuthenticated(); //kullanıcı mı yetkili mi kontrolünü yapan middleware

            app.Run(async (context) =>
            {
                if (context.Items["value"] != null && context.Items["value"].ToString() != "")
                {
                    var value = context.Items["value"].ToString();
                    await context.Response.WriteAsync($"category : {value}");
                }
                else
                {
                    await context.Response.WriteAsync("No query string");
                }
                    
            });
        }
    }
}
