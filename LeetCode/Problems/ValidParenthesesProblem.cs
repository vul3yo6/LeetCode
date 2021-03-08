using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
     * 
     * An input string is valid if:
     * Open brackets must be closed by the same type of brackets.
     * Open brackets must be closed in the correct order.
     * 
     * Example 1:
     * Input: s = "()"
     * Output: true
     * 
     * Example 2:
     * Input: s = "()[]{}"
     * Output: true
     * 
     * Example 3:
     * Input: s = "(]"
     * Output: false
     * 
     * Example 4:
     * Input: s = "([)]"
     * Output: false
     * 
     * Example 5:
     * Input: s = "{[]}"
     * Output: true
     */
    public class ValidParenthesesProblem
    {
        public bool IsValid(string s)
        {
            // 空字串
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            return CheckSentence(s);
        }

        private bool CheckSentence(string s)
        {
            // 空字串
            if (s.Length == 0)
            {
                return true;
            }

            // 不成對
            if (s.Length % 2 == 1)
            {
                return false;
            }

            // 長度為二就結束, 否則切字串比較
            char source = s[0];
            char target = GetTargetChar(source);
            if (s.Length == 2)
            {
                return target == s[1];
            }
            else
            {
                int index = FindTheCharIndex(s, source, target);
                if (index == -1)
                {
                    return false;
                }

                string subText1 = s.Substring(1, index - 1);
                string subText2 = s.Substring(index + 1, s.Length - (index + 1));
                return CheckSentence(subText1) && CheckSentence(subText2);
            }
        }

        private static char GetTargetChar(char source)
        {
            switch (source)
            {
                case '(':
                    return ')';
                case '[':
                    return ']';
                case '{':
                    return '}';
                default:
                    return char.MinValue;
            }
        }

        private int FindTheCharIndex(string s, char source, char target)
        {
            int duplicate = 0;
            for (int i = 1; i < s.Length; i++)
            {
                // 如果有重複的來源, 那麼目標要往下找一個
                if (s[i] == source)
                {
                    duplicate++;
                }

                if (s[i] == target)
                {
                    if (duplicate == 0)
                    {
                        return i;
                    }
                    else
                    {
                        duplicate--;
                    }
                }
            }

            return -1;
        }
    }
}
