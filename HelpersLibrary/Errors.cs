using log4net;
using System.Text;

namespace HelpersLibrary
{
    public enum ErrorCode
    {
        Void = 0,
        InvalidParametersCount = 1,
        CannotConvertParameter = 2,
        OverflowRange = 3,
        FileNotFound = 4,
        InvalidProperty = 5,
        StringIsEmpty = 6
    }

    public static class Errors
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string[] errorMessages = { "", "Invalid parameters count!", "Cannot convert parameter!",
            "Invalid parameter range!", "File not found!", "Invalid property", "String is empty" };

        public static string GetMessage(this ErrorCode errorCode, string additionalText = null)
        {
            StringBuilder stringBuilder = new StringBuilder(errorMessages[(int)errorCode]);
            if (additionalText != null)
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(additionalText);
            }
            
            log.Error(stringBuilder.ToString());

            return stringBuilder.ToString();
        }
    }
}
