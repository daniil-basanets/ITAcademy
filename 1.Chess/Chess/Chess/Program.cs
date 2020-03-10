using System;

namespace Chess
{
    class Program
    {
        const string INVALID_PARAMETERS = "Invalid parameters!";
        const string OVERFLOW_PARAMETER = "Overflow parameter!";
        const string HELP_STRING = "[HELP] Use parameters: height[0..255] width[0..255] fill_char";

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
                Console.WriteLine(INVALID_PARAMETERS);
                Console.WriteLine(HELP_STRING);

                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine(OVERFLOW_PARAMETER);
                Console.WriteLine(HELP_STRING);

                return;
            }
            catch (Exception)
            {
                Console.WriteLine(HELP_STRING);

                return;
            }

            Сhessboard сhessboard = new Сhessboard(width, height, c);
            сhessboard.DrawBoard();

            Console.ReadKey();
        }
    }
}
