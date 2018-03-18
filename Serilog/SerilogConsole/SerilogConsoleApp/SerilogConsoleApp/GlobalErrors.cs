using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Serilog;
using Serilog.Debugging;

namespace SerilogConsoleApp
{
    public class GlobalErrors
    {
        public static void ReadFromFile()
        {
            SelfLog.Enable(Console.Error);

            //var loggerDB = new LoggerConfiguration()
            //.WriteTo.Console()
            //.CreateLogger();
            //loggerDB.Information("Global Error Handling");

            //Read the file as one string.
            //string FileName = ConfigurationSettings.AppSettings.Get("TextFilePath");


            string FileName1 = ConfigurationManager.AppSettings.Get("TextFilePath");
            //try
            //{
                string text = System.IO.File.ReadAllText(FileName1);
            //    // Display the file contents to the console. Variable text is a string.
                System.Console.WriteLine("Contents of the file is  {0}", text);
            //}
            //catch(Exception ex)
            //{
            //    var logger = new LoggerConfiguration()
            //        .WriteTo.MSSqlServer(@"Server=W106TDTFC2;Initial Catalog=Test;uid=sa;password=Admin123**", "Logs") //This is using sql authentication...
            //        .CreateLogger();
            //    logger.Information(ex.Message);
            //}
        }
    }
}
