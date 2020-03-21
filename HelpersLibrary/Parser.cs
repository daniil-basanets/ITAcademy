using System;
using System.Globalization;

namespace HelpersLibrary
{
    /// <summary>
    /// Represents static class for parsing with additional errors info.
    /// </summary>
    public static class Parser
    {
      /*  static public ErrorCode TryGetRange(string[] s, out int start, out int end)
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
        }*/

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
