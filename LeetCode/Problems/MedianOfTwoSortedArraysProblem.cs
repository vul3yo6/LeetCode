using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
     * 
     * Example 1:
     * Input: nums1 = [1,3], nums2 = [2]
     * Output: 2.00000
     * Explanation: merged array = [1,2,3] and median is 2.
     * 
     * Example 2:
     * Input: nums1 = [1,2], nums2 = [3,4]
     * Output: 2.50000
     * Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
     * 
     * Example 3:
     * Input: nums1 = [0,0], nums2 = [0,0]
     * Output: 0.00000
     * 
     * Example 4:
     * Input: nums1 = [], nums2 = [1]
     * Output: 1.00000
     * 
     * Example 5:
     * Input: nums1 = [2], nums2 = []
     * Output: 2.00000
     */
    public class MedianOfTwoSortedArraysProblem
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] mergedArray = nums1.Concat(nums2).ToArray();

            if (mergedArray.Length == 0)
            {
                return 0;
            }
            else if (mergedArray.Length == 1)
            {
                return mergedArray[0];
            }

            Array.Sort(mergedArray);

            bool needCalculate = mergedArray.Length % 2 == 0;
            int indexOfMiddle = mergedArray.Length / 2;
            if (needCalculate)
            {
                return (mergedArray[indexOfMiddle - 1] + mergedArray[indexOfMiddle]) / 2d;
            }

            return mergedArray[indexOfMiddle];
        }
    }
}
