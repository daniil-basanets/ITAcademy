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
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string HELP_STRING = "\n\r[HELP] Use parameters: \n\rfileName searchPattern\n\rfileName searchPattern replacePattern";

        private static void Main(string[] args)
        {
            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion


            if (args.Length < 2)
            {
                Console.WriteLine(ErrorCode.InvalidParametersCount.GetMessage());
                System.Console.WriteLine(HELP_STRING);

                return;
            }

            if (!Validator.IsFileExists(args[0] ?? ""))
            {
                System.Console.WriteLine(ErrorCode.FileNotFound.GetMessage());
                System.Console.WriteLine(HELP_STRING);

                return;
            }

            //var data = new CountReplaceModel(args[1], args.Length == 3 ? args[2] : null);
            //TextProcessor textProcessor = new TextProcessor(new FileParser(args[0]), data);

            var data = new MatchCountReplaceModel(" ", null);

            var data2 = new MatchCountReplaceModel(" ", "*");

            TextProcessor textProcessor = new TextProcessor(new FileProcessor("t.txt"), data2);
            int count2 = textProcessor.StartAutoParsing();
            System.Console.WriteLine(count2);

            log.Info("Application [FileParser] End");
        }
    }
}
