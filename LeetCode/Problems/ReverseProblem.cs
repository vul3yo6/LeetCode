using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given a 32-bit signed integer, reverse digits of an integer.
     * 
     * Example 1:
     * Input: 123
     * Output: 321
     * 
     * Example 2:
     * Input: -123
     * Output: -321
     * 
     * Example 3:
     * Input: 120
     * Output: 21
     * 
     * Note: Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
     */
    public class ReverseProblem
    {
        public int Reverse(int x)
        {
            long num = x;

            bool isLessThanZero = num < 0;

            long result = 0;
            string numText = string.Empty;
            if (isLessThanZero)
            {
                numText = new string(Math.Abs(num).ToString().Reverse().ToArray());
                long.TryParse(numText, out result);
                return -result < int.MinValue ? 0 : (int)-result;
            }
            else
            {
                numText = new string(num.ToString().Reverse().ToArray());
                long.TryParse(numText, out result);
                return result > int.MaxValue ? 0 : (int)result;
            }
        }
    }
}
