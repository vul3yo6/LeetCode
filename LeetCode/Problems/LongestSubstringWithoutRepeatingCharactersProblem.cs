using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given a string s, find the length of the longest substring without repeating characters.
     * 
     * Example 1:
     * Input: s = "abcabcbb"
     * Output: 3
     * Explanation: The answer is "abc", with the length of 3.
     * 
     * Example 2:
     * Input: s = "bbbbb"
     * Output: 1
     * Explanation: The answer is "b", with the length of 1.
     * 
     * Example 3:
     * Input: s = "pwwkew"
     * Output: 3
     * Explanation: The answer is "wke", with the length of 3.
     * Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
     * 
     * Example 4:
     * Input: s = ""
     * Output: 0
     */
    public class LongestSubstringWithoutRepeatingCharactersProblem
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int n = s.Length;
            int ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
                                                           
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                char c = s[j];
                if (map.ContainsKey(c)) // 若有重複字元, 更新字串的起始索引
                {
                    i = Math.Max(map.GetValueOrDefault(c), i);
                }

                // 比較紀錄長度, 與目前長度
                ans = Math.Max(ans, j - i + 1);
                map[c] = j + 1;
            }
            return ans;
        }
    }
}
