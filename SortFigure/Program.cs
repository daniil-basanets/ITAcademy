using log4net;
using log4net.Config;
using SortFigure.Implementation;
using SortFigure.Logics;
using System;

namespace SortFigure
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion

            ConsoleUI.Start(args);

            Console.ReadKey();
        }

    }
}
