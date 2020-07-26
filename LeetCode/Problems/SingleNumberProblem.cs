using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * https://leetcode.com/problems/single-number/
     * Given a non-empty array of integers, every element appears twice except for one. Find that single one.
     * 
     * Note:
     * Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
     * 
     * Example 1:
     * Input: [2,2,1]
     * Output: 1
     * 
     * Example 2:
     * Input: [4,1,2,1,2]
     * Output: 4
     */
    public class SingleNumberProblem
    {
        private TrimDuplicate _duplicate = new TrimDuplicate();

        public int SingleNumber(int[] nums)
        {
            foreach (int num in nums)
            {
                _duplicate.Add(num);
            }

            return _duplicate.GetSingleNumber();
        }

        internal class TrimDuplicate
        {
            private HashSet<int> _set = new HashSet<int>();

            public void Add(int num)
            {
                if (_set.Contains(num))
                {
                    _set.Remove(num);
                }
                else
                {
                    _set.Add(num);
                }
            }

            public int GetSingleNumber()
            {
                return _set.First();
            }
        }
    }
}
