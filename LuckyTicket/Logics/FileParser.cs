using LuckyTicket.Models;
using System;
using System.IO;
using System.Text;

namespace LuckyTicket.Logics
{
    class FileParser
    {
        #region Private Members

        private readonly string fileName;

        #endregion

        public FileParser(string fileName)
        {
            this.fileName = fileName;
        }

        public LuckyType GetLuckyType()
        {
            string s = null;
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                s = streamReader.ReadLine().ToLower();
            }

            LuckyType luckyType;
            if (s == "piter")
            {
                luckyType = LuckyType.Petersberg;
            }
            else if (s == "moscow")
            {
                luckyType = LuckyType.Moscow;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder("Unknown lucky method: ");
                stringBuilder.Append(s);
                throw new ArgumentException(stringBuilder.ToString());
            }

            return luckyType;
        }
    }
}
