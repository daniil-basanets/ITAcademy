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
        //  private const string HelpString = "\n\r[HELP] Use parameters: \n\rfileName searchPattern\n\rfileName searchPattern replacePattern";

        static void Main(string[] args)
        {

            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion

            int a = 2;
            int b = 3;
            int c = 4;
            FigureHandler figureHandler = new FigureHandler();
            for (int i = 0; i < 10; i++)
            {
                a += i;
                b += i;
                c += i;
                figureHandler.AddFigure(new Triangle(a, b, c, "first " + c));
            }

            Console.WriteLine(figureHandler);
            Console.ReadKey();
        }
    }
}
