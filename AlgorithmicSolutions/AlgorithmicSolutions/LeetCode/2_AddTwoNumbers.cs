/*

2. Add Two Numbers

You are given two non-empty linked lists representing two non-negative integers. 
The digits are stored in reverse order and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions.LeetCode
{
	public static class AddTwoNumbers
	{
		public class ListNode
		{
			public int val;
			public ListNode next;

			public ListNode(int x)
			{
				val = x;
			}

			public override string ToString()
			{
				var builder = new StringBuilder(val.ToString());
				var temp = next;

				while (temp != null)
				{
					builder.Insert(0, temp.val);
					temp = temp.next;
				}

				return builder.ToString();
			}
		}

		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
		}

		public static ListNode GetResult(ListNode l1, ListNode l2)
		{
			const int maxVal = 10;
			var carry = false;
			var result = new ListNode(0);

			ListNode curr = result;
			ListNode prev = curr;
			ListNode currL1 = l1;
			ListNode currL2 = l2;

			while (currL1 != null || currL2 != null)
			{
				curr.next = new ListNode(0);
				var val = (currL1 == null ? 0 : currL1.val) + (currL2 == null ? 0 : currL2.val);

				if (carry)
				{
					val++;
					carry = false;
				}

				if (val >= maxVal)
				{
					carry = true;
				}

				curr.val = val % maxVal;

				prev = curr;
				curr = curr.next;

				currL1 = currL1?.next;
				currL2 = currL2?.next;
			}

			prev.next = carry ? new ListNode(1) : null;

			return result;
		}

		private static void TestCase1()
		{
			var l1 = new ListNode(2)
			{
				next = new ListNode(4)
				{
					next = new ListNode(3)
				}
			};
			var l2 = new ListNode(5)
			{
				next = new ListNode(6)
				{
					next = new ListNode(4)
				}
			};
			var expect = new ListNode(7)
			{
				next = new ListNode(0)
				{
					next = new ListNode(8)
				}
			};

			var result = GetResult(l1, l2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase2()
		{
			var l1 = new ListNode(1)
			{
				next = new ListNode(8)
			};
			var l2 = new ListNode(0);
			var expect = new ListNode(1)
			{
				next = new ListNode(8)
			};

			var result = GetResult(l1, l2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase3()
		{
			var l1 = new ListNode(5);
			var l2 = new ListNode(5);
			var expect = new ListNode(0)
			{
				next = new ListNode(1)
			};

			var result = GetResult(l1, l2);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}
	}
}
