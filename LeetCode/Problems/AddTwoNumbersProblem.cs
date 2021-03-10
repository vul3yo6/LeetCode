using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
     * 
     * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     * 
     * Example 1:
     * Input: l1 = [2,4,3], l2 = [5,6,4]
     * Output: [7,0,8]
     * Explanation: 342 + 465 = 807.
     * 
     * Example 2:
     * Input: l1 = [0], l2 = [0]
     * Output: [0]
     * 
     * Example 3:
     * Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
     * Output: [8,9,9,9,0,0,0,1]
     */
    /*
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class AddTwoNumbersProblem
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return CreateListNode(l1, l2);
        }

        private ListNode CreateListNode(ListNode l1, ListNode l2, int num = 0)
        {
            // ListNode 的尾巴
            if (l1 == null && l2 == null)
            {
                return num != 0 ? new ListNode(num)  : null;
            }

            // 計算部分
            int num1 = 0;
            int num2 = 0;
            ListNode l1next = null;
            ListNode l2next = null;

            if (l1 != null)
            {
                num1 = l1.val;
                l1next = l1.next;
            }
            if (l2 != null)
            {
                num2 = l2.val;
                l2next = l2.next;
            }

            int sum = num1 + num2 + num;
            int surplus = sum % 10;
            int multiple = sum / 10;

            return new ListNode(surplus, CreateListNode(l1next, l2next, multiple));
        }

        //public class ListNode
        //{
        //    public int val;
        //    public ListNode next;

        //    public ListNode(int val = 0, ListNode next = null)
        //    {
        //        this.val = val;
        //        this.next = next;
        //    }
        //}
    }
}
