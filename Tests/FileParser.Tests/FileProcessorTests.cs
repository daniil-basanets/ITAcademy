using System;
using Xunit;
using System.Text.RegularExpressions;
using FileParser.Logics;

namespace FileParser.Tests
{
    public class FileProcessorTests
    {
        [Fact]
        public void ReplaceStringWithRegex_ReplaceText_Positive()
        {
            //arrange
            string sourceText = "This tutorial shows how to build a solution containing a unit test project and source code project";
            string expectedText = "This tutorial shows how to setup a solution containing a unit test project and source code project";
            string searchString = "build";
            string replaceString = "setup";
            Regex regex = new Regex(searchString);

            //act
            var actual = FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex);

            //assert
            Assert.Equal(expectedText, actual);
        }

        [Fact]
        public void ReplaceStringWithRegex_ReplaceRegex_Positive()
        {
            //arrange
            string sourceText = "This  tutorial shows how to build a solution containing a unit test project and source code project";
            string expectedText = "This__tutorial_shows_how_to_build_a_solution_containing_a_unit_test_project_and_source_code_project";
            string searchString = @"\s";
            string replaceString = "_";
            Regex regex = new Regex(searchString);

            //act
            var actual = FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex);

            //assert
            Assert.Equal(expectedText, actual);
        }

        [Fact]
        public void ReplaceStringWithRegex_NothingReplace_Negative()
        {
            //arrange
            string sourceText = "This tutorial shows how to build a solution containing a unit test project and source code project";
            string expectedText = "This tutorial shows how to build a solution containing a unit test project and source code project";
            string searchString = "int";
            string replaceString = "setup";
            Regex regex = new Regex(searchString);

            //act
            var actual = FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex);

            //assert
            Assert.Equal(expectedText, actual);
        }

        [Fact]
        public void ReplaceStringWithRegex_SourceNull_Negative()
        {
            //arrange
            string sourceText = null;
            string searchString = "int";
            string replaceString = "setup";
            Regex regex = new Regex(searchString);

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex));
        }

        [Fact]
        public void ReplaceStringWithRegex_SearchEmpty_Negative()
        {
            //arrange
            string sourceText = "This tutorial shows how to build a solution containing a unit test project and source code project";
            string expectedText = "This tutorial shows how to build a solution containing a unit test project and source code project";
            string searchString = "";
            string replaceString = "setup";
            Regex regex = new Regex(searchString);

            //act
            var actual = FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex);

            //assert
            Assert.Equal(expectedText, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("build")]
        public void ReplaceStringWithRegex_SourceEmpty_Negative(string searchString)
        {
            //arrange
            string sourceText = "";
            string expectedText = "";
            string replaceString = "setup";
            Regex regex = new Regex(searchString);

            //act
            var actual = FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex);

            //assert
            Assert.Equal(expectedText, actual);
        }

        [Fact]
        public void ReplaceStringWithRegex_NothingReplaceRegex_Negative()
        {
            //arrange
            string sourceText = "This  tutorial shows how to build a solution containing a unit test project and source code project";
            string expectedText = "This  tutorial shows how to build a solution containing a unit test project and source code project";
            string searchString = @"\d";
            string replaceString = "_";
            Regex regex = new Regex(searchString);

            //act
            var actual = FileProcessor.ReplaceStringWithRegex(sourceText, replaceString, regex);

            //assert
            Assert.Equal(expectedText, actual);
        }
    }

}
