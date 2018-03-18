using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Formatting.Compact;

namespace SerilogConsoleApp
{
    public class JasonOutput
    {
        public static void JasonRun()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.File(new CompactJsonFormatter(), @"C:\Jayadev\DemoProjects\Core\Serilog\SerilogConsole\SerilogConsoleApp\SerilogConsoleApp\Log\Jasonlog.clef")
                .CreateLogger();
            var appointment = new { Id = 1, Subject = "Appointment Booking", Timestamp = new DateTime(2018, 2, 2) };
            var appointment1 = new { Id = 2, Subject = "Appointment Booking", Timestamp = new DateTime(2018, 2, 2) };
            logger.Information("An appointment is booked successfully: {@appountment}", appointment);
            logger.Error("Failed to book an appointment: {@appountment}", appointment1);
        }
    }
}
