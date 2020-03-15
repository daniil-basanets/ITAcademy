using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    internal enum ErrorCode
    {
        Void = 0,
        InvalidParameters = 1,
        OverflowRange = 2,
        FileNotFound = 3
    }

    static class Errors
    {
        private static readonly string[] errorMessages = { "", "Invalid parameters!", "Invalid parameter range!", "File not found!" };

        public static string GetMessage(this ErrorCode errorCode)
        {
            return errorMessages[(int)errorCode];
        }
    }
}
