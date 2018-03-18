using System;
using System.IO;
using Serilog;
using Serilog.Debugging;

namespace SerilogConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SelfLog.Enable(Console.Error);
            //Console.WriteLine("Hello Serilog!");
            //HelloSerilog.HelloLog(); //General information
            //HelloSerilog.ParameterizedLog(); //Structured data as information
            //HelloSerilog.TemplateLog();

            BasicLogger.Run(); //Write to console and to a text file.

            //CustomizedLogger.SetLevel(); //Usage of level

            //DatabaseLogger.Run(); //Write to database

            //JasonOutput.JasonRun(); //For Jason Output

            //DisposeLogger.DisposeThisLogger();
            //GlobalErrors.ReadFromFile();
            Console.ReadLine();
        }
    }
}
