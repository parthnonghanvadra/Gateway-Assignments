﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        string inputString = "";
        string expected = "";
        [TestMethod]
        public void UpparToLower()
        {
            //Arrange
            inputString = "Unit Test";
            expected = "uNIt tEST";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "UppartoLower");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TitleCase()
        {
            //Arrange
            inputString = "unit test";
            expected = "Unit Test";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "TitleCase");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void Capitalized()
        {
            //Arrange
            inputString = "unit test";
            expected = "Unit Test";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "Capitalized");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void CheckLower()
        {
            //Arrange
            inputString = "unit test";
            expected = "Success";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "CheckLower");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void CheckUppar()
        {
            //Arrange
            inputString = "unit test";
            expected = "null";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "CheckUppar");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void CheckforInt()
        {
            //Arrange
            inputString = "100";
            expected = "Success";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "CheckforInt");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void RemoveLastChar()
        {
            //Arrange
            inputString = "Unit Test";
            expected = "Unit Tes";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "RemoveLastChar");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void WordCount()
        {
            //Arrange
            inputString = "Unit Test";
            expected = "10";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "WordCount");

            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void StringToInt()
        {
            //Arrange
            inputString = "100";
            expected = "100";

            //Act
            string output = Testing_Assignment_2.ExtensionMethods.StringConvert(inputString, "StringToInt");

            //Assert
            Assert.AreEqual(expected, output);
        }
    }
}
