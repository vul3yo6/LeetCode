using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given the head of a linked list, remove the nth node from the end of the list and return its head.
     * 
     * Example 1:
     * Input: head = [1,2,3,4,5], n = 2
     * Output: [1,2,3,5]
     * 
     * Example 2:
     * Input: head = [1], n = 1
     * Output: []
     * 
     * Example 3:
     * Input: head = [1,2], n = 1
     * Output: [1]
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
    public class RemoveNthNodeFromEndOfListProblem
    {
        public int[] RemoveNthFromEndProxy(int[] head, int n)
        {
            var node = RemoveNthFromEnd(Convert(head), n);
            var list = new List<int>();
            Convert(node, list);
            return list.ToArray();
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNodeAddr addr = new ListNodeAddr(head);
            for (int i = 1; i <= n + 1; i++)
            {
                addr.ShiftFirst();
            }

            while (addr.IsNotEndOfList)
            {
                addr.Shift();
            }

            addr.IgnoreSecondNextNode();
            return addr.headPointer.next;
        }

        private ListNode Convert(int[] head)
        {
            if (head.Length == 0)
            {
                return null;
            }

            int subLength = head.Length - 1;
            int[] subArray = new int[subLength];
            if (subLength > 0)
            {
                Array.Copy(head, 1, subArray, 0, subLength);
            }

            return new ListNode(head[0], Convert(subArray));
        }

        private void Convert(ListNode node, IList<int> list)
        {
            if (node == null)
            {
                return;
            }

            list.Add(node.val);
            Convert(node.next, list);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class ListNodeAddr
        {
            public ListNode headPointer;
            public ListNode firstPointer;
            public ListNode secondPointer;

            public bool IsNotEndOfList { get { return firstPointer != null; } }

            public ListNodeAddr(ListNode current)
            {
                headPointer = new ListNode(0, current);
                firstPointer = headPointer;
                secondPointer = headPointer;
            }

            internal void ShiftFirst()
            {
                firstPointer = firstPointer.next;
            }

            internal void Shift()
            {
                firstPointer = firstPointer.next;
                secondPointer = secondPointer.next;
            }

            internal void IgnoreSecondNextNode()
            {
                secondPointer.next = secondPointer.next.next;
            }
        }

        // Vic's sample
        //public ListNode RemoveNthFromEnd(ListNode head, int n)
        //{
        //    var listNodeList = new List<ListNode>();

        //    listNodeList.Add(head);

        //    if (head.next == null)
        //    {
        //        return null;
        //    }

        //    while (head.next != null)
        //    {
        //        head = head.next;

        //        listNodeList.Add(head);
        //    }

        //    listNodeList.Reverse();

        //    for (int i = 0; i < listNodeList.Count; i++)
        //    {
        //        if (i == n - 1)
        //        {
        //            listNodeList[i] = null;
        //        }

        //        if (i >= 1 && listNodeList[i - 1] == null)
        //        {
        //            if (i >= 2)
        //            {
        //                listNodeList[i].next = listNodeList[i - 2];

        //                break;
        //            }
        //            else
        //            {
        //                listNodeList[i].next = null;

        //                break;
        //            }
        //        }
        //    }

        //    for (int i = listNodeList.Count - 1; i >= 0; i--)
        //    {
        //        if (listNodeList[i] != null)
        //        {
        //            return listNodeList[i];
        //        }
        //    }

        //    return listNodeList[listNodeList.Count - 1];
        //}
    }
}
