/*

7. Reverse Integer

Given a 32-bit signed integer, reverse digits of an integer.

Example 1:
Input: 123
Output: 321

Example 2:
Input: -123
Output: -321

Example 3:
Input: 120
Output: 21

Note:
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−2^31, 2^31 − 1]. 
For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.

*/

using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class ReverseInteger
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
		}

		private static int GetResult(int x)
		{
			var num = x.ToString().ToCharArray();
			var res = new char[num.Length + 1];
			res[0] = '0';

			for (int i = num.Length - 1, j = 1; i >= 0; i--, j++)
			{
				res[j] = num[i];
			}

			if (num[0] == '-')
			{
				res[res.Length - 1] = ' ';
				res[0] = '-';
			}

			var number = new string(res);

			var result = 0;
			if (!int.TryParse(number.TrimEnd(), out result))
			{
				result = 0;
			}

			return result;
		}

		private static void TestCase1()
		{
			var input = 123;
			var expect = 321;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = -123;
			var expect = -321;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = 120;
			var expect = 21;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase4()
		{
			var input = int.MaxValue;
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

	}
}
