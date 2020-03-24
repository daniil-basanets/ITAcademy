using LuckyTicket.Models;
using System;
using System.Collections.Generic;
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
            StreamReader streamReader = new StreamReader(fileName);

        }
    }
}
