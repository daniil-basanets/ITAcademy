using System.Text;

namespace NumberToWords.Models
{
    interface IStringNumerals
    {
        string GetString(int sourceNumber);
        StringBuilder GetStringBuilder(int sourceNumber);
    }
}
