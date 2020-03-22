using System.Collections.Generic;
using HelpersLibrary;

namespace Sequences.Interfaces
{
    interface ISequence
    {
        public IList<long> Generate(IntRange range);
    }
}
