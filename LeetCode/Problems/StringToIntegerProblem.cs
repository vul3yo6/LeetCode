using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode.Problems
{
    // https://leetcode.com/problems/string-to-integer-atoi/
    public class StringToIntegerProblem
    {
        private Regex _regex = new Regex(@"^[(\s)|""]*[+-]?(\d)+", RegexOptions.Compiled | RegexOptions.Singleline);

        public int MyAtoi(string str)
        {
            // 本身就會排除空白, 去掉小數位數
            //if (string.IsNullOrEmpty(str))
            //{
            //    return 0;
            //}

            var match = _regex.Match(str);
            if (match.Success == false)
            {
                return 0;
            }

            double num = 0;
            string numText = match.Value.Trim(' ', '"');
            double.TryParse(numText, out num);

            if (num > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (num < int.MinValue)
            {
                return int.MinValue;
            }
            else
            {
                return (int)num;
            }
        }
    }
}
