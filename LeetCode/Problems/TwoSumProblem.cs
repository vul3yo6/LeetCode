using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    public class TwoSumProblem
    {
        /*
         * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
         * 
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         * Example:
         * 
         * Given nums = [2, 7, 11, 15], target = 9,
         * Because nums[0] + nums[1] = 2 + 7 = 9,
         * return [0, 1].
         */

        public int[] TwoSum(int[] nums, int target)
        {
            // convert to dict, keep the index and value
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }

            // start process
            int firstIndex = -1;
            int secondIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                if (dict.ContainsKey(target - num))
                {
                    var index = dict[target - num];
                    if (i == index)
                    {
                        continue;
                    }

                    firstIndex = i;
                    secondIndex = index;
                    break;
                }
            }

            if (firstIndex > secondIndex)
            {
                return new int[] { secondIndex, firstIndex };
            }

            return new int[] { firstIndex, secondIndex };
        }
    }
}
