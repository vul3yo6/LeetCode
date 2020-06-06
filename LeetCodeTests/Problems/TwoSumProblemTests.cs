using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems.Tests
{
    public class TwoSumProblemTests
    {
        [Fact]
        public void TwoSumTest_Case1()
        {
            // Arrange
            TwoSumProblem obj = new TwoSumProblem();
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            var expected = new int[] { 0, 1 };

            // Act
            var actual = obj.TwoSum(nums, target);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoSumTest_Case2()
        {
            // Arrange
            TwoSumProblem obj = new TwoSumProblem();
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;
            int[] expected = new int[] { 1, 2 };

            // Act
            var actual = obj.TwoSum(nums, target);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoSumTest_Case3()
        {
            // Arrange
            TwoSumProblem obj = new TwoSumProblem();
            int[] nums = new int[] { 0, 4, 3, 0 };
            int target = 0;
            int[] expected = new int[] { 0, 3 };

            // Act
            var actual = obj.TwoSum(nums, target);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoSumTest_Case4()
        {
            // Arrange
            TwoSumProblem obj = new TwoSumProblem();
            int[] nums = new int[] { -3, 4, 3, 90 };
            int target = 0;
            int[] expected = new int[] { 0, 2 };

            // Act
            var actual = obj.TwoSum(nums, target);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoSumTest_Case5()
        {
            // Arrange
            TwoSumProblem obj = new TwoSumProblem();
            int[] nums = new int[] { -10, -1, -18, -19 };
            int target = -19;
            int[] expected = new int[] { 1, 2 };

            // Act
            var actual = obj.TwoSum(nums, target);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}