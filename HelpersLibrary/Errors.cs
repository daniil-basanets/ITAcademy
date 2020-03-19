﻿namespace HelpersLibrary
{
    public enum ErrorCode
    {
        Void = 0,
        InvalidParametersCount = 1,
        CannotConvertParameter = 2,
        OverflowRange = 3,
        FileNotFound = 4,
        InvalidProperty = 5
    }

    public static class Errors
    {
        private static readonly string[] errorMessages = { "", "Invalid parameters!", "Invalid parameter range!", "File not found!", "Invalid property" };

        public static string GetMessage(this ErrorCode errorCode)
        {
            return errorMessages[(int)errorCode];
        }
    }
}