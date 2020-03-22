using System;
using HelpersLibrary;
using Sequences.Logics;

namespace Sequences
{
    class Program
    {
        static readonly string[] errors = { "", "Invalid parameters!", "Invalid parameter range!" };
        const string HELP_STRING = "[HELP] Use parameters: StartIndex EndIndex SequenceType\n\rwhere SequenceType: 1 - Fibonacci, 2 - Square natural numbers";
        const int SEQUENECE_TYPE_INPUT_INDEX = 2;
        const int MAX_FOR_FIBONACCI = 92;

        static void PrintError(ErrorCode errorCode)
        {
            Console.WriteLine(errors[(int)errorCode]);
            Console.WriteLine(HELP_STRING);
        }

        static void Main(string[] args)
        {
            int sequenceType;
            ErrorCode errorCode;

            sequenceType = Parser.TryGetInt(args, SEQUENECE_TYPE_INPUT_INDEX, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                PrintError(errorCode);
                return;
            }

            var range = Parser.TryGetRange(args, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                PrintError(errorCode);
                return;
            }

            if (!Validator.IsNaturalNumber(range.Start) || !Validator.IsNaturalNumber(range.End)
                || !Validator.IsNaturalNumber(range.Count())
                || !Validator.IsNumberInRange(range.End, 0, (sequenceType == 1) ? MAX_FOR_FIBONACCI : Int32.MaxValue))
            {
                PrintError(ErrorCode.OverflowRange);
                return;
            }

            SequenceCalculator sequenceCalculator;
            switch (sequenceType)
            {
                case 1:
                    sequenceCalculator = new SequenceCalculator(new Fibonacci());
                    break;
                case 2:
                    sequenceCalculator = new SequenceCalculator(new SquareNaturalNumbers());
                    break;
                default:
                    PrintError(ErrorCode.Void);
                    return;
            }

            sequenceCalculator.PrintGeneratedString(range, ',');

            sequenceCalculator.SetSequence(new Fibonacci());
        }
    }
}
