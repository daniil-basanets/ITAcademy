using System.Collections.Generic;
using System.Linq;

namespace Sequences
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

        public IList<long> Generate(int startIndex, int endIndex)
        {
            var result = GetEnumerator().Skip(startIndex - 1).Take(endIndex - startIndex + 1).ToList();

            return result;
        }
    }
}
