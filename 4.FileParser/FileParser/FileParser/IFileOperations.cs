using System;
using System.Collections.Generic;
using System.Text;

namespace FileParser
{
    interface IFileOperations
    {
        int MatchCount(CountReplaceModel countReplaceModel);
        int ReplaceString(CountReplaceModel countReplaceModel);
    }
}
