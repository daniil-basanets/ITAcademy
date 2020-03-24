using log4net;
using LuckyTicket.Logics;
using LuckyTicket.Models;
using System;
using HelpersLibrary;
using System.IO;
using log4net.Config;

namespace LuckyTicket
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string NotFound = "File not found!";

        static void Main(string[] args)
        {

            #region Initialize logger

            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("Log4Net.config"));
            log.Info("Application [FileParser] Start");

            #endregion


            #region Check input data

            var fileName = Parser.TryGetString(args, 0, out ErrorCode errorCode);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());

                return;
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine(NotFound);

                return;
            }

            #endregion

            try
            {
                var ticketType = new FileParser(fileName).GetLuckyType();
                Ticket ticket = TicketFactory.Build(ticketType);

                var count = ticket.GetLuckyCount();

                Console.WriteLine("Lucky tickets count:" + count);
            }
            catch (Exception e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }

        }
    }
}
