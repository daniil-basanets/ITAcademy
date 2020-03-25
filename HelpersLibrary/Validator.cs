using System;
using System.IO;

namespace HelpersLibrary
{
    public static class Validator
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

        static public bool IsValidTriangle(float sideA, float sideB, float sideC)
        {
            return (sideA > 0 && sideB > 0 && sideC > 0) &&
                (sideA < sideB + sideC && sideB < sideA + sideC && sideC < sideB + sideA);
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
