using Xunit;

namespace HelpersLibrary.Test
{
    public class ParserTest
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        public void TryGetRange_Positive(int start, int end)
        {
            //arrange
            string[] args = { start.ToString(), end.ToString() };
            ErrorCode errorCode;
            IntRange intRange = new IntRange(start, end);

            //act
            var expectedIntRange = Parser.TryGetRange(args, out errorCode);

            //assert
            Assert.Equal(intRange, expectedIntRange);
        }

        [Theory]
        [InlineData("ds", "3")]
        [InlineData("1", "3")]
        [InlineData("32.5", "3")]
        public void TryGetString_Positive(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetString(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.Void, errorCode);
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("332321", "")]
        [InlineData("-332321", "")]
        public void TryGetInt_Positive(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetInt(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.Void, errorCode);
        }

        [Theory]
        [InlineData("1", "3")]
        [InlineData("2,0", "2.5")]
        [InlineData("-0,434343", "-0.0000005")]
        public void TryGetFloat_Positive(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetFloat(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.Void, errorCode);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("333321312312321432242342432432", "")]
        [InlineData("23", "2.5")]
        [InlineData(null, null)]
        public void TryGetRange_Negative(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetRange(args, out errorCode);

            //assert
            Assert.Equal(ErrorCode.CannotConvertParameter, errorCode);
        }

        [Fact]
        public void TryGetRange_Empty_Negative()
        {
            //arrange
            string[] args = { "" };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetRange(args, out errorCode);

            //assert
            Assert.Equal(ErrorCode.InvalidParametersCount, errorCode);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("2.3", "2.5")]
        [InlineData(null, null)]
        public void TryGetInt_Negative(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetInt(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.CannotConvertParameter, errorCode);
        }

        [Fact]
        public void TryGetInt_Empty_Negative()
        {
            //arrange
            string[] args = { "" };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetInt(args, 2, out errorCode);

            //assert
            Assert.Equal(ErrorCode.InvalidParametersCount, errorCode);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("2.3", "2.5")]
        [InlineData(null, null)]
        public void TryGetLong_Negative(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetLong(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.CannotConvertParameter, errorCode);
        }

        [Fact]
        public void TryGetLong_Empty_Negative()
        {
            //arrange
            string[] args = { "" };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetLong(args, 2, out errorCode);

            //assert
            Assert.Equal(ErrorCode.InvalidParametersCount, errorCode);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("2,o", "2.5")]
        [InlineData(null, null)]
        public void TryGetFloat_Negative(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetFloat(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.CannotConvertParameter, errorCode);
        }

        [Fact]
        public void TryGetFloat_Empty_Negative()
        {
            //arrange
            string[] args = { "" };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetFloat(args, 2, out errorCode);

            //assert
            Assert.Equal(ErrorCode.InvalidParametersCount, errorCode);
        }

        [Theory]
        [InlineData(null, null)]
        public void TryGetString_Negative(string start, string end)
        {
            //arrange
            string[] args = { start, end };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetString(args, 0, out errorCode);

            //assert
            Assert.Equal(ErrorCode.StringIsEmpty, errorCode);
        }

        [Fact]
        public void TryGetString_2Parameter_Negative()
        {
            //arrange
            string[] args = { "" };
            ErrorCode errorCode;

            //act
            var expectedIntRange = Parser.TryGetString(args, 2, out errorCode);

            //assert
            Assert.Equal(ErrorCode.InvalidParametersCount, errorCode);
        }
    }
}
