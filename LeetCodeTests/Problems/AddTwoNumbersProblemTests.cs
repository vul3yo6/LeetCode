using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class AddTwoNumbersProblemTests
    {
        [Fact]
        public void AddTwoNumbers_Case1()
        {
            // Arrange
            AddTwoNumbersProblem obj = new AddTwoNumbersProblem();
            var l1 = CreateListNode(2, 4, 3);
            var l2 = CreateListNode(5, 6, 4);
            var expected = CreateListNode(7, 0, 8);

            // Act
            var actual = obj.AddTwoNumbers(l1, l2);

            // Assert
            AssertEqual(expected, actual);
        }

        [Fact]
        public void AddTwoNumbers_Case2()
        {
            // Arrange
            AddTwoNumbersProblem obj = new AddTwoNumbersProblem();
            var l1 = CreateListNode(0);
            var l2 = CreateListNode(0);
            var expected = CreateListNode(0);

            // Act
            var actual = obj.AddTwoNumbers(l1, l2);

            // Assert
            AssertEqual(expected, actual);
        }

        [Fact]
        public void AddTwoNumbers_Case3()
        {
            // Arrange
            AddTwoNumbersProblem obj = new AddTwoNumbersProblem();
            var l1 = CreateListNode(9, 9, 9, 9, 9, 9, 9);
            var l2 = CreateListNode(9, 9, 9, 9);
            var expected = CreateListNode(8, 9, 9, 9, 0, 0, 0, 1);

            // Act
            var actual = obj.AddTwoNumbers(l1, l2);

            // Assert
            AssertEqual(expected, actual);
        }

        private static ListNode CreateListNode(int num, params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return new ListNode(num);
            }
            else
            {
                return new ListNode(num, CreateListNode(numbers[0], numbers.Skip(1).ToArray()));
            }
        }

        private static void AssertEqual(ListNode l1, ListNode l2)
        {
            Assert.Equal(l1.val, l2.val);

            if (l1.next == null && l2.next == null)
            {
                return;
            }
            else if (l1.next != null && l2.next != null)
            {
                AssertEqual(l1.next, l2.next);
            }
            else
            {
                // 兩邊不同
                Assert.True(false);
            }
        }
    }
}