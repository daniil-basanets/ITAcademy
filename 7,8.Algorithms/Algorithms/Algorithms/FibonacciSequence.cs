using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class FibonacciSequence : ISequenceCalculable
    {
        private int CalculateRecursively(int currentNumber, ref List<int> result)
        {          
            if (currentNumber < result.Count)
            {
                return result[currentNumber];
            }
            if (currentNumber == 0 || currentNumber == 1)
            {
                result.Add(1);
            }
            else
                result.Add(checked(CalculateRecursively(currentNumber - 2, ref result) + CalculateRecursively(currentNumber - 1, ref result)));
            return result[currentNumber];
        }

        public List<int> CalculateSequence(int startIndex, int endIndex)
        {
            var result = new List<int>(0);
            CalculateRecursively(endIndex, ref result);
        
            return result;
        }
    }
}
