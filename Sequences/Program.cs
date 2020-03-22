﻿using System;
using HelpersLibrary;
using log4net;
using log4net.Config;
using Sequences.Logics;
using Sequences.Implementation;

namespace Sequences
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
        const string HELP_STRING = "[HELP] Use parameters: StartIndex EndIndex SequenceType\n\rwhere SequenceType: 1 - Fibonacci, 2 - Square natural numbers\n\rmax endIndex for Fibonacci is 92";
        const int SEQUENECE_TYPE_INPUT_INDEX = 2;
        const int MAX_FOR_FIBONACCI = 92;

        static void ConsoleShowError(ErrorCode errorCode, string parameter = "")
        {
            Console.WriteLine(errorCode.GetMessage(parameter));
            Console.WriteLine(HELP_STRING);
        }

        static void Main(string[] args)
        {

            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion

            SequenceType sequenceType;
            int sequenceTypeString;
            IntRange range;

            #region Check input data

            sequenceTypeString = Parser.TryGetInt(args, SEQUENECE_TYPE_INPUT_INDEX, out ErrorCode errorCode);
            if (errorCode != ErrorCode.Void)
            {
                ConsoleShowError(errorCode);
                return;
            }

            if (!Enum.IsDefined(typeof(SequenceType), sequenceTypeString))
            {
                log.Error(ErrorCode.InvalidParameter.ToString());
                ConsoleShowError(ErrorCode.InvalidParameter, "SequenceType");

                return;
            }
            else
            {
                sequenceType = (SequenceType)sequenceTypeString;
            }

            range = Parser.TryGetRange(args, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                ConsoleShowError(errorCode);
                return;
            }

            if (!Validator.IsNaturalNumber(range.Start) || !Validator.IsNaturalNumber(range.End)
                || !Validator.IsNaturalNumber(range.Count())
                || !Validator.IsNumberInRange(range.End, 0, (sequenceType == SequenceType.Fibonacci) ? MAX_FOR_FIBONACCI : Int32.MaxValue))
            {
                ConsoleShowError(ErrorCode.OverflowRange);
                return;
            }

            #endregion

            SequenceCalculator sequenceCalculator = new SequenceCalculator(SequenceFactory.Build(sequenceType));

            sequenceCalculator.PrintGeneratedString(range, ',');
            Console.ReadKey();

            log.Info("Application [FileParser] End");
        }
    }
}
