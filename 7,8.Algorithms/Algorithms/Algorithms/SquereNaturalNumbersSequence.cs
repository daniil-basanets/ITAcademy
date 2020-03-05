using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class SquereNaturalNumbersSequence : ISequenceCalculable
    {
        public List<int> CalculateSequence(int startIndex, int endIndex)
        {
            var resultSequience = new List<int>();
            for (int i = startIndex; i * i < endIndex; i++)
            {
                resultSequience.Add(i);
            }
            return resultSequience;
        }
    }
}
