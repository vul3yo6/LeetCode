using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeTests.Problems
{
    public class SingleNumberProblemTests
    {
        [Fact]
        public void Case1()
        {
            // Arrange
            SingleNumberProblem obj = new SingleNumberProblem();
            int[] num = new int[] { 2, 2, 1 };
            int expected = 1;

            // Act
            int actual = obj.SingleNumber(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Case2()
        {
            // Arrange
            SingleNumberProblem obj = new SingleNumberProblem();
            int[] num = new int[] { 4, 1, 2, 1, 2 };
            int expected = 4;

            // Act
            int actual = obj.SingleNumber(num);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
