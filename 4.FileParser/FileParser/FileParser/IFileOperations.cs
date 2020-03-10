namespace FileParser
{
    interface IFileOperations
    {
        int MatchCount(CountReplaceModel countReplaceModel);
        int ReplaceString(CountReplaceModel countReplaceModel);
    }
}
