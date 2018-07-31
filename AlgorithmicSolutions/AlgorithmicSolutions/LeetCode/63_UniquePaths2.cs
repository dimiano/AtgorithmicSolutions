/*

63. Unique Paths II

A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
The robot can only move either down or right at any point in time.
The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
Now consider if some obstacles are added to the grids.
How many unique paths would there be?

An obstacle and empty space is marked as 1 and 0 respectively in the grid.

Note: m and n will be at most 100.

Example 1:
Input:
[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
Output: 2

Explanation:
There is one obstacle in the middle of the 3x3 grid above.
There are two ways to reach the bottom-right corner:
1. Right -> Right -> Down -> Down
2. Down -> Down -> Right -> Right

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class UniquePaths2
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

		private static int GetResult(int[,] obstacleGrid)
		{
			return GetResultDpUp(obstacleGrid);
			return GetResultRecursion(obstacleGrid);
		}

		// Bottom-Up
		private static int GetResultDpUp(int[,] arr)
		{
			var m = arr.GetLength(0);
			var n = arr.GetLength(1);

			if (m == 0 && n == 0) return 0;
			if (arr[0, 0] == 1) return 0;

			var dp = new long[m, n];
			dp[0, 0] = 1;
			dp[1, 0] = arr[1, 0] == 1 ? 0 : 1;
			dp[0, 1] = arr[0, 1] == 1 ? 0 : 1;

			for (int i = m - 1; i > 0; i--)
			{
				if (arr[i, 0] == 1)
					dp[i, 0] = 0;
				else
					dp[i, 0] = dp[i - 1, 0];
			}

			for (int j = n - 1; j > 0; j--)
			{
				if (arr[0, j] == 1)
					dp[0, j] = 0;
				else
					dp[0, j] = dp[0, j - 1];
			}

			for (int i = 1; i < m; i++)
			{
				for (int j = 1; j < n; j++)
				{
					if (arr[i, j] == 1)
					{
						dp[i, j] = 0;
					}
					else
					{
						dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
					}
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
			if (arr[0, 0] == 1) return 0;

			var mem = new Dictionary<string, long>(m * n);
			long res = GetResultDpRecursion(m - 1, n - 1, arr, mem);

			return res > int.MaxValue ? int.MaxValue : (int)res;
		}

		private static long GetResultDpRecursion(int i, int j, int[,] arr, Dictionary<string, long> mem)
		{
			var key = i + ":" + j;
			if (mem.ContainsKey(key)) return mem[key];
			if (arr[i, j] == 1)
			{
				mem[key] = 0;
				return 0;
			}
			if (i == 0 && j == 0)
			{
				mem[key] = 1;
				return 1;
			}
			if (i < 1)
			{
				mem[key] = GetResultDpRecursion(i, j - 1, arr, mem);
				return mem[key];
			}
			if (j < 1)
			{
				mem[key] = GetResultDpRecursion(i - 1, j, arr, mem);
				return mem[key];
			}

			mem[key] = GetResultDpRecursion(i - 1, j, arr, mem) + GetResultDpRecursion(i, j - 1, arr, mem);

			return mem[key];
		}



		private static void TestCase1()
		{
			var input = new int[,] {
				{0, 0, 0},
				{0, 1, 0},
				{0, 0, 0}};
			var expect = 2;

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
			var expect = int.MaxValue;

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
				{0, 0, 0},
				{0, 0, 1},
				{0, 1, 0}};
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase5()
		{
			var input = new int[,] { { 1, 0 } };
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}

		private static void TestCase6()
		{
			var input = new int[,]{
				{0, 0},
				{1, 1},
				{0, 0}};
			var expect = 0;

			var result = GetResult(input);

			WriteResult(input.GetLength(0) + "x" + input.GetLength(1), expect, result);
		}
	}
}
