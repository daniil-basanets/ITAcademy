using System;
using Sequence.Helpers;

namespace Sequences
{
    class Program
    {
        static readonly string[] errors = {"","Invalid parameters!", "Invalid parameter range!"};
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
            int startIndex, endIndex, sequenceType;
            ErrorCode errorCode;

            errorCode = Parser.TryGetInt(args, SEQUENECE_TYPE_INPUT_INDEX, out sequenceType);
            if(errorCode != ErrorCode.Void)
            {
                PrintError(errorCode);
                return;
            }
            
            errorCode = Parser.TryGetRange(args, out startIndex, out endIndex);          
            if (errorCode != ErrorCode.Void)
            {
                PrintError(errorCode);
                return;
            }

            if (!Validator.IsNaturalNumber(startIndex) || !Validator.IsNaturalNumber(endIndex)
                || !Validator.IsNaturalNumber(endIndex-startIndex)
                || !Validator.IsNumberInRange(endIndex, 0, (sequenceType == 1) ? MAX_FOR_FIBONACCI : Int32.MaxValue) )
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

            sequenceCalculator.PrintGeneratedString(startIndex, endIndex, ',');

            sequenceCalculator.SetSequence(new Fibonacci());
        }
    }
}
