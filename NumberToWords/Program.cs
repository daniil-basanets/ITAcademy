using NumberToWords.Implementation;
using System;

namespace NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            for (int i = 0; i < 150; i++)
            {
                var m = rand.Next() * 10;
                //Console.WriteLine(m.ToString("#,#", CultureInfo.InvariantCulture) + " " + new NumberStringBuilder(m).GetString(m));
                Console.WriteLine(new NumberStringBuilder(m).GetString(m));
            }

            Console.ReadLine();

        }
    }
}
