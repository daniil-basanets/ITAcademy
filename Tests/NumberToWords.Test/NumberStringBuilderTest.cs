using NumberToWords.Implementation;
using System;
using Xunit;

namespace NumberToWords.Test
{
    public class NumberStringBuilderTest
    {
        [Fact]
        public void GetString_without_argument_Positive()
        {
            //arrange
            String expectedText = "one thousand two hundred thirty four";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1234);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_with_argument_Positive()
        {
            //arrange
            String expectedText = "thirty one million one hundred eighty three thousand three hundred forty four";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1);
            String actualText = numberStringBuilder.GetString(31_183_344);

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_minus_number_Positive()
        {
            //arrange
            String expectedText = "minus two billion one hundred two million one hundred thousand four hundred seventy two";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1);
            String actualText = numberStringBuilder.GetString(-2_102_100_472);

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_max_int_Positive()
        {
            //arrange
            String expectedText = "two billion one hundred forty seven million four hundred eighty three thousand six hundred forty seven";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(2_147_483_647);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_zero_Positive()
        {
            //arrange
            String expectedText = "zero";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(0);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_one_Positive()
        {
            //arrange
            String expectedText = "one";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_ten_Positive()
        {
            //arrange
            String expectedText = "ten";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(10);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_one_hundred_Positive()
        {
            //arrange
            String expectedText = "one hundred";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(100);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_one_thousand_Positive()
        {
            //arrange
            String expectedText = "one thousand";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1000);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_one_million_Positive()
        {
            //arrange
            String expectedText = "one million";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1_000_000);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void GetString_one_billion_Positive()
        {
            //arrange
            String expectedText = "one billion";

            //act
            NumberStringBuilder numberStringBuilder = new NumberStringBuilder(1_000_000_000);
            String actualText = numberStringBuilder.GetString();

            //assert
            Assert.Equal(expectedText, actualText);
        }
    }
}
