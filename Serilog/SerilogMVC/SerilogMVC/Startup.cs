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
using Elasticsearch;
using Serilog.Sinks.Elasticsearch;

namespace SerilogMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup(IHostingEnvironment env)
        {
            //var configuration = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json")
            //.Build();

            //Configure the Serilog pipeline
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .Enrich.FromLogContext()
            //    .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Information)
            //    .WriteTo.File("log.txt")
            //    .WriteTo.Console()
            //    .WriteTo.Seq("http://localhost:5341")
            //    .WriteTo.Elasticsearch("localhost:9200")
            //    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            //    {
            //        AutoRegisterTemplate = true,
            //    })
            //    .ReadFrom.Configuration(configuration)

            //    //var loggerConfig = new LoggerConfiguration()
            //    //    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            //    //    {
            //    //        AutoRegisterTemplate = true,
            //    //    });
            //    .CreateLogger();
            //Log.Logger.Information("Executed by Dev at[Startup] {ExecutionTime}", Environment.TickCount);
            //Log.Logger.Error("ElasticSearch:Kibana - This is a critical Error");
            //Log.Logger.Warning("ElasticSearch:Kibana - Just a warning");
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
            //loggerFactory.AddSerilog();  //Add Serilog to the logging pipeline

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
