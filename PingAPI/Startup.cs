using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PingAPI.WebSocketRequests;
using System;

namespace PingAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) { }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var wsOptions = new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(6000) };

            app.UseWebSockets(wsOptions);
            app.Use(async (context, next) =>
            {
                await new WebSocketRequestFactory().Get(context).Create();
                await next(context);
            });
        }
    }
}
