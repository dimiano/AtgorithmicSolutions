/*

64. Minimum Path Sum

Given a m x n grid filled with non-negative numbers, find a path from 
top left to bottom right which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example:

Input:
[
  [1,3,1],
  [1,5,1],
  [4,2,1]
]
Output: 7

Explanation: Because the path 1→3→1→1→1 minimizes the sum.

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class MinimumPathSum
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();
			TestCase4();
			TestCase5();
			TestCase6();

			WriteResultStatistic();
		}

		private static int GetResult(int[,] grid)
		{
			return GetResultDpUp(grid);
			return GetResultRecursion(grid);
		}

		// Bottom-Up
		private static int GetResultDpUp(int[,] arr)
		{
			var m = arr.GetLength(0);
			var n = arr.GetLength(1);

			if (m == 0 && n == 0) return 0;

			var dp = new long[m, n];
			dp[0, 0] = arr[0, 0];

			for (int i = 1; i < m; i++)
			{
				dp[i, 0] = dp[i - 1, 0] + arr[i, 0];
			}

			for (int j = 1; j < n; j++)
			{
				dp[0, j] = dp[0, j - 1] + arr[0, j];
			}

			for (int i = 1; i < m; i++)
			{
				for (int j = 1; j < n; j++)
				{
					dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + arr[i, j];
				}
			}

			var result = dp[m - 1, n - 1];
			if (result > int.MaxValue || result < int.MinValue)
			{
				return int.MaxValue;
			}
			else
			{
				return (int)result;
			}
		}

		// Recursion 
		private static int GetResultRecursion(int[,] arr)
		{
			var m = arr.GetLength(0);
			var n = arr.GetLength(1);
			if (m == 0 && n == 0) return 0;
			if (m == 1 && n == 1) return arr[0, 0];

			var mem = new Dictionary<string, long>(m * n);
			long res = GetResultDpRecursion(m - 1, n - 1, arr, mem);

			return res > int.MaxValue ? int.MaxValue : (int)res;
		}

		private static long GetResultDpRecursion(int i, int j, int[,] arr, Dictionary<string, long> mem)
		{
			var key = i + ":" + j;
			if (mem.ContainsKey(key)) return mem[key];
			if (i == 0 && j == 0)
			{
				mem[key] = arr[i, j];
				return mem[key];
			}
			if (i < 1)
			{
				mem[key] = GetResultDpRecursion(i, j - 1, arr, mem) + arr[i, j];
				return mem[key];
			}
			if (j < 1)
			{
				mem[key] = GetResultDpRecursion(i - 1, j, arr, mem) + arr[i, j];
				return mem[key];
			}

			mem[key] = Math.Min(GetResultDpRecursion(i - 1, j, arr, mem), GetResultDpRecursion(i, j - 1, arr, mem)) + arr[i, j];

			return mem[key];
		}



		private static void TestCase1()
		{
			var input = new int[,] {
				{1, 3, 1},
				{1, 5, 1},
				{4, 2, 1}};
			var expect = 7;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase2()
		{
			var input = new int[0, 0];
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase3()
		{
			var input = new int[100, 100];
			var expect = 0;

			var sw = new Stopwatch();
			sw.Start();
			var result = GetResult(input);
			sw.Stop();
			Console.WriteLine(" Time (ms): " + sw.ElapsedMilliseconds);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase4()
		{
			var input = new int[,] {
				{0, 2, 0},
				{2, 0, 1},
				{0, 1, 0}};
			var expect = 3;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase5()
		{
			var input = new int[,] { { 1, 0 } };
			var expect = 1;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase6()
		{
			var input = new int[,]{
				{1, 3},
				{1, 2},
				{3, 1}};
			var expect = 5;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}
	}
}
