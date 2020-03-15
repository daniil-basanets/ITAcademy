using System;
using System.Collections.Generic;
using System.Text;
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
