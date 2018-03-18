using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace SerilogConsoleApp
{
    public class HelloSerilog
    {
        public static void HelloLog()
        {
            // Create Logger
            var logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();
            // Output logs
            logger.Debug("Serilog Debugging message");
            logger.Information("Serilog Information message");
            logger.Warning("Serilog Warning message");
            logger.Error("Serilog Error message");
            logger.Fatal("Serilog Fatal message");
        }
        public static void ParameterizedLog()
        {
            // Create Logger
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            // write structured data
            logger.Information("Processed {Number} records in {Time} ms", 500, 120);
        }
        public static void TemplateLog()
        {
            // Create Logger
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            // prepare data
            var order = new { Id = 12, Total = 111.22, CustomerId = 72 };
            var customer = new { Id = 72, Name = "Jayadev" };
            // write log message
            logger.Information("New orders {OrderId} by {Customer}", order, customer);
        }
    }
}
