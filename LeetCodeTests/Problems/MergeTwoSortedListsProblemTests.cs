using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;
using LeetCode.Models;

namespace LeetCodeTests.Problems
{
    public class MergeTwoSortedListsProblemTests
    {
        [Fact]
        public void MergeTwoSortedListsProblem_Case1()
        {
            // Arrange
            var obj = new MergeTwoSortedListsProblem();
            var l1 = ListNode.CreateListNode(1, 2, 4);
            var l2 = ListNode.CreateListNode(1, 3, 4);
            var expected = ListNode.CreateListNode(1, 1, 2, 3, 4, 4);

            // Act
            ListNode actual = obj.MergeTwoLists(l1, l2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeTwoSortedListsProblem_Case2()
        {
            // Arrange
            var obj = new MergeTwoSortedListsProblem();
            var l1 = ListNode.CreateListNode();
            var l2 = ListNode.CreateListNode();
            var expected = ListNode.CreateListNode();

            // Act
            ListNode actual = obj.MergeTwoLists(l1, l2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeTwoSortedListsProblem_Case3()
        {
            // Arrange
            var obj = new MergeTwoSortedListsProblem();
            var l1 = ListNode.CreateListNode();
            var l2 = ListNode.CreateListNode(0);
            var expected = ListNode.CreateListNode(0);

            // Act
            ListNode actual = obj.MergeTwoLists(l1, l2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}