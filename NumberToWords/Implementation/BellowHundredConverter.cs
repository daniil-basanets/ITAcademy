using NumberToWords.Models;
using System.Text;

namespace NumberToWords.Implementation
{
    class BellowHundredConverter : IStringNumerals
    {
        private readonly string[] baseDigitWords =
            {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

        private readonly string[] doubleDigitWords =
            {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};

        private readonly string[] dozenWords =
          {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};

        public string GetString(int sourceNumber) 
        {
            return GetStringBuilder(sourceNumber).ToString();
        }

        public StringBuilder GetStringBuilder(int sourceNumber)
        {
            /*  if (number == 0)
           {
               return "";
           }*/

            if (sourceNumber >= 20)
            {
                int unit = sourceNumber % 10;
                int wordIndex = (sourceNumber / 10) % 10 - 2;
                StringBuilder stringBuilder = new StringBuilder(dozenWords[wordIndex]);
                if (unit != 0)
                {
                    stringBuilder.Append(" ");
                    stringBuilder.Append(baseDigitWords[unit]);
                }
                return stringBuilder;
            }

            if (10 <= sourceNumber && sourceNumber <= 19)
            {
                return new StringBuilder(doubleDigitWords[sourceNumber - 10]);
            }

            if (0 < sourceNumber && sourceNumber < 10)
            {
                return new StringBuilder(baseDigitWords[sourceNumber]);
            }
            else
            {
                return new StringBuilder();
            }
        }
    }
}
