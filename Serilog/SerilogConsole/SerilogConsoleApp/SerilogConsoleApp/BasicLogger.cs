using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Formatting.Compact;

namespace SerilogConsoleApp
{
    public class BasicLogger
    {
        public static void Run()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .WriteTo.RollingFile(@"C:\Jayadev\DemoProjects\Core\Serilog\SerilogConsole\SerilogConsoleApp\SerilogConsoleApp\Log\Log-{Date}.txt")
                .WriteTo.File(@"C:\Jayadev\DemoProjects\Core\Serilog\SerilogConsole\SerilogConsoleApp\SerilogConsoleApp\Log\Log-{Date}.txt") //Date will not printed
                .WriteTo.File(@"C:\Jayadev\DemoProjects\Core\Serilog\SerilogConsole\SerilogConsoleApp\SerilogConsoleApp\Log\Jay.txt")
                .WriteTo.File(new CompactJsonFormatter(), @"C:\Jayadev\DemoProjects\Core\Serilog\SerilogConsole\SerilogConsoleApp\SerilogConsoleApp\Log\log.clef")
                .CreateLogger();
            var appointment = new { Id = 1, Subject = "New Appointment Booking", Timestamp = new DateTime(2018, 2, 2) };
            var appointment1 = new { Id = 2, Subject = "New Appointment Booking", Timestamp = new DateTime(2018, 2, 2) };
            logger.Information("New appointment is booked successfully: {@appointment}", appointment);
            logger.Error("Failed to book an appointment: {@appointment}", appointment1);
        }
    }
}
