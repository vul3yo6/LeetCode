using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeTests.Problems
{
    public class ReverseProblemTests
    {
        [Fact]
        public void ReverseTest_Case1()
        {
            // Arrange
            ReverseProblem obj = new ReverseProblem();
            int num = 123;
            int expected = 321;

            // Act
            int actual = obj.Reverse(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseTest_Case2()
        {
            // Arrange
            ReverseProblem obj = new ReverseProblem();
            int num = -123;
            int expected = -321;

            // Act
            int actual = obj.Reverse(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseTest_Case3()
        {
            // Arrange
            ReverseProblem obj = new ReverseProblem();
            int num = 120;
            int expected = 21;

            // Act
            int actual = obj.Reverse(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseTest_Case4()
        {
            // Arrange
            ReverseProblem obj = new ReverseProblem();
            int num = 1534236469;
            int expected = 0;

            // Act
            int actual = obj.Reverse(num);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
