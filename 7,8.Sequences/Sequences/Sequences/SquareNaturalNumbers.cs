using System;
using System.Collections.Generic;
using System.Text;

namespace Sequences
{
    class SquareNaturalNumbers : ISequence
    {
        public IList<long> Generate(int startIndex, int endIndex)
        {
            var resultSequience = new List<long>();
            var sqrt = Math.Sqrt(endIndex);

            for (long i = startIndex; i < sqrt; i++)
            {
                resultSequience.Add(i);
            }

            return resultSequience;
        }
    }
}
