using NLog;
using System.IO;
using System;
using System.Reflection;

namespace SpeechServer
{

    internal static class Program
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        internal static void Main(string[] args)
        {
            ConfigureLogManager();
            _log.Info("Starting Speech Server");

            try
            {
                SayHello();
                while (true)
                {
                    string line = Console.ReadLine().Trim();
                    if (line.Length == 0)
                        continue;

                    var command = Command.Parse(line);
                    CommandDispatcher.Dispatch(command);
                }
            }
            catch (Exception x)
            {
                _log.Error(x);

            }
        }

        private static void ConfigureLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "jasmine.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

        }

        private static void SayHello()
        {
            CommandDispatcher.Dispatch(Command.Parse("q {Jasmine sWindows TTS started }"));
        }

        private static void ConfigureLogManager()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(assemblyPath + "\\nlog.config");
        }
    }
}
