using FileParser.Interfaces;
using FileParser.Models;
using log4net;

namespace FileParser.Logics
{
    /// <summary>
    /// Represents a text processor for the match count, replacing. Using IOperationProcessor for processing
    /// </summary>
    public class TextProcessor
    {
        #region Private Members
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            int count;
            try
            {
                count = worker.MatchCount(countReplaceData);
            }
            catch (System.Exception e)
            {
                log.Error(e);
                throw;
            }
            return count;
        }

        public int ReplaceSubstring(MatchCountReplaceModel countReplaceData)
        {
            int count;
            try
            {
                count = worker.ReplaceString(countReplaceData);
            }
            catch (System.Exception e)
            {
                log.Error(e);
                throw;
            }
            return count;
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
