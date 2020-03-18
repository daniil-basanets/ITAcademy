namespace FileParser
{
    class CountReplaceModel
    {
        public string SearchString { get; set; }
        public string ReplaceString { get; set; }

        public CountReplaceModel(string searchString, string replaceString)
        {
            SearchString = searchString;
            ReplaceString = replaceString;
        }
    }
}
