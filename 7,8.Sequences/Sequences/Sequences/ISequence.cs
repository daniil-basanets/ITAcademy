using System;
using System.Collections.Generic;
using System.Text;

namespace Sequences
{
    interface ISequence
    {
        public IList<long> Generate(int startIndex, int endIndex);
    }
}
