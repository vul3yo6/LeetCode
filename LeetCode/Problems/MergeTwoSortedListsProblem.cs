using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Merge two sorted linked lists and return it as a sorted list. The list should be made by splicing together the nodes of the first two lists.
     * 
     * Example 1:
     * Input: l1 = [1,2,4], l2 = [1,3,4]
     * Output: [1,1,2,3,4,4]
     * 
     * Example 2:
     * Input: l1 = [], l2 = []
     * Output: []
     * 
     * Example 3:
     * Input: l1 = [], l2 = [0]
     * Output: [0]
     */
    /**
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
    public class MergeTwoSortedListsProblem
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            // 排除例外
            if (l1 == null && l2 == null)
            {
                return null;
            }
            else if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }

            ListNode startNode = null;
            if (l1.val > l2.val)
            {
                startNode = l2;
                l2 = l2.next;
            }
            else
            {
                startNode = l1;
                l1 = l1.next;
            }

            ListNode node = startNode;
            while (true)
            {
                if (l1 == null)
                {
                    node.next = l2;
                    break;
                }
                else if (l2 == null)
                {
                    node.next = l1;
                    break;
                }

                // 判斷哪一個大, 指標往下移動
                if (l1.val > l2.val)
                {
                    node.next = l2;
                    l2 = l2.next;
                    node = node.next;
                }
                else
                {
                    node.next = l1;
                    l1 = l1.next;
                    node = node.next;
                }
            }
            return startNode;
        }
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
