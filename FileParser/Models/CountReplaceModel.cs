namespace FileParser.Models
{
    /// <summary>
    /// Stores search and replace string patterns
    /// </summary>
    public class MatchCountReplaceModel
    {
        public string SearchPattern { get; set; }
        public string ReplacePattern { get; set; }

        public MatchCountReplaceModel(string searchPattern, string replacePattern)
        {
            SearchPattern = searchPattern;
            ReplacePattern = replacePattern;
        }
    }
}
