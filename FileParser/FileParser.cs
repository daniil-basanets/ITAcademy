using System.IO;
using System.Text.RegularExpressions;

namespace FileParser
{
    class FileParser : IOperationProcessor
    {
        #region Private Members

        const string TEMP_FILE_NAME = "tmp_file";
        private readonly int bufferSize;

        #endregion

        public FileParser(string filePath)
        {
            bufferSize = 1024;
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public int MatchCount(CountReplaceModel countReplaceModel)
        {
            int matchCount = 0;
            string s;
            Regex regex = new Regex(countReplaceModel.SearchString);
            MatchCollection matches;

            using (var buffStream = new BufferedStream(File.OpenRead(FilePath), bufferSize))
            {
                using var stream = new StreamReader(buffStream);
                while (!stream.EndOfStream)
                {
                    s = stream.ReadLine();
                    matches = regex.Matches(s);
                    matchCount += matches.Count;
                }
            }

            return matchCount;
        }

        public int ReplaceString(CountReplaceModel countReplaceModel)
        {
            int replaceCount = 0;
            string s;
            Regex regex = new Regex(countReplaceModel.SearchString);

            using (var buffReader = new BufferedStream(File.OpenRead(FilePath), bufferSize))
            {
                using var buffWriter = new BufferedStream(File.OpenWrite(TEMP_FILE_NAME), bufferSize);
                using var reader = new StreamReader(buffReader);
                using var writer = new StreamWriter(buffWriter);

                while (!reader.EndOfStream)
                {
                    s = reader.ReadLine();
                    replaceCount += regex.Matches(s).Count;
                    s = ReplaceStringWithRegex(s, countReplaceModel.ReplaceString, regex);
                    writer.WriteLine(s);
                }

                writer.Flush();
                writer.Close();

                reader.Close();

                File.Delete(FilePath);
                File.Move(TEMP_FILE_NAME, FilePath);
            }

            return replaceCount;
        }

        public static string ReplaceStringWithRegex(string input, string replacement, Regex regex)
        {
            if (regex.IsMatch(input))
            {
                return regex.Replace(input, replacement);
            }

            return input;   //nothing replaced
        }

    }
}
