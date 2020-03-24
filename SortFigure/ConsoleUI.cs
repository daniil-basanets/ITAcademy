using System;
using System.Collections.Generic;
using System.Text;
using SortFigure.Interfaces;
using SortFigure.Logics;
using HelpersLibrary;
using SortFigure.Implementation;
using log4net;

namespace SortFigure
{
    static class ConsoleUI
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static bool IsUserChoiceYes()
        {
            var s = Console.ReadLine();
            s = s.ToLower();
            return s.Contains('y') || s.Contains("yes");
        }

        private static Figure GetTriangleFromArgs(string[] args)
        {
            float sideA;
            float sideB;
            float sideC;
            string name;

            name = Parser.TryGetString(args, 0, out ErrorCode errorCode);
            if (errorCode != ErrorCode.Void)
            {
                return null;
            }

            sideA = Parser.TryGetFloat(args, 0, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                return null;
            }

            sideB = Parser.TryGetFloat(args, 1, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                return null;
            }

            sideC = Parser.TryGetFloat(args, 1, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                return null;
            }

            if (!Validator.IsValidTriangle(sideA, sideB, sideC))
            {
                return null;
            }

            Figure figure = new Triangle(sideA, sideB, sideC, name);

            return figure;
        }

        private static bool AskInputContinue()
        {
            Console.WriteLine("Do you want to continue? Type \"y\" or \"yes\"");
            var b = IsUserChoiceYes();
            Console.WriteLine(("").PadRight(24, '-'));
            return b;
        }

        private static Figure AskInputNewTriangle()
        {

            float sideA;
            float sideB;
            float sideC;
            string name;
            string s;
            string[] inputParams;


            Console.WriteLine("\r\nPlease, enter the new Triangle\r\n<name>;<sideA>;<sideB>;<sideC>");
            s = Console.ReadLine().Trim();
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", "");
            inputParams = s.Split(';');
            if (inputParams.Length != 4)
            {
                Console.WriteLine(ErrorCode.InvalidParametersCount.GetMessage());

                return null;
            }

            name = inputParams[0];

            sideA = Parser.TryGetFloat(inputParams, 1, out ErrorCode errorCode);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());

                return null;
            }

            sideB = Parser.TryGetFloat(inputParams, 2, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());

                return null;
            }

            sideC = Parser.TryGetFloat(inputParams, 3, out errorCode);
            if (errorCode != ErrorCode.Void)
            {
                Console.WriteLine(errorCode.GetMessage());

                return null;
            }

            if (!Validator.IsValidTriangle(sideA, sideB, sideC))
            {
                Console.WriteLine(ErrorCode.IncorrectTriangle.GetMessage());

                return null;
            }

            Figure figure = new Triangle(sideA, sideB, sideC, name);

            return figure;
        }

        public static void Start(string[] args)
        {
            bool needContinue = true;
            FigureHandler figureHandler = new FigureHandler();

            try
            {
                Figure figure = GetTriangleFromArgs(args);

                if (figure == null)
                {
                    figure = AskInputNewTriangle();
                }

                while (needContinue)
                {
                    if (figure != null)
                    {
                        figureHandler.AddFigure(figure);
                    }

                    needContinue = AskInputContinue();

                    if (needContinue)
                    {
                        figure = AskInputNewTriangle();
                    }
                }

                Console.WriteLine(figureHandler);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw;
            }

        }


    }
}
