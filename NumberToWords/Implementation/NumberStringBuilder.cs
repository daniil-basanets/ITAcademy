using NumberToWords.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords.Implementation
{
    class NumberStringBuilder : IStringNumerals
    {
        #region Private Members

        private int number;
        private IStringNumerals numeralsConverter;

        #endregion

        public NumberStringBuilder(int sourceNumber)
        {
            number = sourceNumber;
            numeralsConverter = new BellowHundredConverter();
        }

        public string NumberToWords(int sourceNumber)
        {
            this.number = sourceNumber;
            if (sourceNumber == 0)
                return "zero";

            if (sourceNumber < 0)
                return "minus " + NumberToWords(Math.Abs(sourceNumber));

            string words = "";

            if ((sourceNumber / 1000000) > 0)
            {
                words += NumberToWords(sourceNumber / 1000000) + " million ";
                sourceNumber %= 1000000;
            }

            if ((sourceNumber / 1000) > 0)
            {
                words += NumberToWords(sourceNumber / 1000) + " thousand ";
                sourceNumber %= 1000;
            }

            if ((sourceNumber / 100) > 0)
            {
                words += NumberToWords(sourceNumber / 100) + " hundred ";
                sourceNumber %= 100;
            }

            if (sourceNumber > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (sourceNumber < 20)
                    words += unitsMap[sourceNumber];
                else
                {
                    words += tensMap[sourceNumber / 10];
                    if ((sourceNumber % 10) > 0)
                        words += "-" + unitsMap[sourceNumber % 10];
                }
            }

            return words;
        }

        public string GetString(int sourceNumber)
        {
            return GetStringBuilder(sourceNumber).ToString().Trim();
        }

        public StringBuilder GetStringBuilder(int sourceNumber)
        {
            number = sourceNumber;

            var hundred_num = number % 1000;
            var hundreds = hundred_num / 100;
            var remainderHundred = hundred_num % 100;
            StringBuilder stringBuilder = null;

            if (hundreds > 0)
            {
                stringBuilder = numeralsConverter.GetStringBuilder(hundreds);
                stringBuilder.Append(" hundred");
            }

            if (stringBuilder == null)
            {
                stringBuilder = new StringBuilder();
            }

            stringBuilder.Append(" ");
            stringBuilder.Append(numeralsConverter.GetString(remainderHundred));

            return stringBuilder;
        }
    }
}
