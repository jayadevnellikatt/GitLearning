using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SerilogMVC.Models;

using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Events;


namespace SerilogMVC.Controllers
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var p = new Person { FirstName = "Jay", LastName = "Nelli" };
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Information)
            .WriteTo.File("log.txt")
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();
            Log.Logger.Information("Just trying the logger {@person}", p);
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
