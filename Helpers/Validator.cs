using System;
using System.IO;

namespace Helpers
{
    static class Validator
    {
        static public bool IsNaturalNumber(int number, int max = Int32.MaxValue)
        {
            return IsNumberInRange(number, 0, max);
        }

        static public bool IsNumberInRange(int number, int start, int max)
        {
            return number >= start && number <= max;
        }

        static public bool IsNumberInRange(float number, float start, float max)
        {
            return number >= start && number <= max;
        }

        static public bool IsPositiveNumber(int number)
        {
            return IsNumberInRange(number, 0, Int32.MaxValue);
        }

        static public bool IsPositiveNumber(float number)
        {
            return IsNumberInRange(number, 0f, float.MaxValue);
        }

        static public bool IsFileExists(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (File.OpenRead(fileName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
