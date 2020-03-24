using System;
using NumberToWords.Implementation;
using HelpersLibrary;
using log4net;
using log4net.Config;

namespace NumberToWords
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string HelpString = "\n\r[HELP] Use parameters: number";

        static void Main(string[] args)
        {
            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion

            int number = Parser.TryGetInt(args, 0, out ErrorCode errorCode);

            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());
                Console.WriteLine(HelpString);

                return;
            }

            try
            {
                Console.WriteLine(new NumberStringBuilder(number).GetString());
            }
            catch (Exception e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
        }
    }
}
