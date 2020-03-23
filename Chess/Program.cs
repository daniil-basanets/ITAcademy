using System;

namespace Chess
{
    class Program
    {
        const string InvalidParameters = "Invalid parameters!";
        const string OverflowParameter = "Overflow parameter!";
        const string HelpString = "[HELP] Use parameters: height[0..255] width[0..255] fill_char";

        static void Main(string[] args)
        {
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
            catch (FormatException)
            {
                Console.WriteLine(InvalidParameters);
                Console.WriteLine(HelpString);

                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine(OverflowParameter);
                Console.WriteLine(HelpString);

                return;
            }
            catch (Exception)
            {
                Console.WriteLine(HelpString);

                return;
            }

            Сhessboard сhessboard = new Сhessboard(width, height, c);
            сhessboard.DrawBoard();

            Console.ReadKey();
        }
    }
}
