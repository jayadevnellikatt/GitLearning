using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace SerilogMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json")
            //.Build();

            //var configuration = new ConfigurationBuilder()
            ////.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json")
            //.Build();
            //Configure the Serilog pipeline

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Information)
                .WriteTo.File("log.txt")
                .WriteTo.Console()
                .WriteTo.ColoredConsole()
                //.WriteTo.Seq("http://localhost:5341")
                .WriteTo.Elasticsearch("http://localhost:9200/")
                //.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                //{
                //    AutoRegisterTemplate = true,
                //})
                .Enrich.FromLogContext()
                .CreateLogger();
                //Log.Logger = new LoggerConfiguration()
                //.WriteTo.LiterateConsole()
                //.CreateLogger();
            Log.Logger.Information("Test - Executed by Dev[Program] at {ExecutionTime}", Environment.TickCount);
            Log.Logger.Error("Test - An error has occured");
            Log.Logger.Warning("Test - Kibana - Only warning");

            Console.ReadLine();
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog() //Added for Serilog
                .Build();
    }
}
