using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class MedianOfTwoSortedArraysProblemTests
    {
        [Fact]
        public void FindMedianSortedArrays_Case1()
        {
            // Arrange
            var obj = new MedianOfTwoSortedArraysProblem();
            int[] nums1 = new int[] { 1, 3 };
            int[] nums2 = new int[] { 2 };
            double expected = 2;   // merged array = [1,2,3] and median is 2.

            // Act
            double actual = obj.FindMedianSortedArrays(nums1, nums2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindMedianSortedArrays_Case2()
        {
            // Arrange
            var obj = new MedianOfTwoSortedArraysProblem();
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { 3, 4 };
            double expected = 2.5;   // merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

            // Act
            double actual = obj.FindMedianSortedArrays(nums1, nums2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindMedianSortedArrays_Case3()
        {
            // Arrange
            var obj = new MedianOfTwoSortedArraysProblem();
            int[] nums1 = new int[] { 0, 0 };
            int[] nums2 = new int[] { 0, 0 };
            double expected = 0;

            // Act
            double actual = obj.FindMedianSortedArrays(nums1, nums2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindMedianSortedArrays_Case4()
        {
            // Arrange
            var obj = new MedianOfTwoSortedArraysProblem();
            int[] nums1 = new int[] { };
            int[] nums2 = new int[] { 1 };
            double expected = 1;

            // Act
            double actual = obj.FindMedianSortedArrays(nums1, nums2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindMedianSortedArrays_Case5()
        {
            // Arrange
            var obj = new MedianOfTwoSortedArraysProblem();
            int[] nums1 = new int[] { 2 };
            int[] nums2 = new int[] { };
            double expected = 2;

            // Act
            double actual = obj.FindMedianSortedArrays(nums1, nums2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}