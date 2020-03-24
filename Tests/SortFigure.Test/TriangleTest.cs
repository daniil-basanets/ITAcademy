using SortFigure.Implementation;
using SortFigure.Interfaces;
using System;
using Xunit;

namespace SortFigure.Test
{
    public class TriangleTest
    {
        [Theory]
        [InlineData(2f, 3f, 5f)]
        [InlineData(0f, 3f, 5f)]
        [InlineData(4f, 0f, 4f)]
        [InlineData(4f, 3f, 0f)]
        public void Create_triangle_Negative(float sideA, float sideB, float sideC)
        {
            //arrange

            //act
            Triangle triangle;

            //assert
            Assert.Throws<ArgumentException>(() => triangle = new Implementation.Triangle(sideA, sideB, sideC, "testTriangle"));
        }

        [Fact]
        public void Perimeter_Positive()
        {
            //arrange

            //act
            Figure triangle = new Implementation.Triangle(2f, 3f, 4f, "testTriangle");
            float perimeter = triangle.Perimeter;

            //assert
            Assert.Equal(9f, perimeter);
        }

        [Fact]
        public void Square_Positive()
        {
            //arrange

            //act
            Figure triangle = new Implementation.Triangle(2f, 3f, 4f, "testTriangle");
            float square = triangle.Square;

            //assert
            Assert.Equal(2.9047374725341797, square);
        }
    }
}
