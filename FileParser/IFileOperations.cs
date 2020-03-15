namespace FileParser
{
    interface IOperationProcessor
    {
        int MatchCount(CountReplaceModel countReplaceModel);
        int ReplaceString(CountReplaceModel countReplaceModel);
    }
}
