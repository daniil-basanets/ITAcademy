using Sequences.Interfaces;
using Sequences.Logics;
using Sequences.Implementation;
using HelpersLibrary;
using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sequence.Test
{
    public class SequenceCalculatorTest
    {
        [Fact]
        public void SequenceCalculator_Negative()
        {
            //arrange

            //act
            ISequence sequence = null;
            SequenceCalculator sequenceCalculator;

            //assert
            Assert.Throws<ArgumentNullException>(() => sequenceCalculator = new SequenceCalculator(sequence));
        }

        [Fact]
        public void SetSequence_Negative()
        {
            //arrange

            //act
            ISequence sequence = null;
            SequenceCalculator sequenceCalculator;

            //assert
            Assert.Throws<ArgumentNullException>(() => sequenceCalculator = new SequenceCalculator(sequence));
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_Empty_Positive()
        {
            //arrange
            IList expected = new List<long>(0);

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(0, 0));

            //assert
            Assert.Equal(expected, actual.ToList());
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_FromZeroToFive_Positive()
        {
            //arrange
            IList expected = new List<long>() { 0, 1, 2 };

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(0, 5));

            //assert
            Assert.Equal(expected, actual.ToList());
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_FromTwoToNine_Positive()
        {
            //arrange
            IList expected = new List<long>() { 2 };

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(2, 9));

            //assert
            Assert.Equal(expected, actual.ToList());
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_FromTwoToTwenty_Positive()
        {
            //arrange
            IList expected = new List<long>() { 2, 3, 4 };

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(2, 20));

            //assert
            Assert.Equal(expected, actual.ToList());
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_Negative()
        {
            //arrange
            IList expected = new List<long>(0);

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(2, 1));

            //assert
            Assert.Equal(expected, actual.ToList());
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_FromThreeToFive_Negative()
        {
            //arrange
            IList expected = new List<long>(0);

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(3, 5));

            //assert
            Assert.Equal(expected, actual.ToList());
        }

        [Fact]
        public void Generate_SquareNaturalNumbers_FromMinusOneToFive_Negative()
        {
            //arrange
            IList expected = new List<long>() { -1, 0, 1, 2 };

            //act
            ISequence sequence = new SquareNaturalNumbers();
            SequenceCalculator sequenceCalculator = new SequenceCalculator(sequence);
            var actual = sequenceCalculator.Generate(new IntRange(-1, 5));

            //assert
            Assert.Equal(expected, actual.ToList());
        }
    }
}
