using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PingAPI.WebSocketRequests;
using System;
using System.Threading.Tasks;

namespace PingAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppContext, AppContext>();
        }

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
                var appContext = context.RequestServices.GetService<IAppContext>();
                await new WebSocketRequestFactory().Get(context, appContext).Create();
                await next(context);
            });
        }
    }
}
