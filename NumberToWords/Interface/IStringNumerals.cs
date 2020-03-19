using System.Text;

namespace NumberToWords.Interface
{
    interface IStringNumerals
    {
        string GetString(int sourceNumber);
        StringBuilder GetStringBuilder(int sourceNumber);
    }
}
