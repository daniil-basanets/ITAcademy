using System.IO;
using System.Text.RegularExpressions;
using FileParser.Interfaces;
using FileParser.Models;

namespace FileParser.Logics
{
    public class FileProcessor : IOperationProcessor
    {
        #region Private Members

        private const string TEMP_FILE_NAME = "Temp_FileParser_File";
        private const int DEFAULT_BUFFER_SIZE = 4096;
        private readonly int bufferSize;

        #endregion

        public string FilePath { get; set; }

        public FileProcessor(string filePath)
        {
            bufferSize = DEFAULT_BUFFER_SIZE;
            FilePath = filePath;
        }

        public int MatchCount(MatchCountReplaceModel countReplaceModel)
        {
            int matchCount = 0;
            string s;
            Regex regex = new Regex(countReplaceModel.SearchPattern);
            MatchCollection matches;
            
            using var buffStream = new BufferedStream(File.OpenRead(FilePath), bufferSize);
            using var stream = new StreamReader(buffStream);

            while (!stream.EndOfStream)
            {
                s = stream.ReadLine();
                matches = regex.Matches(s);
                matchCount += matches.Count;
            }


            return matchCount;
        }

        public int ReplaceString(MatchCountReplaceModel countReplaceModel)
        {
            int replaceCount = 0;
            string s;
            Regex regex = new Regex(countReplaceModel.SearchPattern);

            using var buffReader = new BufferedStream(File.OpenRead(FilePath), bufferSize);
            using var buffWriter = new BufferedStream(File.OpenWrite(TEMP_FILE_NAME), bufferSize);
            using var streamReader = new StreamReader(buffReader);
            using var streamWriter = new StreamWriter(buffWriter);

            while (!streamReader.EndOfStream)
            {
                s = streamReader.ReadLine();
                replaceCount += regex.Matches(s).Count;
                s = ReplaceStringWithRegex(s, countReplaceModel.ReplacePattern, regex);
                streamWriter.WriteLine(s);
            }

            streamWriter.Flush();
            streamWriter.Close();

            streamReader.Close();

            File.Delete(FilePath);
            File.Move(TEMP_FILE_NAME, FilePath);


            return replaceCount;
        }

        public static string ReplaceStringWithRegex(string input, string replacement, Regex regex)
        {
            if(input == "" || replacement =="" || regex.ToString() == "")
            {
                return input;
            }

            if (regex.IsMatch(input))
            {
                return regex.Replace(input, replacement);
            }

            return input;   //nothing replaced
        }

    }
}
