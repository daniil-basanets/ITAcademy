using System;
using System.Globalization;

namespace HelpersLibrary
{
    public struct IntRange
    {
        public IntRange(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }

        public int Count()
        {
            return End - Start;
        }
    }

    /// <summary>
    /// Represents static class for parsing with additional errors info.
    /// </summary>
    public static class Parser
    {
        static public IntRange TryGetRange(string[] s, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.Void;          
            var start = 0;
            var end = 0;
            IntRange range = new IntRange(start, end);

            if (s.Length < 2)
            {
                errorCode = ErrorCode.InvalidParametersCount;

                return range;
            }

            if (!Int32.TryParse(s[0], out start) || !Int32.TryParse(s[1], out end))
            {
                errorCode = ErrorCode.CannotConvertParameter;

                return range;
            }
            range.Start = start;
            range.End = end;

            return range;
        }

        static public int TryGetInt(string[] s, int argIndex, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.Void;
            int value = 0;

            if (s.Length - 1 < argIndex)
            {
                errorCode = ErrorCode.InvalidParametersCount;
                return value;
            }
            else if (!int.TryParse(s[argIndex], out value))
            {
                errorCode = ErrorCode.CannotConvertParameter;
            }

            return value;
        }

        static public float TryGetFloat(string[] stringArray, int argIndex, out ErrorCode errorCode)
        {
            float value = 0f;

            if (stringArray.Length - 1 < argIndex)
            {
                errorCode = ErrorCode.InvalidParametersCount;
                return value;
            }
            else
            {
                value = TryGetFloat(stringArray[argIndex], out errorCode);
            }


            return value;
        }

        static public float TryGetFloat(string s, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.Void;

            if (!float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
            {
                errorCode = ErrorCode.CannotConvertParameter;
            }

            return value;
        }

        static public string TryGetString(string[] stringArray, int paramIndex, out ErrorCode errorCode)
        {
            errorCode = ErrorCode.Void;

            if (stringArray.Length - 1 < paramIndex)
            {
                errorCode = ErrorCode.InvalidParametersCount;
                return null;
            }
            else if (stringArray[paramIndex] == null)
            {
                errorCode = ErrorCode.StringIsEmpty;
            }

            return stringArray[paramIndex];
        }
    }
}
