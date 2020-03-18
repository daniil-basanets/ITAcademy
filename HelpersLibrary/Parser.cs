using System;
using System.Globalization;

namespace HelpersLibrary
{
    public static class Parser
    {
        static public ErrorCode TryGetRange(string[] s, out int start, out int end)
        {
            start = 0;
            end = 0;

            if (s.Length < 2)
            {
                return ErrorCode.InvalidParametersCount;
            }

            if (!Int32.TryParse(s[0], out start) || !Int32.TryParse(s[1], out end))
            {
                return ErrorCode.CannotConvertParameter;
            }

            return ErrorCode.Void;
        }

        static public ErrorCode TryGetInt(string[] s, int argIndex, out int value)
        {
            value = 0;

            if (s.Length - 1 < argIndex)
            {
                return ErrorCode.InvalidParametersCount;
            }

            if (!Int32.TryParse(s[argIndex], out value))
            {
                return ErrorCode.CannotConvertParameter;
            }

            return ErrorCode.Void;
        }

        static public ErrorCode TryGetFloat(string[] s, int argIndex, out float value)
        {
            value = 0f;

            if (s.Length - 1 < argIndex)
            {
                return ErrorCode.InvalidParametersCount;
            }

            if (!float.TryParse(s[argIndex], NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return ErrorCode.CannotConvertParameter;
            }

            return ErrorCode.Void;
        }

        static public ErrorCode TryGetFloat(string s, out float value)
        {
            value = 0f;

            if (!float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return ErrorCode.CannotConvertParameter;
            }

            return ErrorCode.Void;
        }
    }
}
