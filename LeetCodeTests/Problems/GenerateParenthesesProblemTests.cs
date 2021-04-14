using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;
using LeetCode.Models;

namespace LeetCodeTests.Problems
{
    public class GenerateParenthesesProblemTests
    {
        [Fact]
        public void GenerateParenthesesProblem_Case1()
        {
            // Arrange
            var obj = new GenerateParenthesesProblem();
            int n = 3;
            var expected = new List<string>()
            {
                "((()))",
                "(()())",
                "(())()",
                "()(())",
                "()()()"
            };

            // Act
            IList<string> actual = obj.GenerateParenthesis(n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GenerateParenthesesProblem_Case2()
        {
            // Arrange
            var obj = new GenerateParenthesesProblem();
            int n = 1;
            var expected = new List<string>()
            {
                "()"
            };

            // Act
            IList<string> actual = obj.GenerateParenthesis(n);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}