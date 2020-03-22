using System;
using System.Collections.Generic;
using HelpersLibrary;
using Sequences.Interfaces;

namespace Sequences.Implementation
{
    class SquareNaturalNumbers : ISequence
    {
        public IList<long> Generate(IntRange range)
        {
            var resultSequience = new List<long>();
            var sqrt = Math.Sqrt(range.End);

            for (long i = range.Start; i < sqrt; i++)
            {
                resultSequience.Add(i);
            }

            return resultSequience;
        }
    }
}
