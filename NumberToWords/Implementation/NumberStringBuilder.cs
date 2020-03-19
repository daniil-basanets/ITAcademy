using NumberToWords.Interface;
using System;
using System.Text;

namespace NumberToWords.Implementation
{
    class NumberStringBuilder : IStringNumerals
    {
        #region Private Members

        const int HUNDRED_WORD_INDEX = 0;
        private int number;
        private readonly IStringNumerals numeralsConverter;
        private readonly IStringNumerals largeNumeralsConverter;

        #endregion

        private string GetWordsForPartNumber(int partOfNumber)
        {
            var hundreds = partOfNumber / 100;
            var remainderHundred = partOfNumber % 100;
            StringBuilder stringBuilder = null;

            if (hundreds > 0)
            {
                stringBuilder = numeralsConverter.GetStringBuilder(hundreds);
                stringBuilder.Append(" ");
                stringBuilder.Append(largeNumeralsConverter.GetString(HUNDRED_WORD_INDEX));
            }
            if (stringBuilder == null)
            {
                stringBuilder = new StringBuilder();
            }

            stringBuilder.Append(" ");
            stringBuilder.Append(numeralsConverter.GetString(remainderHundred));

            return stringBuilder.ToString().Trim();
        }

        public NumberStringBuilder(int sourceNumber)
        {
            number = sourceNumber;
            numeralsConverter = new BellowHundredUSConverter();
            largeNumeralsConverter = new AboveHundredUSConverter();
        }

        public StringBuilder GetStringBuilder(int sourceNumber)
        {
            var isNegative = sourceNumber < 0;
            number = Math.Abs(sourceNumber);

            int remainderThousand;
            StringBuilder stringBuilder = new StringBuilder();
            int largeNumeralsIndexer = 0;

            while (number > 0)
            {
                remainderThousand = number % 1000;
                if (largeNumeralsIndexer > 0)
                {
                    stringBuilder.Insert(0, " " + largeNumeralsConverter.GetString(largeNumeralsIndexer));
                }

                stringBuilder.Insert(0, GetWordsForPartNumber(remainderThousand));
                stringBuilder.Insert(0, " ");
                number /= 1000;
                ++largeNumeralsIndexer;
            }
            if (isNegative)
            {
                stringBuilder.Insert(0, "minus");
            }

            return stringBuilder;
        }

        public string GetString(int sourceNumber)
        {
            return GetStringBuilder(sourceNumber).ToString().Trim();
        }

    }
}
