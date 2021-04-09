using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Testing_Assignment_2;
using Xunit;

namespace UnitTestProject
{
    
    public class UnitTest
    {
        string inputString = "";
        string expected = "";
        [Fact]
        public void UpparToLower()
        {
            // Arrange
            inputString = "Unit Test";
            expected = "uNIT tEST";

            // Act
            string output = inputString.InverseCase();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void TitleCase()
        {
            // Arrange
            inputString = "unit test";
            expected = "Unit Test";

            // Act
            string output = inputString.TitleCase();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void Capitalized()
        {
            // Arrange
            inputString = "unit test";
            expected = "Unit Test";

            // Act
            string output = inputString.Capitalized();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckLower()
        {
            // Arrange
            inputString = "unit test";
            expected = "lowerCase";

            // Act
            string output = inputString.CheckLower();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckUppar()
        {
            // Arrange
            inputString = "unit test";
            expected = "null";

            // Act
            string output = inputString.CheckUppar();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckforInt()
        {
            // Arrange
            inputString = "100";
            expected = "Success";

            // Act
            string output = inputString.CheckforInt();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void RemoveLastChar()
        {
            // Arrange
            inputString = "Unit Test";
            expected = "Unit Tes";

            // Act
            string output = inputString.RemoveLastChar();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void WordCount()
        {
            // Arrange
            inputString = "Unit Test";
            expected = "9";

            // Act
            string output = inputString.WordCount();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }

        [Fact]
        public void StringToInt()
        {
            // Arrange
            inputString = "100";
            expected = "100";

            // Act
            string output = inputString.StringToInt();

            // Assert
            Xunit.Assert.Equal(expected, output);
        }
    }
}
