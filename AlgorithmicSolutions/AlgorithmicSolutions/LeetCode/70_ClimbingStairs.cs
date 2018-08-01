/*

70. Climbing Stairs

You are climbing a stair case. It takes n steps to reach to the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Note: Given n will be a positive integer.

Example 1:
Input: 2
Output: 2

Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: 3
Output: 3

Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static AlgorithmicSolutions.ConsoleExtensions;

namespace AlgorithmicSolutions.LeetCode
{
	public class ClimbingStairs
	{
		public static void Test()
		{
			TestCase1();
			TestCase2();
			TestCase3();

			WriteResultStatistic();
		}

		private static int GetResult(int n)
		{
			return GetResultDpUp(n);
			return GetResultRecursion(n);
		}

		// Bottom-Up
		private static int GetResultDpUp(int n)
		{
			if (n < 2) return 1;

			var dp = new int[n];
			dp[0] = 1;
			dp[1] = 2;

			for (int i = 2; i < n; i++)
			{
				dp[i] = dp[i - 1] + dp[i - 2];
			}

			return dp[n - 1];
		}

		// Recursion 
		private static int GetResultRecursion(int n)
		{
			if (n < 2) return 1;

			var mem = new Dictionary<int, long>(n);
			long res = GetResultDpRecursion(n, mem);

			return res > int.MaxValue ? int.MaxValue : (int)res;
		}

		private static long GetResultDpRecursion(int i, Dictionary<int, long> mem)
		{
			if (mem.ContainsKey(i)) return mem[i];

			if (i < 2)
			{
				mem[i] = 1;
				return mem[i];
			}
			if (i == 2)
			{
				mem[i] = 2;
				return mem[i];
			}

			mem[i] = GetResultDpRecursion(i - 1, mem) + GetResultDpRecursion(i - 2, mem);

			return mem[i];
		}



		private static void TestCase1()
		{
			var input = 2;
			var expect = 2;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase2()
		{
			var input = 3;
			var expect = 3;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}

		private static void TestCase3()
		{
			var input = 1;
			var expect = 1;

			var result = GetResult(input);

			WriteResult(input, expect, result);
		}
	}
}

