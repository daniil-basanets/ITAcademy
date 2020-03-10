using System.Collections.Generic;

namespace Sequences
{
    interface ISequence
    {
        public IList<long> Generate(int startIndex, int endIndex);
    }
}
