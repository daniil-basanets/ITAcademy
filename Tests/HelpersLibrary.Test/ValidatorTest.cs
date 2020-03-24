using System;
using Xunit;

namespace HelpersLibrary.Test
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(Int32.MaxValue)]
        public void IsNaturalNumber_Positive(int number)
        {
            //arrange

            //act
            var numberIsNatural = Validator.IsNaturalNumber(number);

            //assert
            Assert.True(numberIsNatural);
        }

        [Fact]
        public void IsNaturalNumber_Negative()
        {
            //arrange

            //act
            var numberIsNatural = Validator.IsNaturalNumber(-1);

            //assert
            Assert.False(numberIsNatural);
        }

        [Fact]
        public void IsNaturalNumber_with_max_check_Positive()
        {
            //arrange

            //act
            var numberIsNatural = Validator.IsNaturalNumber(9, 10);

            //assert
            Assert.True(numberIsNatural);
        }

        [Fact]
        public void IsNaturalNumber_with_max_Negative()
        {
            //arrange

            //act
            var numberIsNatural = Validator.IsNaturalNumber(10, 5);

            //assert
            Assert.False(numberIsNatural);
        }

        [Theory]
        [InlineData(4, 1, 10)]
        [InlineData(2, 2, 5)]
        [InlineData(5, 2, 5)]
        [InlineData(3, 3, 3)]
        public void IsNumberInRange_Positive(int number, int start, int max)
        {
            //arrange

            //act
            var numberInRange = Validator.IsNumberInRange(number, start, max);

            //assert
            Assert.True(numberInRange);
        }

        [Fact]
        public void IsNumberInRange_Negative()
        {
            //arrange

            //act
            var numberInRange = Validator.IsNumberInRange(1, 4, 10);

            //assert
            Assert.False(numberInRange);
        }

        [Theory]
        [InlineData(4.7f, 1.1f, 10.5f)]
        [InlineData(2.2f, 2.2f, 5.6f)]
        [InlineData(6.6f, 3f, 6.6f)]
        [InlineData(7.7f, 7.7f, 7.7f)]
        public void IsNumberInRange_float_Positive(int number, int start, int max)
        {
            //arrange

            //act
            var numberInRange = Validator.IsNumberInRange(number, start, max);

            //assert
            Assert.True(numberInRange);
        }

        [Fact]
        public void IsNumberInRange_float_Negative()
        {
            //arrange

            //act
            var numberInRange = Validator.IsNumberInRange(1.2f, 2.0f, 10.4f);

            //assert
            Assert.False(numberInRange);
        }

        [Fact]
        public void IsPositiveNumber_Positive()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsPositiveNumber(2);

            //assert
            Assert.True(numberIsPositive);
        }

        [Fact]
        public void IsPositiveNumber_Negative()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsPositiveNumber(-2);

            //assert
            Assert.False(numberIsPositive);
        }

        [Fact]
        public void IsPositiveNumber_zero_check_Negative()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsPositiveNumber(0);

            //assert
            Assert.True(numberIsPositive);
        }

        [Fact]
        public void IsPositiveNumber_float_Positive()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsPositiveNumber(3.2f);

            //assert
            Assert.True(numberIsPositive);
        }

        [Fact]
        public void IsPositiveNumber_float_Negative()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsPositiveNumber(-3.2f);

            //assert
            Assert.False(numberIsPositive);
        }

        [Fact]
        public void IsPositiveNumber_float_zero_check_Negative()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsPositiveNumber(0f);

            //assert
            Assert.True(numberIsPositive);
        }

        [Fact]
        public void IsValidTriangle_Positive()
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsValidTriangle(2f, 3f, 4f);

            //assert
            Assert.True(numberIsPositive);
        }

        [Theory]
        [InlineData(2f, 3f, 5f)]
        [InlineData(0f, 3f, 5f)]
        [InlineData(4f, 0f, 4f)]
        [InlineData(4f, 3f, 0f)]
        public void IsValidTriangle_Negative(float sideA, float sideB, float sideC)
        {
            //arrange

            //act
            var numberIsPositive = Validator.IsValidTriangle(sideA, sideB, sideC);

            //assert
            Assert.False(numberIsPositive);
        }
    }
}
