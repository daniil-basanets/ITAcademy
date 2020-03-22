using log4net;
using log4net.Config;
using FileParser.Logics;
using FileParser.Models;
using HelpersLibrary;
using System;

namespace FileParser
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string HELP_STRING = "\n\r[HELP] Use parameters: \n\rfileName searchPattern\n\rfileName searchPattern replacePattern";

        private static void Main(string[] args)
        {
            string fileName;

            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion
            
            #region Check input data

            fileName = Parser.TryGetString(args, 0, out ErrorCode errorCode);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());
                Console.WriteLine(HELP_STRING);

                return;
            }

            if (args.Length < 2)
            {
                Console.WriteLine(ErrorCode.InvalidParametersCount.GetMessage());
                Console.WriteLine(HELP_STRING);

                return;
            }

            if (!Validator.IsFileExists(args[0]))
            {
                Console.WriteLine(ErrorCode.FileNotFound.GetMessage(args[0]));
                Console.WriteLine(HELP_STRING);

                return;
            }

            #endregion

            var searchReplaceData = new MatchCountReplaceModel(args[1], args.Length == 3 ? args[2] : null);


            TextProcessor textProcessor = new TextProcessor(new FileProcessor(fileName), searchReplaceData);

            for (int i = 0; i < 10; i++)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                textProcessor.StartAutoParsing();
                stopwatch.Stop();
                Console.WriteLine(((double)(stopwatch.Elapsed.TotalSeconds)).ToString("0.00 s"));
            }

            var count = textProcessor.StartAutoParsing();
            Console.WriteLine("Operation count: " + count);
            Console.ReadKey();

            log.Info("Application [FileParser] End");
        }
    }
}
