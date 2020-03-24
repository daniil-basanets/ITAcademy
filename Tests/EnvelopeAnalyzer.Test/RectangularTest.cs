using EnvelopeAnalyzer.Models;
using System;
using Xunit;

namespace EnvelopeAnalyzer.Test
{
    public class RectangularTest
    {
        [Theory]
        [InlineData(4f, 3f, 2f, 1f)]
        [InlineData(4f, 3f, 2f, 3f)]
        [InlineData(4f, 3f, 4f, 2f)]
        [InlineData(4f, 3f, 4f, 3f)]
        public void IsEnoughSpaceFor_Positive(float width1, float height1, float width2, float height2)
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width1, height1);
            CommonEnvelope envelope2 = new Implementation.Rectangular(width2, height2);

            var actual_space_check = envelope1.IsEnoughSpaceFor(envelope2);

            //assert
            Assert.True(actual_space_check);
        }

        [Theory]
        [InlineData(4f, 3.3f, 2f, 1.6f)]
        [InlineData(4.5f, 3f, 2f, 3f)]
        [InlineData(4f, 3f, 4f, 2.3f)]
        public void IsEnoughSpaceFor_Negative(float width1, float height1, float width2, float height2)
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width1, height1);
            CommonEnvelope envelope2 = new Implementation.Rectangular(width2, height2);

            var actualSpaceCheck = envelope2.IsEnoughSpaceFor(envelope1);

            //assert
            Assert.False(actualSpaceCheck);
        }

        [Fact]
        public void Square_Positive()
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(2f, 3f);
            var square = envelope1.Square();

            //assert
            Assert.Equal(6f, square);
        }

        [Fact]
        public void Square_Negative()
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(2f, 3f);
            var square = envelope1.Square();

            //assert
            Assert.NotEqual(8f, square);
        }

        [Theory]
        [InlineData(4f, 3f)]
        [InlineData(4f, 4f)]
        public void MaxSide_left_Positive(float width, float height) {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width, height);
            var maxSide = envelope1.MaxSide();

            //assert
            Assert.Equal(width, maxSide);
        }

        [Theory]
        [InlineData(2f, 3f)]
        [InlineData(2f, 2f)]
        public void MaxSide_right_Positive(float width, float height)
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width, height);
            var maxSide = envelope1.MaxSide();

            //assert
            Assert.Equal(height, maxSide);
        }

        [Theory]
        [InlineData(4.5f, 1.5f)]
        [InlineData(1f, 1f)]
        public void MinSide_right_Positive(float width, float height)
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width, height);
            var minSide = envelope1.MinSide();

            //assert
            Assert.Equal(height, minSide);
        }

        [Theory]
        [InlineData(2.5f, 3.5f)]
        [InlineData(3f, 3f)]
        public void MinSide_left_Positive(float width, float height)
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width, height);
            var minSide = envelope1.MinSide();

            //assert
            Assert.Equal(width, minSide);
        }

        [Theory]
        [InlineData(-2.5f, 3.5f)]
        [InlineData(3f, -3.7f)]
        [InlineData(-4.5f, -1.5f)]
        public void Create_envelope_Negative(float width, float height)
        {
            //arrange

            //act
            //CommonEnvelope envelope1 = new Implementation.Rectangular(width, height);
            //var minSide = envelope1.MinSide();
            CommonEnvelope envelope;

            //assert
            Assert.Throws<ArgumentException>(() => envelope = new Implementation.Rectangular(width, height));
        }

    }
}
