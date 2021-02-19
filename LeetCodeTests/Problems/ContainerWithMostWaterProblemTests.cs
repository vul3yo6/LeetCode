using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTests.Problems
{
    public class ContainerWithMostWaterProblemTests
    {
        [Fact]
        public void MaxAreaTest_Case1()
        {
            // Arrange
            ContainerWithMostWaterProblem obj = new ContainerWithMostWaterProblem();
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int expected = 49;

            // Act
            var actual = obj.MaxArea(height);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxAreaTest_Case2()
        {
            // Arrange
            ContainerWithMostWaterProblem obj = new ContainerWithMostWaterProblem();
            int[] height = new int[] { 1, 1 };
            int expected = 1;

            // Act
            var actual = obj.MaxArea(height);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxAreaTest_Case3()
        {
            // Arrange
            ContainerWithMostWaterProblem obj = new ContainerWithMostWaterProblem();
            int[] height = new int[] { 4, 3, 2, 1, 4 };
            int expected = 16;

            // Act
            var actual = obj.MaxArea(height);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxAreaTest_Case4()
        {
            // Arrange
            ContainerWithMostWaterProblem obj = new ContainerWithMostWaterProblem();
            int[] height = new int[] { 1, 2, 1 };
            int expected = 2;

            // Act
            var actual = obj.MaxArea(height);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}