using FileParser.Models;

namespace FileParser.Interfaces
{
    public interface IOperationProcessor
    {
        /// <summary>
        /// Count matches for regex pattern 
        /// </summary>
        /// <param name="countReplaceModel">Input data for match count or replace</param>
        /// <returns>Number of matches</returns>
        int MatchCount(MatchCountReplaceModel countReplaceModel);
        int ReplaceString(MatchCountReplaceModel countReplaceModel);
    }
}
