using NumberToWords.Implementation;
using NumberToWords.Models;
using System;

namespace NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 123_456_789;
            IStringNumerals num = new BellowHundredConverter();

            var s = new NumberStringBuilder(n).GetString(n);
            Console.WriteLine(s);

            for (int i = 110; i < 200; i++)
            {
                Console.WriteLine(new NumberStringBuilder(i).GetString(i));
            }
            
            
        }
    }
}
