using System;

namespace Sequence.Helpers
{
    internal enum ErrorCode
    {
        Void = 0,
        InvalidParameters = 1,
        OverflowRange = 2
    }

    static class Parser
    {
        static public ErrorCode TryGetRange(string[] s, out int start, out int end)
        {
            start = 0;
            end = 0;

            if (s.Length < 2)
            {
                return ErrorCode.InvalidParameters;
            }

            if (!Int32.TryParse(s[0], out start) || !Int32.TryParse(s[1], out end))
            {
                return ErrorCode.InvalidParameters;
            }

            return ErrorCode.Void;
        }

        static public ErrorCode TryGetInt(string[] s, int argIndex, out int value)
        {
            value = 0;

            if (s.Length - 1 < argIndex)
            {
                return ErrorCode.InvalidParameters;
            }

            if (!Int32.TryParse(s[argIndex], out value))
            {
                return ErrorCode.InvalidParameters;
            }

            return ErrorCode.Void;
        }
    }
}
