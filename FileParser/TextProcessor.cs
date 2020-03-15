using System;
using System.Collections.Generic;
using System.Text;

namespace FileParser
{
    class TextProcessor
    {
        #region Private Members

        private IOperationProcessor worker;

        #endregion

        public CountReplaceModel CountReplaceData { get; set; }

         public TextProcessor(IOperationProcessor processor)
        {
            worker = processor;
        }

        public TextProcessor(IOperationProcessor processor, CountReplaceModel data):
            this(processor)
        {
            CountReplaceData = data;
        }

        public int CountSubstring()
        {
           return CountSubstring(CountReplaceData); 
        }

        public int CountSubstring(CountReplaceModel countReplaceData)
        {
            return worker.MatchCount(countReplaceData);
        }

        public int ReplaceSubstring(CountReplaceModel countReplaceData)
        {
            return worker.ReplaceString(countReplaceData);
        }

        public int ReplaceSubstring()
        {
            return ReplaceSubstring(CountReplaceData);
        }

        public int StartAutoParsing()
        {
            if (CountReplaceData.ReplaceString != null)
            {
                return ReplaceSubstring();
            }
            else
            {
                return CountSubstring();
            }
        }
    }
}
