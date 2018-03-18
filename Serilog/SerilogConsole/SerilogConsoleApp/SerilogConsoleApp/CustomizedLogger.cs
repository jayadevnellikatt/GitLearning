using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace SerilogConsoleApp
{
    public class CustomizedLogger
    {
        public static void SetLevel()
        {
            var logger = new LoggerConfiguration()
             //.MinimumLevel.Debug()
             .MinimumLevel.Warning() //Setting the level
             .WriteTo.ColoredConsole()
             .CreateLogger();
            var appointment = new { Id = 1, Subject = "Serilog Logging", Timestamp = new DateTime(2018, 2, 2) };
            logger.Verbose("You will not see this log"); //This will not print
            logger.Information("Appointment is booked successfully: {@appointment}", appointment); //This will not be printed
            logger.Error("Failed to book an appointment: {@Appointment}", appointment); //This will be printed
        }
    }
}
