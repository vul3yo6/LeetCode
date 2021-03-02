using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LeetCode.Problems.AddTwoNumbersProblem;

namespace LeetCodeTests.Problems
{
    public class RemoveNthNodeFromEndOfListProblemTests
    {
        [Fact]
        public void RemoveNthNodeFromEndOfListProblem_Case1()
        {
            // Arrange
            var obj = new RemoveNthNodeFromEndOfListProblem();
            int[] head = new int[] { 1, 2, 3, 4, 5 };
            int n = 2;
            var expected = new int[] { 1, 2, 3, 5 };

            // Act
            var actual = obj.RemoveNthFromEndProxy(head, n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveNthNodeFromEndOfListProblem_Case2()
        {
            // Arrange
            var obj = new RemoveNthNodeFromEndOfListProblem();
            int[] head = new int[] { 1 };
            int n = 1;
            var expected = new int[] { };

            // Act
            var actual = obj.RemoveNthFromEndProxy(head, n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveNthNodeFromEndOfListProblem_Case3()
        {
            // Arrange
            var obj = new RemoveNthNodeFromEndOfListProblem();
            int[] head = new int[] { 1, 2 };
            int n = 1;
            var expected = new int[] { 1 };

            // Act
            var actual = obj.RemoveNthFromEndProxy(head, n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveNthNodeFromEndOfListProblem_Case4()
        {
            // Arrange
            var obj = new RemoveNthNodeFromEndOfListProblem();
            int[] head = new int[] { 1, 2, 3, 4, 5 };
            int n = 3;
            var expected = new int[] { 1, 2, 4, 5 };

            // Act
            var actual = obj.RemoveNthFromEndProxy(head, n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveNthNodeFromEndOfListProblem_Case5()
        {
            // Arrange
            var obj = new RemoveNthNodeFromEndOfListProblem();
            int[] head = new int[] { 1, 2 };
            int n = 2;
            var expected = new int[] { 2 };

            // Act
            var actual = obj.RemoveNthFromEndProxy(head, n);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}