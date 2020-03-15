using Helpers;

namespace FileParser
{
    class Program
    {
        const string HELP_STRING = "\n\r[HELP] Use parameters: \n\rfileName searchPattern\n\rfileName searchPattern replacePattern";

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine(ErrorCode.InvalidParameters.GetMessage());
                System.Console.WriteLine(HELP_STRING);

                return;
            }

            if(!Validator.IsFileExists(args[0] == null ? "" : args[0]))
            {
                System.Console.WriteLine(ErrorCode.FileNotFound.GetMessage());
                System.Console.WriteLine(HELP_STRING);

                return;
            }
           
            var data = new CountReplaceModel(args[1], args.Length == 3 ? args[2] : null);
            TextProcessor textProcessor = new TextProcessor(new FileParser(args[0]), data);

            int count = textProcessor.StartAutoParsing();
            System.Console.WriteLine(count);
        }   
    }
}
