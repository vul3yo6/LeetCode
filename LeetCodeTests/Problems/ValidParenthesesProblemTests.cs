using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class ValidParenthesesProblemTests
    {
        [Fact]
        public void ValidParenthesesProblem_Case1()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "()";
            bool expected = true;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case2()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "()[]{}";
            bool expected = true;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case3()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "(]";
            bool expected = false;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case4()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "([)]";
            bool expected = false;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case5()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "{[]}";
            bool expected = true;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case6()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "({[)";
            bool expected = false;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case7()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "(([]){})";
            bool expected = true;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidParenthesesProblem_Case8()
        {
            // Arrange
            var obj = new ValidParenthesesProblem();
            string s = "{}{}()[]";
            bool expected = true;

            // Act
            bool actual = obj.IsValid(s);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}