using NumberToWords.Interface;
using System.Text;

namespace NumberToWords.Implementation
{
    class AboveHundredUSConverter : IStringNumerals
    {
        #region Private Members

        private readonly string[] numberWords =
            {"hundred", "thousand", "million", "billion", "trillion"};

        #endregion

        public string GetString(int sourceNumber)
        {
            return GetStringBuilder(sourceNumber).ToString();
        }

        public StringBuilder GetStringBuilder(int sourceNumber)
        {
            return new StringBuilder(numberWords[sourceNumber]);
        }
    }
}
