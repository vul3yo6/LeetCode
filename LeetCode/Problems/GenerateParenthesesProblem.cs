using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
     * 
     * Example 1:
     * Input: n = 3
     * Output: ["((()))","(()())","(())()","()(())","()()()"]
     * 
     * Example 2:
     * Input: n = 1
     * Output: ["()"]
     * 
     * Constraints:
     * 1 <= n <= 8
     */
    public class GenerateParenthesesProblem
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> combinations = new List<string>();
            GenerateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        private void GenerateAll(char[] current, int pos, List<string> result)
        {
            if (pos == current.Length)
            {
                if (Valid(current))
                    result.Add(new string(current));
            }
            else
            {
                current[pos] = '(';
                GenerateAll(current, pos + 1, result);
                current[pos] = ')';
                GenerateAll(current, pos + 1, result);
            }
        }

        private bool Valid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }
    }
}
