using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Models
{
    public class ListNode : IEquatable<ListNode>
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode CreateListNode(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return null;
            }
            else
            {
                return new ListNode(numbers[0], CreateListNode(numbers.Skip(1).ToArray()));
            }
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ListNode);
        }

        public bool Equals(ListNode p)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != p.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            //return (X == p.X) && (Y == p.Y);
            return (val == p.val) && (next == p.next);
        }

        public override int GetHashCode()
        {
            return val * 0x00010000 + next.GetHashCode();
        }

        public static bool operator ==(ListNode s, ListNode t)
        {
            // Check for null on left side.
            if (Object.ReferenceEquals(s, null))
            {
                if (Object.ReferenceEquals(t, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return s.Equals(t);
        }

        public static bool operator !=(ListNode s, ListNode t)
        {
            return !(s == t);
        }

        #endregion
    }
}
