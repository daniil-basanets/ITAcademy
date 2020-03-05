using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    interface ISequenceCalculable
    {
        public List<int> CalculateSequence(int startIndex, int endIndex);
    }
}
