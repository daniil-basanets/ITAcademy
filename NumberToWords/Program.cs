using System;
using NumberToWords.Implementation;
using HelpersLibrary;

namespace NumberToWords
{
    class Program
    {
        private const string HelpString = "\n\r[HELP] Use parameters: number";

        static void Main(string[] args)
        {
            int number = Parser.TryGetInt(args, 0, out ErrorCode errorCode);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());
                Console.WriteLine(HelpString);

                return;
            }

            Console.WriteLine(new NumberStringBuilder(number).GetString());
            Console.ReadKey();
        }
    }
}
