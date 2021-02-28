using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class ThreeSumProblemTests
    {
        [Fact]
        public void ThreeSum_Case1()
        {
            // Arrange
            var obj = new ThreeSumProblem();
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var expected = new List<IList<int>>()
            {
                new List<int>() { -1, -1, 2 },
                new List<int>() { -1, 0, 1 },
            };

            // Act
            var actual = obj.ThreeSum(nums);

            // Assert
            Assert.Equal(expected, actual);
            //Assert.Equal(expected.ToExpectedObject(), actual.ToExpectedObject());
        }

        [Fact]
        public void ThreeSum_Case2()
        {
            // Arrange
            var obj = new ThreeSumProblem();
            int[] nums = new int[] { };
            var expected = new List<IList<int>>();

            // Act
            var actual = obj.ThreeSum(nums);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeSum_Case3()
        {
            // Arrange
            var obj = new ThreeSumProblem();
            int[] nums = new int[] { 0 };
            var expected = new List<IList<int>>();

            // Act
            var actual = obj.ThreeSum(nums);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeSum_Case4()
        {
            // Arrange
            var obj = new ThreeSumProblem();
            int[] nums = new int[] { 0, 0, 0, 0 };
            var expected = new List<IList<int>>()
            {
                new List<int>() { 0, 0, 0 },
            };

            // Act
            var actual = obj.ThreeSum(nums);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeSum_Case5()
        {
            // Arrange
            var obj = new ThreeSumProblem();
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 };
            var expected = new List<IList<int>>()
            {
                new List<int>() { -4, 0, 4 },
                new List<int>() { -4, 1, 3 },
                new List<int>() { -3, -1, 4 },
                new List<int>() { -3, 0, 3 },
                new List<int>() { -3, 1, 2 },
                new List<int>() { -2, -1, 3 },
                new List<int>() { -2, 0, 2 },
                new List<int>() { -1, -1, 2 },
                new List<int>() { -1, 0, 1 },
            };

            // Act
            var actual = obj.ThreeSum(nums);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeSum_Case6()
        {
            // Arrange
            var obj = new ThreeSumProblem();
            int[] nums = new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 };
            var expected = new List<IList<int>>()
            {
                new List<int>() { -4, -2, 6 },
                new List<int>() { -4, 0, 4 },
                new List<int>() { -4, 1, 3 },
                new List<int>() { -4, 2, 2 },
                new List<int>() { -2, -2, 4 },
                new List<int>() { -2, 0, 2 },
            };

            // Act
            var actual = obj.ThreeSum(nums);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}