using log4net;
using Sequences.Interfaces;
using Sequences.Implementation;
using System;
using System.Text;

namespace Sequences.Logics
{
    public enum SequenceType
    {
        SquareNaturalNumbers = 1,
        Fibonacci = 2
    }

    public static class SequenceFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        public static ISequence Build(SequenceType sequenceType)
        {
            log.Info("Build ISequence: " + sequenceType);
            switch (sequenceType)
            {
                case SequenceType.SquareNaturalNumbers:
                    return new SquareNaturalNumbers();
                case SequenceType.Fibonacci:
                    return new Fibonacci();
                default:
                    StringBuilder stringBuilder = new StringBuilder(nameof(sequenceType));
                    stringBuilder.Append(" ");
                    stringBuilder.Append(sequenceType);
                    var e = new ArgumentException(stringBuilder.ToString());
                    log.Error(e);
                    throw e;
            }
        }
    }
}
