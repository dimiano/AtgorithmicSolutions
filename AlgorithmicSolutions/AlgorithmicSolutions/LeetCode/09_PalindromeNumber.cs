/*

9. Palindrome Number

Determine whether an integer is a palindrome. 
An integer is a palindrome when it reads the same backward as forward.

Example 1:
Input: 121
Output: true

Example 2:
Input: -121
Output: false

Explanation: From left to right, it reads -121. From right to left, it becomes 121-.
Therefore it is not a palindrome.

Example 3:
Input: 10
Output: false

Explanation: Reads 01 from right to left.
Therefore it is not a palindrome.

Follow up:
Could you solve it without converting the integer to a string?

*/

using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class PalindromeNumber
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
		}

		private static bool GetResult(int x)
		{
			if (x < 0)
			{
				return false;
			}
			
			var i = 0;
			var num = new int[10]; // int.Max digit count

			while (x >= 0 && i < num.Length)
			{
				num[i] = x % 10;

				if (x<10)
				{
					break;
				}

				x /= 10;
				i++;
			}

			var j = i;
			i = 0;
			while (i <= j)
			{
				if (num[i] != num[j])
				{
					return false;
				}
				i++;
				j--;
			}

			return true;
		}

		// this is submitted
		private static bool GetResultEasy(int x)
		{
			if (x < 0)
			{
				return false;
			}

			var s = x.ToString();
			var i = 0;
			var j = s.Length - 1;

			while (i <= j)
			{
				if (s[i] != s[j])
				{
					return false;
				}
				i++;
				j--;
			}

			return true;
		}


		private static void TestCase1()
		{
			var input = 121;
			var expect = true;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = -121;
			var expect = false;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = 10;
			var expect = false;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}
