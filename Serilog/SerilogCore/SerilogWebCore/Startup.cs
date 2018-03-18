using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace SerilogWebCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup(IHostingEnvironment env)
        {
            //Configure the Serilog pipeline
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .Enrich.FromLogContext()
            //    .WriteTo.RollingFile("log-{Date}.txt",LogEventLevel.Information)
            //    .WriteTo.File("log.txt")
            //    .WriteTo.Console()
            //    .WriteTo.Seq("http://localhost:5341")
            //    .CreateLogger();
            //Log.Logger.Information("Executed by Dev at[Startup] {ExecutionTime}", Environment.TickCount);
            //Log.Logger.Error("Startup - This is a critical Error");
            //Log.Warning("Startup - Just a final warning");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            loggerFactory.AddSerilog();  //Add Serilog to the logging pipeline

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
