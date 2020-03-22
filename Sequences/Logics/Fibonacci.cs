using System.Collections.Generic;
using System.Linq;
using HelpersLibrary;
using Sequences.Interfaces;

namespace Sequences.Logics
{
    class Fibonacci : ISequence
    {
        private IEnumerable<long> GetEnumerator()
        {
            long prevElement = 1;
            long currentElement = 1;

            yield return prevElement;

            while (true)
            {
                yield return currentElement;

                long t = prevElement + currentElement;
                prevElement = currentElement;
                currentElement = t;
            }
        }

        public IList<long> Generate(IntRange range)
        {
            var result = GetEnumerator().Skip(range.Start - 1).Take(range.Count() + 1).ToList();

            return result;
        }
    }
}
