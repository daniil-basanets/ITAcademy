using System.Collections.Generic;
using HelpersLibrary;

namespace Sequences.Interfaces
{
    public interface ISequence
    {
        public IList<long> Generate(IntRange range);
    }
}
