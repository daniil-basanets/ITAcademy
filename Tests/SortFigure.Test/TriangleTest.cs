using System;
using Xunit;

namespace SortFigure.Test
{
    public class TriangleTest
    {
        [Fact]
        public void Create_triangle_Negative(float width, float height)
        {
            //arrange

            //act
            //CommonEnvelope envelope1 = new Implementation.Rectangular(width, height);
            //var minSide = envelope1.MinSide();
            CommonEnvelope envelope;

            //assert
            Assert.Throws<ArgumentException>(() => envelope = new Implementation.Rectangular(width, height));
        }

        [Fact]
        public void Test1()
        {
            //arrange

            //act
            CommonEnvelope envelope1 = new Implementation.Rectangular(width1, height1);
            CommonEnvelope envelope2 = new Implementation.Rectangular(width2, height2);

            var actual_space_check = envelope1.IsEnoughSpaceFor(envelope2);

            //assert
            Assert.True(actual_space_check);
        }
    }
}
