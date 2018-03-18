using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Formatting.Compact;

namespace SerilogConsoleApp
{
    public class DisposeLogger
    {
        public static void DisposeThisLogger()
        {
            //Use the using block will automatically will dispose / shutdown
            using (var Mylog = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger())
            {
                Mylog.Information("Using Block to Dispose the logger!!!");
                Mylog.Warning("logger is dispopsed");
            }

            //Alternatively, you can store the Logger in a well-known location; Serilog has a built-in static Log class for this:
            //The Log class provides all of the same methods as the ILogger interface. 
            //Instead of a using block, we call Log.CloseAndFlush() to shut things down.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Information("To be disposed");
            Log.CloseAndFlush();
            Log.Information("Disposed");
        }
    }
}
