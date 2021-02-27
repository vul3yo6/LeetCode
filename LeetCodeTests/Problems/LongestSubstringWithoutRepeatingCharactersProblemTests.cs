using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class LongestSubstringWithoutRepeatingCharactersProblemTests
    {
        [Fact]
        public void LengthOfLongestSubstring_Case1()
        {
            // Arrange
            var obj = new LongestSubstringWithoutRepeatingCharactersProblem();
            string s = "abcabcbb";
            int expected = 3;   // "abc"

            // Act
            int actual = obj.LengthOfLongestSubstring(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LengthOfLongestSubstring_Case2()
        {
            // Arrange
            var obj = new LongestSubstringWithoutRepeatingCharactersProblem();
            string s = "bbbbb";
            int expected = 1;   // "b"

            // Act
            int actual = obj.LengthOfLongestSubstring(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LengthOfLongestSubstring_Case3()
        {
            // Arrange
            var obj = new LongestSubstringWithoutRepeatingCharactersProblem();
            string s = "pwwkew";
            int expected = 3;   // "wke"

            // Act
            int actual = obj.LengthOfLongestSubstring(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LengthOfLongestSubstring_Case4()
        {
            // Arrange
            var obj = new LongestSubstringWithoutRepeatingCharactersProblem();
            string s = "";
            int expected = 0;

            // Act
            int actual = obj.LengthOfLongestSubstring(s);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LengthOfLongestSubstring_Case5()
        {
            // Arrange
            var obj = new LongestSubstringWithoutRepeatingCharactersProblem();
            string s = "abcdeafbdgcbb";
            int expected = 7;   // "eafbdgc"

            // Act
            int actual = obj.LengthOfLongestSubstring(s);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}