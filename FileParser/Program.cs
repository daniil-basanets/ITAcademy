using HelpersLibrary;

namespace FileParser
{
    class Program
    {
        const string HELP_STRING = "\n\r[HELP] Use parameters: \n\rfileName searchPattern\n\rfileName searchPattern replacePattern";

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine(ErrorCode.InvalidParametersCount.GetMessage());
                System.Console.WriteLine(HELP_STRING);

                return;
            }

            if (!Validator.IsFileExists(args[0] ?? ""))
            {
                System.Console.WriteLine(ErrorCode.FileNotFound.GetMessage());
                System.Console.WriteLine(HELP_STRING);

                return;
            }

            //var data = new CountReplaceModel(args[1], args.Length == 3 ? args[2] : null);
            //TextProcessor textProcessor = new TextProcessor(new FileParser(args[0]), data);

            var data = new CountReplaceModel(" ", null);

            TextProcessor textProcessor1 = new TextProcessor(new FileParser("t.txt"), data);
            int count = textProcessor1.StartAutoParsing();
            System.Console.WriteLine(count);


            var data2 = new CountReplaceModel(" ", "*");

            TextProcessor textProcessor = new TextProcessor(new FileParser("t.txt"), data2);
            int count2 = textProcessor.StartAutoParsing();
            System.Console.WriteLine(count2);
        }
    }
}
