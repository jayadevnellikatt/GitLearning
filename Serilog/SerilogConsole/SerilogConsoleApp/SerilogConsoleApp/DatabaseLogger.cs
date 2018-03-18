using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace SerilogConsoleApp
{
    public class DatabaseLogger
    {
        public static void Run()
        {
            //Using windows auth
            var loggerDB = new LoggerConfiguration()
                    .WriteTo.MSSqlServer(@"Server=.;Database=TestNew; Trusted_Connection=True; uid=sa;password=Admin123**", "Logs")
                    .CreateLogger();
            loggerDB.Information("This is an information, writing to console and DB table");
            loggerDB.Error("An Error occured!");

            //Using SQL Auth
            //var logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.MSSqlServer(@"Server=W106TDTFC2;Initial Catalog=Test;uid=sa;password=Admin123**", "Logs") //This is using sql authentication...
            //    .CreateLogger();
            //logger.Information("This is an information, writing to console and DB table");
            //logger.Error("An Error occured!");
        }
    }
}
