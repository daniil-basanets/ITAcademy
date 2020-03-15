using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace FileParser
{
    class FileParser : IOperationProcessor
    {
        #region Private Members

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
            int len = 0;
            string s;
            Regex regex = new Regex(countReplaceModel.SearchString);
            byte[] buff = new byte[bufferSize];

            using FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (var buffStream = new BufferedStream(fileStream, bufferSize))
            {               
                while( len < buffStream.Length)
                {
                    len += buffStream.Read(buff, (int)0, bufferSize);
                    s = Encoding.UTF8.GetString(buff);
                    while (regex.IsMatch(s))
                    {
                        s = regex.Replace(s, countReplaceModel.ReplaceString);
                        replaceCount++;
                    }
                    buff = Encoding.UTF8.GetBytes(s);
                    buffStream.Seek( -bufferSize, SeekOrigin.Current);
                    buffStream.Write(buff, 0, bufferSize);
                }
                buffStream.Flush();
                buffStream.Close();
            }
            
            return replaceCount;
        }
    }
}
