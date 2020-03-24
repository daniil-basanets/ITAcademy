using log4net;
using log4net.Config;
using System;

namespace Chess
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const string InvalidParameters = "Invalid parameters!";
        const string OverflowParameter = "Overflow parameter!";
        const string HelpString = "[HELP] Use parameters: height[0..255] width[0..255] fill_char";

        static void Main(string[] args)
        {

            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion


            int height;
            int width;
            char c = '*';

            try
            {
                if (args.Length < 2)
                {
                    throw new FormatException();
                }

                height = Convert.ToInt32(args[0]);
                width = Convert.ToInt32(args[1]);
                if (args.Length > 2)
                {
                    c = Convert.ToChar(args[2]);
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(InvalidParameters);
                Console.WriteLine(HelpString);
                log.Error(fe);

                return;
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(OverflowParameter);
                Console.WriteLine(HelpString);
                log.Error(oe);

                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(HelpString);
                log.Error(e);

                return;
            }

            try
            {
                Сhessboard сhessboard = new Сhessboard(width, height, c);
                сhessboard.DrawBoard();

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
