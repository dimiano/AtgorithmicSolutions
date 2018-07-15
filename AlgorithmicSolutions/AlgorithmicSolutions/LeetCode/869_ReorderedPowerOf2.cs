/*

869. Reordered Power of 2

Difficulty: Medium
Starting with a positive integer N, we reorder the digits in any order (including the original order) such that the leading digit is not zero.

Return true if and only if we can do this in a way such that the resulting number is a power of 2.

 

Example 1:
Input: 1
Output: true

Example 2:
Input: 10
Output: false

Example 3:
Input: 16
Output: true

Example 4:
Input: 24
Output: false

Example 5:
Input: 46
Output: true

Note:
1 <= N <= 10^9

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicSolutions.LeetCode
{
	public class ReorderedPowerOf2
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();
		}

		private static bool GetResult(int N)
		{
			for (int i = 0, c = Counter(N); i < 32; i++)
			{
				if (Counter(1 << i) == c)
				{
					return true;
				}
			}

			return false;
		}

		public static int Counter(int N)
		{
			var res = 0;

			for (var i = N; i > 0; i /= 10)
			{
				res += (int)Math.Pow(10, i % 10);
			}
			return res;
		}

		private static void TestCase1()
		{
			var num = 1;
			var expect = true;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase2()
		{
			var num = 10;
			var expect = false;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase3()
		{
			var num = 16;
			var expect = true;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase4()
		{
			var num = 24;
			var expect = false;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}

		private static void TestCase5()
		{
			var num = 46;
			var expect = true;

			var result = GetResult(num);

			Console.WriteLine(" EXPECTED: " + string.Join(", ", expect));
			Console.WriteLine(" RESULT:   " + string.Join(", ", result));
			Console.WriteLine("_".PadLeft(20, '_'));
			Console.WriteLine();
		}
	}
}
