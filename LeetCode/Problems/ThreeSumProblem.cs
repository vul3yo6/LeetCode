using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
     * 
     * Notice that the solution set must not contain duplicate triplets.
     * 
     * Example 1:
     * Input: nums = [-1,0,1,2,-1,-4]
     * Output: [[-1,-1,2],[-1,0,1]]
     * 
     * Example 2:
     * Input: nums = []
     * Output: []
     * 
     * Example 3:
     * Input: nums = [0]
     * Output: []
     */
    public class ThreeSumProblem
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            // 先排序, 讓數值排列 -2, -1, 0, 1, 2,...
            Array.Sort(nums);

            // 找出最大的面積
            // 從兩頭開始找, 讓寬度最大; 再比較數值大小, 讓高度最大
            int startIndex = 0;
            int endIndex = nums.Length - 1;

            var result = new HashSet<IList<int>>(new ThreeSumComparer());
            while (startIndex < endIndex - 1)
            {
                int startNum = Math.Abs(nums[startIndex]);
                int endNum = Math.Abs(nums[endIndex]);

                bool isASC = startNum < endNum;
                int middleIndex = isASC ? startIndex + 1 : endIndex - 1;
                var temp = new List<int>();
                while (middleIndex > startIndex && middleIndex < endIndex)
                {
                    // 起始數值大於 0, 或結尾數值小於 0, 就不可能相加等於 0
                    if (nums[startIndex] > 0 || nums[endIndex] < 0)
                    {
                        break;
                    }

                    if (IsVaildNums(nums[startIndex], nums[middleIndex], nums[endIndex]))
                    {
                        temp.Add(nums[startIndex]);
                        temp.Add(nums[middleIndex]);
                        temp.Add(nums[endIndex]);
                        break;
                    }

                    //int middleNum = Math.Abs(nums[middleIndex]);
                    if (isASC)
                    {
                        middleIndex++;
                    }
                    else
                    {
                        middleIndex--;
                    }
                }

                if (temp.Count > 0)
                {
                    result.Add(temp);
                }

                if (startNum <= endNum)
                {
                    endIndex--;
                }
                else
                {
                    startIndex++;
                }
            }

            return result.ToList();
        }

        private bool IsVaildNums(int num1, int num2, int num3)
        {
            return num1 + num2 + num3 == 0;
        }

        public class ThreeSumComparer : IEqualityComparer<IList<int>>
        {
            //public bool Equals([AllowNull] IList<int> x, [AllowNull] IList<int> y)
            public bool Equals(IList<int> x, IList<int> y)
            {
                if (x == null || y == null)
                {
                    return false;
                }

                if (x.Count != y.Count)
                {
                    return false;
                }

                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] != y[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            //public int GetHashCode([DisallowNull] IList<int> obj)
            public int GetHashCode(IList<int> obj)
            {
                return string.Join(",", obj).GetHashCode();
            }
        }
    }
}
