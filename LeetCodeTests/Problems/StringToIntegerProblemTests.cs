using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeTests.Problems
{
    public class StringToIntegerProblemTests
    {
        [Fact]
        public void StringToIntegerTest_Case1()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "42";
            int expected = 42;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case2()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "   -42";
            int expected = -42;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case3()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "4193 with words";
            int expected = 4193;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case4()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "words and 987";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case5()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "-91283472332";
            int expected = -2147483648;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case6()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "+1";
            int expected = 1;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case7()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = ".1";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case8()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "3.14159";
            int expected = 3;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case9()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case10()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "+";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case11()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "+-2";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case12()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "-+1";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case13()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "   +0 123";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case14()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "  0000000000012345678";
            int expected = 12345678;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case15()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "  -0012a42";
            int expected = -12;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case16()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num = "-   234";
            int expected = 0;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StringToIntegerTest_Case17()
        {
            // Arrange
            StringToIntegerProblem obj = new StringToIntegerProblem();
            string num ="\"3.14159\"";
            int expected = 3;

            // Act
            int actual = obj.MyAtoi(num);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
