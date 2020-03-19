using System;
using System.Collections.Generic;

namespace Sequences
{
    class SequenceCalculator
    {
        #region private members

        private ISequence sequence;

        #endregion 

        public SequenceCalculator(ISequence sequence)
        {
            this.sequence = sequence;
        }

        public void SetSequence(ISequence sequence)
        {
            this.sequence = sequence;
        }

        public IList<long> Generate(int startIndex, int endIndex)
        {
            return sequence.Generate(startIndex, endIndex);
        }

        public void PrintGeneratedString(int startIndex, int endIndex, char separator)
        {
            var result = Generate(startIndex, endIndex);
            for (int i = 0; i < result.Count - 1; i++)
            {
                Console.Write("{0},", result[i]);
            }
            Console.Write(result[^1]);
        }
    }
}
