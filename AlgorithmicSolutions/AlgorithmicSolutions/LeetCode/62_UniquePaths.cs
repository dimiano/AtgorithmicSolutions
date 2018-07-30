/*

62. Unique Paths

A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
The robot can only move either down or right at any point in time. 
The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?


Above is a 7 x 3 grid. How many possible unique paths are there?

Note: m and n will be at most 100.

Example 1:
Input: m = 3, n = 2
Output: 3

Explanation:
From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
1. Right -> Right -> Down
2. Right -> Down -> Right
3. Down -> Right -> Right

Example 2:
Input: m = 7, n = 3
Output: 28

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class UniquePaths
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();

			WriteResultStatistic();
		}

		private static int GetResult(int m, int n)
		{
			return GetResultDpUp(m, n);
			return GetResultRecursion(m, n);
		}

		// Bottom-Up
		private static int GetResultDpUp(int m, int n)
		{
			if (m < 2 || n < 2) return 1;
			if (m == 2 && n == 2) return 2;

			var dp = new long[m, n];
			dp[0, 0] = 1;
			dp[1, 1] = 2;

			for (int i = 0; i < m; i++)
			{
				dp[i, 0] = 1;
			}

			for (int j = 0; j < n; j++)
			{
				dp[0, j] = 1;
			}

			for (int i = 1; i < m; i++)
			{
				for (int j = 1; j < n; j++)
				{
					dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
				}
			}
			var result = dp[m - 1, n - 1];
			return result > int.MaxValue ? int.MaxValue : (int)result;
		}

		// Recursion 
		private static int GetResultRecursion(int m, int n)
		{
			if (m == 0 && n == 0)
			{
				return 0;
			}
			var mem = new Dictionary<string, long>(m * n);
			long res = GetResultDpRecursion(m, n, mem);

			return res > int.MaxValue ? int.MaxValue : (int)res;
		}

		private static long GetResultDpRecursion(int i, int j, Dictionary<string, long> mem)
		{
			var key = i + ":" + j;
			if (mem.ContainsKey(key)) return mem[key];
			if (i < 2 || j < 2)
			{
				mem[key] = 1;
				return 1;
			}
			if (i == 2 && j == 2)
			{
				mem[key] = 2;
				return 2;
			}
			mem[key] = GetResultDpRecursion(i - 1, j, mem) + GetResultDpRecursion(i, j - 1, mem);

			return mem[key];
		}



		private static void TestCase1()
		{
			var input1 = 3;
			var input2 = 2;
			var expect = 3;

			var result = GetResult(input1, input2);

			WriteResult(input1 + "x" + input2, expect, result);
		}

		private static void TestCase2()
		{
			var input1 = 7;
			var input2 = 3;
			var expect = 28;

			var result = GetResult(input1, input2);

			WriteResult(input1 + "x" + input2, expect, result);
		}


		private static void TestCase3()
		{
			var input1 = 100;
			var input2 = 100;
			var expect = int.MaxValue;

			var sw = new Stopwatch();
			sw.Start();
			var result = GetResult(input1, input2);
			sw.Stop();
			Console.WriteLine(" Time (ms): " + sw.ElapsedMilliseconds);

			WriteResult(input1 + "x" + input2, expect, result);
		}

	}
}
