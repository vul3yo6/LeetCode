using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class LetterCombinationsOfPhoneNumberProblemTests
    {
        [Fact]
        public void LetterCombinations_Case1()
        {
            // Arrange
            var obj = new LetterCombinationsOfPhoneNumberProblem();
            string digits = "23";
            var expected = new List<string>()
            {
                "ad","ae","af","bd","be","bf","cd","ce","cf"
            };

            // Act
            var actual = obj.LetterCombinations(digits);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LetterCombinations_Case2()
        {
            // Arrange
            var obj = new LetterCombinationsOfPhoneNumberProblem();
            string digits = "";
            var expected = new List<string>();

            // Act
            var actual = obj.LetterCombinations(digits);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LetterCombinations_Case3()
        {
            // Arrange
            var obj = new LetterCombinationsOfPhoneNumberProblem();
            string digits = "2";
            var expected = new List<string>()
            {
                "a","b","c"
            };

            // Act
            var actual = obj.LetterCombinations(digits);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}