using FileParser.Interfaces;
using FileParser.Models;

namespace FileParser.Logics
{
    /// <summary>
    /// Represents a text processor for the match count, replacing. Using IOperationProcessor for processing
    /// </summary>
    internal class TextProcessor
    {
        #region Private Members

        private readonly IOperationProcessor worker;

        #endregion

        public MatchCountReplaceModel CountReplaceData { get; set; }

        /// <summary>
        /// Initializes a new instance of the TextProcessor class with the specified IOperationProcessor
        /// </summary>
        /// <param name="processor">Processing worker</param>
        public TextProcessor(IOperationProcessor processor)
        {
            worker = processor;
        }

        /// <summary>
        /// Initializes a new instance of the TextProcessor class with the specified IOperationProcessor and MatchCountReplaceModel
        /// </summary>
        /// <param name="processor">Processing worker</param>
        /// <param name="data">Input search and replace string patterns</param>
        public TextProcessor(IOperationProcessor processor, MatchCountReplaceModel data) :
            this(processor)
        {
            CountReplaceData = data;
        }

        public int CountSubstring()
        {
            return CountSubstring(CountReplaceData);
        }

        public int CountSubstring(MatchCountReplaceModel countReplaceData)
        {
            return worker.MatchCount(countReplaceData);
        }

        public int ReplaceSubstring(MatchCountReplaceModel countReplaceData)
        {
            return worker.ReplaceString(countReplaceData);
        }

        public int ReplaceSubstring()
        {
            return ReplaceSubstring(CountReplaceData);
        }

        public int StartAutoParsing()
        {
            if (CountReplaceData.ReplacePattern != null)
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
