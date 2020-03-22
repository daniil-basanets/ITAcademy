using Sequences.Interfaces;
using Sequences.Logics;
using System;
using Xunit;

namespace Sequence.Test
{
    public class SequenceFactoryTest
    {
        [Fact]
        public void Build_UndefinedType_Negative()
        {
            //arrange

            //act
            ISequence sequence = null;

            //assert
            Assert.Throws<ArgumentException>(() => sequence = SequenceFactory.Build(0));
        }

        [Theory]
        [InlineData(SequenceType.Fibonacci)]
        [InlineData(SequenceType.SquareNaturalNumbers)]
        public void Build_Fibonnaci_Positive(SequenceType sequenceType)
        {
            //arrange

            //act
            ISequence sequence = SequenceFactory.Build(sequenceType);

            //assert
            Assert.NotNull(sequence);
        }
    }
}
