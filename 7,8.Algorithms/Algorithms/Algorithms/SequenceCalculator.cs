using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class SequenceCalculator
    {
        private ISequenceCalculable sequenceCalculable;

        public SequenceCalculator(ISequenceCalculable sequence)
        {
            this.sequenceCalculable = sequence;
        }

        public void SetSequence(ISequenceCalculable sequence)
        {
            this.sequenceCalculable = sequence;
        }

        public List<int> Calculate(int startIndex, int endIndex)
        {
            return sequenceCalculable.CalculateSequence(startIndex, endIndex);
        }

        public void GetCalculatedString(int startIndex, int endIndex, char separator)
        {
            var result = Calculate(startIndex, endIndex);
            for (int i = 0; i < result.Count - 1; i++)
            {
                Console.Write("{0},", result[i]);
            }
            Console.Write(result[^1]);
        }
    }
}
