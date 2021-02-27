using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
     * A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
     * 
     * Example 1:
     * Input: digits = "23"
     * ["ad","ae","af","bd","be","bf","cd","ce","cf"]
     * 
     * Example 2:
     * Input: digits = ""
     * Output: []
     * 
     * Example 3:
     * Input: digits = "2"
     * Output: ["a","b","c"]
     */
    public class LetterCombinationsOfPhoneNumberProblem
    {
        private Dictionary<string, string> phone = new Dictionary<string, string>()
        {
            { "2", "abc" },
            { "3", "def" },
            { "4", "ghi" },
            { "5", "jkl" },
            { "6", "mno" },
            { "7", "pqrs" },
            { "8", "tuv" },
            { "9", "wxyz" },
        };
        //private Dictionary<string, string[]> _phone2 = new Dictionary<string, string[]>()
        //{
        //    { "2", new string[] { "a", "b", "c" } },
        //    { "3", new string[] { "d", "e", "f" } },
        //    { "4", new string[] { "g", "h", "i" } },
        //    { "5", new string[] { "j", "k", "l" } },
        //    { "6", new string[] { "m", "n", "o" } },
        //    { "7", new string[] { "p", "q", "r", "s" } },
        //    { "8", new string[] { "t", "u", "v" } },
        //    { "9", new string[] { "w", "x", "y", "z" } },
        //};

        private List<string> output = new List<string>();

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits) == false)
            {
                Backtrack("", digits);
                //Backtrack2("", digits);
            }

            return output;
        }

        public void Backtrack(string combination, string next_digits)
        {
            // if there is no more digits to check
            if (next_digits.Length == 0)
            {
                // the combination is done
                output.Add(combination);
            }
            // if there are still digits to check
            else
            {
                // iterate over all letters which map 
                // the next available digit
                string digit = next_digits.Substring(0, 1);
                string letters = phone[digit];
                for (int i = 0; i < letters.Length; i++)
                {
                    string letter = phone[digit].Substring(i, 1);
                    // append the current letter to the combination
                    // and proceed to the next digits
                    Backtrack(combination + letter, next_digits.Substring(1));
                }
            }
        }

        //public void Backtrack2(string combination, string next_digits)
        //{
        //    // if there is no more digits to check
        //    if (next_digits.Length == 0)
        //    {
        //        // the combination is done
        //        output.Add(combination);
        //    }
        //    // if there are still digits to check
        //    else
        //    {
        //        // iterate over all letters which map 
        //        // the next available digit
        //        string digit = next_digits.Substring(0, 1);
        //        string[] letters = _phone2[digit];
        //        for (int i = 0; i < letters.Length; i++)
        //        {
        //            string letter = letters[i];
        //            // append the current letter to the combination
        //            // and proceed to the next digits
        //            Backtrack2(combination + letter, next_digits.Substring(1));
        //        }
        //    }
        //}
    }
}
