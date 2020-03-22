using System;
using System.Collections.Generic;
using HelpersLibrary;
using Sequences.Interfaces;

namespace Sequences.Logics
{
    public class SequenceCalculator
    {
        #region private members

        private ISequence sequence;

        #endregion 

        public SequenceCalculator(ISequence sequence)
        {
            this.sequence = sequence ?? throw new ArgumentNullException(nameof(sequence));
        }

        public void SetSequence(ISequence sequence)
        {
            this.sequence = sequence ?? throw new ArgumentNullException(nameof(sequence));
        }

        public IList<long> Generate(IntRange range)
        {
            return sequence.Generate(range);
        }

        public void PrintGeneratedString(IntRange range, char separator)
        {
            var result = Generate(range);
            if (result.Count == 0)
            {
                Console.WriteLine("No elements in the sequence");

                return;
            }
            for (int i = 0; i < result.Count - 1; i++)
            {
                Console.Write("{0},", result[i]);
            }
            Console.Write(result[^1]);
        }
    }
}
