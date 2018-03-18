using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Serilog;
//using SerilogWebCore;
using Serilog.Events;

namespace SerilogWebCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            // .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            // .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            // .Build();

            //Configure the Serilog pipeline
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Information)
                .WriteTo.File("log.txt")
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")
                //.ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            Log.Logger.Information("Test Kandathil - at {ExecutionTime}", Environment.TickCount);
            Log.Logger.Error("Test Kandathil - This is a critical Error");
            Log.Warning("Test Kandathil - Just a final warning");
            Console.ReadLine();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog() //Added for Serilog
                .Build();
    }
}
