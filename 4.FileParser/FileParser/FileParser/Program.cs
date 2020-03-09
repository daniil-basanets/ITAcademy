using System;
using System.IO;

namespace FileParser
{
    class Program
    {

        static void Main(string[] args)
        {
            FileParser parcer = new FileParser("test.txt");
            CountReplaceModel model = new CountReplaceModel
            {
                SearchString = "AAA",
                ReplaceString = "BBB"
            };
            var t = parcer.MatchCount(model);
            t = parcer.ReplaceString(model);
        }   
    }
}
