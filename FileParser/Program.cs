﻿using log4net;
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
        private const string HelpString = "\n\r[HELP] Use parameters: \n\rfileName searchPattern\n\rfileName searchPattern replacePattern";

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
                Console.WriteLine(HelpString);

                return;
            }

            if (args.Length < 2)
            {
                Console.WriteLine(ErrorCode.InvalidParametersCount.GetMessage());
                Console.WriteLine(HelpString);

                return;
            }

            if (!Validator.IsFileExists(args[0]))
            {
                Console.WriteLine(ErrorCode.FileNotFound.GetMessage(args[0]));
                Console.WriteLine(HelpString);

                return;
            }

            #endregion

            var searchReplaceData = new MatchCountReplaceModel(args[1], args.Length == 3 ? args[2] : null);


            TextProcessor textProcessor = new TextProcessor(new FileProcessor(fileName), searchReplaceData);

            var count = textProcessor.StartAutoParsing();
            Console.WriteLine("Operation match/replace count: " + count);
            Console.ReadKey();

            log.Info("Application [FileParser] End");
        }
    }
}
