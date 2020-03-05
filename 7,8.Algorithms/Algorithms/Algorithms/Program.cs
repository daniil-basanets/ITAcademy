using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceCalculator = new SequenceCalculator(new FibonacciSequence());
            var result = sequenceCalculator.Calculate(0, 5);

            sequenceCalculator.GetCalculatedString(0, 12, ',');
        }
    }
}
